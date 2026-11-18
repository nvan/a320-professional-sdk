using System.Diagnostics;
using System.Runtime.InteropServices;
using NVAN.A320.Sdk.HardwarePlugin;

namespace ExamplePanel;

// The only native export: Hardware calls it once when it loads the plugin. Keep it as is.
public static class Exports
{
    [UnmanagedCallersOnly(EntryPoint = "nvan_hw_plugin_entry")]
    public static nint Entry(nint host) => PluginExports.Start(host, new ExamplePanelPlugin());
}

// What the plugin adds to Hardware: one device type, a panel with one button and one light. The plugin itself writes
// the button's dataref and follows the light's dataref. Which datarefs those are is the plugin's own setting: here
// two text settings the user fills in Hardware's device list, helped by the list the "Config..." button writes.
public sealed class ExamplePanelPlugin : HardwarePlugin
{
    public override PluginInfo Info
    {
        get
        {
            // Ids are stored in users' configurations: never change them once published.
            var type = new DeviceTypeInfo("example-panel", "Example panel", "One button and one light") { HasConfig = true };
            type.AddSetting(new SettingInfo("port", "Port", SettingType.String, "", "Where the panel is connected"));
            type.AddSetting(new SettingInfo("button", "Button dataref", SettingType.String, "glare.masterWarn.capt.pressed",
                "The pushbutton the button presses (Config... lists them)"));
            type.AddSetting(new SettingInfo("light", "Light dataref", SettingType.String, "glare.masterWarn.capt.lit",
                "The light that follows a dataref (Config... lists them)"));
            return new PluginInfo("com.example.panel", "Example panel", "2.0.0")
            {
                Vendor = "Example",
                Description = "NVAN A320 Professional SDK example: one button and one light.",
                DeviceTypes = { type },
            };
        }
    }

    public override HardwareDevice CreateDevice(DeviceTypeInfo type, DeviceSettings settings, DeviceContext context) =>
        new ExamplePanelDevice(context, settings.GetString("port"), settings.GetString("button", "glare.masterWarn.capt.pressed"),
            settings.GetString("light", "glare.masterWarn.capt.lit"));
}

// One panel the user added. Update() runs on the plugin thread every 10 ms: read the hardware there, without blocking.
// This example has no real hardware: the button is "pressed" every 5 seconds and the light is written to the plugin
// log (Hardware's Plugins tab). Replace those two places with your device's I/O.
public sealed class ExamplePanelDevice : HardwareDevice
{
    private readonly Stopwatch _clock = Stopwatch.StartNew();
    private readonly string _port;
    private readonly string _button;
    private bool _connected;
    private bool _wasPressed;

    public ExamplePanelDevice(DeviceContext context, string port, string button, string light) : base(context)
    {
        _port = port;
        _button = button;
        // The light follows its dataref (on the plugin thread). value.Valid is false while there is no data: dark.
        Context.Subscribe(light, value => Context.Log(LogLevel.Info, $"Light {(value.IsOn ? "ON" : "off")}"));
        Context.SetStatus(false, "Connecting...");
    }

    public override void Update()
    {
        if (!_connected)
        {
            // Open the hardware here (with a short timeout). If it fails, return and try again on a later Update.
            _connected = true;
            Context.SetStatus(true, $"Connected (simulated) {_port}");
        }

        // The button: press its dataref when it goes down. A switch would write its position instead:
        // Datarefs.Write("overhead.elec.bat1.pressed", on).
        var pressed = _clock.Elapsed.TotalSeconds % 5 < 0.5;
        if (pressed && !_wasPressed) Datarefs.Press(_button);
        _wasPressed = pressed;
    }

    // "Config..." in Hardware (its own thread). A real plugin shows its own window here, listing Datarefs.Catalog so
    // the user picks the dataref of each button and light. This example writes the list to a file instead.
    public override void OpenConfig()
    {
        var catalog = Datarefs.Catalog;
        var file = Path.Combine(Environment.CurrentDirectory, "ExamplePanel-datarefs.txt"); // the plugin's folder
        File.WriteAllLines(file, catalog
            .Where(d => d.Kind is DatarefKind.Pushbutton or DatarefKind.Light)
            .Select(d => $"{d.Path}\t{(d.Writable ? "writable" : "read-only")}{(d.Momentary ? ", momentary" : "")}\t{d.Description}"));
        Context.Log(LogLevel.Info, $"{catalog.Count} datarefs; pushbuttons and lights listed in {file}");
    }
}
