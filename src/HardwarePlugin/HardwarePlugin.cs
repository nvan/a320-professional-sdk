using System.Globalization;
using System.Text.Json;

namespace NVAN.A320.Sdk.HardwarePlugin;

/// <summary>
/// A Hardware plugin. Derive from it, describe the device types in <see cref="Info"/>, create devices in
/// <see cref="CreateDevice"/>, and export the entry point from your assembly:
/// <code>
/// public static class Exports
/// {
///     [UnmanagedCallersOnly(EntryPoint = "nvan_hw_plugin_entry")]
///     public static nint Entry(nint host) => PluginExports.Start(host, new MyPlugin());
/// }
/// </code>
/// Every method of the plugin and its devices is called on one thread (the plugin thread), one call at a time, except
/// <see cref="HardwareDevice.OpenConfig"/> (its own thread). Read and write the aircraft with <see cref="Datarefs"/>.
/// </summary>
public abstract class HardwarePlugin
{
    /// <summary>The manifest. Read once, at start.</summary>
    public abstract PluginInfo Info { get; }

    /// <summary>Creates a device of <paramref name="type"/> with the user's settings. Do not wait for the hardware here:
    /// return a device that reports itself not connected and keeps trying from <see cref="HardwareDevice.Update"/>.
    /// Return null to refuse (log why); throwing does the same.</summary>
    public abstract HardwareDevice? CreateDevice(DeviceTypeInfo type, DeviceSettings settings, DeviceContext context);

    /// <summary>Called last, after every device was disposed.</summary>
    public virtual void Shutdown()
    {
    }
}

/// <summary>
/// One device the user added in Hardware. Poll the hardware in <see cref="Update"/>, write datarefs when its buttons
/// move (<see cref="Datarefs.Write(string, bool)"/>, <see cref="Datarefs.Press"/>) and follow the datarefs of its
/// lights and displays with <see cref="DeviceContext.Subscribe"/>. If any method throws, the device is disposed, shows
/// the error and is created again after 5 seconds.
/// </summary>
public abstract class HardwareDevice(DeviceContext context) : IDisposable
{
    /// <summary>Settings, status, subscriptions and log of this device.</summary>
    public DeviceContext Context { get; } = context;

    /// <summary>Called every update interval: read the hardware (without blocking), reconnect when lost, write datarefs
    /// for what changed, report the connection with <see cref="DeviceContext.SetStatus"/>.</summary>
    public virtual void Update()
    {
    }

    /// <summary>The user pressed this device's "Config…" button in Hardware (shown for device types with
    /// <see cref="DeviceTypeInfo.HasConfig"/>): show your own configuration window, with any toolkit, or do whatever
    /// configuring means for your device (open a file, start a tool...). Fire and forget: Hardware expects no result.
    /// <para>Typically: list <see cref="Datarefs.Catalog"/> so the user picks the dataref of each button and light,
    /// and store the choice.</para>
    /// <para>Runs on a dedicated config thread, <b>not</b> the plugin thread and <b>concurrently</b> with
    /// <see cref="Update"/> and the dataref callbacks: protect the state it shares with them (a lock, or hand the new
    /// values over to <see cref="Update"/>). It is not watched by the 3 s watchdog: it may block while the window is
    /// open (a modal dialog is fine). The device may be disposed while it runs. Store your configuration where you
    /// like (next to the plugin library, the user's configuration folder...). A second press while this call has not
    /// returned is not delivered. On Windows the thread is a single-threaded apartment (STA).</para></summary>
    public virtual void OpenConfig()
    {
    }

    /// <summary>Release the hardware. Subscriptions made with <see cref="DeviceContext.Subscribe"/> end on their own.</summary>
    public virtual void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}

/// <summary>The user's settings of a device: one JSON member per <see cref="SettingInfo.Key"/> (missing ones: use
/// the default).</summary>
public sealed class DeviceSettings
{
    private readonly Dictionary<string, JsonElement> _values = new(StringComparer.Ordinal);

    /// <summary>Parses the settings JSON object Hardware passes to open_device.</summary>
    public DeviceSettings(string json)
    {
        Json = json;
        try
        {
            using var document = JsonDocument.Parse(json.Length == 0 ? "{}" : json);
            if (document.RootElement.ValueKind != JsonValueKind.Object) return;
            foreach (var p in document.RootElement.EnumerateObject()) _values[p.Name] = p.Value.Clone();
        }
        catch (JsonException)
        {
        }
    }

    /// <summary>The raw JSON.</summary>
    public string Json { get; }

    /// <summary>A text setting.</summary>
    public string GetString(string key, string fallback = "") =>
        _values.TryGetValue(key, out var v) && v.ValueKind == JsonValueKind.String ? v.GetString() ?? fallback : fallback;

    /// <summary>A number setting.</summary>
    public double GetNumber(string key, double fallback = 0) =>
        _values.TryGetValue(key, out var v) && v.ValueKind == JsonValueKind.Number ? v.GetDouble()
        : _values.TryGetValue(key, out v) && v.ValueKind == JsonValueKind.String
          && double.TryParse(v.GetString(), NumberStyles.Float, CultureInfo.InvariantCulture, out var d) ? d : fallback;

    /// <summary>A bool setting.</summary>
    public bool GetBool(string key, bool fallback = false) =>
        _values.TryGetValue(key, out var v) && v.ValueKind is JsonValueKind.True or JsonValueKind.False ? v.GetBoolean() : fallback;

