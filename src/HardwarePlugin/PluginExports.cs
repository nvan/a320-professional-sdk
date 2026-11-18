using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace NVAN.A320.Sdk.HardwarePlugin;

/// <summary>
/// The C ABI glue (include/nvan_hardware_plugin.h, version 2). Call <see cref="Start"/> from your exported
/// <c>nvan_hw_plugin_entry</c>. Nothing here lets an exception reach native code: a failing device is disposed,
/// reported and created again after <see cref="RetryDelay"/>.
/// </summary>
public static unsafe class PluginExports
{
    /// <summary>The ABI version this library implements.</summary>
    public const uint AbiVersion = 2;

    /// <summary>How long a device that threw waits before it is created again.</summary>
    public static readonly TimeSpan RetryDelay = TimeSpan.FromSeconds(5);

    [StructLayout(LayoutKind.Sequential)]
    private struct HostApi
    {
        public uint StructSize;
        public uint AbiVersion;
        public void* Context;
        public delegate* unmanaged<void*, int, byte*, void> Log;
        public delegate* unmanaged<void*, uint, int, byte*, void> SetStatus;
        public delegate* unmanaged<void*, byte*, uint> Subscribe;
        public delegate* unmanaged<void*, uint, void> Unsubscribe;
        public delegate* unmanaged<void*, byte*, double, void> WriteNumber;
        public delegate* unmanaged<void*, byte*, byte*, void> WriteText;
        public delegate* unmanaged<void*, byte*, void> Press;
        public delegate* unmanaged<void*, byte*, double*, byte*, uint, int> Read;
        public delegate* unmanaged<void*, uint*, NativeDatarefInfo*> Catalog;
        public delegate* unmanaged<void*, int> SystemsConnected;
        public delegate* unmanaged<void*, uint, byte*, byte*, double, double, double, void> RemoteAxis;   // since 2026-11-16 (grown table)
    }

    // The host table of the first ABI 2 Hardware (up to SystemsConnected): 2 × u32 + context + 10 functions.
    private const uint HostApiBaseSize = 96;

    [StructLayout(LayoutKind.Sequential)]
    private struct PluginApi
    {
        public uint StructSize;
        public uint AbiVersion;
        public byte* ManifestJson;
        public delegate* unmanaged<uint, byte*, byte*, int> OpenDevice;
        public delegate* unmanaged<uint, void> CloseDevice;
        public delegate* unmanaged<void> Update;
        public delegate* unmanaged<void> Shutdown;
        public delegate* unmanaged<uint, void> OpenConfig;
        public delegate* unmanaged<uint, int, double, byte*, void> OnDataref;
        public delegate* unmanaged<void> OnCatalogChanged;
        public delegate* unmanaged<int, void> OnSystemsChanged;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct NativeDatarefInfo
    {
        public byte* Path;
        public byte* Panel;
        public byte* Description;
        public int Type;
        public int Kind;
        public int Writable;
        public int Momentary;
    }

    private sealed class Slot(DeviceTypeInfo type, DeviceSettings settings)
    {
        public readonly DeviceTypeInfo Type = type;
        public readonly DeviceSettings Settings = settings;
        public HardwareDevice? Device;
        public DeviceContext? Context;
        public long RetryAt;
    }

    // One subscribed path: its id in the host, its subscriptions and its last value.
    private sealed class Path(uint id)
    {
        public readonly uint Id = id;
        public readonly List<DatarefSubscription> Subscriptions = new();
        public DatarefValue Value = DatarefValue.None;
    }

    private static HostApi* _host;
    private static HardwarePlugin? _plugin;
    private static PluginInfo? _info;
    private static readonly Dictionary<uint, Slot> Devices = new();
    // Changes to Devices and Slot.Device happen on the plugin thread under this lock, so the config thread
    // (open_config) can look a device up safely; the plugin thread itself reads without it.
    private static readonly Lock DevicesLock = new();

    // Datarefs (any thread: under DatarefsLock).
    private static readonly Lock DatarefsLock = new();
    private static readonly Dictionary<string, Path> Paths = new(StringComparer.Ordinal);
    private static readonly Dictionary<uint, Path> PathsById = new();
    private static readonly List<DatarefSubscription> FirstValues = new();   // new subscriptions to give the known value
    private static NativeDatarefInfo* _catalogPointer;
    private static IReadOnlyList<DatarefInfo> _catalog = [];

