# NVAN A320 Professional: display streams (the ready-to-draw PFD)

Part of the WebSocket API of Systems (`ws://<address>:8080/api/ws`; the datarefs ops are in the
[README](README.md#datarefs-over-websocket)). For programs that drive a **real or home-made PFD display unit** from NVAN
A320 Professional without re-implementing the DMC. Any language with a WebSocket and a JSON parser works; the SDK's
client library does not wrap these ops (yet): send them as JSON text.

In our simulation the PFD picture is not computed from datarefs: Systems simulates the three DMCs, and the EFIS
channel of the DMC driving each side builds a complete, display-ready PFD (every value, color, flag, "shown" decision
and flashing phase). Our own Displays program only draws it. The display streams give a client **that same result** as
JSON, with the state of the two display units of that side. A client draws; it decides
nothing.

## 1. Streams

| Stream | Content |
|---|---|
| `pfd.capt` | The captain PFD (side 1), from the DMC that drives it (DMC 1, or DMC 3 with EIS DMC switching on CAPT 3) |
| `pfd.fo` | The first officer PFD (side 2), from DMC 2 (or DMC 3 on F/O 3) |

Each new frame is computed every 2 simulation ticks: **50 Hz**, the rate our Displays gets. A frame is only copied
for the API while at least one client subscribes that stream; nothing is computed for it otherwise.

## 2. Protocol

Client → Systems (any request may carry an `"id"`, echoed in its reply):

| Request | Reply |
|---|---|
| `{"op":"subscribe-display","streams":["pfd.capt","pfd.fo"],"rate":50}` | `{"op":"display-subscribed","streams":["pfd.capt","pfd.fo"],"format":1,"rate":50}`, then `display` messages |
| `{"op":"unsubscribe-display","streams":["pfd.fo"]}` | `{"op":"display-unsubscribed","streams":["pfd.fo"]}`; no `display` message of those streams follows it |

- `"streams"` is an array of stream names; `"stream"` (one name) is accepted too, by every op above.
- An **unknown stream** answers `{"op":"error","message":"Unknown display stream 'x' (known: pfd.capt, pfd.fo)"}` and
  subscribes nothing of that request. A `rate` that is no
  number is an error.
- `"rate"` (optional): the most messages per second of the streams of this request, **10 to 50 Hz** (a number
  outside is clamped; default 50). At 50 every new frame is sent; below, frames are skipped evenly (30 Hz sends 3 of
  every 5 frames). The streams have their own pacing, independent of the datarefs' 30 ms batches.
- **Subscribing again** to a subscribed stream restarts it: new rate, `seq` from 1, a full message first.
- The reply to `subscribe-display` always arrives before that stream's first `display` message.
- Closing the connection unsubscribes everything. After a reconnection (Systems restarted: a new `instanceId` in
  `info`, or the socket closed) the client subscribes again and gets a full message: it never needs anything older.
- The datarefs ops (`subscribe`, `set`, `press`...) work as before on the same connection.

Systems → client:

```
{"op":"display","stream":"pfd.capt","format":1,"seq":17,"tick":123456,"full":false,"data":{...}}
```

| Field | Meaning |
|---|---|
| `stream` | `pfd.capt` or `pfd.fo` |
| `format` | Display-stream **schema version**, 1. Raised only for a breaking change (a field renamed, moved, removed or its meaning changed); **adding fields keeps it**: ignore keys you do not know. Independent of the API version (`"api"` of `info`), which these ops did not change |
| `seq` | Messages of this stream on this connection since its subscription, from 1, with no gap (TCP: no loss) |
| `tick` | Simulation tick (100 Hz) of the frame: ordering and timing; it does not advance while the simulation is paused or frozen |
| `full` | `true`: `data` holds every field. `false`: a delta |
| `data` | The PFD (section 4) |

### When a message is full

- the first message after `subscribe-display`;
- every **2 s** after the last full one (a resync point: a client that missed a message, or restarted its merge state,
  has the whole PFD again within 2 s; it also acts as a heartbeat while nothing changes).

### Delta encoding and the merge rule

A delta holds **only the fields whose value differs from the last message of that stream sent to this client**, each
inside its parent objects (an object appears only when a field below it changed). The client keeps one JSON object
per stream:

1. On a full message, replace the copy with `data`.
2. On a delta, merge `data` into the copy **recursively, key by key**: where both the delta and the copy have an
   object under a key, merge those two objects the same way; otherwise the delta's value (number, boolean, string,
   `null`, or an array) **replaces** the copy's value.
3. No key is ever removed: every key of format 1 is in every full message. `null` is a value ("no number": a
   non-finite float), not a deletion.
4. Arrays are replaced whole, never merged. **Format 1 has no arrays.**
5. A frame with no change sends **no message** (no empty delta); continuous values (attitude, speed...) change at
   almost every frame in flight, so a moving aircraft gives one message per frame.

```js
function merge(copy, delta) {
  for (const [k, v] of Object.entries(delta)) {
    if (v !== null && typeof v === 'object' && !Array.isArray(v) && copy[k] !== null && typeof copy[k] === 'object')
      merge(copy[k], v);
    else copy[k] = v;
  }
}
```

After the merge the copy equals the full message of that frame.

### Sizes and cost (measured 2026-11-22)

- A full message: about **6.3 KB**. A delta: about **125 B** parked with the engines running, about **450 B** in flight
  with every continuous value moving (attitude, speed, trend, altitude, V/S, heading, track, FD bars, radio height).
  At 50 Hz in flight that is about 23 KB/s per stream.
- Building a message: about **8 µs** per delta frame, **14 µs** for a full one, no allocation per frame (on the
  connection's own task, never on the simulation thread).

## 3. Conventions of `data`

- **Names:** camelCase, the unit in the name where there is one (`Kt` knots CAS, `Ft` feet, `Fpm` feet per minute,
  `Deg` degrees, `Nm` nautical miles, `Khz` kilohertz, `G` g load factor, `Ratio` -1..1).
- **Numbers:** float values as the shortest round-trip decimal; integers as integers; a non-finite float is `null`.
- **Continuous values** (attitude, scales, heading, radio height, deviations) move at every frame: interpolate
  between the last two frames like our Displays does if you draw faster than you receive. Everything discrete (flags,
  colors, digits, texts) is used as received.
- **`shown`**: the DMC's decision to draw that item. When `shown` is false, or the flag of its data is set, the
  values of that item are meaningless (often 0 or the last value): do not draw them.
- **Validity:** `status` (the DMC's EFIS channel) and `displayUnits.*.dmcStatus` use the ARINC 429 SSM names of our
  signals: `"normal"`, `"noComputedData"`, `"functionalTest"`, `"failureWarning"`. Per-value validity is not a status
  but what the real PFD shows for it: the red / amber **flags** (`flags.*`) and the `shown` decisions. Example: a
  failed ADR gives `flags.spd` true and the speed scale must be replaced by the red SPD flag.
- **Colors** (EcamColor): `"white"`, `"green"`, `"amber"`, `"cyan"` (the ECAM "blue", drawn cyan), `"magenta"`,
  `"red"`, `"yellow"`.
- **Enumerations** are written by name; any value this document does not list is written `"unknown"` (a newer
  Systems; draw nothing for it).
- **Flashing:** the DMC times every flashing item. A `...FlashOff` boolean true means the item is shown but in the
  **off phase** of its flashing right now (do not draw it; for a "pulsing" item, draw it dim). A flashing item whose
  `...FlashOff` is false is drawn normally. The phases come with the frames: draw what you receive, do not add your
  own flashing.
- **Side and DMC:** `side` is 1 (captain) or 2 (first officer); `dmc` (1–3) is the DMC that computed the frame.

## 4. Fields of `data` (format 1)

The table lists every field of format 1. `{a|b}` stands for one
field per alternative. Types: `float`, `int`, `bool`, `string`, `enum` (a name, listed). "P n" is the page of FCOM
DSC-31-40 "Indications on PFD" (A318/A319/A320/A321 FCOM, 15 FEB 2019, EIS2).

### 4.1 Frame and display units

| Field | Type | Unit / range | Meaning (PFD element) |
|---|---|---|---|
| `systemsInstanceId` | int | | Systems instance (as `instanceId` of `info`); a new one = Systems restarted |
| `status` | enum | `normal`, `noComputedData`, `functionalTest`, `failureWarning` | The DMC's EFIS channel. Not `normal`: nothing of this frame may be drawn (the DMC lost or failed; the DU then shows its own failure display, see `displayUnits`) |
| `dmc` | int | 1–3 | DMC that computed the PFD |
| `side` | int | 1, 2 | 1 = captain PFD, 2 = first officer PFD |
| `displayUnits.{pfd\|nd}.state` | enum | `unpowered`, `switchedOff`, `failed`, `selfTest`, `on` | State of the DU at the PFD position (`pfd`) / ND position (`nd`) of this side. Below `selfTest` the DU is black; `failed` (EIS2): blank with the amber "F"; `selfTest`: the power-up test screen |
| `displayUnits.{pfd\|nd}.format` | enum | `none`, `pfd`, `nd`, `ewd`, `sd`, `ecamOnNd` | What that DU shows. With PFD/ND XFR (or an automatic transfer after a DU failure) the PFD is on the ND position: `nd.format` = `pfd`. `none` with `state` `on`: nothing to show |
| `displayUnits.{pfd\|nd}.dmc` | int | 0–3 | DMC driving that DU (0 = none) |
| `displayUnits.{pfd\|nd}.dmcStatus` | enum | as `status` | `failureWarning`: the DMC output is lost (EIS2 "INVALID DATA"); `noComputedData`: the DMC initializes (EIS2 green "WAITING FOR DATA") |
| `displayUnits.{pfd\|nd}.brightness` | float | 0–1 | Brightness of the whole image (DU knob, automatic adjustment); apply as a final dimming |
| `displayUnits.{pfd\|nd}.feedback` | enum | `none`, `checkCaptPfd`, `checkFoPfd`, `checkCaptNd`, `checkFoNd`, `checkEwd`, `checkSd` | Amber "CHECK CAPT PFD" ... message on that DU: the DMC found a discrepancy between what it sent and what the DU shows (DSC-31-05-60) |
| `displayUnits.{pfd\|nd}.notMonitored` | bool | | Amber "DU NOT MONITORED" (on ground, the DU monitored by one DMC instead of two) |
| `displayUnits.{pfd\|nd}.imageBrightness` | float | 0–1 | ND formats only: weather radar / terrain image brightness (outer ring of the ND knob) |

### 4.2 Flags (P26–P29)

`flags.X` true: the flag is shown. `flagsFlashOff.X` true: shown, but in the off phase of its 9 s flashing (EIS2;
then steady). The windshear items are messages (not flashing).

| Field | Type | Meaning (PFD element) |
|---|---|---|
| `{flags\|flagsFlashOff}.att` | bool | Red ATT: attitude lost, the sphere is cleared (no pitch scale, horizon, roll index, sideslip, FD, FPV) |
| `{flags\|flagsFlashOff}.spd` | bool | Red SPD replaces the speed scale (every speed symbol removed) |
| `{flags\|flagsFlashOff}.alt` | bool | Red ALT replaces the altitude scale (and its window, target, baro reference digits) |
| `{flags\|flagsFlashOff}.vs` | bool | Red V/S replaces the vertical speed scale |
| `{flags\|flagsFlashOff}.hdg` | bool | Red HDG replaces the heading scale |
| `{flags\|flagsFlashOff}.mach` | bool | Red MACH below the speed scale: Mach data failed |
| `{flags\|flagsFlashOff}.si` | bool | Red SI: sideslip lost, the sideslip index removed (EIS2 flashes 9 s; EIS1 steady) |
| `{flags\|flagsFlashOff}.ra` | bool | Red RA: both radio altimeters failed |
| `{flags\|flagsFlashOff}.checkAtt` | bool | Amber CHECK ATT: the two PFDs' attitudes differ by 5° or more (DSC-31-05-60) |
| `{flags\|flagsFlashOff}.checkAlt` | bool | Amber CHECK ALT: the altitudes differ (250 ft QNH / 500 ft STD) with the same baro reference |
| `{flags\|flagsFlashOff}.checkHdg` | bool | Amber CHECK HDG: the headings differ by 5° or more |
| `{flags\|flagsFlashOff}.fd` | bool | Red FD: both FMGCs failed, or the FD pb ON with the FD not engaged |
| `{flags\|flagsFlashOff}.fpv` | bool | Red FPV: TRK FPA selected, drift or flight path angle invalid |
| `{flags\|flagsFlashOff}.windshear` | bool | Red "WINDSHEAR": FAC reactive windshear warning (15 s at least) |
| `{flags\|flagsFlashOff}.wsAheadWarning` | bool | Red "W/S AHEAD": predictive windshear warning |
| `{flags\|flagsFlashOff}.wsAheadCaution` | bool | Amber "W/S AHEAD": predictive windshear caution |

### 4.3 Attitude (P3–P4)

| Field | Type | Unit / range | Meaning (PFD element) |
|---|---|---|---|
| `attitude.pitchDeg` | float | ° (+ nose up) | Pitch: sphere and pitch scale |
| `attitude.rollDeg` | float | ° (+ right wing down) | Bank: sphere and roll index |
| `attitude.pitchArrowsDown` | bool | | Red arrowheads: pitch beyond 30° nose up (move the nose down) |
| `attitude.pitchArrowsUp` | bool | | Red arrowheads: pitch beyond 30° nose down |
| `attitude.sideslipG` | float | g, ±0.3 (stop) | Sideslip index displacement under the roll index (+ = index to the right) |
| `attitude.sideslipColor` | enum | `yellow`, `cyan` | Yellow; cyan (blue) = β target (engine-out asymmetric thrust, FAC) |
| `attitude.protections` | enum | `none`, `normal`, `lost` | Protection symbols on the roll and pitch scales: green "=" (normal law), amber X (alternate / direct law), none (no flight control data) |
| `attitude.sidestick.shown` | bool | | Sidestick order indication (white cross), on ground after the first engine start (DSC-27-20-30) |
| `attitude.sidestick.{pitchRatio\|rollRatio}` | float | -1..1 (+ nose up / roll right) | Sidestick order as a fraction of full deflection |

### 4.4 Speed scale (P5–P9). Speeds are CAS in knots.

| Field | Type | Unit / range | Meaning (PFD element) |
|---|---|---|---|
| `speed.casKt` | float | kt, 30 minimum | Speed on the scale (filtered as the DMC does; the reference line reads it) |
| `speed.trend.shown` / `speed.trend.kt` | bool / float | kt | Yellow speed trend arrow: the speed in 10 s minus the present speed |
| `speed.vmax.shown` / `speed.vmax.kt` | bool / float | kt | Red and black VMAX strip: `kt` is its lower end |
| `speed.mach.shown` / `speed.mach.hundredths` | bool / int | 0–99 | Green Mach number below the scale (above M 0.5): `.67` = 67 |
| `speed.decel` | bool | | Green "DECEL" below the scale: autobrake deceleration achieved |
| `speed.target.shown` / `.managed` / `.kt` | bool / bool / float | kt | Speed target triangle (digits above / below the scale when off it): magenta when `managed`, cyan otherwise; a Mach target converted to CAS |
| `speed.econMargins.shown` / `.lowKt` / `.highKt` | bool / float / float | kt | Magenta ECON speed range marks (P6 (6)) |
| `speed.v1.shown` / `.kt` | bool / float | kt | Cyan "1" (V1) on the scale, its digits at the top when off it |
| `speed.vr.shown` / `.kt` | bool / float | kt | Cyan VR circle |
| `speed.vls.shown` / `.kt` | bool / float | kt | Amber VLS strip (top of the low speed band) |
| `speed.alphaProt.shown` / `.kt` | bool / float | kt | Black and amber strip from VαPROT down to VαMAX (normal law) |
| `speed.alphaMax.shown` / `.kt` | bool / float | kt | Red strip below VαMAX (normal law) |
| `speed.vsw.shown` / `.kt` | bool / float | kt | Red and black barber pole below VSW (alternate / direct law) |
| `speed.vfeNext.shown` / `.kt` | bool / float | kt | Amber "=" at VFE of the next flaps lever position |
| `speed.greenDot.shown` / `.kt` | bool / float | kt | Green dot (clean configuration) |
| `speed.fSpeed.shown` / `.kt` | bool / float | kt | Green "F" (CONF 2 / 3) |
| `speed.sSpeed.shown` / `.kt` | bool / float | kt | Green "S" (CONF 1) |
| `speed.highSpeedProtection.shown` / `.kt` | bool / float | kt | Green "=" at the high speed protection speed (normal law) |

(Each `x.shown` / `x.kt` row is two fields, `speed.x.shown` and `speed.x.kt`.)

### 4.5 Altitude scale, baro reference, radio height (P9–P12)

| Field | Type | Unit / range | Meaning (PFD element) |
|---|---|---|---|
| `altitude.ft` | float | ft | Altitude on the scale: baro-corrected (QNH) or pressure altitude (STD) |
| `altitude.negative` | bool | | "NEG" in the altitude window |
| `altitude.digitsColor` | enum | `green` (`amber` reserved: below MDA, not computed yet) | Altitude window digits |
| `altitude.window.color` | enum | `yellow`, `amber` | Window outline: yellow; amber = altitude alert deviation |
| `altitude.window.pulseDim` | bool | | Altitude alert "approaching": the yellow outline pulses, now in its dim phase |
| `altitude.window.flashOff` | bool | | Altitude alert "deviation": the amber outline flashes, now in its off phase |
| `altitude.target.shown` / `.constraint` / `.ft` | bool / bool / int | ft | Altitude target symbol (digits above / below when off the scale): magenta when `constraint` (constraint of a managed vertical mode), cyan = the FCU altitude |
| `altitude.baro.mode` | enum | `none`, `std`, `qnhHpa`, `qnhInHg` | Baro reference under the scale: nothing, "STD" (boxed), "QNH" + setting |
| `altitude.baro.value` | int | hPa, or inHg × 100 | QNH setting (1013 = "1013"; 2992 = "29.92") |
| `altitude.baro.flashOff` | bool | | Wrong setting for the transition altitude / level (P10 (4)): the STD box or QNH + setting flash, now off |
| `altitude.radioHeight.shown` | bool | | Radio height digits (below 2500 ft) |
| `altitude.radioHeight.ft` | float | ft | Radio height, continuous: positions the ground reference ribbon |
| `altitude.radioHeight.digitsFt` | int | ft | Radio height digits as displayed (10 / 5 / 1 ft steps; negative on ground possible) |
| `altitude.radioHeight.color` | enum | `green`, `amber` | Digits color (amber at 400 ft and below: no DH logic yet) |
| `altitude.radioHeight.groundRibbon` | bool | | Red ground reference ribbon on the altitude scale (below 570 ft RA) |
| `altitude.verticalDeviation.ft` | float | ft (+ above the path) | FM vertical deviation: altitude minus path altitude (the dot and the VDEV index) |
| `altitude.verticalDeviation.dotShown` | bool | | Linear deviation dot on the altitude scale (from the T/D to the MAP) |
| `altitude.verticalDeviation.scaleShown` | bool | | FINAL: ±200 ft VDEV scale and index in place of the G/S scale |
| `altitude.verticalDeviation.messageShown` / `.messageFlashOff` | bool / bool | | Amber "V/DEV" above the G/S scale (FINAL with the LS pb pressed), flashing |

### 4.6 Vertical speed and TCAS RA (P12–P13; DSC-34-SURV-60-20 P4)

| Field | Type | Unit / range | Meaning (PFD element) |
|---|---|---|---|
| `verticalSpeed.fpm` | float | ft/min, ±6000 | Needle (limited by the DMC) |
| `verticalSpeed.hundreds` | int | ft/min / 100 (sign = direction) | Digits (`-7` = "7" below the needle, descending) |
| `verticalSpeed.color` | enum | `green`, `amber`, `white` | Needle and digits: amber above 6000 ft/min, or descending faster than 2000 ft/min between 1000 and 2500 ft RA / 1200 ft/min below 1000 ft RA; white during a TCAS RA (the digits then take `tcas.digitsColor`) |
| `verticalSpeed.digitsShown` | bool | | Digits shown (200 ft/min and more) |
| `verticalSpeed.baroOnly` | bool | | V/S from barometric data only: amber box around the digits |
| `tcas.raShown` | bool | | Resolution advisory: rectangular V/S scale, white needle, the zones below |
| `tcas.{redLow\|redHigh\|green}.shown` | bool | | One RA zone shown |
| `tcas.{redLow\|redHigh\|green}.{fromFpm\|toFpm}` | int | ft/min (from < to) | That zone's limits |
| `tcas.message` | bool | | Amber vertical "TCAS" in the V/S scale (no RA data while not in STBY) |
| `tcas.digitsColor` | enum | color | During an RA: the V/S digits in the color of the zone the V/S is in |

### 4.7 Heading scale (P13–P14)

| Field | Type | Unit / range | Meaning (PFD element) |
|---|---|---|---|
| `heading.deg` | float | ° 0–360 | Heading: magnetic, or true when `trueReference` |
| `heading.trueReference` | bool | | Cyan "TRUE" above the scale (EIS1 "TRU"); every heading and course of the PFD is then true |
| `heading.track.shown` / `.deg` | bool / float | ° | Green track diamond |
| `heading.target.shown` / `.deg` | bool / float | ° | Cyan selected heading / track index (FCU), digits at the side when off the scale |

### 4.8 Guidance (FD, FPV / FPD; DSC-22_30-20)

| Field | Type | Unit / range | Meaning (PFD element) |
|---|---|---|---|
| `guidance.pitchBar.shown` / `.flashOff` / `.deg` | bool / bool / float | ° | FD pitch bar (HDG V/S), flashing 10 s on some mode changes: ordered pitch minus actual pitch (+ = bar up). With `flightPathDirector`: the FPD's vertical order (ordered FPA minus actual FPA) |
| `guidance.rollBar.shown` / `.flashOff` / `.deg` | bool / bool / float | ° | FD roll bar: ordered bank minus actual bank (+ = bank right). With `flightPathDirector`: the FPD's roll order |
| `guidance.yawBar.shown` / `.deg` | bool / float | ° | Yaw bar (RWY, FLARE below 30 ft, ROLL OUT): heading order minus heading (+ = steer right) |
| `guidance.flightPathDirector` | bool | | The flight path director (green) replaces the FD bars (TRK FPA with the FD on) |
| `guidance.flightPathVector.shown` / `.fpaDeg` / `.driftDeg` | bool / float / float | ° | Flight path vector ("bird", TRK FPA): flight path angle (vertical) and drift = track − heading (lateral) |

### 4.9 FMA (DSC-22_30-100; P23)

Five columns × three lines. Columns: `thrust` (1: A/THR mode), `vertical` (2: AP/FD vertical modes), `lateral`
(3: AP/FD lateral modes), `approachCapability` (4: approach capability, DH / MDA), `engagement` (5: AP, FD, A/THR
engagement status). Lines `line1` (top) to `line3`. Every cell
`fma.{thrust|vertical|lateral|approachCapability|engagement}.{line1|line2|line3}` has:

| Field (in each cell) | Type | Unit / range | Meaning |
|---|---|---|---|
| `fma.{thrust\|vertical\|lateral\|approachCapability\|engagement}.{line1\|line2\|line3}.text` | string | up to 22 ASCII characters | The text; `""` = empty cell |
| `fma.{thrust\|vertical\|lateral\|approachCapability\|engagement}.{line1\|line2\|line3}.color` | enum | color | Color of the text from its first character |
| `fma.{thrust\|vertical\|lateral\|approachCapability\|engagement}.{line1\|line2\|line3}.color2` | enum | color | Second color, from character `color2From` on (e.g. "V/S" green + "+2500" cyan, "MAN FLX" white + "68" cyan) |
| `fma.{thrust\|vertical\|lateral\|approachCapability\|engagement}.{line1\|line2\|line3}.color2From` | int | 0–22 | Index of the first character in `color2`; the text length or more: one color |
| `fma.{thrust\|vertical\|lateral\|approachCapability\|engagement}.{line1\|line2\|line3}.boxWhite` | bool | | White box around the text (10 s after a new annunciation; MAN TOGA / FLX / MCT) |
| `fma.{thrust\|vertical\|lateral\|approachCapability\|engagement}.{line1\|line2\|line3}.boxAmber` | bool | | Amber box (MAN THR, A.FLOOR, TOGA LK, V/S not held) |
| `fma.{thrust\|vertical\|lateral\|approachCapability\|engagement}.{line1\|line2\|line3}.boxFlashOff` | bool | | Off phase of a flashing box |
| `fma.{thrust\|vertical\|lateral\|approachCapability\|engagement}.{line1\|line2\|line3}.textFlashOff` | bool | | Off phase of a flashing text (LVR CLB, THR LK...) |
| `fma.{thrust\|vertical\|lateral\|approachCapability\|engagement}.{line1\|line2\|line3}.spanNext` | bool | | The text is centered over this column and the next one (LAND, messages across columns 2–3) |
| `fma.{thrust\|vertical\|lateral\|approachCapability\|engagement}.{line1\|line2\|line3}.boxTwoLines` | bool | | The box also takes the cell below (MAN / TOGA on two lines) |

### 4.10 Flight control message (DSC-27-20-20; P29)

| Field | Type | Unit / range | Meaning (PFD element) |
|---|---|---|---|
| `fctlMessage.message` | enum | `none`, `useManPitchTrim`, `manPitchTrimOnly` | Below the FMA: amber "USE MAN PITCH TRIM" (direct law) or red "MAN PITCH TRIM ONLY" (mechanical back-up) |
| `fctlMessage.flashOff` | bool | | First 9 s: the red text flashing (hidden now), the amber one pulsing (dim now); then steady |

### 4.11 Landing system (P19–P21, P26–P29)

| Field | Type | Unit / range | Meaning (PFD element) |
|---|---|---|---|
| `landingSystem.receiver` | int | 1, 2 | Receiver number in the ILS / DME flags ("ILS1" on PFD 1, "ILS2" on PFD 2) |
| `landingSystem.locScale.shown` / `.flashOff` | bool / bool | | LOC deviation scale (LS pb on); flashing: excessive deviation |
| `landingSystem.gsScale.shown` / `.flashOff` | bool / bool | | G/S deviation scale; flashing: excessive deviation |
| `landingSystem.loc.shown` / `.flashOff` / `.dots` | bool / bool / float | dots (+ = localizer to the right) | Magenta LOC diamond; beyond 2 dots a half diamond at the end of the scale, flashing 2 s (draw at ±2 at most) |
| `landingSystem.gs.shown` / `.flashOff` / `.dots` | bool / bool / float | dots (+ = glide slope above) | Magenta G/S diamond, same rules |
| `landingSystem.ilsInfo.shown` | bool | | ILS information, bottom left: magenta frequency, ident and DME below |
| `landingSystem.ilsInfo.frequencyKhz` | int | kHz | 109900 = "109.90" |
| `landingSystem.ilsInfo.identShown` / `.ident` | bool / string | up to 8 ASCII | Decoded LOC ident |
| `landingSystem.ilsInfo.dmeShown` / `.dmeNm` | bool / float | NM | ILS DME distance |
| `landingSystem.course.shown` / `.deg` | bool / float | ° | Magenta ILS course dagger on the heading scale (digits in a box when off the scale); on the heading scale's reference (true with `heading.trueReference`) |
| `landingSystem.lsMessage.shown` / `.flashOff` | bool / bool | | Amber "LS" (APPR armed with the LS pb off), flashing |
| `landingSystem.marker.shown` / `.flashOff` / `.type` | bool / bool / enum | `none`, `outer`, `middle`, `inner` | Marker: OM (cyan), MM (amber), IM (white), blinking with the beacon keying |
| `landingSystem.{flags\|flagsFlashOff}.loc` | bool | | Red "LOC" on the LOC scale: localizer receiver failed |
| `landingSystem.{flags\|flagsFlashOff}.gs` | bool | | Red "G/S" on the G/S scale |
| `landingSystem.{flags\|flagsFlashOff}.ils` | bool | | Red "ILS1" / "ILS2" in place of the ILS frequency |
| `landingSystem.{flags\|flagsFlashOff}.dme` | bool | | Red "DME1" / "DME2" in place of the DME distance |

(Rows with `a` / `.b` list several fields of one item: `landingSystem.loc.shown`, `landingSystem.loc.flashOff`,
`landingSystem.loc.dots`.)

339 fields in format 1.

## 5. What the PFD shows that the stream does not carry

Not computed by our DMC yet (and so neither in the stream nor drawn by our Displays): the STALL message; the SPD SEL,
SPD LIM, V1 INOP, ALT SEL and DH flags; the approach minimum mark and the amber altitude digits below the MDA (the
FMGC has the MDA / DH: the FMA column 4 shows them); the DH-based radio height color (a fixed 400 ft rule instead);
the landing elevation (brown); the tailstrike pitch limit indicator; the ground roll bar; the selected heading
symbol on the horizon with both FDs off; GLS / MLS and RNP L/DEV scales; the BUSS (option); the gray background
removal on avionics ventilation failure. Adding any of them adds fields (the format stays 1).

## 6. Example session

```
→ {"op":"subscribe-display","streams":["pfd.capt"],"id":1}
← {"op":"display-subscribed","id":1,"streams":["pfd.capt"],"format":1,"rate":50}
← {"op":"display","stream":"pfd.capt","format":1,"seq":1,"tick":58,"full":true,"data":{
     "systemsInstanceId":1876543210,"status":"normal","dmc":1,"side":1,
     "displayUnits":{"pfd":{"state":"on","format":"pfd","dmc":1,"dmcStatus":"normal","brightness":0.8,"feedback":"none",
                            "notMonitored":false,"imageBrightness":0},
                     "nd":{"state":"on","format":"nd","dmc":1,"dmcStatus":"normal","brightness":0.8,"feedback":"none",
                           "notMonitored":false,"imageBrightness":0.8}},
     "flags":{"att":false,"spd":false, ... ,"wsAheadCaution":false},
     "flagsFlashOff":{ ... },
     "attitude":{"pitchDeg":0,"rollDeg":0,"pitchArrowsDown":false,"pitchArrowsUp":false,"sideslipG":0,
                 "sideslipColor":"yellow","protections":"normal","sidestick":{"shown":true,"pitchRatio":0,"rollRatio":0}},
     "speed":{"casKt":30,"trend":{"shown":false,"kt":0},"vmax":{"shown":true,"kt":230}, ... },
     "altitude":{"ft":0,"negative":false,"digitsColor":"green", ...,
                 "baro":{"mode":"qnhHpa","value":1013,"flashOff":false},
                 "radioHeight":{"shown":true,"ft":-0.4370051,"digitsFt":0,"color":"amber","groundRibbon":true}, ... },
     ...,
     "fma":{ ..., "engagement":{"line1":{"text":"", ...},
                                "line2":{"text":"1 FD 2","color":"white","color2":"white","color2From":22,"boxWhite":true,
                                         "boxAmber":false,"boxFlashOff":false,"textFlashOff":false,"spanNext":false,
                                         "boxTwoLines":false}, ... }},
     "fctlMessage":{"message":"none","flashOff":false},
     "landingSystem":{"receiver":1, ... }}}
← {"op":"display","stream":"pfd.capt","format":1,"seq":2,"tick":60,"full":false,"data":{"speed":{"vmax":{"kt":215}}}}
← {"op":"display","stream":"pfd.capt","format":1,"seq":3,"tick":104,"full":false,"data":{"altitude":{"radioHeight":{"ft":-0.7116899,"digitsFt":-1}}}}
← {"op":"display","stream":"pfd.capt","format":1,"seq":4,"tick":154,"full":false,"data":{"altitude":{"radioHeight":{"ft":-1.0458593}}}}
← {"op":"display","stream":"pfd.capt","format":1,"seq":40,"tick":204,"full":true,"data":{ ...every field (2 s later)... }}
→ {"op":"unsubscribe-display","streams":["pfd.capt"]}
← {"op":"display-unsubscribed","streams":["pfd.capt"]}
```

(Recorded with ENGINES RUNNING on the ground, shortened with "...": a full message has every field of section 4.)