    /// <summary>True when the user set this key.</summary>
    public bool Has(string key) => _values.ContainsKey(key);

    /// <summary>The device's stable id in Hardware (Plugin API 1.1.0, the reserved setting "deviceId"): it never
    /// changes while the user keeps the device, so per-device data the plugin stores itself can be named after it.
    /// Empty on a Hardware older than Plugin API 1.1.0 (declare <c>MinPluginApi = "1.1.0"</c> when you rely on it).</summary>
    public string DeviceId => GetString("deviceId");
}

/// <summary>Log levels of <see cref="PluginLog"/>.</summary>
public enum LogLevel
{
    /// <summary>Details for the plugin's developer.</summary>
    Debug = 0,
    /// <summary>Normal events (device found, connected...).</summary>
    Info = 1,
    /// <summary>Something the user may want to fix.</summary>
    Warning = 2,
    /// <summary>Something failed.</summary>
    Error = 3,
}

/// <summary>The plugin's log: Hardware's Plugins tab and plugin-logs/&lt;file&gt;.log next to Hardware. Thread-safe.</summary>
public static class PluginLog
{
    /// <summary>Writes a line.</summary>
    public static void Write(LogLevel level, string message) => PluginExports.Log(level, message);

    /// <summary>Writes a debug line.</summary>
    public static void Debug(string message) => Write(LogLevel.Debug, message);

    /// <summary>Writes an info line.</summary>
    public static void Info(string message) => Write(LogLevel.Info, message);

    /// <summary>Writes a warning line.</summary>
    public static void Warning(string message) => Write(LogLevel.Warning, message);

    /// <summary>Writes an error line.</summary>
    public static void Error(string message) => Write(LogLevel.Error, message);
}

/// <summary>What a device has and reports: its settings, status, log and the subscriptions that end with it.
/// <see cref="SetStatus"/>, <see cref="Log"/> and <see cref="Subscribe"/> are thread-safe.</summary>
public sealed class DeviceContext
{
    private readonly Lock _lock = new();
    private readonly List<DatarefSubscription> _subscriptions = new();
    private bool _connected;
    private bool _closed;

    internal DeviceContext(uint handle, DeviceTypeInfo type, DeviceSettings settings)
    {
        Handle = handle;
        Type = type;
        Settings = settings;
    }

    /// <summary>The device handle Hardware chose.</summary>
    public uint Handle { get; }

    /// <summary>The device type.</summary>
    public DeviceTypeInfo Type { get; }

    /// <summary>The user's settings.</summary>
    public DeviceSettings Settings { get; }

    /// <summary>Whether the device last reported itself connected.</summary>
    public bool Connected
    {
        get { lock (_lock) return _connected; }
    }

    /// <summary>Reports the connection state and a short text for Hardware's device list.</summary>
    public void SetStatus(bool connected, string text)
    {
        lock (_lock) _connected = connected;
        PluginExports.SetStatus(Handle, connected, text);
    }

    /// <summary>As <see cref="Datarefs.Subscribe"/>, ended when this device is disposed (closed, failed or its
    /// settings changed): the callbacks never run for a disposed device.</summary>
    public DatarefSubscription Subscribe(string path, Action<DatarefValue> onChange)
    {
        var subscription = PluginExports.Subscribe(path, onChange, this);
        lock (_lock)
        {
            if (!_closed)
            {
                _subscriptions.Add(subscription);
                return subscription;
            }
        }
        subscription.Dispose();
        return subscription;
    }

    /// <summary>Reports a remote axis of this device: a lever, stick, pedal or tiller the plugin reads.
    /// <paramref name="name"/> identifies it on the device (shown to the user), <paramref name="function"/> is the axis
    /// function it drives by default (<c>"ctl.axis.thrustLever1"</c>...), <paramref name="value"/> its raw reading
    /// between <paramref name="min"/> and <paramref name="max"/> (its own units; min &gt; max for a reversed axis).
    /// Hardware sends it flat by default (the raw range linearly onto the function's: a lever 0 = IDLE .. 1 = TO/GA, no
    /// detents, no reverse); the user may enable it per axis to calibrate it like a joystick axis (any function, end
    /// stops, response curve, a lever's detents and reverse zone). Call it on every change (more often is harmless);
    /// <see cref="double.NaN"/> releases it (sticks and pedals return to neutral, levers hold). Returns false when this
    /// Hardware is older (before 2026-11-16): then write the <c>ctl.axis.*</c> dataref yourself.</summary>
    public bool ReportRemoteAxis(string name, string function, double value, double min, double max) =>
        !Closed && PluginExports.RemoteAxis(Handle, name, function, value, min, max);

    /// <summary>Whether this Hardware takes remote axes (<see cref="ReportRemoteAxis"/>).</summary>
    public static bool RemoteAxesSupported => PluginExports.HostHasRemoteAxes;

    /// <summary>Writes a line to the plugin log, prefixed with the device handle.</summary>
    public void Log(LogLevel level, string message) => PluginExports.Log(level, $"[device {Handle}] {message}");

    internal bool Closed
    {
        get { lock (_lock) return _closed; }
    }

    // The device is gone: its subscriptions end.
    internal void Close()
    {
        DatarefSubscription[] subscriptions;
        lock (_lock)
        {
            _closed = true;
            subscriptions = _subscriptions.ToArray();
            _subscriptions.Clear();
        }
        foreach (var subscription in subscriptions) subscription.Dispose();
    }
}