    /// <summary>Starts the plugin: keeps the host functions and returns the plugin's function table (to return from
    /// <c>nvan_hw_plugin_entry</c>), or 0 when the plugin cannot start (the reason is logged).</summary>
    public static nint Start(nint host, HardwarePlugin plugin)
    {
        try
        {
            var h = (HostApi*)host;
            if (h is null || h->AbiVersion != AbiVersion || h->StructSize < HostApiBaseSize) return 0;
            _host = h;
            _plugin = plugin;
            _info = plugin.Info;
            var manifest = Encoding.UTF8.GetBytes(_info.ToJson() + "\0");
            var json = (byte*)NativeMemory.Alloc((nuint)manifest.Length);
            manifest.CopyTo(new Span<byte>(json, manifest.Length));
            var api = (PluginApi*)NativeMemory.AllocZeroed((nuint)sizeof(PluginApi));
            api->StructSize = (uint)sizeof(PluginApi);
            api->AbiVersion = AbiVersion;
            api->ManifestJson = json;
            api->OpenDevice = &OpenDevice;
            api->CloseDevice = &CloseDevice;
            api->Update = &Update;
            api->Shutdown = &Shutdown;
            api->OpenConfig = &OpenConfig;
            api->OnDataref = &OnDataref;
            api->OnCatalogChanged = &OnCatalogChanged;
            api->OnSystemsChanged = &OnSystemsChanged;
            return (nint)api;
        }
        catch (Exception e)
        {
            Log(LogLevel.Error, $"The plugin failed to start: {e}");
            return 0;
        }
    }

    [UnmanagedCallersOnly]
    private static int OpenDevice(uint device, byte* typeId, byte* settingsJson)
    {
        try
        {
            var id = Utf8(typeId);
            var type = _info?.DeviceTypes.FirstOrDefault(t => t.Id == id);
            if (type is null)
            {
                Log(LogLevel.Error, $"Unknown device type \"{id}\"");
                return -1;
            }
            CloseSlot(device);
            var slot = new Slot(type, new DeviceSettings(Utf8(settingsJson)));
            lock (DevicesLock) Devices[device] = slot;
            return Create(device, slot) ? 0 : -2;
        }
        catch (Exception e)
        {
            Log(LogLevel.Error, $"open_device failed: {e}");
            return -3;
        }
    }

    [UnmanagedCallersOnly]
    private static void CloseDevice(uint device)
    {
        try
        {
            CloseSlot(device);
        }
        catch (Exception e)
        {
            Log(LogLevel.Error, $"close_device failed: {e}");
        }
    }

    [UnmanagedCallersOnly]
    private static void Update()
    {
        DeliverFirstValues();
        var now = Stopwatch.GetTimestamp();
        foreach (var (handle, slot) in Devices)
        {
            if (slot.Device is null)
            {
                if (slot.RetryAt != 0 && now >= slot.RetryAt) Create(handle, slot);
                continue;
            }
            try
            {
                slot.Device.Update();
            }
            catch (Exception e)
            {
                Fail(handle, slot, "Update", e);
            }
        }
    }

    [UnmanagedCallersOnly]
    private static void Shutdown()
    {
        foreach (var handle in Devices.Keys.ToArray())
        {
            try
            {
                CloseSlot(handle);
            }
            catch (Exception e)
            {
                Log(LogLevel.Error, $"Dispose failed: {e}");
            }
        }
        try
        {
            _plugin?.Shutdown();
        }
        catch (Exception e)
        {
            Log(LogLevel.Error, $"Shutdown failed: {e}");
        }
        _host = null;
    }

    // The config thread (not the plugin thread, no watchdog): the user pressed the device's Config… button.
    [UnmanagedCallersOnly]
    private static void OpenConfig(uint device)
    {
        HardwareDevice? target;
        lock (DevicesLock) target = Devices.TryGetValue(device, out var slot) ? slot.Device : null;
        if (target is null)
        {
            Log(LogLevel.Warning, $"[device {device}] Configuration requested, but the device is not open");
            return;
        }
        try
        {
            target.OpenConfig();
        }
        catch (Exception e)
        {
            Log(LogLevel.Error, $"[device {device}] OpenConfig threw: {e}");
        }
    }

    // Plugin thread: a subscribed dataref's value.
    [UnmanagedCallersOnly]
    private static void OnDataref(uint id, int valid, double number, byte* text)
    {
        try
        {
            DeliverFirstValues();
            DatarefSubscription[] targets;
            DatarefValue value;
            lock (DatarefsLock)
            {
                if (!PathsById.TryGetValue(id, out var path) || path.Subscriptions.Count == 0) return;
                value = valid != 0 ? new DatarefValue(true, number, Utf8(text)) : DatarefValue.None;
                path.Value = value;
                targets = path.Subscriptions.ToArray();
                // Whoever was waiting for a first value has it now.
                foreach (var s in targets) FirstValues.Remove(s);
            }
            foreach (var subscription in targets) Call(subscription, value);
        }
        catch (Exception e)
        {
            Log(LogLevel.Error, $"on_dataref failed: {e}");
        }
    }

