# PFD on a canvas (display stream example)

A basic A320 captain PFD drawn in a web page (plain HTML + JavaScript, canvas 2D) from the **display stream** of
NVAN A320 Professional Systems. It is meant as a starting point for third parties that drive a PFD display unit
(a real one, a home-made cockpit screen, a tablet...) from the simulation.

**This is a didactic example, not a certified display.** It shows how to connect, keep the stream state and draw it;
several items are simplified (listed below).

| File | |
| --- | --- |
| `pfd.html` | The page: a host field, the status, a square canvas |
| `pfd.js` | Everything else (one plain script, no build step, no framework, no CDN) |
| `NVANEIS-Regular.ttf` | NVAN's display font (**proprietary**, see below) |
| `FONT-LICENSE.txt` | The font's license |

## Run

Systems must run with its web API enabled (the address and API port are in the Systems window; 8080 by default).
Open `pfd.html` in a browser (double click).

URL parameters:

| Parameter | |
| --- | --- |
| `host` | Systems' address, `localhost` by default (as `datarefs.html`). `?host=192.168.1.20` uses port 8080; `?host=192.168.1.20:8091` another port. The field at the top changes it too |
| `stream` | `pfd.capt` (default) or `pfd.fo` (first officer PFD) |
| `rate` | Messages per second, 10 to 50 (default 50) |
| `bare` | Only the canvas, filling the window (for a display unit) |

The page connects, subscribes, and draws. When the connection closes (Systems closed or restarted, network lost) it
forgets the picture, tries again every 2 s and subscribes again by itself.

## The protocol in short

Every field and rule: [DISPLAY-STREAMS.md](../../../DISPLAY-STREAMS.md) (and the README section "Display streams over
WebSocket").

1. Open `ws://<host>:8080/api/ws` and send
   `{"op":"subscribe-display","streams":["pfd.capt"],"rate":50}`.
2. Systems answers `{"op":"display-subscribed",...}`, then sends
   `{"op":"display","stream":"pfd.capt","format":1,"seq":N,"tick":T,"full":true|false,"data":{...}}`.
3. `full: true` (the first message, then one every 2 s): `data` holds every field; it replaces your copy.
   `full: false`: a delta with only what changed, merged into your copy object by object, key by key.
   There is no request for a full message: after a problem, wait for the next full one (2 s at most).
4. `format` is the schema version (1). New fields keep it: ignore keys you do not know.

The merge (in `pfd.js`):

```js
function merge(copy, delta) {
  for (const [k, v] of Object.entries(delta)) {
    if (v !== null && typeof v === "object" && !Array.isArray(v) && copy[k] !== null && typeof copy[k] === "object")
      merge(copy[k], v);
    else copy[k] = v;
  }
}
```

The client decides nothing: Systems' DMC sends what to show (`shown`), the flags, the colors by name (`"green"`,
`"amber"`, `"cyan"`...) and the flashing phases (`...FlashOff` true = the off phase now: do not draw it). The example
reads every field defensively (a missing or non-number value never stops the drawing) and draws nothing while
`status` is not `"normal"`; it honors `displayUnits` (DU off / failed / self test, INVALID DATA, WAITING FOR DATA,
PFD/ND transfer, brightness).

## What it draws

On a 1000 x 1000 design-unit square (the units of our own Displays PFD), scaled to the canvas:

- **FMA**: 5 columns x 3 lines, two colors per cell, white / amber boxes (flashing), two-line boxes, texts spanning two
  columns, the column 4 minimum (BARO / RADIO); the flight control message (USE MAN PITCH TRIM, MAN PITCH TRIM ONLY).
- **Attitude**: sky / ground, horizon, pitch scale, heading marks on the horizon, ground box raised by the radio height,
  roll scale and roll index, sideslip index (yellow / cyan), protection marks (green "=" / amber X), red pitch arrows,
  aircraft symbol, FD bars, yaw bar, sidestick order on the ground, flight path vector, radio height.
- **Speed scale**: graduations, speed reference, trend arrow, target (managed / selected, off-scale digits), VMAX,
  VLS, alpha prot, alpha max, VSW, VFE next, high speed protection, green dot, F, S, V1, VR, ECON marks, DECEL, Mach.
- **Altitude scale**: graduations, window with rolling digits and the tens drum, NEG, window outline (yellow, pulsing,
  amber flashing), target (feet or FL, constraint color, off-scale digits), ground ribbon, baro reference (STD box,
  QNH hPa / inHg, flashing).
- **Vertical speed**: scale, needle, digits box (baro-only amber box), TCAS RA zones, TCAS message.
- **Heading scale**: graduations, track diamond, selected heading / track (off-scale digits), TRUE.
- **Flags and messages**: ATT, SPD, ALT, V/S, HDG, MACH, SI, RA, FD, FPV, CHECK ATT / ALT / HDG, WINDSHEAR,
  W/S AHEAD, CHECK ... PFD / DU NOT MONITORED.

Simplified (marked `SIMPLIFIED` in `pfd.js`): the landing system (LOC / G/S scales and diamonds, ILS data, the course
as a plain magenta line, marker and LS texts at approximate places, no half diamonds), the flight path director, the
linear deviation (dot only), the TCAS RA scale, the DU states (plain texts), the CHECK / NOT MONITORED place. Not
drawn: the VDEV scale (`altitude.verticalDeviation.scaleShown`, `messageShown`). No interpolation between frames: an
example drawing faster than 50 Hz can interpolate the continuous values between the last two frames.

## Font license

`NVANEIS-Regular.ttf` is **not** covered by the SDK's MIT license. NVAN EIS font (NVANEIS-Regular.ttf) — Copyright
2026 NVAN. All rights reserved. It is provided only to draw displays connected to NVAN A320 Professional; it may not
be redistributed separately, modified, or used in other products without NVAN's written permission. See
[FONT-LICENSE.txt](FONT-LICENSE.txt). Without the font file the page falls back to the browser's monospace font.
The rest of this example (HTML, JavaScript, this README) is under the SDK's MIT license.
