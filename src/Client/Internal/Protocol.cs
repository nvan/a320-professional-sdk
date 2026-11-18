using System.Text.Json;

namespace NVAN.A320.Sdk.Client.Internal;

// JSON messages of the WebSocket API (ws://host:8080/api/ws). Utf8JsonWriter / JsonDocument only: no reflection,
// NativeAOT and trimming safe.
internal static class Protocol
{
    // {"op":"...","id":n, ...body}
    public static byte[] Request(string op, long id, Action<Utf8JsonWriter>? body = null) => Object(w =>
    {
        w.WriteString("op", op);
        w.WriteNumber("id", id);
        body?.Invoke(w);
    });

    public static byte[] Object(Action<Utf8JsonWriter> body)
    {
        using var buffer = new MemoryStream();
        using (var w = new Utf8JsonWriter(buffer))
        {
            w.WriteStartObject();
            body(w);
            w.WriteEndObject();
        }
        return buffer.ToArray();
    }

    public static byte[] Paths(string op, long id, IEnumerable<string> paths) => Request(op, id, w =>
    {
        w.WriteStartArray("paths");
        foreach (var path in paths) w.WriteStringValue(path);
        w.WriteEndArray();
    });

    public static byte[] Set(long id, string path, double value)
    {
        if (!double.IsFinite(value)) throw new ArgumentOutOfRangeException(nameof(value), "Dataref values must be finite numbers");
        return Request("set", id, w => { w.WriteString("path", path); w.WriteNumber("value", value); });
    }

    public static byte[] Set(long id, string path, string value) =>
        Request("set", id, w => { w.WriteString("path", path); w.WriteString("value", value); });

    public static byte[] Press(long id, string path, int ms) =>
        Request("press", id, w => { w.WriteString("path", path); w.WriteNumber("ms", ms); });

    // Op and id of any message from Systems (id is the number this client sent; anything else is not ours).
    public static (string? Op, long? Id) Head(JsonElement root)
    {
        var op = root.TryGetProperty("op", out var o) && o.ValueKind == JsonValueKind.String ? o.GetString() : null;
        long? id = root.TryGetProperty("id", out var i) && i.ValueKind == JsonValueKind.Number && i.TryGetInt64(out var n) ? n : null;
        return (op, id);
    }

    public static string ErrorMessage(JsonElement root) =>
        root.TryGetProperty("message", out var m) && m.ValueKind == JsonValueKind.String ? m.GetString() ?? "" : "Error";

    // "values" pushes and "get" replies: {"tick":n,"values":{"path":value,...}}
    public static List<KeyValuePair<string, DatarefValue>> Values(JsonElement root, out long tick)
    {
        tick = root.TryGetProperty("tick", out var t) && t.TryGetInt64(out var n) ? n : 0;
        var list = new List<KeyValuePair<string, DatarefValue>>();
        if (!root.TryGetProperty("values", out var values) || values.ValueKind != JsonValueKind.Object) return list;
        foreach (var property in values.EnumerateObject())
        {
            if (TryValue(property.Value, out var value)) list.Add(new(property.Name, value));
        }
        return list;
    }

    public static bool TryValue(JsonElement element, out DatarefValue value)
    {
        switch (element.ValueKind)
        {
            case JsonValueKind.Number: value = DatarefValue.FromNumber(element.GetDouble()); return true;
            case JsonValueKind.String: value = DatarefValue.FromText(element.GetString() ?? ""); return true;
            case JsonValueKind.True: value = DatarefValue.FromNumber(1); return true;
            case JsonValueKind.False: value = DatarefValue.FromNumber(0); return true;
            case JsonValueKind.Null: value = DatarefValue.FromNumber(double.NaN); return true; // a non-finite float
            default: value = default; return false;
        }
    }

    // One element of the "datarefs" array of the catalog op and of GET /api/datarefs.
    public static DatarefInfo Info(JsonElement e) => new(
        Text(e, "path"), Text(e, "panel"), DatarefInfo.ParseType(Text(e, "type")), DatarefInfo.ParseKind(Text(e, "kind")),
        Bool(e, "writable"), Bool(e, "momentary"), Text(e, "description"));

    public static List<DatarefInfo> Catalog(JsonElement root)
    {
        var list = new List<DatarefInfo>();
        if (root.TryGetProperty("datarefs", out var array) && array.ValueKind == JsonValueKind.Array)
            foreach (var e in array.EnumerateArray()) list.Add(Info(e));
        return list;
    }

    public static SystemsInfo SystemsInfo(JsonElement root) => new(
        Text(root, "product"), Text(root, "version"),
        root.TryGetProperty("api", out var api) && api.TryGetInt32(out var a) ? a : 0,
        Text(root, "simId"), Text(root, "name"),
        root.TryGetProperty("instanceId", out var id) && id.TryGetUInt32(out var i) ? i : 0);

    private static string Text(JsonElement e, string name) =>
        e.TryGetProperty(name, out var p) && p.ValueKind == JsonValueKind.String ? p.GetString() ?? "" : "";

    private static bool Bool(JsonElement e, string name) =>
        e.TryGetProperty(name, out var p) && p.ValueKind == JsonValueKind.True;
}