    [UnmanagedCallersOnly]
    private static void OnCatalogChanged()
    {
        try
        {
            Datarefs.RaiseCatalogChanged();
        }
        catch (Exception e)
        {
            Log(LogLevel.Error, $"CatalogChanged threw: {e}");
        }
    }

    [UnmanagedCallersOnly]
    private static void OnSystemsChanged(int connected)
    {
        try
        {
            Datarefs.RaiseSystemsConnectionChanged(connected != 0);
        }
        catch (Exception e)
        {
            Log(LogLevel.Error, $"SystemsConnectionChanged threw: {e}");
        }
    }

    private static bool Create(uint handle, Slot slot)
    {
        var context = new DeviceContext(handle, slot.Type, slot.Settings);
        try
        {
            var device = _plugin!.CreateDevice(slot.Type, slot.Settings, context);
            if (device is null)
            {
                context.Close();
                SetStatus(handle, false, "Refused by the plugin (see its log)");
                slot.RetryAt = 0;
                return false;
            }
            lock (DevicesLock) slot.Device = device;
            slot.Context = context;
            slot.RetryAt = 0;
            return true;
        }
        catch (Exception e)
        {
            slot.Context = context;
            Fail(handle, slot, "CreateDevice", e);
            return true; // opened: it retries on its own
        }
    }

    private static void Fail(uint handle, Slot slot, string where, Exception e)
    {
        Log(LogLevel.Error, $"[device {handle}] {where} threw: {e}");
        try
        {
            slot.Device?.Dispose();
        }
        catch (Exception dispose)
        {
            Log(LogLevel.Error, $"[device {handle}] Dispose threw: {dispose.Message}");
        }
        slot.Context?.Close();
        lock (DevicesLock) slot.Device = null;
        slot.RetryAt = Stopwatch.GetTimestamp() + (long)(RetryDelay.TotalSeconds * Stopwatch.Frequency);
        SetStatus(handle, false, $"Error: {e.Message} (retrying)");
    }

    private static void CloseSlot(uint handle)
    {
        Slot? slot;
        lock (DevicesLock)
            if (!Devices.Remove(handle, out slot)) return;
        try
        {
            slot.Device?.Dispose();
        }
        finally
        {
            slot.Context?.Close();
        }
    }

    // ---- Datarefs (any thread) -------------------------------------------------------------------------------------

    internal static DatarefSubscription Subscribe(string path, Action<DatarefValue> onChange, DeviceContext? owner)
    {
        ArgumentNullException.ThrowIfNull(onChange);
        if (string.IsNullOrEmpty(path) || Encoding.UTF8.GetByteCount(path) > 255)
            throw new ArgumentException("A dataref path is 1..255 bytes", nameof(path));
        var subscription = new DatarefSubscription(path, onChange, owner);
        lock (DatarefsLock)
        {
            if (!Paths.TryGetValue(path, out var entry))
            {
                var id = HostSubscribe(path);
                if (id == 0) throw new InvalidOperationException("The plugin is not running in Hardware (no host)");
                Paths[path] = entry = PathsById.TryGetValue(id, out var known) ? known : new Path(id);
                PathsById[id] = entry;
            }
            else if (entry.Subscriptions.Count == 0)
            {
                HostSubscribe(path);
            }
            entry.Subscriptions.Add(subscription);
            if (entry.Value.Valid) FirstValues.Add(subscription);
        }
        return subscription;
    }

    internal static void Unsubscribe(DatarefSubscription subscription)
    {
        lock (DatarefsLock)
        {
            FirstValues.Remove(subscription);
            if (!Paths.TryGetValue(subscription.Path, out var entry) || !entry.Subscriptions.Remove(subscription) || entry.Subscriptions.Count > 0) return;
            entry.Value = DatarefValue.None;
            var host = _host;
            if (host is not null) host->Unsubscribe(host->Context, entry.Id);
        }
    }

    internal static DatarefValue Read(string path)
    {
        lock (DatarefsLock) return Paths.TryGetValue(path, out var entry) && entry.Subscriptions.Count > 0 ? entry.Value : DatarefValue.None;
    }

    internal static void WriteNumber(string path, double value)
    {
        var host = _host;
        if (host is null || string.IsNullOrEmpty(path)) return;
        var p = Utf8Z(path);
        fixed (byte* pp = p) host->WriteNumber(host->Context, pp, value);
    }

