namespace NVAN.A320.Sdk.Client.Internal;

// Last value of every subscribed dataref. Values carry the Systems tick they were read at: within one connection an
// older value never replaces a newer one ("get" replies and "values" pushes are read from different snapshots and may
// arrive in either order). A new connection (generation) accepts anything: ticks start again when Systems restarts.
// Not thread-safe: SystemsClient calls it under its lock.
internal sealed class ValueCache
{
    private readonly Dictionary<string, Entry> _entries = new(StringComparer.Ordinal);

    private struct Entry
    {
        public DatarefValue Value;
        public int Generation;
        public long Tick;
    }

    // Returns true when the value is new or different (previous = the value held before, if any).
    public bool Apply(string path, DatarefValue value, int generation, long tick, out DatarefValue? previous)
    {
        previous = null;
        if (_entries.TryGetValue(path, out var entry))
        {
            if (entry.Generation == generation && tick < entry.Tick) return false;
            previous = entry.Value;
        }
        _entries[path] = new Entry { Value = value, Generation = generation, Tick = tick };
        return previous is not { } p || p != value;
    }

    public bool TryGet(string path, out DatarefValue value)
    {
        var found = _entries.TryGetValue(path, out var entry);
        value = entry.Value;
        return found;
    }

    public void RemoveWhere(Func<string, bool> predicate)
    {
        foreach (var path in _entries.Keys.Where(predicate).ToList()) _entries.Remove(path);
    }
}
