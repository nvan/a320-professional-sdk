# NVAN A320 Professional SDK

Connect your own software and hardware to **NVAN A320 Professional**. Every cockpit control, light, display and
aircraft state is a **dataref** served by the *Systems* program. There are two ways in, both by dataref path:

- **Datarefs:** a program talks to Systems directly over its WebSocket API to read, write, press and follow datarefs.
- **Hardware plugin:** a native library loaded by the *Hardware* program drives your own device (I/O card, panel,
  button box). The plugin itself reads, writes, presses and follows datarefs; it lets its user choose them in its own
  settings or configuration window, from the dataref catalog.

Every dataref, with its type, kind, access and meaning, is listed in [DATAREFS.md](DATAREFS.md). The ready-to-draw
PFD (display streams over the same WebSocket) is described in [DISPLAY-STREAMS.md](DISPLAY-STREAMS.md).

Requires the [.NET 10 SDK](https://dotnet.microsoft.com/download). Uses no NuGet packages. MIT license (see
[LICENSE](LICENSE)).

```sh
dotnet build NVAN.A320.Sdk.slnx
```

## Minimal examples

One short file each, nothing to install, no SDK library: read them first to see how the API works.

| Example | Run |
| --- | --- |
| [examples/python/datarefs.py](examples/python/datarefs.py) (Python 3) | `python3 examples/python/datarefs.py [address]` |
| [examples/js/datarefs.mjs](examples/js/datarefs.mjs) (Node.js 22+) | `node examples/js/datarefs.mjs [address]` |
| [examples/js/datarefs.html](examples/js/datarefs.html) (browser) | open the file; `datarefs.html?host=<address>` for another PC |
| [examples/c](examples/c) (Hardware plugin in C) | `gcc -shared -fPIC -I include -o example_panel.so examples/c/example_panel.c` |

