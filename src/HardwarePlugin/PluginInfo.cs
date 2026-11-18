using System.Text;
using System.Text.Json;

namespace NVAN.A320.Sdk.HardwarePlugin;

/// <summary>Type of a device setting shown to the user in Hardware.</summary>
public enum SettingType
{
    /// <summary>Free text.</summary>
    String,
    /// <summary>A number (optional min / max).</summary>
    Number,
    /// <summary>A check box.</summary>
    Bool,
    /// <summary>One of <see cref="SettingInfo.Choices"/>.</summary>
    Choice,
}

/// <summary>One setting of a device type, edited by the user in Hardware and passed to the device when it opens.</summary>
public sealed record SettingInfo(string Key, string Label, SettingType Type, object? Default = null, string Help = "",
    IReadOnlyList<string>? Choices = null, double? Min = null, double? Max = null);

/// <summary>A kind of device the plugin adds to Hardware's "Add device" list.</summary>
public sealed class DeviceTypeInfo(string id, string name, string description = "")
{
    /// <summary>Stable id (A-Z a-z 0-9 . _ -, up to 64 characters): stored in the user's configuration.</summary>
    public string Id { get; } = id;

    /// <summary>Name shown to the user.</summary>
    public string Name { get; } = name;

    /// <summary>One line shown to the user.</summary>
    public string Description { get; } = description;

    /// <summary>Devices of this type have their own configuration window: Hardware shows a "Config…" button that calls
    /// <see cref="HardwareDevice.OpenConfig"/> (manifest <c>"hasConfig": true</c>).</summary>
    public bool HasConfig { get; init; }

    /// <summary>Settings, in display order.</summary>
    public List<SettingInfo> Settings { get; } = new();

    /// <summary>Adds a setting.</summary>
    public DeviceTypeInfo AddSetting(SettingInfo setting)
    {
        Settings.Add(setting);
        return this;
    }
}

/// <summary>Who the plugin is and the device types it adds (the manifest of the C ABI).</summary>
public sealed class PluginInfo(string id, string name, string version)
{
    /// <summary>Unique id, reverse-domain style recommended ("com.example.panels"): A-Z a-z 0-9 . _ -, up to 64 characters.</summary>
    public string Id { get; } = id;

    /// <summary>Name shown to the user.</summary>
    public string Name { get; } = name;

    /// <summary>Plugin version shown to the user (free text, e.g. "1.2.0").</summary>
    public string Version { get; } = version;

    /// <summary>Who made it.</summary>
    public string Vendor { get; init; } = "";

    /// <summary>One or two sentences shown to the user.</summary>
    public string Description { get; init; } = "";

    /// <summary>How often <see cref="HardwareDevice.Update"/> runs, 1..1000 ms (default 10).</summary>
    public int UpdateIntervalMs { get; init; } = 10;

    /// <summary>The oldest Plugin API ("x.y.z") the plugin needs (README "Compatibility"); default "1.0.0".</summary>
    public string MinPluginApi { get; init; } = "1.0.0";

    /// <summary>Optional Plugin API the plugin no longer works with (excluded), only after a drastic (MAJOR) change.</summary>
    public string? MaxPluginApi { get; init; }

    /// <summary>The device types.</summary>
    public List<DeviceTypeInfo> DeviceTypes { get; } = new();

    /// <summary>The manifest JSON (see include/nvan_hardware_plugin.h).</summary>
    public string ToJson()
    {
        using var buffer = new MemoryStream();
        using (var w = new Utf8JsonWriter(buffer))
        {
            w.WriteStartObject();
            w.WriteString("id", Id);
            w.WriteString("name", Name);
            w.WriteString("version", Version);
            if (Vendor.Length > 0) w.WriteString("vendor", Vendor);
            if (Description.Length > 0) w.WriteString("description", Description);
            w.WriteNumber("updateIntervalMs", UpdateIntervalMs);
            w.WriteString("minPluginApi", MinPluginApi);
            if (MaxPluginApi is { Length: > 0 }) w.WriteString("maxPluginApi", MaxPluginApi);
            w.WriteStartArray("deviceTypes");
            foreach (var type in DeviceTypes)
            {
                w.WriteStartObject();
                w.WriteString("id", type.Id);
                w.WriteString("name", type.Name);
                if (type.Description.Length > 0) w.WriteString("description", type.Description);
                if (type.HasConfig) w.WriteBoolean("hasConfig", true);
                w.WriteStartArray("settings");
                foreach (var s in type.Settings) WriteSetting(w, s);
                w.WriteEndArray();
                w.WriteEndObject();
            }
            w.WriteEndArray();
            w.WriteEndObject();
        }
        return Encoding.UTF8.GetString(buffer.GetBuffer(), 0, (int)buffer.Length);
    }

    private static void WriteSetting(Utf8JsonWriter w, SettingInfo s)
    {
        w.WriteStartObject();
        w.WriteString("key", s.Key);
        w.WriteString("label", s.Label);
        w.WriteString("type", s.Type.ToString().ToLowerInvariant());
        if (s.Help.Length > 0) w.WriteString("help", s.Help);
        switch (s.Default)
        {
            case string text: w.WriteString("default", text); break;
            case bool flag: w.WriteBoolean("default", flag); break;
            case double number: w.WriteNumber("default", number); break;
            case int number: w.WriteNumber("default", number); break;
            case float number: w.WriteNumber("default", number); break;
        }
        if (s.Choices is { Count: > 0 } choices)
        {
            w.WriteStartArray("choices");
            foreach (var c in choices) w.WriteStringValue(c);
            w.WriteEndArray();
        }
        if (s.Min is { } min) w.WriteNumber("min", min);
        if (s.Max is { } max) w.WriteNumber("max", max);
        w.WriteEndObject();
    }
}
