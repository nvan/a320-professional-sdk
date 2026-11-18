namespace NVAN.A320.Sdk.Client.Internal;

// Dataref patterns as Systems understands them: an exact path, or a prefix ending in '*'.
internal static class Patterns
{
    public static bool IsPrefix(string pattern) => pattern.EndsWith('*');

    public static bool Matches(string path, string pattern) =>
        IsPrefix(pattern) ? path.StartsWith(pattern.AsSpan(0, pattern.Length - 1), StringComparison.Ordinal) : path == pattern;

    // Whether some path could match both patterns. Systems keeps one subscribed flag per dataref, so unsubscribing one
    // pattern also unsubscribes what an overlapping pattern still wants: the client subscribes those again.
    public static bool Overlap(string a, string b)
    {
        if (!IsPrefix(a)) return Matches(a, b);
        if (!IsPrefix(b)) return Matches(b, a);
        var pa = a.AsSpan(0, a.Length - 1);
        var pb = b.AsSpan(0, b.Length - 1);
        return pa.StartsWith(pb, StringComparison.Ordinal) || pb.StartsWith(pa, StringComparison.Ordinal);
    }

    public static string[] Validate(IEnumerable<string> patterns)
    {
        ArgumentNullException.ThrowIfNull(patterns);
        var list = patterns.ToArray();
        foreach (var pattern in list)
        {
            if (string.IsNullOrEmpty(pattern)) throw new ArgumentException("Empty dataref path or pattern", nameof(patterns));
            if (pattern.IndexOf('*') is var star && star >= 0 && star != pattern.Length - 1)
                throw new ArgumentException($"'{pattern}': '*' is only allowed at the end (prefix)", nameof(patterns));
        }
        return list;
    }
}
