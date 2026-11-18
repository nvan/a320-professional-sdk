using NVAN.A320.Sdk.Client;

// Connects to Systems, lists and reads datarefs, follows a few lights and presses buttons from the keyboard.
//   dotnet run --project examples/Datarefs -- [host[:port]]       (default localhost:8080)
// The client reconnects on its own: try restarting Systems while this runs.

var host = args.Length > 0 ? args[0] : "localhost";
var port = SystemsClient.DefaultPort;
if (host.LastIndexOf(':') is var colon && colon > 0 && int.TryParse(host[(colon + 1)..], out var p))
{
    port = p;
    host = host[..colon];
}

await using var client = new SystemsClient(host, port);
client.ConnectionStateChanged += (_, e) => Console.WriteLine($"[{e.State}] {e.Info?.Name ?? e.Error?.Message ?? client.Address.ToString()}");

// 1. Connect.
var info = await client.WaitUntilConnectedAsync();
Console.WriteLine($"Connected to {info.Product} {info.Version}, SIM ID {info.SimId}");

// 2. List: the catalog has every dataref with its type, kind and whether it can be written.
var catalog = await client.GetCatalogAsync();
Console.WriteLine($"{catalog.Count} datarefs. The FCU pushbuttons:");
foreach (var d in catalog.Where(d => d.Path.StartsWith("glare.fcu.", StringComparison.Ordinal) && d.Kind == DatarefKind.Pushbutton))
    Console.WriteLine($"  {d.Path,-32} {(d.Writable ? "writable" : "read-only")}  {d.Description}");

// 3. Read one value once.
var altWindow = await client.GetAsync("glare.fcu.altWindow");
Console.WriteLine($"FCU ALT window: \"{altWindow.AsString()}\" (empty while the FCU has no power)");

// 4. Subscribe: the handler gets the current value first, then every change (also after reconnecting).
string[] lights = ["glare.masterWarn.capt.lit", "glare.masterCaut.capt.lit", "glare.fcu.ap1.on", "overhead.elec.bat1.pressed"];
using var subscription = await client.SubscribeAsync(lights, (_, e) => Console.WriteLine($"  {e.Path} = {e.Value}"));

// 5. Write from the keyboard.
Console.WriteLine("Keys: A = press AP 1, W = press MASTER WARN, B = toggle BAT 1, Q = quit");
while (true)
{
    var key = Console.ReadKey(intercept: true).Key;
    try
    {
        switch (key)
        {
            case ConsoleKey.A:
                await client.PressAsync("glare.fcu.ap1.pressed");             // momentary: Systems writes 1, then 0 after 100 ms
                break;
            case ConsoleKey.W:
                await client.PressAsync("glare.masterWarn.capt.pressed");
                break;
            case ConsoleKey.B:
                var bat1 = client.GetValue("overhead.elec.bat1.pressed").AsBool();  // from the subscription
                await client.SetAsync("overhead.elec.bat1.pressed", !bat1);          // latching: write the position
                break;
            case ConsoleKey.Q or ConsoleKey.Escape:
                return;
        }
    }
    catch (Exception e) when (e is SystemsDisconnectedException or SystemsApiException)
    {
        Console.WriteLine($"Not sent: {e.Message}");
    }
}
