namespace NVAN.A320.Sdk.Client;

/// <summary>
/// Systems rejected a request (<c>{"op":"error","message":"..."}</c>): unknown dataref, read-only, wrong type...
/// </summary>
public sealed class SystemsApiException : Exception
{
    /// <summary>Creates the exception with the message sent by Systems.</summary>
    public SystemsApiException(string message) : base(message)
    {
    }
}

/// <summary>
/// The connection to Systems was lost before the reply to a request arrived. The client reconnects on its own; the
/// request may or may not have been applied.
/// </summary>
public sealed class SystemsDisconnectedException : Exception
{
    /// <summary>Creates the exception.</summary>
    public SystemsDisconnectedException(string message, Exception? inner = null) : base(message, inner)
    {
    }
}
