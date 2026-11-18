namespace NVAN.A320.Sdk.HardwarePlugin;

/// <summary>
/// The aircraft's datarefs, read and written by path ("glare.fcu.ap1.pressed", "overhead.elec.bat1.pressed"...).
/// Every method is thread-safe and returns at once. Callbacks and events run on the plugin thread (where
/// <see cref="HardwareDevice.Update"/> runs), one at a time.
/// <code>
/// var ap1 = Datarefs.Subscribe("glare.fcu.ap1.on", value => led.Set(value.IsOn));
/// Datarefs.Press("glare.fcu.ap1.pressed");             // momentary pushbutton: 1, then 0 after 100 ms
/// Datarefs.Write("overhead.elec.bat1.pressed", true);  // latching pushbutton or switch: its position
/// Datarefs.Write("pedestal.intLt.floodLtMainPnl", 0.5);
/// </code>
/// Reconnection is automatic: while Hardware has no Systems every subscription gets an invalid value, then every value
/// again. Writes made while Systems is away are dropped after 3 s: write your switch positions again when
/// <see cref="SystemsConnectionChanged"/> says true.
/// </summary>
public static class Datarefs
{
    /// <summary>Follows a dataref: <paramref name="onChange"/> gets its current value as soon as Hardware has it, then
    /// every change (on the plugin thread). Dispose the result to stop. Subscribing to the same path several times is
    /// fine (one subscription in Hardware).</summary>
    /// <exception cref="ArgumentException">Empty path, or longer than 255 bytes.</exception>
    public static DatarefSubscription Subscribe(string path, Action<DatarefValue> onChange) => PluginExports.Subscribe(path, onChange, null);

    /// <summary>Writes a number: a bool (0 / non-zero), int (rounded) or float dataref; a string dataref gets it as
    /// text. Waits (up to 3 s) until Systems knows the path; unknown and read-only paths are logged and dropped. A
    /// non-zero value on a momentary pushbutton is held at least 100 ms, then until you write 0.</summary>
    public static void Write(string path, double value) => PluginExports.WriteNumber(path, value);

    /// <summary>Writes a bool dataref (1 / 0): a latching pushbutton or a switch.</summary>
    public static void Write(string path, bool value) => PluginExports.WriteNumber(path, value ? 1 : 0);

    /// <summary>Writes a string dataref; a numeric dataref gets the text parsed as a number.</summary>
    public static void Write(string path, string text) => PluginExports.WriteText(path, text);

    /// <summary>Presses a momentary pushbutton: 1, then 0 at least 100 ms later. Hardware releases it even if the
    /// plugin crashes in between.</summary>
    public static void Press(string path) => PluginExports.Press(path);

    /// <summary>The last value of a subscribed path (invalid when not subscribed or not received yet).</summary>
    public static DatarefValue Read(string path) => PluginExports.Read(path);

    /// <summary>Every dataref Systems has (empty until Hardware received it), in Systems' order: show it in your
    /// configuration window so the user picks the datarefs of each button and light.</summary>
    public static IReadOnlyList<DatarefInfo> Catalog => PluginExports.Catalog;

    /// <summary>A new <see cref="Catalog"/> arrived (plugin thread).</summary>
    public static event Action? CatalogChanged;

    /// <summary>Hardware is connected to Systems: values and writes flow.</summary>
    public static bool SystemsConnected => PluginExports.SystemsConnected;

    /// <summary>Hardware's connection to Systems changed (plugin thread). On true, write the positions of your switches
    /// and selectors again (a restarted Systems starts from its defaults).</summary>
    public static event Action<bool>? SystemsConnectionChanged;

    internal static void RaiseCatalogChanged() => CatalogChanged?.Invoke();

    internal static void RaiseSystemsConnectionChanged(bool connected) => SystemsConnectionChanged?.Invoke(connected);
}

/// <summary>A dataref's value.</summary>
/// <param name="Valid">False when there is no data (Systems not connected, unknown path, not received yet): show it
/// dark / blank.</param>
/// <param name="Number">bool 0 / 1, int or float; NaN for a string dataref.</param>
/// <param name="Text">The value as text: a string dataref as is, a number formatted invariantly ("1", "26.5"); "" when
/// not valid.</param>
public readonly record struct DatarefValue(bool Valid, double Number, string Text)
{
    /// <summary>No data.</summary>
    public static DatarefValue None => new(false, 0, "");

    /// <summary>For lights and switches: valid and not zero.</summary>
    public bool IsOn => Valid && Number != 0 && !double.IsNaN(Number);
}

/// <summary>One <see cref="Datarefs.Subscribe"/>. Dispose it to stop the callbacks.</summary>
public sealed class DatarefSubscription : IDisposable
{
    internal DatarefSubscription(string path, Action<DatarefValue> onChange, DeviceContext? owner)
    {
        Path = path;
        OnChange = onChange;
        Owner = owner;
    }

    /// <summary>The dataref.</summary>
    public string Path { get; }

    /// <summary>Its last value.</summary>
    public DatarefValue Value => PluginExports.Read(Path);

    internal Action<DatarefValue> OnChange { get; }

    internal DeviceContext? Owner { get; }

    internal bool Disposed { get; private set; }

    /// <summary>Stops the callbacks (and the subscription in Hardware when it was the last one for its path).</summary>
    public void Dispose()
    {
        if (Disposed) return;
        Disposed = true;
        PluginExports.Unsubscribe(this);
    }
}

/// <summary>Value type of a dataref.</summary>
public enum DatarefType
{
    /// <summary>0 / 1.</summary>
    Bool = 0,
    /// <summary>Whole number.</summary>
    Int = 1,
    /// <summary>Real number.</summary>
    Float = 2,
    /// <summary>Text with a fixed format ("0456", "121.800", "24000").</summary>
    String = 3,
}

/// <summary>What a dataref is in the cockpit.</summary>
public enum DatarefKind
{
    /// <summary>Korry or pushbutton (momentary ones are 1 only while held).</summary>
    Pushbutton = 0,
    /// <summary>Toggle or multi-position switch.</summary>
    Switch = 1,
    /// <summary>Selector position.</summary>
    Rotary = 2,
    /// <summary>Incremental knob.</summary>
    Encoder = 3,
    /// <summary>Potentiometer, lever, axis.</summary>
    Analog = 4,
    /// <summary>Bulb or korry legend.</summary>
    Light = 5,
    /// <summary>Ground service or simulator convenience.</summary>
    Service = 6,
    /// <summary>Failure trigger.</summary>
    Failure = 7,
    /// <summary>State computed by Systems (exterior lights, displays as text...).</summary>
    Output = 8,
    /// <summary>Condition of the aircraft (weight on wheels...).</summary>
    Gate = 9,
}

/// <summary>One dataref of the <see cref="Datarefs.Catalog"/>.</summary>
/// <param name="Path">Its name, e.g. "glare.fcu.ap1.pressed".</param>
/// <param name="Panel">Where it is, for grouping in a list.</param>
/// <param name="Description">One line for the user.</param>
/// <param name="Type">Value type.</param>
/// <param name="Kind">What it is.</param>
/// <param name="Writable">Write and Press accept it.</param>
/// <param name="Momentary">A pushbutton that is 1 only while held: use <see cref="Datarefs.Press"/>.</param>
public sealed record DatarefInfo(string Path, string Panel, string Description, DatarefType Type, DatarefKind Kind, bool Writable, bool Momentary);
