namespace NVAN.A320.Sdk.Client;

/// <summary>State of the connection to Systems.</summary>
public enum ConnectionState
{
    /// <summary>Not connected; the client waits before the next attempt (or was not started).</summary>
    Disconnected,

    /// <summary>Opening the WebSocket.</summary>
    Connecting,

    /// <summary>Connected: <see cref="SystemsClient.Info"/> is known and the subscriptions were sent.</summary>
    Connected,
}

/// <summary>A dataref value received from Systems that differs from the previous one the client held.</summary>
public sealed class DatarefChangedEventArgs(string path, DatarefValue value, DatarefValue? previous, long tick) : EventArgs
{
    /// <summary>Dataref path.</summary>
    public string Path { get; } = path;

    /// <summary>New value.</summary>
    public DatarefValue Value { get; } = value;

    /// <summary>Value held before, or null for the first value received.</summary>
    public DatarefValue? Previous { get; } = previous;

    /// <summary>Systems simulation tick of the value (starts again from 0 when Systems restarts).</summary>
    public long Tick { get; } = tick;
}

/// <summary>The connection state changed.</summary>
public sealed class ConnectionStateChangedEventArgs(
    ConnectionState state, SystemsInfo? info, bool systemsRestarted, Exception? error) : EventArgs
{
    /// <summary>New state.</summary>
    public ConnectionState State { get; } = state;

    /// <summary>The Systems connected to (Connected only).</summary>
    public SystemsInfo? Info { get; } = info;

    /// <summary>
    /// Connected only: true when this Systems is a different process from the one of the previous connection (it was
    /// restarted, or another Systems took its place). Subscriptions are resent either way.
    /// </summary>
    public bool SystemsRestarted { get; } = systemsRestarted;

    /// <summary>Disconnected only: why the connection was lost or the attempt failed, if known.</summary>
    public Exception? Error { get; } = error;
}