The Python and Node.js ones follow BAT 1, read the FCU ALT window once, switch BAT 1 on and press MASTER WARN; the page
shows BAT 1 with a button to toggle it and one to press MASTER WARN. They use the WebSocket API at
`ws://<address>:8080/api/ws` (JSON: `subscribe`, `get`, `set`, `press`); the full list of messages is in the
[Datarefs over WebSocket](#datarefs-over-websocket) section.

## Datarefs example

`examples/Datarefs` connects to Systems, lists the FCU pushbuttons, reads the FCU ALT window, follows a few lights, and
writes datarefs when you press keys (press AP 1, press MASTER WARN, toggle BAT 1).

```sh
dotnet run --project examples/Datarefs -- 192.168.1.20      # Systems' address; default localhost, port 8080
```

The address and API port are shown in the Systems window. Open `http://<address>:8080/api` in a browser to see every
dataref with its live value. The library is `src/Client` (`SystemsClient`). It reconnects and resubscribes on its own.

## Hardware plugin example

`examples/Plugin` is a device with one button and one light:

```csharp
Context.Subscribe("glare.masterWarn.capt.lit", value => SetLed(value.IsOn));   // the light follows a dataref
Datarefs.Press("glare.masterWarn.capt.pressed");                                // momentary pushbutton
Datarefs.Write("overhead.elec.bat1.pressed", true);                             // switch or latching pushbutton
```

A lever, stick, pedal or tiller the device reads can be a remote axis instead of a `ctl.axis.*` write: flat by default,
and the user may enable it in Hardware to calibrate it like a joystick axis (end stops, curve, a lever's detents and
reverse zone):

```csharp
Context.ReportRemoteAxis("THROTTLE 1", "ctl.axis.thrustLever1", raw, 0, 1023);   // false on an older Hardware
```

Build it as a native library:

```sh
dotnet publish examples/Plugin -c Release -r linux-x64      # → examples/Plugin/bin/Release/net10.0/linux-x64/publish/ExamplePanel.so
dotnet publish examples/Plugin -c Release -r win-x64        # on Windows → ...\win-x64\publish\ExamplePanel.dll
```

Copy the `.so` / `.dll` into the `plugins` folder next to the Hardware executable and add an "Example panel" in the
Devices tab. Its settings name the button's and the light's datarefs; its Config… button lists the pushbuttons and
lights of `Datarefs.Catalog` (a real plugin shows them in its own window). The plugin's log is in the Plugins tab.

To build a plugin with NativeAOT you need `clang` and the `zlib` development files on Linux, or the Visual Studio
"Desktop development with C++" workload on Windows. The helper library is `src/HardwarePlugin`. Plugins in C, C++ or
Rust can implement the C interface in `include/nvan_hardware_plugin.h` instead.

## Datarefs over WebSocket

Connect to `ws://<address>:8080/api/ws` and send JSON text messages. Any request may carry an `"id"`, echoed in its
reply. A path ending in `*` means every dataref starting with that prefix.

| Send | Systems answers |
| --- | --- |
| `{"op":"subscribe","paths":["overhead.elec.*"]}` | `{"op":"subscribed","count":n}`, then `values` with the current values |
| `{"op":"unsubscribe","paths":[...]}` | `{"op":"unsubscribed","count":n}` |
| `{"op":"get","paths":["glare.fcu.altWindow"]}` | `{"op":"get","tick":123,"count":1,"values":{"glare.fcu.altWindow":"24000"}}` |
| `{"op":"set","path":"overhead.elec.bat1.pressed","value":1}` | `{"op":"ack","ok":true}` or `{"op":"error","message":"..."}` |
| `{"op":"press","path":"glare.masterWarn.capt.pressed","ms":100}` | `{"op":"ack","ok":true}`: 1 now, 0 after `ms` (100..10000, default 100) |
| `{"op":"catalog"}` | `{"op":"catalog","datarefs":[{"path","panel","type","kind","writable","momentary","description"}]}` |
| `{"op":"info"}` | `{"op":"info","product","version","api":1,"simId","name","instanceId"}` |

After subscribing, Systems sends `{"op":"values","tick":123,"values":{"path":value,...}}` with only the datarefs that
changed, at most every 30 ms. Bools are 0 / 1, strings are JSON strings. If Systems restarts the connection closes:
connect and subscribe again.

## Display streams over WebSocket (the ready-to-draw PFD)

For a real or home-made PFD display unit: the same connection also gives each side's PFD exactly as the simulated DMC
computes it (every value, color, flag, shown decision and flashing phase) and the state of that side's two display
units, up to 50 times a second. Streams: `pfd.capt`, `pfd.fo`.

| Send | Systems answers |
| --- | --- |
| `{"op":"subscribe-display","streams":["pfd.capt","pfd.fo"],"rate":50}` | `{"op":"display-subscribed","streams":[...],"format":1,"rate":50}`, then `display` messages. `rate` optional, 10..50 Hz (default 50) |
| `{"op":"unsubscribe-display","streams":["pfd.fo"]}` | `{"op":"display-unsubscribed","streams":["pfd.fo"]}`; no message of those streams after it |

An unknown stream is an `error` and subscribes nothing. Then Systems sends
`{"op":"display","stream":"pfd.capt","format":1,"seq":N,"tick":T,"full":true|false,"data":{...}}`:

- **Full** messages (`"full":true`, every field): the first after subscribing and one every 2 s (a client that missed something has the whole PFD again within 2 s).
- **Deltas** otherwise: only the fields that changed since the last message of that stream to this connection. Keep
  one JSON object per stream; on a full message replace it with `data`; on a delta merge `data` into it **object by
  object, key by key** (any non-object value, `null` included, replaces the old one; no key is ever removed; arrays
  would be replaced whole, and format 1 has none). No message is sent while nothing changes.
- `format` is the display-stream schema version (1): raised only for a breaking change; new fields keep it (ignore
  keys you do not know). These ops did not change the API version (`"api":1`) nor the Plugin API version.
- `seq` counts the stream's messages from 1 at each subscription; `tick` is the simulation tick of the frame.
- Sizes: a full message about 6.3 KB, a delta about 125 B parked and 450 B in flight.

`data` (339 fields): `status`, `dmc`, `side`, `displayUnits` (the DUs at the PFD and ND positions: state, format shown,
DMC, brightness, CHECK / DU NOT MONITORED messages), `flags` / `flagsFlashOff` (ATT, SPD, ALT, V/S, HDG, MACH, SI, RA,
CHECK ATT / ALT / HDG, FD, FPV, windshear), `attitude`, `speed` (scale, trend, VMAX, Mach, targets, VLS, α prot, α max,
VSW, VFE next, green dot, F, S, V1, VR...), `altitude` (scale, window, target, baro reference, radio height, vertical
deviation), `verticalSpeed`, `tcas` (RA zones), `heading`, `guidance` (FD bars, FPV / FPD, yaw bar), `fma` (5 columns
× 3 lines: text, colors, boxes, flashing, span), `fctlMessage`, `landingSystem` (LOC / G/S, ILS data, course, markers,
flags). Colors and states are names, every flag a named boolean, flashing items carry a `...FlashOff` boolean (the off
phase, timed by Systems). **Every field, its unit and meaning, the conventions and an example session:
[DISPLAY-STREAMS.md](DISPLAY-STREAMS.md).**

## Compatibility

The **Plugin API** has its own version, `MAJOR.MINOR.PATCH`, starting at **1.0.0**:

- **PATCH** (1.0.0 → 1.0.1): datarefs added (or made writable).
- **MINOR** (1.0.x → 1.1.0): functions or services added (for example weather).
- **MAJOR** (1.x → 2.0.0): a rewrite that breaks older plugins. Not planned: the API only grows, nothing is ever removed.

| Plugin API | Added |
| --- | --- |
| 1.0.0 | The plugin ABI, datarefs, remote axes |
| 1.1.0 | `deviceId` in each device's settings (C#: `DeviceSettings.DeviceId`): the device's stable id, to store per-device data |
| 1.1.1 | Datarefs `gear.{nose,left,right}.doorPosition` and `.transit`, `hyd.rat.turbineRpm`, `hyd.rat.turbineAngleDeg` |
| 1.1.2 | Datarefs `mip.gear.leverSolenoid` (L/G lever locked DOWN), `ctl.sidestickSolenoid.capt` / `.fo` (sidestick locked in neutral, AP engaged) |
| 1.1.3 | `instructor.sim.paused` writable (1 pause, 0 resume, as the IOS PAUSE / PLAY; the value stays the simulator's state); `instructor.simRate` (writable before too) documented for clients: 1, 2, 4 or 8, any other value refused |
| 1.1.4 | Datarefs `ped.mcdu<n>.key.blank1` / `blank2`: the two unlabeled MCDU keys (upper function row right of DATA, and right of AIRPORT), momentary like the other keys |
| 1.1.5 | Datarefs `ped.mcdu<n>.subsystem.fmgc` / `aids` / `cfds` / `atsu`: select an MCDU MENU system directly (as MCDU MENU then its line select key), for ARINC MCDU hardware without an MCDU MENU key |
| 1.1.6 | Datarefs: failures `failures.elec.idg1Disc` / `idg2Disc` (IDG disconnected; 0 reconnects, in flight too), `failures.fire.*BottleDischarged` (fire bottles discharged; 0 refills), `failures.wshld.birdSplatL` / `R` and the decals `wshld.birdSplatL` / `R` |

Each plugin declares the **minimum** Plugin API it needs (and a maximum only after a drastic change). It works on every
product version that provides that API or later within the same MAJOR. NVAN may also mark specific versions compatible
or not.

Declare it in the manifest (`"minPluginApi": "1.0.0"`, optional `"maxPluginApi"`, excluded; the default minimum is
1.0.0). With the C# helper:

```csharp
new PluginInfo("com.example.panels", "Example panels", "1.2.0") { MinPluginApi = "1.0.0" }
```

Hardware checks the range when it loads the plugin: a plugin needing a newer Plugin API than the installed product
provides is not started and shows "Not compatible with this version" (its users update the product, or keep an older
plugin release). Plugins installed from the Plugin Marketplace are also checked by NVAN's server after every product update,
and disabled (kept installed) while it says they are not compatible.

The binary ABI number in `nvan_hardware_plugin.h` (`NVAN_HW_ABI_VERSION`, 2) is the struct layout version, separate from
the Plugin API version: functions are only added at the end of the tables, so check that the host has one before calling
it (for example `NVAN_HW_HOST_HAS_REMOTE_AXIS(host)`).
