namespace NVAN.A320.Sdk.Client;

/// <summary>Value type of a dataref.</summary>
public enum DatarefType
{
    /// <summary>A type this version of the library does not know (sent by a newer Systems).</summary>
    Unknown,

    /// <summary>On / off. Sent as the numbers 0 and 1.</summary>
    Bool,

    /// <summary>Whole number (selector positions, encoder counters...).</summary>
    Int,

    /// <summary>Single-precision number in Systems, sent as a JSON number.</summary>
    Float,

    /// <summary>Text with a fixed display format (transponder "0456", frequency "121.800", FCU windows...).</summary>
    String,
}

/// <summary>What a dataref represents in the cockpit or in the simulation.</summary>
public enum DatarefKind
{
    /// <summary>A kind this version of the library does not know (sent by a newer Systems).</summary>
    Unknown,

    /// <summary>Korry or pushbutton: 1 = pressed (in) or held. See <see cref="DatarefInfo.Momentary"/>.</summary>
    Pushbutton,

    /// <summary>Toggle or multi-position switch.</summary>
    Switch,

    /// <summary>Selector position.</summary>
    Rotary,

    /// <summary>Incremental knob: a counter that goes up one per clockwise click and down one per counter-clockwise click.</summary>
    Encoder,

    /// <summary>Potentiometer, lever or axis.</summary>
    Analog,

    /// <summary>Bulb, korry legend, gauge or display window.</summary>
    Light,

    /// <summary>Ground services and other external conditions handled by Systems (e.g. ground power).</summary>
    Service,

    /// <summary>Failure trigger (1 = failed).</summary>
    Failure,

    /// <summary>State computed by Systems for the simulator model and third parties (exterior lights, cabin signs...).</summary>
    Output,

    /// <summary>Read-only discrete condition of the aircraft shared by every system (weight on wheels...).</summary>
    Gate,
}

/// <summary>Metadata of one dataref, as listed by the catalog.</summary>
/// <param name="Path">Unique name, e.g. <c>glare.fcu.ap1.pressed</c>.</param>
/// <param name="Panel">Cockpit panel or group it belongs to, e.g. <c>Glareshield / FCU 13VU (AFS control panel)</c>.</param>
/// <param name="Type">Value type.</param>
/// <param name="Kind">What it represents.</param>
/// <param name="Writable">Whether clients may write it.</param>
/// <param name="Momentary">A pushbutton that is 1 only while held: it stays 1 until it is written back to 0.</param>
/// <param name="Description">Human-readable description, with units and ranges.</param>
public sealed record DatarefInfo(
    string Path, string Panel, DatarefType Type, DatarefKind Kind, bool Writable, bool Momentary, string Description)
{
    internal static DatarefType ParseType(string? text) => text switch
    {
        "bool" => DatarefType.Bool,
        "int" => DatarefType.Int,
        "float" => DatarefType.Float,
        "string" => DatarefType.String,
        _ => DatarefType.Unknown,
    };

    internal static DatarefKind ParseKind(string? text) => text switch
    {
        "pushbutton" => DatarefKind.Pushbutton,
        "switch" => DatarefKind.Switch,
        "rotary" => DatarefKind.Rotary,
        "encoder" => DatarefKind.Encoder,
        "analog" => DatarefKind.Analog,
        "light" => DatarefKind.Light,
        "service" => DatarefKind.Service,
        "failure" => DatarefKind.Failure,
        "output" => DatarefKind.Output,
        "gate" => DatarefKind.Gate,
        _ => DatarefKind.Unknown,
    };
}
