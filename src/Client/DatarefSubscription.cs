namespace NVAN.A320.Sdk.Client;

/// <summary>
/// A set of subscribed datarefs (see <see cref="SystemsClient.Subscribe(IEnumerable{string}, EventHandler{DatarefChangedEventArgs}?)"/>).
/// Dispose it to unsubscribe; datarefs still wanted by another subscription stay subscribed.
/// </summary>
public sealed class DatarefSubscription : IDisposable
{
    private readonly SystemsClient _client;
    private readonly string[] _patterns;
    private volatile bool _disposed;

    internal DatarefSubscription(SystemsClient client, string[] patterns)
    {
        _client = client;
        _patterns = patterns;
    }

    /// <summary>The paths and prefixes of this subscription.</summary>
    public IReadOnlyList<string> Patterns => _patterns;

    /// <summary>
    /// Raised when one of these datarefs changes (and for its first value). The sender is the
    /// <see cref="SystemsClient"/>. See its threading remarks.
    /// </summary>
    public event EventHandler<DatarefChangedEventArgs>? ValueChanged;

    internal bool Matches(string path)
    {
        if (_disposed) return false;
        foreach (var pattern in _patterns)
            if (Internal.Patterns.Matches(path, pattern)) return true;
        return false;
    }

    internal void Raise(DatarefChangedEventArgs change) => ValueChanged?.Invoke(_client, change);

    /// <summary>Unsubscribes.</summary>
    public void Dispose()
    {
        if (_disposed) return;
        _disposed = true;
        _client.Unsubscribe(this);
    }
}