    internal static void WriteText(string path, string text)
    {
        var host = _host;
        if (host is null || string.IsNullOrEmpty(path)) return;
        var p = Utf8Z(path);
        var t = Utf8Z(text ?? "");
        fixed (byte* pp = p, tt = t) host->WriteText(host->Context, pp, tt);
    }

    internal static void Press(string path)
    {
        var host = _host;
        if (host is null || string.IsNullOrEmpty(path)) return;
        var p = Utf8Z(path);
        fixed (byte* pp = p) host->Press(host->Context, pp);
    }

    internal static bool SystemsConnected
    {
        get
        {
            var host = _host;
            return host is not null && host->SystemsConnected(host->Context) != 0;
        }
    }

    // The host's catalog array, converted once per new array (it never changes once given).
    internal static IReadOnlyList<DatarefInfo> Catalog
    {
        get
        {
            var host = _host;
            if (host is null) return [];
            uint count;
            var infos = host->Catalog(host->Context, &count);
            lock (DatarefsLock)
            {
                if (infos == _catalogPointer) return _catalog;
                var list = new DatarefInfo[infos is null ? 0 : count];
                for (var i = 0; i < list.Length; i++)
                {
                    var e = infos[i];
                    list[i] = new DatarefInfo(Utf8(e.Path), Utf8(e.Panel), Utf8(e.Description), (DatarefType)e.Type, (DatarefKind)e.Kind, e.Writable != 0,
                        e.Momentary != 0);
                }
                _catalogPointer = infos;
                _catalog = list;
                return list;
            }
        }
    }

    private static uint HostSubscribe(string path)
    {
        var host = _host;
        if (host is null) return 0;
        var p = Utf8Z(path);
        fixed (byte* pp = p) return host->Subscribe(host->Context, pp);
    }

    // Plugin thread: subscriptions made since the last call get the value their path already has.
    private static void DeliverFirstValues()
    {
        List<(DatarefSubscription, DatarefValue)>? due = null;
        lock (DatarefsLock)
        {
            if (FirstValues.Count == 0) return;
            foreach (var s in FirstValues)
                if (Paths.TryGetValue(s.Path, out var entry) && entry.Value.Valid) (due ??= new()).Add((s, entry.Value));
            FirstValues.Clear();
        }
        if (due is null) return;
        foreach (var (subscription, value) in due) Call(subscription, value);
    }

    private static void Call(DatarefSubscription subscription, DatarefValue value)
    {
        if (subscription.Disposed || subscription.Owner is { Closed: true }) return;
        try
        {
            subscription.OnChange(value);
        }
        catch (Exception e)
        {
            var who = subscription.Owner is { } owner ? $"[device {owner.Handle}] " : "";
            Log(LogLevel.Error, $"{who}The callback of {subscription.Path} threw: {e}");
        }
    }

    // ---- Host functions (thread-safe on the host side) ------------------------------------------------------------

    internal static void Log(LogLevel level, string message)
    {
        var host = _host;
        if (host is null || host->Log is null)
        {
            Console.Error.WriteLine($"[{level}] {message}");
            return;
        }
        var bytes = Utf8Z(message);
        fixed (byte* p = bytes) host->Log(host->Context, (int)level, p);
    }

    // Whether this Hardware has the remote_axis host function (Hardware from 2026-11-16 on).
    internal static bool HostHasRemoteAxes
    {
        get
        {
            var host = _host;
            return host is not null && host->StructSize >= (uint)sizeof(HostApi) && host->RemoteAxis is not null;
        }
    }

    internal static bool RemoteAxis(uint device, string name, string function, double value, double min, double max)
    {
        var host = _host;
        if (host is null || host->StructSize < (uint)sizeof(HostApi) || host->RemoteAxis is null
            || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(function)) return false;
        var n = Utf8Z(name);
        var f = Utf8Z(function);
        fixed (byte* nn = n, ff = f) host->RemoteAxis(host->Context, device, nn, ff, value, min, max);
        return true;
    }

    internal static void SetStatus(uint device, bool connected, string text)
    {
        var host = _host;
        if (host is null) return;
        var bytes = Utf8Z(text);
        fixed (byte* p = bytes) host->SetStatus(host->Context, device, connected ? 1 : 0, p);
    }

    private static byte[] Utf8Z(string text)
    {
        var bytes = new byte[Encoding.UTF8.GetByteCount(text) + 1];
        Encoding.UTF8.GetBytes(text, bytes);
        return bytes;
    }

    private static string Utf8(byte* text) => text is null ? "" : Marshal.PtrToStringUTF8((nint)text) ?? "";
}
