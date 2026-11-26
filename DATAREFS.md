# Datarefs

Every dataref of NVAN A320 Professional (4269), grouped by panel or system. Generated from Systems' catalog;
a running Systems lists the same at `http://<address>:8080/api` and over the WebSocket (`{"op":"catalog"}`).

Access: **read** (only Systems writes it), **write** (a plugin or client may write it), **momentary** (a
pushbutton or key: write 1 while pressed, 0 on release, or use `press`). Types: `bool` (0 / 1), `int`, `float`,
`string`. Sample value: the format of a value (e.g. frequencies and window texts): the first example of the description
for texts, else what a running Systems reported when the list was made (cold and dark aircraft on the ground).

## Contents

- [ADIRS (parameters)](#adirs-parameters) (81)
- [ADIRS / ATT heading (MCDU IRS MONITOR SET HDG)](#adirs--att-heading-mcdu-irs-monitor-set-hdg) (3)
- [ADIRS / IR state](#adirs--ir-state) (6)
- [Air (parameters)](#air-parameters) (28)
- [Air systems (indications)](#air-systems-indications) (21)
- [Aircraft](#aircraft) (11)
- [Aircraft (sound sources)](#aircraft-sound-sources) (22)
- [Aircraft options](#aircraft-options) (6)
- [APU (indications)](#apu-indications) (14)
- [ATSU](#atsu) (7)
- [Audio management (AMU)](#audio-management-amu) (70)
- [Cabin / PURSER panel](#cabin--purser-panel) (1)
- [CIDS / Cabin](#cids--cabin) (12)
- [CIDS / FAP (cabin)](#cids--fap-cabin) (23)
- [Circuit breakers / 105VU](#circuit-breakers--105vu) (16)
- [Circuit breakers / 106VU](#circuit-breakers--106vu) (14)
- [Circuit breakers / 121VU](#circuit-breakers--121vu) (180)
- [Circuit breakers / 122VU](#circuit-breakers--122vu) (135)
- [Circuit breakers / 123VU](#circuit-breakers--123vu) (36)
- [Circuit breakers / 124VU](#circuit-breakers--124vu) (6)
- [Circuit breakers / 125VU](#circuit-breakers--125vu) (4)
- [Circuit breakers / 49VU](#circuit-breakers--49vu) (109)
- [Controls / Axes (hardware)](#controls--axes-hardware) (19)
- [Controls / Brake pedals](#controls--brake-pedals) (2)
- [Controls / Buttons (hardware)](#controls--buttons-hardware) (19)
- [Controls / PTT](#controls--ptt) (4)
- [Controls / steering hand wheels](#controls--steering-hand-wheels) (2)
- [DDRMI](#ddrmi) (16)
- [Doors](#doors) (33)
- [Doors / cockpit door (cabin side)](#doors--cockpit-door-cabin-side) (18)
- [EFB](#efb) (1)
- [EIS (parameters)](#eis-parameters) (2)
- [Electrical (parameters)](#electrical-parameters) (26)
- [Electrical contactors](#electrical-contactors) (22)
- [Engines (parameters)](#engines-parameters) (12)
- [FADEC (parameters)](#fadec-parameters) (6)
- [Failures / ADIRS](#failures--adirs) (46)
- [Failures / Air conditioning](#failures--air-conditioning) (21)
- [Failures / APU](#failures--apu) (22)
- [Failures / ATSU](#failures--atsu) (1)
- [Failures / CFDS](#failures--cfds) (1)
- [Failures / Circuit breakers](#failures--circuit-breakers) (500)
- [Failures / Clock](#failures--clock) (1)
- [Failures / Communications](#failures--communications) (20)
- [Failures / Doors](#failures--doors) (6)
- [Failures / EIS](#failures--eis) (17)
- [Failures / Electrical](#failures--electrical) (30)
- [Failures / Electrical contactors](#failures--electrical-contactors) (66)
- [Failures / Engines](#failures--engines) (85)
- [Failures / Engines (CFM)](#failures--engines-cfm) (6)
- [Failures / Engines (IAE)](#failures--engines-iae) (28)
- [Failures / FCU](#failures--fcu) (2)
- [Failures / Fire](#failures--fire) (48)
- [Failures / Flight controls](#failures--flight-controls) (66)
- [Failures / FMGC](#failures--fmgc) (3)
- [Failures / Fuel](#failures--fuel) (29)
- [Failures / FWS](#failures--fws) (4)
- [Failures / Hydraulic](#failures--hydraulic) (17)
- [Failures / Ice and rain](#failures--ice-and-rain) (6)
- [Failures / ISIS](#failures--isis) (5)
- [Failures / Landing gear](#failures--landing-gear) (31)
- [Failures / Lights](#failures--lights) (17)
- [Failures / MCDU](#failures--mcdu) (2)
- [Failures / Oxygen](#failures--oxygen) (5)
- [Failures / Pneumatic](#failures--pneumatic) (30)
- [Failures / Pressurization](#failures--pressurization) (6)
- [Failures / Probe / window heat](#failures--probe--window-heat) (21)
- [Failures / Radio](#failures--radio) (22)
- [Failures / Recorders](#failures--recorders) (3)
- [Failures / Surveillance](#failures--surveillance) (7)
- [Failures / Ventilation](#failures--ventilation) (13)
- [Failures / Water / waste](#failures--water--waste) (4)
- [Failures / Weather radar](#failures--weather-radar) (6)
- [FG (indications)](#fg-indications) (48)
- [Fire protection (indications)](#fire-protection-indications) (16)
- [Flight controls / State (read-only)](#flight-controls--state-read-only) (47)
- [FMGC (indications)](#fmgc-indications) (35)
- [FMGS stand-in](#fmgs-stand-in) (3)
- [Forward entrance](#forward-entrance) (1)
- [Fuel (indications)](#fuel-indications) (40)
- [FWC / ALERTS](#fwc--alerts) (2)
- [FWC / AURAL](#fwc--aural) (10)
- [Gates](#gates) (11)
- [Glareshield](#glareshield) (2)
- [Glareshield / ATC MSG](#glareshield--atc-msg) (4)
- [Glareshield / ATTENTION GETTERS](#glareshield--attention-getters) (8)
- [Glareshield / CHART LT](#glareshield--chart-lt) (4)
- [Glareshield / CHRONO](#glareshield--chrono) (8)
- [Glareshield / FCU](#glareshield--fcu) (4)
- [Glareshield / FCU 13VU (AFS control panel)](#glareshield--fcu-13vu-afs-control-panel) (47)
- [Glareshield / FCU 13VU (EFIS control panels)](#glareshield--fcu-13vu-efis-control-panels) (55)
- [Glareshield / INTEG LT](#glareshield--integ-lt) (1)
- [Glareshield / SIDE STICK PRIORITY](#glareshield--side-stick-priority) (4)
- [GPWS](#gpws) (7)
- [GPWS / RAAS](#gpws--raas) (9)
- [Ground / Calls](#ground--calls) (5)
- [Ground / EXTERNAL POWER panel](#ground--external-power-panel) (2)
- [Ground / Refuel panel 800VU](#ground--refuel-panel-800vu) (23)
- [Ground / Water and waste](#ground--water-and-waste) (3)
- [Ground services](#ground-services) (68)
- [Ground services / Fuel](#ground-services--fuel) (9)
- [Ground services / Load](#ground-services--load) (12)
- [Hydraulic (parameters)](#hydraulic-parameters) (12)
- [Instructor](#instructor) (7)
- [Instructor / Simulator](#instructor--simulator) (20)
- [Instructor / Slew](#instructor--slew) (10)
- [Landing gear / State (read-only)](#landing-gear--state-read-only) (23)
- [Lights](#lights) (1)
- [Lights / avionics compartment](#lights--avionics-compartment) (1)
- [Lights / cockpit](#lights--cockpit) (19)
- [Lights / exterior lamps](#lights--exterior-lamps) (19)
- [Lights / state](#lights--state) (24)
- [Load](#load) (17)
- [Main instrument panel / DCDU 1](#main-instrument-panel--dcdu-1) (39)
- [Main instrument panel / DCDU 2](#main-instrument-panel--dcdu-2) (39)
- [MIP / CAPT](#mip--capt) (8)
- [MIP / CAPT TERR ON ND 403VU](#mip--capt-terr-on-nd-403vu) (2)
- [MIP / CLOCK 400VU](#mip--clock-400vu) (10)
- [MIP / DDRMI](#mip--ddrmi) (2)
- [MIP / F/O](#mip--fo) (8)
- [MIP / ISIS](#mip--isis) (7)
- [MIP / L/G lever, BRAKES indicator 400VU](#mip--lg-lever-brakes-indicator-400vu) (6)
- [MIP / LDG GEAR, AUTO BRK 402VU](#mip--ldg-gear-auto-brk-402vu) (21)
- [MIP / Loudspeakers](#mip--loudspeakers) (2)
- [Overhead / 21VU](#overhead--21vu) (2)
- [Overhead / 22VU](#overhead--22vu) (2)
- [Overhead / ADIRS 41VU](#overhead--adirs-41vu) (25)
- [Overhead / ADIRS CDU](#overhead--adirs-cdu) (20)
- [Overhead / AIR COND 30VU](#overhead--air-cond-30vu) (25)
- [Overhead / ANTI ICE 25VU](#overhead--anti-ice-25vu) (11)
- [Overhead / APU 25VU](#overhead--apu-25vu) (6)
- [Overhead / CABIN PRESS 25VU](#overhead--cabin-press-25vu) (7)
- [Overhead / CALLS 21VU](#overhead--calls-21vu) (7)
- [Overhead / CARGO HEAT and cargo ventilation (option)](#overhead--cargo-heat-and-cargo-ventilation-option) (11)
- [Overhead / CARGO SMOKE 22VU](#overhead--cargo-smoke-22vu) (7)
- [Overhead / CKPT DOOR CONT](#overhead--ckpt-door-cont) (5)
- [Overhead / COCKPIT DOOR VIDEO 27VU](#overhead--cockpit-door-video-27vu) (2)
- [Overhead / ELEC 35VU](#overhead--elec-35vu) (34)
- [Overhead / EMER ELEC PWR](#overhead--emer-elec-pwr) (6)
- [Overhead / ENG 22VU](#overhead--eng-22vu) (8)
- [Overhead / EVAC 21VU](#overhead--evac-21vu) (5)
- [Overhead / EXT LT 25VU](#overhead--ext-lt-25vu) (8)
- [Overhead / FIRE 20VU](#overhead--fire-20vu) (24)
- [Overhead / FLT CTL 23VU](#overhead--flt-ctl-23vu) (9)
- [Overhead / FLT CTL 24VU](#overhead--flt-ctl-24vu) (12)
- [Overhead / FUEL 40VU](#overhead--fuel-40vu) (24)
- [Overhead / GPWS 21VU](#overhead--gpws-21vu) (12)
- [Overhead / HYD 40VU](#overhead--hyd-40vu) (16)
- [Overhead / INT LT 25VU](#overhead--int-lt-25vu) (4)
- [Overhead / MAINT 50VU](#overhead--maint-50vu) (23)
- [Overhead / OXYGEN 21VU](#overhead--oxygen-21vu) (6)
- [Overhead / RCDR 21VU](#overhead--rcdr-21vu) (4)
- [Overhead / READING LT](#overhead--reading-lt) (2)
- [Overhead / RMP 3](#overhead--rmp-3) (32)
- [Overhead / SIGNS 25VU](#overhead--signs-25vu) (4)
- [Overhead / VENTILATION 22VU](#overhead--ventilation-22vu) (8)
- [Oxygen](#oxygen) (5)
- [Oxygen / crew mask stowage boxes](#oxygen--crew-mask-stowage-boxes) (21)
- [Pedestal / 111VU](#pedestal--111vu) (2)
- [Pedestal / 112VU](#pedestal--112vu) (2)
- [Pedestal / ACP](#pedestal--acp) (219)
- [Pedestal / ATC-TCAS](#pedestal--atc-tcas) (18)
- [Pedestal / AUDIO SWITCHING](#pedestal--audio-switching) (1)
- [Pedestal / COCKPIT DOOR](#pedestal--cockpit-door) (4)
- [Pedestal / DRAIMS (dummy)](#pedestal--draims-dummy) (130)
- [Pedestal / ECAM CONTROL PANEL](#pedestal--ecam-control-panel) (34)
- [Pedestal / ENG 115VU](#pedestal--eng-115vu) (7)
- [Pedestal / Flight controls](#pedestal--flight-controls) (8)
- [Pedestal / GRAVITY GEAR EXTN](#pedestal--gravity-gear-extn) (1)
- [Pedestal / MCDU 1](#pedestal--mcdu-1) (115)
- [Pedestal / MCDU 2](#pedestal--mcdu-2) (115)
- [Pedestal / PARKING BRK](#pedestal--parking-brk) (1)
- [Pedestal / PRINTER](#pedestal--printer) (3)
- [Pedestal / RMP 1](#pedestal--rmp-1) (32)
- [Pedestal / RMP 2](#pedestal--rmp-2) (32)
- [Pedestal / SWITCHING](#pedestal--switching) (4)
- [Pedestal / THRUST LEVERS](#pedestal--thrust-levers) (4)
- [Pedestal / WEATHER RADAR](#pedestal--weather-radar) (7)
- [Performance](#performance) (30)
- [Radio (receivers)](#radio-receivers) (46)
- [Radio (simulator)](#radio-simulator) (4)
- [Radio (transmission)](#radio-transmission) (10)
- [Rain removal](#rain-removal) (12)
- [Recorders](#recorders) (5)
- [Relays (read-only discretes)](#relays-read-only-discretes) (33)
- [Sidesticks](#sidesticks) (4)
- [Simulator](#simulator) (3)
- [Surveillance](#surveillance) (6)
- [Water / waste](#water--waste) (4)
- [Weather radar](#weather-radar) (7)

## ADIRS (parameters)

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `adirs.adr1.aoaDeg` | float | output | read | `0` | ADR 1 angle of attack (degrees, its AOA probe; NaN when not valid) |
| `adirs.adr1.aoaValid` | bool | output | read | `0` | ADR 1 angle of attack valid (normal operation) |
| `adirs.adr1.baroAltitudeCaptFt` | float | output | read |  | ADR 1 baro-corrected altitude with the captain's baro reference (ft; ARINC baro corrected altitude #1; the standard altitude in STD; NaN when not valid): the captain's PFD altitude when this ADR feeds the captain side |
| `adirs.adr1.baroAltitudeFoFt` | float | output | read |  | ADR 1 baro-corrected altitude with the F/O's baro reference (ft; ARINC baro corrected altitude #2; the standard altitude in STD; NaN when not valid): the F/O's PFD altitude when this ADR feeds the F/O side (ADR 2, or ADR 3 with AIR DATA at F/O 3) |
| `adirs.adr1.baroAltitudeFt` | float | output | read |  | ADR 1 baro-corrected altitude of its own side (ft; NaN when not valid): the same as adirs.adr1.baroAltitudeCaptFt (the captain EFIS baro reference; the standard altitude while that side is in STD) |
| `adirs.adr1.baroReferenceCaptHpa` | float | output | read |  | ADR 1 captain baro reference received (hPa; 1013.25 in STD or without FCU; NaN when not valid) |
| `adirs.adr1.baroReferenceFoHpa` | float | output | read |  | ADR 1 F/O baro reference received (hPa; 1013.25 in STD or without FCU; NaN when not valid) |
| `adirs.adr1.baroReferenceHpa` | float | output | read |  | ADR 1 baro reference of its own side (hPa): the captain EFIS QNH, 1013.25 in STD or without FCU; NaN when not valid |
| `adirs.adr1.casKt` | float | output | read |  | ADR 1 computed airspeed (kt; NaN when not valid) |
| `adirs.adr1.mach` | float | output | read | `0` | ADR 1 Mach number (NaN when not valid) |
| `adirs.adr1.pbOff` | bool | output | read | `0` | ADR 1 pushbutton released OFF (the ADIRU's latch: each press toggles it; cleared when the ADIRU loses power). Not a lamp: overhead.adirs.adr1.off is the OFF light |
| `adirs.adr1.pressureAltitudeFt` | float | output | read |  | ADR 1 standard (1013.25 hPa) pressure altitude (ft; NaN when not valid) |
| `adirs.adr1.satC` | float | output | read |  | ADR 1 static air temperature (°C; NaN when not valid) |
| `adirs.adr1.tasKt` | float | output | read |  | ADR 1 true airspeed (kt; NaN when not valid) |
| `adirs.adr1.tatC` | float | output | read |  | ADR 1 total air temperature (°C; NaN when not valid) |
| `adirs.adr1.verticalSpeedFpm` | float | output | read |  | ADR 1 barometric vertical speed (ft/min, + up; NaN when not valid) |
| `adirs.adr2.aoaDeg` | float | output | read | `0` | ADR 2 angle of attack (degrees, its AOA probe; NaN when not valid) |
| `adirs.adr2.aoaValid` | bool | output | read | `0` | ADR 2 angle of attack valid (normal operation) |
| `adirs.adr2.baroAltitudeCaptFt` | float | output | read |  | ADR 2 baro-corrected altitude with the captain's baro reference (ft; ARINC baro corrected altitude #1; the standard altitude in STD; NaN when not valid): the captain's PFD altitude when this ADR feeds the captain side |
| `adirs.adr2.baroAltitudeFoFt` | float | output | read |  | ADR 2 baro-corrected altitude with the F/O's baro reference (ft; ARINC baro corrected altitude #2; the standard altitude in STD; NaN when not valid): the F/O's PFD altitude when this ADR feeds the F/O side (ADR 2, or ADR 3 with AIR DATA at F/O 3) |
| `adirs.adr2.baroAltitudeFt` | float | output | read |  | ADR 2 baro-corrected altitude of its own side (ft; NaN when not valid): the same as adirs.adr2.baroAltitudeFoFt (the F/O EFIS baro reference; the standard altitude while that side is in STD) |
| `adirs.adr2.baroReferenceCaptHpa` | float | output | read |  | ADR 2 captain baro reference received (hPa; 1013.25 in STD or without FCU; NaN when not valid) |
| `adirs.adr2.baroReferenceFoHpa` | float | output | read |  | ADR 2 F/O baro reference received (hPa; 1013.25 in STD or without FCU; NaN when not valid) |
| `adirs.adr2.baroReferenceHpa` | float | output | read |  | ADR 2 baro reference of its own side (hPa): the F/O EFIS QNH, 1013.25 in STD or without FCU; NaN when not valid |
| `adirs.adr2.casKt` | float | output | read |  | ADR 2 computed airspeed (kt; NaN when not valid) |
| `adirs.adr2.mach` | float | output | read | `0` | ADR 2 Mach number (NaN when not valid) |
| `adirs.adr2.pbOff` | bool | output | read | `0` | ADR 2 pushbutton released OFF (the ADIRU's latch: each press toggles it; cleared when the ADIRU loses power). Not a lamp: overhead.adirs.adr2.off is the OFF light |
| `adirs.adr2.pressureAltitudeFt` | float | output | read |  | ADR 2 standard (1013.25 hPa) pressure altitude (ft; NaN when not valid) |
| `adirs.adr2.satC` | float | output | read |  | ADR 2 static air temperature (°C; NaN when not valid) |
| `adirs.adr2.tasKt` | float | output | read |  | ADR 2 true airspeed (kt; NaN when not valid) |
| `adirs.adr2.tatC` | float | output | read |  | ADR 2 total air temperature (°C; NaN when not valid) |
| `adirs.adr2.verticalSpeedFpm` | float | output | read |  | ADR 2 barometric vertical speed (ft/min, + up; NaN when not valid) |
| `adirs.adr3.aoaDeg` | float | output | read | `0` | ADR 3 angle of attack (degrees, its AOA probe; NaN when not valid) |
| `adirs.adr3.aoaValid` | bool | output | read | `0` | ADR 3 angle of attack valid (normal operation) |
| `adirs.adr3.baroAltitudeCaptFt` | float | output | read |  | ADR 3 baro-corrected altitude with the captain's baro reference (ft; ARINC baro corrected altitude #1; the standard altitude in STD; NaN when not valid): the captain's PFD altitude when this ADR feeds the captain side |
| `adirs.adr3.baroAltitudeFoFt` | float | output | read |  | ADR 3 baro-corrected altitude with the F/O's baro reference (ft; ARINC baro corrected altitude #2; the standard altitude in STD; NaN when not valid): the F/O's PFD altitude when this ADR feeds the F/O side (ADR 2, or ADR 3 with AIR DATA at F/O 3) |
| `adirs.adr3.baroAltitudeFt` | float | output | read |  | ADR 3 baro-corrected altitude of its own side (ft; NaN when not valid): the same as adirs.adr3.baroAltitudeCaptFt (the captain EFIS baro reference; the standard altitude while that side is in STD) |
| `adirs.adr3.baroReferenceCaptHpa` | float | output | read |  | ADR 3 captain baro reference received (hPa; 1013.25 in STD or without FCU; NaN when not valid) |
| `adirs.adr3.baroReferenceFoHpa` | float | output | read |  | ADR 3 F/O baro reference received (hPa; 1013.25 in STD or without FCU; NaN when not valid) |
| `adirs.adr3.baroReferenceHpa` | float | output | read |  | ADR 3 baro reference of its own side (hPa): the captain EFIS QNH, 1013.25 in STD or without FCU; NaN when not valid |
| `adirs.adr3.casKt` | float | output | read |  | ADR 3 computed airspeed (kt; NaN when not valid) |
| `adirs.adr3.mach` | float | output | read | `0` | ADR 3 Mach number (NaN when not valid) |
| `adirs.adr3.pbOff` | bool | output | read | `0` | ADR 3 pushbutton released OFF (the ADIRU's latch: each press toggles it; cleared when the ADIRU loses power). Not a lamp: overhead.adirs.adr3.off is the OFF light |
| `adirs.adr3.pressureAltitudeFt` | float | output | read |  | ADR 3 standard (1013.25 hPa) pressure altitude (ft; NaN when not valid) |
| `adirs.adr3.satC` | float | output | read |  | ADR 3 static air temperature (°C; NaN when not valid) |
| `adirs.adr3.tasKt` | float | output | read |  | ADR 3 true airspeed (kt; NaN when not valid) |
| `adirs.adr3.tatC` | float | output | read |  | ADR 3 total air temperature (°C; NaN when not valid) |
| `adirs.adr3.verticalSpeedFpm` | float | output | read |  | ADR 3 barometric vertical speed (ft/min, + up; NaN when not valid) |
| `adirs.ir1.fpaDeg` | float | output | read | `0` | IR 1 flight path angle (degrees, + climbing; NaN when not valid) |
| `adirs.ir1.groundSpeedKt` | float | output | read |  | IR 1 ground speed (kt; NAV only, NaN otherwise) |
| `adirs.ir1.headingMagDeg` | float | output | read | `0` | IR 1 magnetic heading (degrees; NaN when not valid, e.g. polar TRUE reference) |
| `adirs.ir1.headingTrueDeg` | float | output | read | `0` | IR 1 true heading (degrees; NaN when not valid) |
| `adirs.ir1.lateralAccelG` | float | output | read |  | IR 1 body lateral acceleration (g; the PFD sideslip index on ground is minus this value, ±0.3 g; NaN when not valid) |
| `adirs.ir1.pbOff` | bool | output | read | `0` | IR 1 pushbutton released OFF (the ADIRU's latch: each press toggles it; cleared when the ADIRU loses power). Not a lamp: overhead.adirs.ir1.off is the OFF light |
| `adirs.ir1.pitchDeg` | float | output | read |  | IR 1 pitch attitude (degrees, + nose up; NaN when not valid: OFF, failed, before the 30 s coarse levelling of an alignment) |
| `adirs.ir1.rollDeg` | float | output | read |  | IR 1 roll attitude (degrees, + right wing down; NaN when not valid, as adirs.ir1.pitchDeg) |
| `adirs.ir1.trackMagDeg` | float | output | read | `0` | IR 1 magnetic track (degrees; NaN when not valid) |
| `adirs.ir1.trackTrueDeg` | float | output | read | `0` | IR 1 true track (degrees; NaN when not valid) |
| `adirs.ir1.verticalSpeedFpm` | float | output | read |  | IR 1 inertial vertical speed (ft/min, + up; NAV only, NaN otherwise) |
| `adirs.ir2.fpaDeg` | float | output | read | `0` | IR 2 flight path angle (degrees, + climbing; NaN when not valid) |
| `adirs.ir2.groundSpeedKt` | float | output | read |  | IR 2 ground speed (kt; NAV only, NaN otherwise) |
| `adirs.ir2.headingMagDeg` | float | output | read | `0` | IR 2 magnetic heading (degrees; NaN when not valid, e.g. polar TRUE reference) |
| `adirs.ir2.headingTrueDeg` | float | output | read | `0` | IR 2 true heading (degrees; NaN when not valid) |
| `adirs.ir2.lateralAccelG` | float | output | read |  | IR 2 body lateral acceleration (g; the PFD sideslip index on ground is minus this value, ±0.3 g; NaN when not valid) |
| `adirs.ir2.pbOff` | bool | output | read | `0` | IR 2 pushbutton released OFF (the ADIRU's latch: each press toggles it; cleared when the ADIRU loses power). Not a lamp: overhead.adirs.ir2.off is the OFF light |
| `adirs.ir2.pitchDeg` | float | output | read |  | IR 2 pitch attitude (degrees, + nose up; NaN when not valid: OFF, failed, before the 30 s coarse levelling of an alignment) |
| `adirs.ir2.rollDeg` | float | output | read |  | IR 2 roll attitude (degrees, + right wing down; NaN when not valid, as adirs.ir2.pitchDeg) |
| `adirs.ir2.trackMagDeg` | float | output | read | `0` | IR 2 magnetic track (degrees; NaN when not valid) |
| `adirs.ir2.trackTrueDeg` | float | output | read | `0` | IR 2 true track (degrees; NaN when not valid) |
| `adirs.ir2.verticalSpeedFpm` | float | output | read |  | IR 2 inertial vertical speed (ft/min, + up; NAV only, NaN otherwise) |
| `adirs.ir3.fpaDeg` | float | output | read | `0` | IR 3 flight path angle (degrees, + climbing; NaN when not valid) |
| `adirs.ir3.groundSpeedKt` | float | output | read |  | IR 3 ground speed (kt; NAV only, NaN otherwise) |
| `adirs.ir3.headingMagDeg` | float | output | read | `0` | IR 3 magnetic heading (degrees; NaN when not valid, e.g. polar TRUE reference) |
| `adirs.ir3.headingTrueDeg` | float | output | read | `0` | IR 3 true heading (degrees; NaN when not valid) |
| `adirs.ir3.lateralAccelG` | float | output | read |  | IR 3 body lateral acceleration (g; the PFD sideslip index on ground is minus this value, ±0.3 g; NaN when not valid) |
| `adirs.ir3.pbOff` | bool | output | read | `0` | IR 3 pushbutton released OFF (the ADIRU's latch: each press toggles it; cleared when the ADIRU loses power). Not a lamp: overhead.adirs.ir3.off is the OFF light |
| `adirs.ir3.pitchDeg` | float | output | read |  | IR 3 pitch attitude (degrees, + nose up; NaN when not valid: OFF, failed, before the 30 s coarse levelling of an alignment) |
| `adirs.ir3.rollDeg` | float | output | read |  | IR 3 roll attitude (degrees, + right wing down; NaN when not valid, as adirs.ir3.pitchDeg) |
| `adirs.ir3.trackMagDeg` | float | output | read | `0` | IR 3 magnetic track (degrees; NaN when not valid) |
| `adirs.ir3.trackTrueDeg` | float | output | read | `0` | IR 3 true track (degrees; NaN when not valid) |
| `adirs.ir3.verticalSpeedFpm` | float | output | read |  | IR 3 inertial vertical speed (ft/min, + up; NAV only, NaN otherwise) |

## ADIRS / ATT heading (MCDU IRS MONITOR SET HDG)

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `adirs.init.attHeading` | float | analog | write | `0` | Magnetic heading for the IRs in ATT mode (degrees) |
| `adirs.init.sendAttHeading` | bool | pushbutton | momentary | `0` | Sends the ATT magnetic heading to every IR in ATT mode (momentary: 1 while held) |
| `adirs.instantAlign` | bool | service | momentary | `0` | Simulator convenience: finish every IR alignment in progress now, with the present position (momentary) |

## ADIRS / IR state

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `adirs.ir1.alignSecondsLeft` | float | output | read | `0` | IR 1: seconds until NAV (alignment) or ATT (erection); 0 otherwise |
| `adirs.ir1.state` | int | output | read | `0` | IR 1 state: 0 OFF, 1 ALIGN (alignment), 2 NAV (aligned), 3 ATT erection, 4 ATT |
| `adirs.ir2.alignSecondsLeft` | float | output | read | `0` | IR 2: seconds until NAV (alignment) or ATT (erection); 0 otherwise |
| `adirs.ir2.state` | int | output | read | `0` | IR 2 state: 0 OFF, 1 ALIGN (alignment), 2 NAV (aligned), 3 ATT erection, 4 ATT |
| `adirs.ir3.alignSecondsLeft` | float | output | read | `0` | IR 3: seconds until NAV (alignment) or ATT (erection); 0 otherwise |
| `adirs.ir3.state` | int | output | read | `0` | IR 3 state: 0 OFF, 1 ALIGN (alignment), 2 NAV (aligned), 3 ATT erection, 4 ATT |

## Air (parameters)

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `aircond.aftCabin.trimValve` | float | output | read | `0` | AFT cabin trim air valve position (0 cold, closed .. 1 hot, open) |
| `aircond.cockpit.trimValve` | float | output | read | `0` | Cockpit trim air valve position (0 cold, closed .. 1 hot, open) |
| `aircond.fwdCabin.trimValve` | float | output | read | `0` | FWD cabin trim air valve position (0 cold, closed .. 1 hot, open) |
| `aircond.hotAirValve` | float | output | read | `0` | Hot air pressure regulating valve position (0 closed .. 1 open) |
| `aircond.pack1.bypassValve` | float | output | read | `1` | PACK 1 bypass (temperature control) valve position (0 cold, closed .. 1 hot, open) |
| `aircond.pack1.flowRatio` | float | output | read | `0` | PACK 1 flow as a fraction of the nominal flow (0.5675 kg/s = 1; LO 0.8, NORM 1.0, HI 1.2, single pack or APU bleed 1.2) |
| `aircond.pack1.flowValve` | float | output | read | `0` | PACK 1 flow control valve position (0 closed .. 1 open; 2 s travel) |
| `aircond.pack1.ramInlet` | float | output | read | `0.2` | PACK 1 ram air inlet flap position (0 closed .. 1 open) |
| `aircond.pack2.bypassValve` | float | output | read | `1` | PACK 2 bypass (temperature control) valve position (0 cold, closed .. 1 hot, open) |
| `aircond.pack2.flowRatio` | float | output | read | `0` | PACK 2 flow as a fraction of the nominal flow (0.5675 kg/s = 1; LO 0.8, NORM 1.0, HI 1.2, single pack or APU bleed 1.2) |
| `aircond.pack2.flowValve` | float | output | read | `0` | PACK 2 flow control valve position (0 closed .. 1 open; 2 s travel) |
| `aircond.pack2.ramInlet` | float | output | read | `0.2` | PACK 2 ram air inlet flap position (0 closed .. 1 open) |
| `aircond.ramAirValve` | float | output | read | `0` | Emergency RAM AIR inlet position (0 closed .. 1 open) |
| `bleed.eng1.hpValve` | float | output | read | `0` | ENG 1 HP valve position (0 closed .. 1 open) |
| `bleed.eng1.prv` | float | output | read | `0` | ENG 1 bleed valve (pressure regulating valve) position (0 closed .. 1 open) |
| `bleed.eng2.hpValve` | float | output | read | `0` | ENG 2 HP valve position (0 closed .. 1 open) |
| `bleed.eng2.prv` | float | output | read | `0` | ENG 2 bleed valve (pressure regulating valve) position (0 closed .. 1 open) |
| `press.landingElevationFt` | float | output | read | `0` | Landing elevation the CPC in control uses (ft): the FMGS destination elevation with the LDG ELEV selector at AUTO, else the selector's value; without either, the takeoff elevation (press.landingElevationSource 2) |
| `press.landingElevationSource` | int | output | read | `2` | Source of press.landingElevationFt: 0 FMGS (AUTO), 1 LDG ELEV selector, 2 none (LDG ELEV FAULT) |
| `press.safetyValve` | float | output | read | `0` | Cabin safety valves position (the most open of the two; 0 closed .. 1 open) |
| `press.safetyValve1` | float | output | read | `0` | Cabin safety valve 1 position (0 closed .. 1 open; opens at 8.6 psi or -1 psi ΔP; held open by failure PRESS.SAFETY_VALVE1_OPEN) |
| `press.safetyValve2` | float | output | read | `0` | Cabin safety valve 2 position (0 closed .. 1 open; opens at 8.6 psi or -1 psi ΔP; held open by failure PRESS.SAFETY_VALVE2_OPEN) |
| `vent.aircondInletValve` | float | output | read | `1` | Avionics ventilation air conditioning inlet valve position (air conditioning air to the avionics bay; 0 closed .. 1 open) |
| `vent.extractValve` | float | output | read | `0.15` | Avionics ventilation skin air outlet (extract) valve position (0 closed .. 1 open; 0.15 partially open) |
| `vent.inletValve` | float | output | read | `0` | Avionics ventilation skin air inlet valve position (0 closed .. 1 open) |
| `vent.skinExchInletBypassValve` | float | output | read | `0` | Avionics ventilation skin exchange inlet bypass valve position (to the cargo underfloor; 0 closed .. 1 open) |
| `vent.skinExchIsolationValve` | float | output | read | `1` | Avionics ventilation skin exchange isolation valve position (skin heat exchanger connected; 0 closed .. 1 open) |
| `vent.skinExchOutletBypassValve` | float | output | read | `0` | Avionics ventilation skin exchange outlet bypass valve position (from the avionics bay; 0 closed .. 1 open) |

## Air systems (indications)

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `aircond.aftCabinTempC` | float | light | read | `0` | Aft cabin zone temperature (°C) |
| `aircond.cargoAftDuctTempC` | float | light | read | `0` | Aft cargo inlet duct temperature (°C) |
| `aircond.cargoAftTempC` | float | light | read | `0` | Aft cargo compartment temperature (°C) |
| `aircond.cargoFwdDuctTempC` | float | light | read | `0` | Forward cargo inlet duct temperature (°C) |
| `aircond.cargoFwdTempC` | float | light | read | `0` | Forward cargo compartment temperature (°C) |
| `aircond.cockpitTempC` | float | light | read | `0` | Cockpit zone temperature (°C) |
| `aircond.fwdCabinTempC` | float | light | read | `0` | Forward cabin zone temperature (°C) |
| `aircond.pack1FlowKgS` | float | light | read | `0` | Pack 1 flow (kg/s) |
| `aircond.pack2FlowKgS` | float | light | read | `0` | Pack 2 flow (kg/s) |
| `bleed.apuValve` | float | light | read | `0` | APU bleed valve position (0 .. 1) |
| `bleed.side1PressurePsi` | float | light | read | `0` | Bleed duct pressure, side 1 (psi, precooler inlet) |
| `bleed.side1TempC` | float | light | read | `0` | Bleed temperature, side 1 (°C, precooler outlet) |
| `bleed.side2PressurePsi` | float | light | read | `0` | Bleed duct pressure, side 2 (psi) |
| `bleed.side2TempC` | float | light | read | `0` | Bleed temperature, side 2 (°C) |
| `bleed.xBleedValve` | float | light | read | `0` | Crossbleed valve position (0 closed .. 1 open) |
| `press.activeSystem` | int | light | read | `0` | Active pressurization system (1, 2; 0 = MAN) |
| `press.cabinAltitudeFt` | float | light | read | `0` | Cabin altitude (ft) |
| `press.cabinVsFpm` | float | light | read | `0` | Cabin vertical speed (ft/min) |
| `press.deltaPPsi` | float | light | read | `0` | Cabin differential pressure (psi) |
| `press.mode` | int | light | read | `0` | CPC mode (0 GN, 1 TO, 2 CL, 3 CR, 4 DE, 5 AB) |
| `press.outflowValve` | float | light | read | `0` | Outflow valve position (0 closed .. 1 open) |

## Aircraft

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `aircraft.catalogCount` | int | output | read | `0` | Installed variant / livery combinations the simulator reported |
| `aircraft.catalogRevision` | int | output | read | `0` | Raised by every new catalog of installed variants and liveries from the simulator (the IOS fetches it again) |
| `aircraft.changing` | bool | output | read | `0` | An aircraft variant / livery change is under way (until the simulator shows it loaded or refuses it) |
| `aircraft.draims` | bool | output | read | `0` | Cockpit radio / audio equipment of the loaded variant: 1 = DRAIMS (aural alerts in the headsets too; Displays shows the DRAIMS panels), 0 = classic RMPs, ACPs and ATC/TCAS panel (aural alerts on the loudspeakers only) |
| `aircraft.engineType` | int | output | read | `0` | Engine type of the loaded variant (1 = CFM56-5B, 2 = IAE V2500-A5), from the simulator model |
| `aircraft.livery` | string | output | read | `""` | Livery the simulator has loaded (its folder in the aircraft's liveries/; empty: the variant's own paint) |
| `aircraft.liveryName` | string | output | read | `""` | Name of the loaded livery (its nvan-livery.json name, else the folder name; Default: the variant's own paint) |
| `aircraft.registration` | string | output | read | `""` | Registration of the loaded model (its .model.json next to the .acf; empty: not given) |
| `aircraft.selcal` | string | output | read | `""` | SELCAL code of the loaded model (four tone letters A..S without I, N, O, e.g. ABCD; empty: no SELCAL) |
| `aircraft.variant` | string | output | read | `""` | Variant the simulator has loaded (its .acf name without .acf, e.g. A320ceo_CFM; empty: not known yet) |
| `aircraft.variantName` | string | output | read | `""` | Name of the loaded variant (e.g. A320ceo CFM56-5B4) |

## Aircraft (sound sources)

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `aircond.cabinFans.running` | bool | output | read | `0` | Cabin recirculation fans running |
| `aircraft.groundSpeedKt` | float | output | read | `0` | Ground speed (kt, simulator truth) |
| `aircraft.iasKt` | float | output | read | `0` | Indicated airspeed (kt, simulator truth) |
| `aircraft.verticalSpeedFpm` | float | output | read | `0` | Vertical speed (ft/min, simulator truth) |
| `engine1.ignition` | bool | output | read | `0` | Engine 1 igniter A or B sparking |
| `engine1.n1` | float | output | read | `0` | Engine 1 N1 (%) |
| `engine1.n2` | float | output | read | `0` | Engine 1 N2 (%) |
| `engine1.reverser` | float | output | read | `0` | Engine 1 thrust reverser position (0 stowed .. 1 deployed) |
| `engine1.stallBangs` | float | output | read | `0` | Engine 1 compressor surges (a counter: each step is one bang) |
| `engine1.starter` | bool | output | read | `0` | Engine 1 air starter turning the engine |
| `engine2.ignition` | bool | output | read | `0` | Engine 2 igniter A or B sparking |
| `engine2.n1` | float | output | read | `0` | Engine 2 N1 (%) |
| `engine2.n2` | float | output | read | `0` | Engine 2 N2 (%) |
| `engine2.reverser` | float | output | read | `0` | Engine 2 thrust reverser position (0 stowed .. 1 deployed) |
| `engine2.stallBangs` | float | output | read | `0` | Engine 2 compressor surges (a counter: each step is one bang) |
| `engine2.starter` | bool | output | read | `0` | Engine 2 air starter turning the engine |
| `hyd.blueElecPump.running` | bool | output | read | `0` | Blue electric pump running |
| `hyd.ptu.deltaPsi` | float | output | read | `0` | Pressure difference between the green and yellow systems across the PTU (psi, absolute) |
| `hyd.ptu.running` | bool | output | read | `0` | PTU running (transferring power between green and yellow) |
| `hyd.yellowElecPump.running` | bool | output | read | `0` | Yellow electric pump running |
| `vent.blower.running` | bool | output | read | `0` | Avionics ventilation blower fan running |
| `vent.extract.running` | bool | output | read | `0` | Avionics ventilation extract fan running |

## Aircraft options

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `ddrmi.vorOnly` | bool | service | write | `0` | DDRMI type (aircraft option saved in systems.json): 0 = VOR/ADF (selectors for each pointer), 1 = VOR-only (both pointers always VOR 1 / VOR 2, no selectors) |
| `efis.qfe.installed` | bool | service | write | `0` | QFE BARO setting option (aircraft option saved in systems.json, off by default): the BARO knob push alternates QNH and QFE; PFD "QFE" and heights above the field; FMGC and EGPWS QFE pin program |
| `elec.acEssFeedAuto` | bool | service | write | `0` | AC ESS FEED auto switching (aircraft option saved in systems.json): 1 = installed (AC BUS 2 supplies the AC ESS BUS automatically when AC BUS 1 is lost), 0 = not installed (the crew selects AC ESS FEED ALTN) |
| `overhead.adirs.cdu.installed` | bool | service | write | `0` | ADIRS panel variant (aircraft option saved in systems.json): 0 = the panel without CDU (2019 FCOM: IR pbs FAULT/OFF), 1 = the older panel with the ADIRS CDU (2006 FCOM 1.34.10: display, DATA and SYS selectors, keyboard, IR lights FAULT/ALIGN) |
| `radio.gls.installed` | bool | service | write | `0` | GLS (GBAS landing system) installed (aircraft option saved in systems.json, off by default: not on the aircraft of the 2019 FCOM): MMR GLS channels, GLS approaches with LOC / G/S and the FMA AUTOLAND capability |
| `wheel.tpis.installed` | bool | service | write | `0` | Tire pressure indicating system installed (aircraft option saved in systems.json): WHEEL page tire pressures, WHEEL TYRE LO PR |

## APU (indications)

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `apu.avail` | bool | light | read | `0` | APU AVAIL |
| `apu.coolingLeftS` | float | light | read | `0` | Cooling period left after MASTER SW OFF (s) |
| `apu.egtC` | float | light | read | `0` | APU EGT (°C) |
| `apu.egtMaxC` | float | light | read | `0` | EGT max computed by the ECB (°C): APU page red mark, amber mark 33 °C below |
| `apu.fault` | bool | light | read | `0` | Automatic shutdown (MASTER SW FAULT) |
| `apu.flap` | float | light | read | `0` | Air intake flap position (0 closed .. 1 open) |
| `apu.fuelFlowKgH` | float | light | read | `0` | APU fuel flow (kg/h, from the left feed line) |
| `apu.fuelLowPressure` | bool | light | read | `0` | APU fuel low pressure |
| `apu.fuelPump` | bool | light | read | `0` | APU fuel pump running |
| `apu.ignition` | bool | light | read | `0` | Ignition on |
| `apu.n` | float | light | read | `0` | APU speed N (%) |
| `apu.phase` | int | light | read | `0` | ECB sequence (0 off, 1 starting, 2 running, 3 cooling, 4 stopping) |
| `apu.shutdownCause` | int | light | read | `0` | Last automatic shutdown cause (0 none, 1 fire, 2 flap not open, 3 overspeed, 4 no acceleration, 5 slow start, 6 EGT, 7 no flame, 8 underspeed, 9 reverse flow, 10 low oil pressure, 11 high oil temperature, 12 DC power loss, 13 ECB failure, 14 loss of overspeed protection, 15 emergency shutdown, 16 overcurrent, 17 sensor failure, 18 IGV failure, 19 no speed, 20 oil system, 21 inlet overheat, 22 clogged oil filter, 23 loss of EGT thermocouples) |
| `apu.starter` | bool | light | read | `0` | Starter energized (DC BAT BUS) |

## ATSU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `atsu.atc.aural` | bool | output | read | `0` | ATC message aural alert (on until the ATC MSG pushbutton is pressed) |
| `atsu.atc.connected` | bool | output | read | `0` | CPDLC: connected to a current ATC unit |
| `atsu.atc.current` | string | output | read | `""` | CPDLC: the current ATC unit ("" none) |
| `atsu.atc.instructorUplink` | string | service | write | `"TEXT"` | Instructor: write "TEXT" (from the current ATC unit) or "STATION/RA/TEXT" (RA WU, AN, R, Y, NE; "@" around the parameters, e.g. "EDYY/WU/CLIMB TO @FL350@") to receive it as a CPDLC uplink (written back to "") |
| `atsu.atc.next` | string | output | read | `""` | CPDLC: the next ATC unit ("" none) |
| `atsu.companyMsg` | bool | output | read | `0` | COMPANY MSG memo: a received AOC message not displayed yet |
| `atsu.unread` | int | output | read | `0` | Received AOC messages never displayed |

## Audio management (AMU)

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `amu.auralsInHeadset` | bool | output | read | `0` | Aural alerts also in the crew headsets (the loaded variant has DRAIMS, aircraft.draims; classic RMP / ACP aircraft: loudspeakers only) |
| `amu.capt.acp` | int | output | read | `0` | Captain: ACP in use (1..3; 0 = none: ACP 3 taken by AUDIO SWITCHING) |
| `amu.capt.adf1` | float | output | read | `0` | Captain headset: ADF 1 reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.capt.adf2` | float | output | read | `0` | Captain headset: ADF 2 reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.capt.cab` | float | output | read | `0` | Captain headset: CAB reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.capt.hf1` | float | output | read | `0` | Captain headset: HF 1 reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.capt.hf2` | float | output | read | `0` | Captain headset: HF 2 reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.capt.int` | float | output | read | `0` | Captain headset: INT reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.capt.ls` | float | output | read | `0` | Captain headset: LS reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.capt.maskFlow` | float | output | read | `0` | Captain oxygen flow noise picked up by the mask microphone (0..1; only with the mask microphone selected) |
| `amu.capt.mic` | int | output | read | `0` | Captain: microphone destination (0 none, 1..3 VHF n, 4..5 HF n, 6 INT, 7 CAB, 8 PA) |
| `amu.capt.micMask` | bool | output | read | `0` | Captain station microphone: 1 = the oxygen mask microphone (mask out, until RESET), 0 = the boom microphone |
| `amu.capt.mkr` | float | output | read | `0` | Captain headset: MKR reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.capt.mls` | float | output | read | `0` | Captain headset: MLS reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.capt.ok` | bool | output | read | `0` | Captain: audio channel working (ACP and AMU card) |
| `amu.capt.pa` | float | output | read | `0` | Captain headset: PA reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.capt.side` | int | output | read | `0` | Captain: onside LS / MKR receivers of its ACP (1 or 2; 0 = no ACP) |
| `amu.capt.vhf1` | float | output | read | `0` | Captain headset: VHF 1 reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.capt.vhf2` | float | output | read | `0` | Captain headset: VHF 2 reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.capt.vhf3` | float | output | read | `0` | Captain headset: VHF 3 reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.capt.voice` | bool | output | read | `0` | Captain: VOICE filter (navaid idents filtered out) |
| `amu.capt.vor1` | float | output | read | `0` | Captain headset: VOR 1 reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.capt.vor2` | float | output | read | `0` | Captain headset: VOR 2 reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.fo.acp` | int | output | read | `0` | F/O: ACP in use (1..3; 0 = none: ACP 3 taken by AUDIO SWITCHING) |
| `amu.fo.adf1` | float | output | read | `0` | F/O headset: ADF 1 reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.fo.adf2` | float | output | read | `0` | F/O headset: ADF 2 reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.fo.cab` | float | output | read | `0` | F/O headset: CAB reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.fo.hf1` | float | output | read | `0` | F/O headset: HF 1 reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.fo.hf2` | float | output | read | `0` | F/O headset: HF 2 reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.fo.int` | float | output | read | `0` | F/O headset: INT reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.fo.ls` | float | output | read | `0` | F/O headset: LS reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.fo.maskFlow` | float | output | read | `0` | First officer oxygen flow noise picked up by the mask microphone (0..1; only with the mask microphone selected) |
| `amu.fo.mic` | int | output | read | `0` | F/O: microphone destination (0 none, 1..3 VHF n, 4..5 HF n, 6 INT, 7 CAB, 8 PA) |
| `amu.fo.micMask` | bool | output | read | `0` | First officer station microphone: 1 = the oxygen mask microphone (mask out, until RESET), 0 = the boom microphone |
| `amu.fo.mkr` | float | output | read | `0` | F/O headset: MKR reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.fo.mls` | float | output | read | `0` | F/O headset: MLS reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.fo.ok` | bool | output | read | `0` | F/O: audio channel working (ACP and AMU card) |
| `amu.fo.pa` | float | output | read | `0` | F/O headset: PA reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.fo.side` | int | output | read | `0` | F/O: onside LS / MKR receivers of its ACP (1 or 2; 0 = no ACP) |
| `amu.fo.vhf1` | float | output | read | `0` | F/O headset: VHF 1 reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.fo.vhf2` | float | output | read | `0` | F/O headset: VHF 2 reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.fo.vhf3` | float | output | read | `0` | F/O headset: VHF 3 reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.fo.voice` | bool | output | read | `0` | F/O: VOICE filter (navaid idents filtered out) |
| `amu.fo.vor1` | float | output | read | `0` | F/O headset: VOR 1 reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.fo.vor2` | float | output | read | `0` | F/O headset: VOR 2 reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.loudspeaker.capt` | float | output | read | `0` | Captain loudspeaker gain (knob × supply; plays the captain's selected radio, navaid and INT receptions) |
| `amu.loudspeaker.fo` | float | output | read | `0` | F/O loudspeaker gain (knob × supply; plays the F/O's selected radio, navaid and INT receptions) |
| `amu.mech.int` | float | output | read | `0` | Ground mechanic (external power panel jack): interphone available (1) or not (0) |
| `amu.obs.acp` | int | output | read | `0` | Third occupant: ACP in use (1..3; 0 = none: ACP 3 taken by AUDIO SWITCHING) |
| `amu.obs.adf1` | float | output | read | `0` | Third occupant headset: ADF 1 reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.obs.adf2` | float | output | read | `0` | Third occupant headset: ADF 2 reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.obs.cab` | float | output | read | `0` | Third occupant headset: CAB reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.obs.hf1` | float | output | read | `0` | Third occupant headset: HF 1 reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.obs.hf2` | float | output | read | `0` | Third occupant headset: HF 2 reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.obs.int` | float | output | read | `0` | Third occupant headset: INT reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.obs.ls` | float | output | read | `0` | Third occupant headset: LS reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.obs.maskFlow` | float | output | read | `0` | Third occupant oxygen flow noise picked up by the mask microphone (0..1; only with the mask microphone selected) |
| `amu.obs.mic` | int | output | read | `0` | Third occupant: microphone destination (0 none, 1..3 VHF n, 4..5 HF n, 6 INT, 7 CAB, 8 PA) |
| `amu.obs.micMask` | bool | output | read | `0` | Third occupant station microphone: 1 = the oxygen mask microphone (mask out, until RESET), 0 = the boom microphone |
| `amu.obs.mkr` | float | output | read | `0` | Third occupant headset: MKR reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.obs.mls` | float | output | read | `0` | Third occupant headset: MLS reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.obs.ok` | bool | output | read | `0` | Third occupant: audio channel working (ACP and AMU card) |
| `amu.obs.pa` | float | output | read | `0` | Third occupant headset: PA reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.obs.side` | int | output | read | `0` | Third occupant: onside LS / MKR receivers of its ACP (1 or 2; 0 = no ACP) |
| `amu.obs.vhf1` | float | output | read | `0` | Third occupant headset: VHF 1 reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.obs.vhf2` | float | output | read | `0` | Third occupant headset: VHF 2 reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.obs.vhf3` | float | output | read | `0` | Third occupant headset: VHF 3 reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.obs.voice` | bool | output | read | `0` | Third occupant: VOICE filter (navaid idents filtered out) |
| `amu.obs.vor1` | float | output | read | `0` | Third occupant headset: VOR 1 reception gain (0..1; 0 = not selected, lost or not received) |
| `amu.obs.vor2` | float | output | read | `0` | Third occupant headset: VOR 2 reception gain (0..1; 0 = not selected, lost or not received) |

## Cabin / PURSER panel

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `cabin.purser.lightEmer` | bool | pushbutton | write | `0` | LIGHT EMER pb on the purser's panel (1 = pressed) |

## CIDS / Cabin

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `cids.cabin.chime` | int | output | read | `0` | High-low chime in the cabin: call from the cockpit (counter, wraps at 65536) |
| `cids.cabin.emerChime` | int | output | read | `0` | High-low chime three times in the cabin: emergency call from the cockpit (counter, wraps at 65536) |
| `cids.cabin.evacTone` | bool | output | read | `0` | Evacuation tone sounding in the cabin |
| `cids.cabin.exit` | bool | output | read | `0` | EXIT signs lit in the cabin |
| `cids.cabin.mainLights` | float | output | read | `0` | Cabin main lights (0 off .. 1 bright; placeholder) |
| `cids.cabin.noSmoking` | bool | output | read | `0` | NO SMOKING signs lit in the cabin |
| `cids.cabin.oxygenAnnouncement` | bool | output | read | `0` | Prerecorded oxygen mask announcement playing on the PA (passenger oxygen masks released) |
| `cids.cabin.readingLights` | bool | output | read | `0` | Passenger reading lights available (placeholder) |
| `cids.cabin.seatBelts` | bool | output | read | `0` | FASTEN SEAT BELT / RETURN TO SEAT signs lit in the cabin |
| `cids.cabin.signChime` | int | output | read | `0` | Low chime in the cabin: a sign went on or off (counter, wraps at 65536) |
| `cids.cockpit.evacHorn` | bool | output | read | `0` | EVAC horn sounding in the cockpit |
| `cids.paInUse` | bool | output | read | `0` | PA in use (PA IN USE light) |

## CIDS / FAP (cabin)

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `cids.fap.activeDirector` | int | output | read | `0` | Active CIDS director (0 none, 1, 2) |
| `cids.fap.cabinReady` | bool | switch | write | `0` | CABIN READY set on the FAP (the CIDS resets it at lift-off and touchdown) |
| `cids.fap.callCockpit` | bool | pushbutton | momentary | `0` | Attendant CAPT key: call the cockpit (1 = pressed) |
| `cids.fap.captainCallAft` | bool | output | read | `0` | "CAPTAIN CALL" on the aft attendant indication panel (until hang-up) |
| `cids.fap.captainCallFwd` | bool | output | read | `0` | "CAPTAIN CALL" on the forward attendant indication panel (until hang-up) |
| `cids.fap.emerCallCockpit` | bool | pushbutton | momentary | `0` | Attendant EMER CALL key: emergency call to the cockpit (1 = pressed) |
| `cids.fap.emerCallToCockpitActive` | bool | output | read | `0` | The cabin's emergency call to the cockpit is active (until hang-up) |
| `cids.fap.emergencyCall` | bool | output | read | `0` | "EMERGENCY CALL" from the cockpit on every attendant indication panel (until hang-up) |
| `cids.fap.evac` | bool | output | read | `0` | Evacuation alert active (EVAC lights flash at the FWD / AFT attendant panels) |
| `cids.fap.evacCommand` | bool | pushbutton | momentary | `0` | Attendant EVAC CMD pb (starts / stops the alert with CAPT & PURS; 1 = pressed) |
| `cids.fap.evacReset` | bool | pushbutton | momentary | `0` | Attendant EVAC RESET pb: silences the evacuation tone (1 = pressed) |
| `cids.fap.hangUp` | bool | pushbutton | momentary | `0` | Attendant handset hung up: resets the call indications (1 = pressed) |
| `cids.fap.mainLights` | int | rotary | write | `0` | Cabin main lights (0 OFF, 1 DIM 2, 2 DIM 1, 3 BRT; placeholder) |
| `cids.fap.operative` | bool | output | read | `0` | CIDS working (a director active): the FAP has data |
| `cids.fap.paInUse` | bool | switch | write | `0` | An attendant (or a prerecorded announcement) uses the PA |
| `cids.fap.readingLights` | bool | switch | write | `0` | Passenger reading lights enabled (placeholder) |
| `cids.fap.tempTrimAft` | float | analog | write | `0` | FAP cabin temperature control, AFT CABIN zone: offset to the cockpit selection (°C, -2.5..+2.5; reset to 0 when the CIDS is lost) |
| `cids.fap.tempTrimFwd` | float | analog | write | `0` | FAP cabin temperature control, FWD CABIN zone: offset to the cockpit selection (°C, -2.5..+2.5; reset to 0 when the CIDS is lost) |
| `cids.fap.waste.levelPct` | float | output | read | `0` | Waste tank level on the FAP (%, -1 = not available) |
| `cids.fap.waste.tankFull` | bool | output | read | `0` | Waste tank full (toilets inoperative) |
| `cids.fap.waste.vscFault` | bool | output | read | `0` | Vacuum system controller fault reported |
| `cids.fap.water.indicationFault` | bool | output | read | `0` | Water quantity indication fault |
| `cids.fap.water.quantityPct` | float | output | read | `0` | Potable water quantity on the FAP (%, -1 = not available) |

## Circuit breakers / 105VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `cb.105vu.12pb1` | bool | switch | write | `0` | C/B 12PB1 ELEC HOT BUS 701PP SPLY (105VU 25, monitored): 1 = out (pulled or tripped) |
| `cb.105vu.12pb2` | bool | switch | write | `0` | C/B 12PB2 ELEC HOT BUS 702PP SPLY (105VU 15, monitored): 1 = out (pulled or tripped) |
| `cb.105vu.12xb` | bool | switch | write | `0` | C/B 12XB ELEC STAT INV BUS SPLY (105VU 18, monitored): 1 = out (pulled or tripped) |
| `cb.105vu.14xb` | bool | switch | write | `0` | C/B 14XB ELEC STAT INV CNTOR CTL (105VU 17, monitored): 1 = out (pulled or tripped) |
| `cb.105vu.16ce1` | bool | switch | write | `0` | C/B 16CE1 FLT CTL ELAC 1 STBY SPLY (105VU 21, monitored): 1 = out (pulled or tripped) |
| `cb.105vu.16ce2` | bool | switch | write | `0` | C/B 16CE2 FLT CTL ELAC 2 STBY SPLY (105VU 11, monitored): 1 = out (pulled or tripped) |
| `cb.105vu.22ce` | bool | switch | write | `0` | C/B 22CE FLT CTL SEC 1 STBY SPLY (105VU 22, monitored): 1 = out (pulled or tripped) |
| `cb.105vu.23fn` | bool | switch | write | `0` | C/B 23FN NAV STBY INST BAT (105VU 28, monitored): 1 = out (pulled or tripped) |
| `cb.105vu.5pb1` | bool | switch | write | `0` | C/B 5PB1 ELEC HOT BUS 701PP SPLY (105VU 24, monitored): 1 = out (pulled or tripped) |
| `cb.105vu.5pb2` | bool | switch | write | `0` | C/B 5PB2 ELEC HOT BUS 702PP SPLY (105VU 14, monitored): 1 = out (pulled or tripped) |
| `cb.105vu.6fp1` | bool | switch | write | `0` | C/B 6FP1 ADIRS ADIRU 1 28VDC (105VU 13, monitored): 1 = out (pulled or tripped) |
| `cb.105vu.7xe` | bool | switch | write | `0` | C/B 7XE ELEC CSM/G EV AUTO SPLY (105VU 23, monitored): 1 = out (pulled or tripped) |
| `cb.105vu.8pb1` | bool | switch | write | `0` | C/B 8PB1 ELEC BAT BUS REF BCL 1 (105VU 27, monitored): 1 = out (pulled or tripped) |
| `cb.105vu.8pb2` | bool | switch | write | `0` | C/B 8PB2 ELEC BAT BUS REF BCL 2 (105VU 19, monitored): 1 = out (pulled or tripped) |
| `cb.105vu.9pb1` | bool | switch | write | `0` | C/B 9PB1 ELEC BAT REF BCL 1 (105VU 26, monitored): 1 = out (pulled or tripped) |
| `cb.105vu.9pb2` | bool | switch | write | `0` | C/B 9PB2 ELEC BAT REF BCL 2 (105VU 16, monitored): 1 = out (pulled or tripped) |

## Circuit breakers / 106VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `cb.106vu.10xe` | bool | switch | write | `0` | C/B 10XE ELEC AC ESS EMER STBY CNTOR (106VU 23, monitored): 1 = out (pulled or tripped) |
| `cb.106vu.15pc` | bool | switch | write | `0` | C/B 15PC ELEC AC ESS BUS EMER CNTOR (106VU 21, monitored): 1 = out (pulled or tripped) |
| `cb.106vu.1ph` | bool | switch | write | `0` | C/B 1PH ELEC EMER SHED CNTOR SPLY (106VU 22, monitored): 1 = out (pulled or tripped) |
| `cb.106vu.1xh` | bool | switch | write | `0` | C/B 1XH ELEC AC SHED ESS CNTOR CTL (106VU 25, monitored): 1 = out (pulled or tripped) |
| `cb.106vu.27wv` | bool | switch | write | `0` | C/B 27WV ELEC EMER GEN REF (106VU 14, monitored): 1 = out (pulled or tripped) |
| `cb.106vu.2xh` | bool | switch | write | `0` | C/B 2XH ELEC AC ESS BUS MONG SPLY (106VU 24, monitored): 1 = out (pulled or tripped) |
| `cb.106vu.4pe` | bool | switch | write | `0` | C/B 4PE ELEC ESS TR SPLY (106VU 28, monitored): 1 = out (pulled or tripped) |
| `cb.106vu.4xc` | bool | switch | write | `0` | C/B 4XC ELEC AC ESS BUS NORM CNTOR (106VU 16, monitored): 1 = out (pulled or tripped) |
| `cb.106vu.4xh` | bool | switch | write | `0` | C/B 4XH ELEC 26VAC ESS BUS SPLY (106VU 13, monitored): 1 = out (pulled or tripped) |
| `cb.106vu.5pe` | bool | switch | write | `0` | C/B 5PE ELEC ESS TR CNTOR CTL (106VU 27, monitored): 1 = out (pulled or tripped) |
| `cb.106vu.5xc` | bool | switch | write | `0` | C/B 5XC ELEC AC ESS BUS STBY CNTOR (106VU 11, monitored): 1 = out (pulled or tripped) |
| `cb.106vu.5xe` | bool | switch | write | `0` | C/B 5XE ELEC AC ESS BUS EMER CNTOR (106VU 12, monitored): 1 = out (pulled or tripped) |
| `cb.106vu.68wv` | bool | switch | write | `0` | C/B 68WV ELEC DC BUS 1&2 MONG (106VU 26, monitored): 1 = out (pulled or tripped) |
| `cb.106vu.6xe` | bool | switch | write | `0` | C/B 6XE ELEC CSM/G EV MAN SPLY (106VU 15, monitored): 1 = out (pulled or tripped) |

## Circuit breakers / 121VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `cb.121vu.10ca2` | bool | switch | write | `0` | C/B 10CA2 AUTO FLT FMGC 2 (121VU M17, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.10fp` | bool | switch | write | `0` | C/B 10FP ADIRS ADIRU 2 PWR SHED (121VU N11, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.10qa` | bool | switch | write | `0` | C/B 10QA FUEL PUMPS 2 R CTL & L IND (121VU R29, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.10tw` | bool | switch | write | `0` | C/B 10TW CFDS TEST PLUG 2 (121VU J20, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.10wt2` | bool | switch | write | `0` | C/B 10WT2 EIS DMC 2 SPLY (121VU Q8, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.10wt3` | bool | switch | write | `0` | C/B 10WT3 EIS DMC 3 SPLY (121VU Q9, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.10wv` | bool | switch | write | `0` | C/B 10WV SDAC 26VAC SYNC AC BUS 1 (121VU Q5, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.110gg` | bool | switch | write | `0` | C/B 110GG BRAKES ABCU HOT BUS SPLY (121VU P30, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.11ca2` | bool | switch | write | `0` | C/B 11CA2 AUTO FLT MCDU 2 (121VU N20, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.11ca3` | bool | switch | write | `0` | C/B 11CA3 AUTO FLT MCDU 2 SPLY 2 (121VU N21, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.11cv` | bool | switch | write | `0` | C/B 11CV FLIGHT CONTROLS WTB SLT SYS 2 (121VU P19, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.11wt2` | bool | switch | write | `0` | C/B 11WT2 EIS PFD F/O SPLY (121VU R3, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.12cv` | bool | switch | write | `0` | C/B 12CV FLIGHT CONTROLS WTB FLP SYS 2 (121VU P20, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.12wt2` | bool | switch | write | `0` | C/B 12WT2 EIS ND F/O SPLY (121VU R4, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.13ca` | bool | switch | write | `0` | C/B 13CA AUTO FLT STICK LOCK (121VU N16, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.13wn` | bool | switch | write | `0` | C/B 13WN SLIDES ARM & WARN GND (121VU P10, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.13wt2` | bool | switch | write | `0` | C/B 13WT2 EIS ECAM LOWER SPLY (121VU R11, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.14ca` | bool | switch | write | `0` | C/B 14CA AUTO FLT RUDDER ARTF FEEL (121VU N17, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.14cc2` | bool | switch | write | `0` | C/B 14CC2 AUTO FLT FAC 2 26VAC (121VU M18, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.14fn` | bool | switch | write | `0` | C/B 14FN NAV 14FN (121VU K4, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.14wv` | bool | switch | write | `0` | C/B 14WV SDAC 1 & 2 BUS 1 28VDC (121VU P4, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.151rh` | bool | switch | write | `0` | C/B 151RH COM CIDS DIR/ NORM 1 (121VU M5, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.156rh` | bool | switch | write | `0` | C/B 156RH COM CIDS DIR/ NORM 2 (121VU M6, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.15cc` | bool | switch | write | `0` | C/B 15CC AUTO FLT RUDDER TRIM IND (121VU M20, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.15ce2` | bool | switch | write | `0` | C/B 15CE2 FLIGHT CONTROLS ELAC 2 NORM SPLY (121VU R20, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.15wn` | bool | switch | write | `0` | C/B 15WN SLIDES ARM & WARN FLT (121VU P11, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.161rh` | bool | switch | write | `0` | C/B 161RH COM PROG & TST PNL (121VU M7, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.162rh` | bool | switch | write | `0` | C/B 162RH COM DEU B NORM (121VU M8, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.163rh` | bool | switch | write | `0` | C/B 163RH COM DEU A L FWD (121VU M9, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.164rh` | bool | switch | write | `0` | C/B 164RH COM DEU A R FWD (121VU M10, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.165rh` | bool | switch | write | `0` | C/B 165RH COM DEU A L MID (121VU M11, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.166rh` | bool | switch | write | `0` | C/B 166RH COM DEU A R MID (121VU M12, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.167rh` | bool | switch | write | `0` | C/B 167RH COM DEU A L AFT (121VU M13, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.168rh` | bool | switch | write | `0` | C/B 168RH COM DEU A R AFT (121VU M14, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1701gk` | bool | switch | write | `0` | C/B 1701GK HYDRAULIC G HYD PUMP ENG1 CTL (121VU R35, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1702gk` | bool | switch | write | `0` | C/B 1702GK HYDRAULIC G HYD PUMP ENG1 MONG (121VU R34, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.170rh` | bool | switch | write | `0` | C/B 170RH COM FWD ATTND PNL (121VU Q14, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.17wt2` | bool | switch | write | `0` | C/B 17WT2 EIS RLY BOX F/O (121VU R7, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1801gl` | bool | switch | write | `0` | C/B 1801GL HYDRAULIC SOL VALVES G/Y PTU (121VU N34, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1831gq` | bool | switch | write | `0` | C/B 1831GQ HYDRAULIC HYD QTY IND (121VU P35, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1832gq` | bool | switch | write | `0` | C/B 1832GQ HYDRAULIC LOW LVL IND (121VU N32, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1881gp` | bool | switch | write | `0` | C/B 1881GP HYDRAULIC SOL VALVES G/Y/B LEAK TST (121VU N35, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.19ce1` | bool | switch | write | `0` | C/B 19CE1 FLIGHT CONTROLS THS ACTR MOT 1 (121VU Q16, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.19ce3` | bool | switch | write | `0` | C/B 19CE3 FLIGHT CONTROLS THS ACTR MOT 3 (121VU Q17, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1eg1` | bool | switch | write | `0` | C/B 1EG1 ENGINE ENG1 REV LOCK (121VU N44, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1eg2` | bool | switch | write | `0` | C/B 1EG2 ENGINE ENG2 REV LOCK (121VU N45, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1en1` | bool | switch | write | `0` | C/B 1EN1 ENGINE ENG1 OIL QTY & REV SNSR B (121VU N39, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1en2` | bool | switch | write | `0` | C/B 1EN2 ENGINE ENG2 OIL QTY & REV SNSR B (121VU N41, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1ev` | bool | switch | write | `0` | C/B 1EV ENGINE ENG1&2 EVMU (121VU R44, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1gg` | bool | switch | write | `0` | C/B 1GG BRAKING & STEERING SYS1 CTL (121VU M34, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1gs` | bool | switch | write | `0` | C/B 1GS BRAKES BRK FAN WHEELS 1&2 (121VU L32, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1gv` | bool | switch | write | `0` | C/B 1GV BRAKES TYRE PRESS (121VU M31, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1gw` | bool | switch | write | `0` | C/B 1GW BRAKES BRK TEMP DET UNIT (121VU M37, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1kd` | bool | switch | write | `0` | C/B 1KD APU ECB SPLY (121VU L41, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1kt` | bool | switch | write | `0` | C/B 1KT APU APU OIL OIL HTR SPLY (121VU K41, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1qa` | bool | switch | write | `0` | C/B 1QA FUEL L WING TK PUMP1 SPLY (121VU N23, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1qc` | bool | switch | write | `0` | C/B 1QC APU FUEL BLOW OFF CTL (121VU K39, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1qe` | bool | switch | write | `0` | C/B 1QE FUEL X FEED VALVE MOT2 (121VU M24, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1qf` | bool | switch | write | `0` | C/B 1QF APU FUEL LP VALVE CTL (121VU M40, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1qj` | bool | switch | write | `0` | C/B 1QJ FUEL HI LVL SPLY (121VU L25, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1qu` | bool | switch | write | `0` | C/B 1QU FUEL RFL/DFL XFR DEFUEL VALVE (121VU L23, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1re2` | bool | switch | write | `0` | C/B 1RE2 COM HF 2 (121VU L13, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1rp2` | bool | switch | write | `0` | C/B 1RP2 NAV ADF 2 (121VU K2, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1rt2` | bool | switch | write | `0` | C/B 1RT2 NAV ILS 2 (121VU K9, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1sa1` | bool | switch | write | `0` | C/B 1SA1 NAV RAD ALTM 1 (121VU K11, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1sa2` | bool | switch | write | `0` | C/B 1SA2 NAV RAD ALTM 2 (121VU K12, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1sd2` | bool | switch | write | `0` | C/B 1SD2 NAV DME 2 (121VU K6, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1we1` | bool | switch | write | `0` | C/B 1WE1 ENGINE FIRE EXTIG BTL1 SQUIB A (121VU Q43, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1we2` | bool | switch | write | `0` | C/B 1WE2 ENGINE FIRE EXTIG BTL2 SQUIB A (121VU Q41, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1wf` | bool | switch | write | `0` | C/B 1WF APU FIRE EXTIG SQUIB A (121VU L38, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.1wg` | bool | switch | write | `0` | C/B 1WG APU FIRE & OVHT DET LOOP A (121VU L43, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.20ce2` | bool | switch | write | `0` | C/B 20CE2 FLIGHT CONTROLS FCDC 2 SPLY (121VU Q20, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.21ce2` | bool | switch | write | `0` | C/B 21CE2 FLIGHT CONTROLS SEC 2 SPLY (121VU Q18, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.21ce3` | bool | switch | write | `0` | C/B 21CE3 FLIGHT CONTROLS SEC 3 SPLY (121VU Q19, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.21wt2` | bool | switch | write | `0` | C/B 21WT2 EIS DMC 2 SWTG (121VU R8, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.22wt2` | bool | switch | write | `0` | C/B 22WT2 EIS PFD F/O SWTG (121VU R5, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.23wt2` | bool | switch | write | `0` | C/B 23WT2 EIS ND F/O SWTG (121VU R6, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.24wt2` | bool | switch | write | `0` | C/B 24WT2 EIS ECAM LOWER SWTG (121VU R10, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.2803ge` | bool | switch | write | `0` | C/B 2803GE HYDRAULIC RAT EXTN SOL1 (121VU P33, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.29qa` | bool | switch | write | `0` | C/B 29QA FUEL CTR TK PUMP1 SPLY (121VU P23, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.2cn` | bool | switch | write | `0` | C/B 2CN FLIGHT CONTROLS SLT FLP 2 POS IND (121VU P16, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.2en1` | bool | switch | write | `0` | C/B 2EN1 ENGINE ENG1 OIL PRESS & REV SNSR A (121VU N40, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.2en2` | bool | switch | write | `0` | C/B 2EN2 ENGINE ENG2 OIL PRESS & REV SNSR A (121VU N42, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.2ga` | bool | switch | write | `0` | C/B 2GA L/G LGCIU SYS2 (121VU Q35, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.2gg` | bool | switch | write | `0` | C/B 2GG BRAKING & STEERING SYS1 IND & SPLY (121VU M33, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.2gs` | bool | switch | write | `0` | C/B 2GS BRAKES BRK FAN WHEELS 3&4 (121VU L35, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.2jh1` | bool | switch | write | `0` | C/B 2JH1 ENGINE IGN ENG1 SYS A BAT (121VU P39, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.2jh2` | bool | switch | write | `0` | C/B 2JH2 ENGINE IGN ENG2 SYS A BAT (121VU P40, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.2kd` | bool | switch | write | `0` | C/B 2KD APU APU CTL (121VU L42, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.2qa` | bool | switch | write | `0` | C/B 2QA FUEL R WING TK PUMP1 SPLY (121VU Q23, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.2qf` | bool | switch | write | `0` | C/B 2QF APU FUEL LP VALVE SPLY (121VU M39, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.2qt` | bool | switch | write | `0` | C/B 2QT FUEL FQI CHAN 2 (121VU M27, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.2qu` | bool | switch | write | `0` | C/B 2QU FUEL RFL/DFL SPLY (121VU L24, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.2rb` | bool | switch | write | `0` | C/B 2RB COM ACARS MU (121VU L6, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.2rc2` | bool | switch | write | `0` | C/B 2RC2 COM VHF 2 (121VU L4, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.2rc3` | bool | switch | write | `0` | C/B 2RC3 COM VHF 3 (121VU L5, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.2rg2` | bool | switch | write | `0` | C/B 2RG2 COM RMP 2 (121VU L2, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.2rg3` | bool | switch | write | `0` | C/B 2RG3 COM RMP 3 (121VU L3, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.2rs2` | bool | switch | write | `0` | C/B 2RS2 NAV VOR 2 (121VU K8, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.2tw` | bool | switch | write | `0` | C/B 2TW CFDS CFDIU SPLY (121VU J18, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.2wc` | bool | switch | write | `0` | C/B 2WC COM HORN SPLY (121VU P9, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.2we1` | bool | switch | write | `0` | C/B 2WE1 ENGINE FIRE EXTIG BTL1 SQUIB B (121VU Q44, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.2we2` | bool | switch | write | `0` | C/B 2WE2 ENGINE FIRE EXTIG BTL2 SQUIB B (121VU Q42, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.2wf` | bool | switch | write | `0` | C/B 2WF APU FIRE EXTIG SQUIB B (121VU L39, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.2wg` | bool | switch | write | `0` | C/B 2WG APU FIRE & OVHT DET LOOP B (121VU L44, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.2wv` | bool | switch | write | `0` | C/B 2WV SDAC 2 SPLY (121VU Q6, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.2ww` | bool | switch | write | `0` | C/B 2WW FWS FWC 2 SPLY (121VU Q7, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.2wz` | bool | switch | write | `0` | C/B 2WZ NAV GPWS 28VDC (121VU P6, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.30qa` | bool | switch | write | `0` | C/B 30QA FUEL CTR TK PUMP2 SPLY (121VU P26, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.30wf` | bool | switch | write | `0` | C/B 30WF APU AUTO EXTIG GND TEST (121VU L40, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.31qa` | bool | switch | write | `0` | C/B 31QA FUEL CTR TK PUMP 1 CTL & IND (121VU R25, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.32qa` | bool | switch | write | `0` | C/B 32QA FUEL CTR TK PUMP 2 CTL & IND (121VU R26, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.3700gd` | bool | switch | write | `0` | C/B 3700GD HYDRAULIC Y HYD PUMP ENG2 MONG (121VU Q37, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.3701gd` | bool | switch | write | `0` | C/B 3701GD HYDRAULIC Y HYD PUMP ENG2 CTL (121VU Q36, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.3803gx` | bool | switch | write | `0` | C/B 3803GX HYDRAULIC HYD POWER Y (121VU N30, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.3gg` | bool | switch | write | `0` | C/B 3GG BRAKING & STEERING SYS2 CTL (121VU M35, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.3gs` | bool | switch | write | `0` | C/B 3GS BRAKES BRK FAN CTL (121VU M32, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.3jh1` | bool | switch | write | `0` | C/B 3JH1 ENGINE IGN ENG1 SYS B (121VU P41, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.3jh2` | bool | switch | write | `0` | C/B 3JH2 ENGINE IGN ENG2 SYS B (121VU P42, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.3qa` | bool | switch | write | `0` | C/B 3QA FUEL PUMPS 1 L CTL & R IND (121VU R23, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.3qc` | bool | switch | write | `0` | C/B 3QC APU FUEL PUMP CTL (121VU M38, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.3qg` | bool | switch | write | `0` | C/B 3QG FUEL LP VALVE MOT2 ENG1 (121VU M25, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.3qp` | bool | switch | write | `0` | C/B 3QP FUEL XFR VALVE 2 WING L (121VU M22, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.3td` | bool | switch | write | `0` | C/B 3TD CFDS DATA LOADER SPLY (121VU J16, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.3tx1` | bool | switch | write | `0` | C/B 3TX1 ATSU ATSU 1 115VAC (121VU L16, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.3wf` | bool | switch | write | `0` | C/B 3WF APU FIRE STBY (121VU M41, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.3wz` | bool | switch | write | `0` | C/B 3WZ NAV GPWS 115VAC (121VU P7, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.44wv` | bool | switch | write | `0` | C/B 44WV SDAC 1 & 2 BUS 2 28VDC (121VU P3, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.46wv` | bool | switch | write | `0` | C/B 46WV SDAC 1 & 2 DOOR DET AVNCS (121VU P2, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.47qa` | bool | switch | write | `0` | C/B 47QA FUEL CTR TK AUTO CTL (121VU R27, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.48wv` | bool | switch | write | `0` | C/B 48WV SDAC 1 & 2 DOOR DET PAX (121VU P5, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.4fp2` | bool | switch | write | `0` | C/B 4FP2 ADIRS ADIRU 2 115VAC (121VU N7, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.4fp3` | bool | switch | write | `0` | C/B 4FP3 ADIRS ADIRU 3 115VAC (121VU N6, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.4fs` | bool | switch | write | `0` | C/B 4FS NAV CLOCK STBY SPLY (121VU N3, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.4gg` | bool | switch | write | `0` | C/B 4GG BRAKING & STEERING SYS2 SPLY (121VU M36, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.4ks1` | bool | switch | write | `0` | C/B 4KS1 ENGINE ENG1 FADEC B & EIU1 (121VU R41, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.4ks2` | bool | switch | write | `0` | C/B 4KS2 ENGINE ENG2 FADEC B & EIU2 (121VU Q40, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.4qa` | bool | switch | write | `0` | C/B 4QA FUEL PUMPS 1 R CTL & L IND (121VU R28, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.4qg` | bool | switch | write | `0` | C/B 4QG FUEL LP VALVE MOT2 ENG2 (121VU M26, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.4qp` | bool | switch | write | `0` | C/B 4QP FUEL XFR VALVE 2 WING R (121VU M23, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.4sg` | bool | switch | write | `0` | C/B 4SG NAV TCAS (121VU K10, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.4tv` | bool | switch | write | `0` | C/B 4TV AIDS DMU (121VU K15, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.4wf` | bool | switch | write | `0` | C/B 4WF APU FIRE NORM (121VU M42, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.4ww` | bool | switch | write | `0` | C/B 4WW COM F/O LOUD SPKR (121VU P8, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.52ga` | bool | switch | write | `0` | C/B 52GA L/G LGCIU SYS1 GND SPLY (121VU Q34, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.5cc2` | bool | switch | write | `0` | C/B 5CC2 AUTO FLT FAC 2 28VDC (121VU M19, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.5fp2` | bool | switch | write | `0` | C/B 5FP2 ADIRS ADIRU 2 26VAC & AOA (121VU N9, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.5fp3` | bool | switch | write | `0` | C/B 5FP3 ADIRS ADIRU 3 26VAC & AOA (121VU N8, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.5sh2` | bool | switch | write | `0` | C/B 5SH2 NAV ATC 2 (121VU K7, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.5sq1` | bool | switch | write | `0` | C/B 5SQ1 NAV RADAR 1 (121VU K13, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.5sq2` | bool | switch | write | `0` | C/B 5SQ2 NAV RADAR 2 (121VU K14, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.5tx1` | bool | switch | write | `0` | C/B 5TX1 ATSU ATSU 1 28VDC (121VU L15, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.6fp2` | bool | switch | write | `0` | C/B 6FP2 ADIRS ADIRU 2 28VDC (121VU N5, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.6fp3` | bool | switch | write | `0` | C/B 6FP3 ADIRS ADIRU 3 28VDC (121VU N4, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.6rn` | bool | switch | write | `0` | C/B 6RN COM ACP THIRD OCCPNT (121VU M2, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.6tw` | bool | switch | write | `0` | C/B 6TW CFDS PTR SPLY (121VU J21, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.6tx1` | bool | switch | write | `0` | C/B 6TX1 ATSU DCDU 1 (121VU L17, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.6tx2` | bool | switch | write | `0` | C/B 6TX2 ATSU DCDU 2 (121VU L18, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.70gg` | bool | switch | write | `0` | C/B 70GG HYDRAULIC PARK BRK CTL NORM (121VU N36, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.71gg` | bool | switch | write | `0` | C/B 71GG HYDRAULIC PARK BRK CTL STBY (121VU N37, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.7cv` | bool | switch | write | `0` | C/B 7CV FLIGHT CONTROLS SLT CTL SYS 2 (121VU R21, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.7qa` | bool | switch | write | `0` | C/B 7QA FUEL L WING TK PUMP2 SPLY (121VU N26, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.7rn` | bool | switch | write | `0` | C/B 7RN COM ACP AVNCS COMPT (121VU M3, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.7tu` | bool | switch | write | `0` | C/B 7TU RCDR DFDR (121VU K16, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.7wd2` | bool | switch | write | `0` | C/B 7WD2 ENGINE ENG2 FIRE DET LOOP A (121VU Q39, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.7wv` | bool | switch | write | `0` | C/B 7WV SDAC 26VAC SYNC AC BUS 2 (121VU Q3, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.8cv` | bool | switch | write | `0` | C/B 8CV FLIGHT CONTROLS FLP CTL & MONG SYS 2 (121VU Q21, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.8qa` | bool | switch | write | `0` | C/B 8QA FUEL R WING TK PUMP2 SPLY (121VU Q26, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.8qt` | bool | switch | write | `0` | C/B 8QT FUEL FQI CHAN 1&2 (121VU L26, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.8rn` | bool | switch | write | `0` | C/B 8RN COM SELCAL (121VU M4, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.8tu` | bool | switch | write | `0` | C/B 8TU RCDR FDIU & QAR (121VU K17, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.8tw` | bool | switch | write | `0` | C/B 8TW CFDS CFDIU BACK UP (121VU J17, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.8wd1` | bool | switch | write | `0` | C/B 8WD1 ENGINE ENG1 FIRE DET LOOP B (121VU Q38, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.8wv` | bool | switch | write | `0` | C/B 8WV SDAC 26VAC SYNC AC BUS 2 (121VU Q2, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.9ca2` | bool | switch | write | `0` | C/B 9CA2 AUTO FLT FCU 2 (121VU M21, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.9fp` | bool | switch | write | `0` | C/B 9FP ADIRS ADIRU 3 SWTG SPLY (121VU N10, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.9qa` | bool | switch | write | `0` | C/B 9QA FUEL PUMPS 2 L CTL & R IND (121VU R24, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.9tu` | bool | switch | write | `0` | C/B 9TU RCDR ACCLRM (121VU K18, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.9tw` | bool | switch | write | `0` | C/B 9TW CFDS TEST PLUG 1 (121VU J19, monitored): 1 = out (pulled or tripped) |
| `cb.121vu.9wv` | bool | switch | write | `0` | C/B 9WV SDAC 26VAC SYNC AC BUS 1 (121VU Q4, monitored): 1 = out (pulled or tripped) |

## Circuit breakers / 122VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `cb.122vu.10cv` | bool | switch | write | `0` | C/B 10CV FLT CTL WTB FLP SYS1 (122VU S7, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.10lv` | bool | switch | write | `0` | C/B 10LV STROBE WING STROBE (122VU V5, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.11da1` | bool | switch | write | `0` | C/B 11DA1 ANTI ICE P2/T2 ENG 1 (122VU Z10, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.11da2` | bool | switch | write | `0` | C/B 11DA2 ANTI ICE P2/T2 ENG 2 (122VU Y10, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.11hg` | bool | switch | write | `0` | C/B 11HG AIR COND RECIRC FAN R CTL (122VU W20, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.11ls` | bool | switch | write | `0` | C/B 11LS LIGHTING AVNCS COMPT OUT 28VDC (122VU Z8, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.11xe` | bool | switch | write | `0` | C/B 11XE ELEC EMER GEN AUTO 1 (122VU Z25, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.11xg` | bool | switch | write | `0` | C/B 11XG ELEC EXT PWR CTL (122VU X29, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.12ls` | bool | switch | write | `0` | C/B 12LS LIGHTING AVNCS COMPT OUT 115VAC (122VU Z9, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.12wq` | bool | switch | write | `0` | C/B 12WQ AIR COND SDCU CHAN2 (122VU T18, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.12xg` | bool | switch | write | `0` | C/B 12XG ELEC EXT PWR CKPT AVAIL LT (122VU X28, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.14pc` | bool | switch | write | `0` | C/B 14PC ELEC DC BUS TIE 1 FAULT (122VU U24, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.14xu` | bool | switch | write | `0` | C/B 14XU ELEC GEN 1 OFF BTC 2 (122VU T30, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.15xu` | bool | switch | write | `0` | C/B 15XU ELEC GEN 2 OFF BTC 1 SPLY (122VU T29, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.17xn1` | bool | switch | write | `0` | C/B 17XN1 ELEC AC BUS 1 CTL (122VU V25, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.17xn2` | bool | switch | write | `0` | C/B 17XN2 ELEC AC BUS 2 CTL (122VU V27, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.18pc` | bool | switch | write | `0` | C/B 18PC ELEC DC BUS TIE CONFIG (122VU W31, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.1da1` | bool | switch | write | `0` | C/B 1DA1 ANTI ICE TAT 1 (122VU Z12, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.1da2` | bool | switch | write | `0` | C/B 1DA2 ANTI ICE TAT 2 (122VU Y15, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.1db2` | bool | switch | write | `0` | C/B 1DB2 ANTI ICE RAIN RPLNT (122VU W11, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.1dn1` | bool | switch | write | `0` | C/B 1DN1 ANTI ICE ENG 1 (122VU X10, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.1dn2` | bool | switch | write | `0` | C/B 1DN2 ANTI ICE ENG 2 (122VU W10, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.1dr` | bool | switch | write | `0` | C/B 1DR ANTI ICE FOOT WARMER (122VU X15, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.1hg` | bool | switch | write | `0` | C/B 1HG AIR COND RECIRC FAN L SPLY (122VU X18, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.1hh` | bool | switch | write | `0` | C/B 1HH AIR COND PACK TEMP CTL SYS1 1 115VAC (122VU X22, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.1hk` | bool | switch | write | `0` | C/B 1HK AIR COND ZONE TEMP CTL 115VAC SYS1 (122VU V17, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.1hv` | bool | switch | write | `0` | C/B 1HV AIR BLEED X FEED VALVE NORM (122VU Z20, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.1la` | bool | switch | write | `0` | C/B 1LA NAV NAV1 LT (122VU T3, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.1lb` | bool | switch | write | `0` | C/B 1LB LANDING LT LDG LT L SPLY (122VU T4, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.1lc1` | bool | switch | write | `0` | C/B 1LC1 EXT LT RWY TURN OFF L (122VU W6, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.1lc2` | bool | switch | write | `0` | C/B 1LC2 EXT LT RWY TURN OFF R (122VU W5, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.1ll` | bool | switch | write | `0` | C/B 1LL LIGHTING WHL WELL LTG OUT (122VU X7, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.1lr` | bool | switch | write | `0` | C/B 1LR EXT LT TAXI & TAKE OFF TAXI (122VU W8, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.1ls` | bool | switch | write | `0` | C/B 1LS LIGHTING AVNCS COMPT DOME (122VU Z7, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.1lv` | bool | switch | write | `0` | C/B 1LV BEACON BEACON UPPER (122VU U6, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.1lx` | bool | switch | write | `0` | C/B 1LX EXT LT WING & ENG SCAN R (122VU W3, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.1ly` | bool | switch | write | `0` | C/B 1LY LOGO LOGO R (122VU V2, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.1mj` | bool | switch | write | `0` | C/B 1MJ DOORS CARGO (122VU T12, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.1mq` | bool | switch | write | `0` | C/B 1MQ DOORS PAX MONG (122VU T13, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.1ms1` | bool | switch | write | `0` | C/B 1MS1 COCKPIT SEATS CAPT SEAT CTL (122VU U11, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.1ms2` | bool | switch | write | `0` | C/B 1MS2 COCKPIT SEATS F/O SEAT CTL (122VU U14, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.1pr` | bool | switch | write | `0` | C/B 1PR ELEC REFLNG ON BAT (122VU U28, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.1wx` | bool | switch | write | `0` | C/B 1WX CARGO FIRE CARGO FIRE EXTIG (122VU T19, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.1xa` | bool | switch | write | `0` | C/B 1XA GALLEY GALLEY CTL (122VU S26, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.1xt` | bool | switch | write | `0` | C/B 1XT ELEC IDG 1 DISC (122VU T24, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.21hh` | bool | switch | write | `0` | C/B 21HH AIR COND PACK TEMP CTL SYS1 2 115VAC (122VU W22, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.22hh` | bool | switch | write | `0` | C/B 22HH AIR COND PACK TEMP CTL SYS2 2 115VAC (122VU Y20, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.23hh` | bool | switch | write | `0` | C/B 23HH AIR COND PACK TEMP CTL SYS1 2 28VDC (122VU W21, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.24hh` | bool | switch | write | `0` | C/B 24HH AIR COND PACK TEMP CTL SYS2 2 28VDC (122VU Y21, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.24xu1` | bool | switch | write | `0` | C/B 24XU1 ELEC EGIU 1 GEN 1 28VDC (122VU Z30, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.24xu2` | bool | switch | write | `0` | C/B 24XU2 ELEC EGIU 2 GEN 2 28VDC (122VU Y30, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.26lp` | bool | switch | write | `0` | C/B 26LP LIGHTING ANN LT SPLY XFMR BUS1 (122VU X4, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.26xu1` | bool | switch | write | `0` | C/B 26XU1 ELEC EGIU 1 EXT PWR 28VDC (122VU Z31, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.26xu2` | bool | switch | write | `0` | C/B 26XU2 ELEC EGIU 2 APU GEN 28VDC (122VU Y31, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.27lp` | bool | switch | write | `0` | C/B 27LP LIGHTING ANN LT SPLY XFMR BUS2 (122VU X5, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.28lp` | bool | switch | write | `0` | C/B 28LP LIGHTING ANN LT SPLY XFMR STAT INV (122VU X3, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.2da2` | bool | switch | write | `0` | C/B 2DA2 ANTI ICE PHC 2 (122VU Y12, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.2da3` | bool | switch | write | `0` | C/B 2DA3 ANTI ICE PHC 3 (122VU Y16, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.2ha2` | bool | switch | write | `0` | C/B 2HA2 AIR BLEED ENG2 MONG (122VU Z22, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.2hb` | bool | switch | write | `0` | C/B 2HB AIR COND FLOW CTL & IND 2 (122VU V21, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.2hg` | bool | switch | write | `0` | C/B 2HG AIR COND RECIRC FAN L CTL (122VU X20, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.2hh` | bool | switch | write | `0` | C/B 2HH AIR COND PACK TEMP CTL SYS2 1 115VAC (122VU Y18, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.2hk` | bool | switch | write | `0` | C/B 2HK AIR COND ZONE TEMP CTL 115VAC SYS2 (122VU V18, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.2hl` | bool | switch | write | `0` | C/B 2HL AIR COND CAB PRESS CTL 2 (122VU Y22, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.2la` | bool | switch | write | `0` | C/B 2LA NAV NAV2 LT (122VU T2, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.2lb` | bool | switch | write | `0` | C/B 2LB LANDING LT LDG LT R SPLY (122VU T6, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.2le` | bool | switch | write | `0` | C/B 2LE LIGHTING FLOOD CTR INST PNL (122VU Z4, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.2ll` | bool | switch | write | `0` | C/B 2LL LIGHTING WHL WELL LTG DOME (122VU X8, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.2lr` | bool | switch | write | `0` | C/B 2LR EXT LT TAXI & TAKE OFF CTL (122VU W9, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.2ly` | bool | switch | write | `0` | C/B 2LY LOGO LOGO L (122VU V3, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.2pr` | bool | switch | write | `0` | C/B 2PR ELEC REFLNG NORM (122VU S27, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.2xt` | bool | switch | write | `0` | C/B 2XT ELEC IDG 2 DISC (122VU T25, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.2xu1` | bool | switch | write | `0` | C/B 2XU1 ELEC GCU 1 (122VU T26, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.2xu2` | bool | switch | write | `0` | C/B 2XU2 ELEC GCU 2 (122VU T27, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.30hn` | bool | switch | write | `0` | C/B 30HN AIR COND AFT CARGO VENT FAN (122VU S22, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.30lp` | bool | switch | write | `0` | C/B 30LP LIGHTING TST BOARD SPLY (122VU X6, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.3da2` | bool | switch | write | `0` | C/B 3DA2 ANTI ICE PITOT 2 (122VU Y14, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.3da3` | bool | switch | write | `0` | C/B 3DA3 ANTI ICE PITOT 3 (122VU Z16, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.3ha2` | bool | switch | write | `0` | C/B 3HA2 AIR BLEED ENG2 CTL (122VU Z23, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.3hb` | bool | switch | write | `0` | C/B 3HB AIR COND MIXER FLAP (122VU V22, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.3hg` | bool | switch | write | `0` | C/B 3HG AIR COND RECIRC FAN R SPLY (122VU W18, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.3hh` | bool | switch | write | `0` | C/B 3HH AIR COND PACK TEMP CTL SYS1 1 28VDC (122VU X21, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.3hk` | bool | switch | write | `0` | C/B 3HK AIR COND ZONE TEMP CTL 28VDC SYS1 (122VU V19, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.3hl` | bool | switch | write | `0` | C/B 3HL AIR COND CAB PRESS CTL MAN (122VU Y23, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.3hq` | bool | switch | write | `0` | C/B 3HQ AIR COND AVNCS VENT MONG (122VU Y17, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.3lb` | bool | switch | write | `0` | C/B 3LB LANDING LT LDG LT L CTL (122VU T5, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.3le` | bool | switch | write | `0` | C/B 3LE LIGHTING CKPT DOME (122VU Y6, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.3lf` | bool | switch | write | `0` | C/B 3LF LIGHTING INST LT OVHT PNL (122VU Y3, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.3lr` | bool | switch | write | `0` | C/B 3LR EXT LT TAXI & TAKE OFF TO (122VU W7, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.3pc` | bool | switch | write | `0` | C/B 3PC ELEC CNTOR ESS DC BUS TIE (122VU W26, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.3pu1` | bool | switch | write | `0` | C/B 3PU1 ELEC TR 1 MONG (122VU X25, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.3pu2` | bool | switch | write | `0` | C/B 3PU2 ELEC TR 2 MONG (122VU X26, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.3wl` | bool | switch | write | `0` | C/B 3WL EMER LT CAB EMER LT (122VU V7, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.3xx` | bool | switch | write | `0` | C/B 3XX ELEC AC PWR SVCE CTL (122VU V29, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.4da2` | bool | switch | write | `0` | C/B 4DA2 ANTI ICE AOA 2 (122VU Y13, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.4da3` | bool | switch | write | `0` | C/B 4DA3 ANTI ICE AOA 3 (122VU Z15, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.4db1` | bool | switch | write | `0` | C/B 4DB1 ANTI ICE WIPER CAPT (122VU X12, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.4db2` | bool | switch | write | `0` | C/B 4DB2 ANTI ICE WIPER F/O (122VU W12, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.4dd1` | bool | switch | write | `0` | C/B 4DD1 ANTI ICE ICE DET L (122VU V12, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.4dd2` | bool | switch | write | `0` | C/B 4DD2 ANTI ICE ICE DET R (122VU V13, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.4dg1` | bool | switch | write | `0` | C/B 4DG1 ANTI ICE WINDOWS L (122VU X14, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.4dg2` | bool | switch | write | `0` | C/B 4DG2 ANTI ICE WINDOWS R (122VU W14, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.4hh` | bool | switch | write | `0` | C/B 4HH AIR COND PACK TEMP CTL SYS2 1 28VDC (122VU Y19, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.4hk` | bool | switch | write | `0` | C/B 4HK AIR COND ZONE TEMP CTL 28VDC SYS2 (122VU V20, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.4lb` | bool | switch | write | `0` | C/B 4LB LANDING LT LDG LT R CTL (122VU T7, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.4le` | bool | switch | write | `0` | C/B 4LE LIGHTING FLOOD F/O SIDE (122VU Z6, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.4lf` | bool | switch | write | `0` | C/B 4LF LIGHTING INST LT MAIN INST PNL&PED (122VU Y4, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.4pr` | bool | switch | write | `0` | C/B 4PR ELEC RFL SPLY LOGIC (122VU U29, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.4xg` | bool | switch | write | `0` | C/B 4XG ELEC EXT PWR LT AVAIL (122VU X31, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.5da1` | bool | switch | write | `0` | C/B 5DA1 ANTI ICE STATIC 1 (122VU Z13, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.5da2` | bool | switch | write | `0` | C/B 5DA2 ANTI ICE STATIC 2 (122VU Y11, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.5da3` | bool | switch | write | `0` | C/B 5DA3 ANTI ICE STATIC 3 (122VU Z14, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.5dg1` | bool | switch | write | `0` | C/B 5DG1 ANTI ICE WHC 1 (122VU X13, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.5dg2` | bool | switch | write | `0` | C/B 5DG2 ANTI ICE WHC 2 (122VU W13, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.5hu` | bool | switch | write | `0` | C/B 5HU AIR COND LAV/GALLEY VENT EXTRACT FAN CTL (122VU U21, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.5le` | bool | switch | write | `0` | C/B 5LE LIGHTING FLOOD CAPT SIDE (122VU Z5, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.5lf` | bool | switch | write | `0` | C/B 5LF LIGHTING INST LT GLARE SHLD (122VU Y5, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.5lv` | bool | switch | write | `0` | C/B 5LV BEACON BEACON LOWER (122VU U3, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.5lx` | bool | switch | write | `0` | C/B 5LX EXT LT WING & ENG SCAN L (122VU W2, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.5pn` | bool | switch | write | `0` | C/B 5PN ELEC DC SVCE BUS (122VU X24, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.5px` | bool | switch | write | `0` | C/B 5PX ELEC DC SVCE BUS ON TR 2 (122VU U30, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.5xu` | bool | switch | write | `0` | C/B 5XU ELEC GEN 1 OFF BTC 1 (122VU T28, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.6hu` | bool | switch | write | `0` | C/B 6HU AIR COND LAV/GALLEY VENT EXTRACT FAN SPLY (122VU U19, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.6xg` | bool | switch | write | `0` | C/B 6XG ELEC EXT PWR LT NOT IN USE (122VU X30, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.6xs` | bool | switch | write | `0` | C/B 6XS ELEC APU GCU (122VU Y25, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.7mc` | bool | switch | write | `0` | C/B 7MC GALLEY GALLEY CNTOR (122VU S28, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.7pc1` | bool | switch | write | `0` | C/B 7PC1 ELEC TR 1 FAULT CONFIG (122VU W29, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.7pc2` | bool | switch | write | `0` | C/B 7PC2 ELEC TR 2 FAULT CONFIG (122VU W30, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.7xa` | bool | switch | write | `0` | C/B 7XA GALLEY GND/FLT LOGIC (122VU S24, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.7xg` | bool | switch | write | `0` | C/B 7XG ELEC GPCU (122VU Y24, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.8xa` | bool | switch | write | `0` | C/B 8XA GALLEY FAULT LT CTL (122VU S25, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.8xu` | bool | switch | write | `0` | C/B 8XU ELEC GEN 2 OFF BTC 2 SPLY (122VU T31, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.9cv` | bool | switch | write | `0` | C/B 9CV FLT CTL WTB SLT SYS1 (122VU S6, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.9pc` | bool | switch | write | `0` | C/B 9PC ELEC CNTOR DC BUS TIE 1 (122VU W25, monitored): 1 = out (pulled or tripped) |
| `cb.122vu.9xe` | bool | switch | write | `0` | C/B 9XE ELEC EMER GEN AUTO 2 (122VU Z26, monitored): 1 = out (pulled or tripped) |

## Circuit breakers / 123VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `cb.123vu.10xn` | bool | switch | write | `0` | C/B 10XN ELEC BUS2 212XP SPLY (123VU AD3): 1 = out (pulled or tripped) |
| `cb.123vu.11qa` | bool | switch | write | `0` | C/B 11QA FUEL L WING TK PUMP1 STBY SPLY (123VU AD12): 1 = out (pulled or tripped) |
| `cb.123vu.12mc` | bool | switch | write | `0` | C/B 12MC GALLEY AFT GALLEY FEEDER B (123VU AD9): 1 = out (pulled or tripped) |
| `cb.123vu.12qa` | bool | switch | write | `0` | C/B 12QA FUEL R WING TK PUMP1 STBY SPLY (123VU AE12): 1 = out (pulled or tripped) |
| `cb.123vu.14mc` | bool | switch | write | `0` | C/B 14MC GALLEY AFT GALLEY FEEDER E (123VU AF9): 1 = out (pulled or tripped) |
| `cb.123vu.16mc` | bool | switch | write | `0` | C/B 16MC GALLEY FWD GALLEY FEEDER F (123VU AC10): 1 = out (pulled or tripped) |
| `cb.123vu.1dg1` | bool | switch | write | `0` | C/B 1DG1 ANTI ICE L WSHLD (123VU AF10): 1 = out (pulled or tripped) |
| `cb.123vu.1dg2` | bool | switch | write | `0` | C/B 1DG2 ANTI ICE R WSHIELD (123VU AF3): 1 = out (pulled or tripped) |
| `cb.123vu.1hq` | bool | switch | write | `0` | C/B 1HQ AVNCS VENT BLOWER FAN (123VU AD10): 1 = out (pulled or tripped) |
| `cb.123vu.1mc` | bool | switch | write | `0` | C/B 1MC GALLEY FWD GALLEY FEEDER C (123VU AE10): 1 = out (pulled or tripped) |
| `cb.123vu.1xc` | bool | switch | write | `0` | C/B 1XC ELEC AC ESS BUS ON BUS1 (123VU AC12): 1 = out (pulled or tripped) |
| `cb.123vu.1xn1` | bool | switch | write | `0` | C/B 1XN1 ELEC BUS1 101XP SPLY (123VU AD11): 1 = out (pulled or tripped) |
| `cb.123vu.1xn2` | bool | switch | write | `0` | C/B 1XN2 ELEC BUS2 202XP SPLY (123VU AD2): 1 = out (pulled or tripped) |
| `cb.123vu.1xx` | bool | switch | write | `0` | C/B 1XX ELEC TR2/SVCE BUS2 SPLY (123VU AB8): 1 = out (pulled or tripped) |
| `cb.123vu.23xg` | bool | switch | write | `0` | C/B 23XG ELEC EXT PWR EGIU1 115VAC (123VU AA7): 1 = out (pulled or tripped) |
| `cb.123vu.23xs` | bool | switch | write | `0` | C/B 23XS ELEC APU GEN EGIU2 115VAC (123VU AA8): 1 = out (pulled or tripped) |
| `cb.123vu.23xu1` | bool | switch | write | `0` | C/B 23XU1 ELEC GEN1 EGIU1 115VAC (123VU AF12): 1 = out (pulled or tripped) |
| `cb.123vu.23xu2` | bool | switch | write | `0` | C/B 23XU2 ELEC GEN2 EGIU2 115VAC (123VU AF1): 1 = out (pulled or tripped) |
| `cb.123vu.2701gj` | bool | switch | write | `0` | C/B 2701GJ HYD B HYD ELEC PUMP (123VU AB9): 1 = out (pulled or tripped) |
| `cb.123vu.2hq` | bool | switch | write | `0` | C/B 2HQ AVNCS VENT EXTC FAN (123VU AE2): 1 = out (pulled or tripped) |
| `cb.123vu.2mc` | bool | switch | write | `0` | C/B 2MC GALLEY FWD GALLEY FEEDER D (123VU AD4): 1 = out (pulled or tripped) |
| `cb.123vu.2pu1` | bool | switch | write | `0` | C/B 2PU1 ELEC TR1 SPLY (123VU AB10): 1 = out (pulled or tripped) |
| `cb.123vu.2pu2` | bool | switch | write | `0` | C/B 2PU2 ELEC TR2/214XP SPLY (123VU AB4): 1 = out (pulled or tripped) |
| `cb.123vu.2xc` | bool | switch | write | `0` | C/B 2XC ELEC AC ESS BUS ON BUS2 (123VU AC1): 1 = out (pulled or tripped) |
| `cb.123vu.2xg` | bool | switch | write | `0` | C/B 2XG ELEC GND PWR PROT (123VU AB7): 1 = out (pulled or tripped) |
| `cb.123vu.2xx` | bool | switch | write | `0` | C/B 2XX ELEC SVCE BUS2 212XP SPLY (123VU AB5): 1 = out (pulled or tripped) |
| `cb.123vu.3801gx` | bool | switch | write | `0` | C/B 3801GX HYD Y HYD ELEC PUMP NORM (123VU AB3): 1 = out (pulled or tripped) |
| `cb.123vu.3802gx` | bool | switch | write | `0` | C/B 3802GX HYD Y HYD ELEC PUMP (123VU AB6): 1 = out (pulled or tripped) |
| `cb.123vu.3mc` | bool | switch | write | `0` | C/B 3MC GALLEY AFT GALLEY FEEDER A (123VU AF4): 1 = out (pulled or tripped) |
| `cb.123vu.3xn1` | bool | switch | write | `0` | C/B 3XN1 ELEC BUS1 103XP SPLY (123VU AB11): 1 = out (pulled or tripped) |
| `cb.123vu.3xn2` | bool | switch | write | `0` | C/B 3XN2 ELEC BUS2 204XP SPLY (123VU AB2): 1 = out (pulled or tripped) |
| `cb.123vu.4xx` | bool | switch | write | `0` | C/B 4XX ELEC SVCE BUS2 214XP SPLY (123VU AA5): 1 = out (pulled or tripped) |
| `cb.123vu.5xn1` | bool | switch | write | `0` | C/B 5XN1 ELEC BUS1 131XP-A SPLY (123VU AB12): 1 = out (pulled or tripped) |
| `cb.123vu.5xn2` | bool | switch | write | `0` | C/B 5XN2 ELEC BUS2 231XP-A SPLY (123VU AB1): 1 = out (pulled or tripped) |
| `cb.123vu.7xn1` | bool | switch | write | `0` | C/B 7XN1 ELEC BUS1 110XP SPLY (123VU AF11): 1 = out (pulled or tripped) |
| `cb.123vu.7xn2` | bool | switch | write | `0` | C/B 7XN2 ELEC BUS2 210XP SPLY (123VU AF2): 1 = out (pulled or tripped) |

## Circuit breakers / 124VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `cb.124vu.1pn2` | bool | switch | write | `0` | C/B 1PN2 ELEC 202PP SPLY (124VU BG1): 1 = out (pulled or tripped) |
| `cb.124vu.1px` | bool | switch | write | `0` | C/B 1PX ELEC SVCE 601PP/ 602PP SPLY (124VU BB1): 1 = out (pulled or tripped) |
| `cb.124vu.3pn2` | bool | switch | write | `0` | C/B 3PN2 ELEC 204PP SPLY (124VU BF1): 1 = out (pulled or tripped) |
| `cb.124vu.4pu2` | bool | switch | write | `0` | C/B 4PU2 ELEC TR2 CNTOR SPLY (124VU BC1): 1 = out (pulled or tripped) |
| `cb.124vu.6pn` | bool | switch | write | `0` | C/B 6PN ELEC 206PP/208PP SPLY (124VU BE1): 1 = out (pulled or tripped) |
| `cb.124vu.7pn` | bool | switch | write | `0` | C/B 7PN ELEC DC SVCE 6PP SPLY (124VU BD1): 1 = out (pulled or tripped) |

## Circuit breakers / 125VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `cb.125vu.11pb` | bool | switch | write | `0` | C/B 11PB ELEC BAT BUS 301PP SPLY (125VU CC1): 1 = out (pulled or tripped) |
| `cb.125vu.1pn1` | bool | switch | write | `0` | C/B 1PN1 ELEC 101PP SPLY (125VU CD1): 1 = out (pulled or tripped) |
| `cb.125vu.3pn1` | bool | switch | write | `0` | C/B 3PN1 ELEC 103PP SPLY (125VU CE1): 1 = out (pulled or tripped) |
| `cb.125vu.4pu1` | bool | switch | write | `0` | C/B 4PU1 ELEC TR1 CNTOR SPLY (125VU CF1): 1 = out (pulled or tripped) |

## Circuit breakers / 49VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `cb.49vu.10ca1` | bool | switch | write | `0` | C/B 10CA1 AUTO FLT FMGC 1 (49VU B2, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.10wt1` | bool | switch | write | `0` | C/B 10WT1 EIS DMC 1 SPLY (49VU E11, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.11ca1` | bool | switch | write | `0` | C/B 11CA1 AUTO FLT MCDU 1 (49VU B1, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.11wq` | bool | switch | write | `0` | C/B 11WQ AIR COND SDCU CHAN 1 (49VU C6, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.11wt1` | bool | switch | write | `0` | C/B 11WT1 EIS PFD CAPT SPLY (49VU E3, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.12fn` | bool | switch | write | `0` | C/B 12FN NAV VOR/ADF/ DME RMI (49VU F13, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.12wt1` | bool | switch | write | `0` | C/B 12WT1 EIS ND CAPT SPLY (49VU E1, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.12wv` | bool | switch | write | `0` | C/B 12WV SDAC 1&2 28VDC ESS BUS (49VU F5, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.13wt1` | bool | switch | write | `0` | C/B 13WT1 EIS ECAM UPPER SPLY (49VU E5, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.13xg` | bool | switch | write | `0` | C/B 13XG ELEC LT CTL (49VU H10, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.14cc1` | bool | switch | write | `0` | C/B 14CC1 AUTO FLT FAC 1 26VAC (49VU B3, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.14wt1` | bool | switch | write | `0` | C/B 14WT1 EIS DMC 3 STBY SPLY (49VU E10, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.150rh` | bool | switch | write | `0` | C/B 150RH COM CIDS COM DIR ESS 1 (49VU G1, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.153rh` | bool | switch | write | `0` | C/B 153RH COM CIDS DEU B ESS (49VU G3, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.154rh` | bool | switch | write | `0` | C/B 154RH COM DEU A ESS LINE 1 (49VU G4, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.155rh` | bool | switch | write | `0` | C/B 155RH COM DEU A ESS LINE 2 (49VU G5, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.157rh` | bool | switch | write | `0` | C/B 157RH COM CIDS COM DIR ESS 2 (49VU G2, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.15ce1` | bool | switch | write | `0` | C/B 15CE1 FLIGHT CONTROLS ELAC 1 NORM SPLY (49VU B11, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.15wt` | bool | switch | write | `0` | C/B 15WT EIS ECAM CTL PNL (49VU E12, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.16fn` | bool | switch | write | `0` | C/B 16FN NAV STBY ALTM (49VU F14, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.1703gk` | bool | switch | write | `0` | C/B 1703GK HYD FIRE VALVE G ENG 1 (49VU C13, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.17wt1` | bool | switch | write | `0` | C/B 17WT1 EIS RLY BOX CAPT (49VU E8, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.1841gn` | bool | switch | write | `0` | C/B 1841GN HYD HYD PRESS XMTR (49VU C11, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.19ce2` | bool | switch | write | `0` | C/B 19CE2 FLIGHT CONTROLS THS ACTR MOT 2 (49VU B9, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.1cn` | bool | switch | write | `0` | C/B 1CN FLIGHT CONTROLS SLT FLP 1 POS IND (49VU B12, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.1db1` | bool | switch | write | `0` | C/B 1DB1 ANTI ICE RAIN RPLNT CAPT (49VU D1, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.1dl` | bool | switch | write | `0` | C/B 1DL ANTI ICE WING MONG (49VU C1, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.1ga` | bool | switch | write | `0` | C/B 1GA L/G LGCIU SYS 1 (49VU C9, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.1hb` | bool | switch | write | `0` | C/B 1HB AIR COND FLOW CTL & IND 1 (49VU D7, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.1hl` | bool | switch | write | `0` | C/B 1HL AIR COND CAB PRESS CTL 1 (49VU D9, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.1ht` | bool | switch | write | `0` | C/B 1HT OXYGEN CREW OXY SPLY (49VU HA1, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.1hz` | bool | switch | write | `0` | C/B 1HZ AIR COND RAM AIR INLET (49VU D10, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.1jh` | bool | switch | write | `0` | C/B 1JH ENGINE IGN 1&2 SYS A (49VU A3, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.1kc1` | bool | switch | write | `0` | C/B 1KC1 ENGINE HP FUEL SOV 1 (49VU A1, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.1kc2` | bool | switch | write | `0` | C/B 1KC2 ENGINE HP FUEL SOV 2 (49VU A2, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.1le` | bool | switch | write | `0` | C/B 1LE LIGHTING EMER LT CKPT DOME (49VU H8, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.1lf` | bool | switch | write | `0` | C/B 1LF LIGHTING ICE & STBY COMP LT (49VU H4, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.1qg` | bool | switch | write | `0` | C/B 1QG FUEL LP VALVE MOT1 ENG 1 (49VU A8, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.1qp` | bool | switch | write | `0` | C/B 1QP FUEL XFR VALVE 1 WING L (49VU A10, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.1qt` | bool | switch | write | `0` | C/B 1QT FUEL FQI CHAN 1 (49VU A13, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.1re1` | bool | switch | write | `0` | C/B 1RE1 COM HF 1 (49VU HA14, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.1rp1` | bool | switch | write | `0` | C/B 1RP1 NAV ADF 1 (49VU H14, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.1rt1` | bool | switch | write | `0` | C/B 1RT1 NAV ILS 1 (49VU G12, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.1sd1` | bool | switch | write | `0` | C/B 1SD1 NAV DME 1 (49VU G14, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.1wl` | bool | switch | write | `0` | C/B 1WL LIGHTING EMER LT CABIN (49VU H5, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.1wr` | bool | switch | write | `0` | C/B 1WR OXYGEN PAX CTL & WARN (49VU HA2, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.20ce1` | bool | switch | write | `0` | C/B 20CE1 FLIGHT CONTROLS FCDC 1 SPLY (49VU B10, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.21ce1` | bool | switch | write | `0` | C/B 21CE1 FLIGHT CONTROLS SEC 1 NORM SPLY (49VU B8, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.21wt1` | bool | switch | write | `0` | C/B 21WT1 EIS DMC 1 SWTG (49VU E9, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.21wt3` | bool | switch | write | `0` | C/B 21WT3 EIS DMC 3 SWTG (49VU E7, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.22wt1` | bool | switch | write | `0` | C/B 22WT1 EIS PFD CAPT SWTG (49VU E4, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.23wt1` | bool | switch | write | `0` | C/B 23WT1 EIS ND CAPT SWTG (49VU E2, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.24wt1` | bool | switch | write | `0` | C/B 24WT1 EIS ECAM UPPER SWTG (49VU E6, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.2702gj` | bool | switch | write | `0` | C/B 2702GJ HYD HYD PWR B WARN & CTL (49VU C12, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.2801ge` | bool | switch | write | `0` | C/B 2801GE HYD RAT CTL (49VU D14, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.29lp` | bool | switch | write | `0` | C/B 29LP LIGHTING XFMR 115V.5V ESS BUS (49VU H3, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.2da1` | bool | switch | write | `0` | C/B 2DA1 ANTI ICE PHC 1 (49VU D3, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.2dl` | bool | switch | write | `0` | C/B 2DL ANTI ICE WING CTL (49VU C2, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.2ha1` | bool | switch | write | `0` | C/B 2HA1 AIR BLEED ENG 1 MONG (49VU D11, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.2hv` | bool | switch | write | `0` | C/B 2HV AIR BLEED X FEED VALVE BAT (49VU D13, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.2ks1` | bool | switch | write | `0` | C/B 2KS1 ENGINE FADEC A & EIU 1 (49VU A4, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.2ks2` | bool | switch | write | `0` | C/B 2KS2 ENGINE FADEC A & EIU 2 (49VU A5, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.2qc` | bool | switch | write | `0` | C/B 2QC APU FUEL BLOW OFF PUMP (49VU B14, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.2qe` | bool | switch | write | `0` | C/B 2QE FUEL X FEED VALVE MOT 1 (49VU A12, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.2qg` | bool | switch | write | `0` | C/B 2QG FUEL LP VALVE MOT1 ENG 2 (49VU A9, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.2qp` | bool | switch | write | `0` | C/B 2QP FUEL XFR VALVE 1 WING R (49VU A11, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.2rc1` | bool | switch | write | `0` | C/B 2RC1 COM VHF 1 (49VU G9, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.2rg1` | bool | switch | write | `0` | C/B 2RG1 COM RMP 1 (49VU G10, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.2rk` | bool | switch | write | `0` | C/B 2RK COM CVR SPLY (49VU E14, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.2rs1` | bool | switch | write | `0` | C/B 2RS1 NAV VOR 1 (49VU G13, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.2wl` | bool | switch | write | `0` | C/B 2WL LIGHTING EMER LT CABIN (49VU H6, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.2wr` | bool | switch | write | `0` | C/B 2WR OXYGEN PAX CTL & WARN (49VU HA3, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.31hn` | bool | switch | write | `0` | C/B 31HN AIR COND AFT CARGO VENT CTL & MONG (49VU C7, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.3702gd` | bool | switch | write | `0` | C/B 3702GD HYD FIRE VALVE Y ENG 2 (49VU C14, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.3da1` | bool | switch | write | `0` | C/B 3DA1 ANTI ICE PITOT 1 (49VU D2, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.3ha1` | bool | switch | write | `0` | C/B 3HA1 AIR BLEED ENG 1 CTL (49VU D12, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.3wr` | bool | switch | write | `0` | C/B 3WR OXYGEN PAX CTL & WARN (49VU HA4, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.3wv` | bool | switch | write | `0` | C/B 3WV SDAC 1 SPLY (49VU F4, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.3ww` | bool | switch | write | `0` | C/B 3WW FWS FWC 1 SPLY (49VU F1, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.4da1` | bool | switch | write | `0` | C/B 4DA1 ANTI ICE AOA 1 (49VU D4, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.4fp1` | bool | switch | write | `0` | C/B 4FP1 NAV & PROBES ADIRU 1 115VAC (49VU F6, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.4rk` | bool | switch | write | `0` | C/B 4RK COM CVR CTL (49VU E13, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.4rn` | bool | switch | write | `0` | C/B 4RN COM ACP CAPT (49VU G6, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.4wr` | bool | switch | write | `0` | C/B 4WR OXYGEN PAX ACTUATION (49VU HA5, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.55qa` | bool | switch | write | `0` | C/B 55QA FUEL SMOKE CONFIG PUMP CTL (49VU A14, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.5cc1` | bool | switch | write | `0` | C/B 5CC1 AUTO FLT FAC 1 28VDC (49VU B4, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.5cv` | bool | switch | write | `0` | C/B 5CV FLIGHT CONTROLS SLT CTL & MONG SYS 1 (49VU B6, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.5fn` | bool | switch | write | `0` | C/B 5FN NAV ISIS (49VU F12, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.5fp1` | bool | switch | write | `0` | C/B 5FP1 NAV & PROBES ADIRU 1 26VAC & AOA 1 (49VU F7, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.5hq` | bool | switch | write | `0` | C/B 5HQ AIR COND AVNCS VENT CTL (49VU D5, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.5rn` | bool | switch | write | `0` | C/B 5RN COM ACP F/O (49VU G7, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.5sh1` | bool | switch | write | `0` | C/B 5SH1 NAV ATC 1 (49VU G11, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.5wr` | bool | switch | write | `0` | C/B 5WR OXYGEN PAX ACTUATION (49VU HA6, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.5wv` | bool | switch | write | `0` | C/B 5WV SDAC 1 26VAC SYNC AC ESS (49VU F2, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.5ww` | bool | switch | write | `0` | C/B 5WW NAV & PROBES CAPT LOUD SPKR (49VU F10, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.61gg` | bool | switch | write | `0` | C/B 61GG L/G Y BRK PRESS IND (49VU C10, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.6cv` | bool | switch | write | `0` | C/B 6CV FLIGHT CONTROLS FLP CTL & MONG SYS 1 (49VU B7, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.6fs` | bool | switch | write | `0` | C/B 6FS NAV & PROBES CLOCK NORM SPLY (49VU F11, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.6hq` | bool | switch | write | `0` | C/B 6HQ AIR COND AVNCS VENT CTL (49VU D6, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.6wr` | bool | switch | write | `0` | C/B 6WR OXYGEN PAX ACTUATION (49VU HA7, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.6wv` | bool | switch | write | `0` | C/B 6WV SDAC 2 26VAC SYNC AC ESS (49VU F3, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.6xh` | bool | switch | write | `0` | C/B 6XH ELEC AC BUS 8XP MONG (49VU H11, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.79wl` | bool | switch | write | `0` | C/B 79WL LIGHTING EMER LT CABIN (49VU H7, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.7wd1` | bool | switch | write | `0` | C/B 7WD1 ENGINE FIRE DET 1 LOOP A (49VU A6, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.7wr` | bool | switch | write | `0` | C/B 7WR OXYGEN PAX ACTUATION (49VU HA8, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.8fp` | bool | switch | write | `0` | C/B 8FP NAV & PROBES ADIRU 3 SWTG SPLY (49VU F9, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.8wd2` | bool | switch | write | `0` | C/B 8WD2 ENGINE FIRE DET 2 LOOP B (49VU A7, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.9ca1` | bool | switch | write | `0` | C/B 9CA1 AUTO FLT FCU 1 (49VU B5, monitored): 1 = out (pulled or tripped) |
| `cb.49vu.9rn` | bool | switch | write | `0` | C/B 9RN COM FLT INTPH (49VU G8, monitored): 1 = out (pulled or tripped) |

## Controls / Axes (hardware)

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `ctl.axis.captBrakeLeft` | float | analog | write | `0` | CAPT left toe brake (0 released .. 1 fully pressed) |
| `ctl.axis.captBrakeRight` | float | analog | write | `0` | CAPT right toe brake (0 released .. 1 fully pressed) |
| `ctl.axis.captRudderPedals` | float | analog | write | `0` | CAPT rudder pedals (−1 full left .. 0 neutral .. 1 full right) |
| `ctl.axis.captRudderPedalsTiller` | float | analog | write | `0` | CAPT rudder pedals that also steer like the tiller at low speed, for hardware without a tiller (−1 full left .. 0 neutral .. 1 full right) |
| `ctl.axis.captSidestickPitch` | float | analog | write | `0` | CAPT sidestick pitch (−1 full forward / nose down .. 0 neutral .. 1 full aft / nose up) |
| `ctl.axis.captSidestickRoll` | float | analog | write | `0` | CAPT sidestick roll (−1 full left .. 0 neutral .. 1 full right) |
| `ctl.axis.captTiller` | float | analog | write | `0` | CAPT nose wheel steering handwheel (−1 full left .. 0 neutral .. 1 full right) |
| `ctl.axis.flapsLever` | float | analog | write | `0` | Flaps lever (lever value from the positions calibrated in Hardware: 0, 0.25, 0.5, 0.75, 1 = 0, 1, 2, 3, FULL) |
| `ctl.axis.foBrakeLeft` | float | analog | write | `0` | F/O left toe brake (0 released .. 1 fully pressed) |
| `ctl.axis.foBrakeRight` | float | analog | write | `0` | F/O right toe brake (0 released .. 1 fully pressed) |
| `ctl.axis.foRudderPedals` | float | analog | write | `0` | F/O rudder pedals (−1 full left .. 0 neutral .. 1 full right) |
| `ctl.axis.foRudderPedalsTiller` | float | analog | write | `0` | F/O rudder pedals that also steer like the tiller at low speed, for hardware without a tiller (−1 full left .. 0 neutral .. 1 full right) |
| `ctl.axis.foSidestickPitch` | float | analog | write | `0` | F/O sidestick pitch (−1 full forward / nose down .. 0 neutral .. 1 full aft / nose up) |
| `ctl.axis.foSidestickRoll` | float | analog | write | `0` | F/O sidestick roll (−1 full left .. 0 neutral .. 1 full right) |
| `ctl.axis.foTiller` | float | analog | write | `0` | F/O nose wheel steering handwheel (−1 full left .. 0 neutral .. 1 full right) |
| `ctl.axis.speedBrakeLever` | float | analog | write | `0` | Speed brake lever (lever value from the detents calibrated in Hardware: 0 RET .. 0.5 1/2 .. 1 FULL) |
| `ctl.axis.thrustLever1` | float | analog | write | `0` | Thrust lever 1 (lever value from the detents calibrated in Hardware: −0.444 MAX REV .. 0 IDLE .. 1 TO/GA = TLA / 45°) |
| `ctl.axis.thrustLever2` | float | analog | write | `0` | Thrust lever 2 (lever value from the detents calibrated in Hardware: −0.444 MAX REV .. 0 IDLE .. 1 TO/GA = TLA / 45°) |
| `ctl.axis.thrustLevers` | float | analog | write | `0` | Both thrust levers from one hardware axis (lever value like thrust lever 1 / 2); a source on thrust lever 1 or 2 as well is a conflict |

## Controls / Brake pedals

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `ctl.brakePedalLeft` | float | analog | write | `0` | Left brake pedal (0 = released, 1 = fully pressed; the larger of both pilots) |
| `ctl.brakePedalRight` | float | analog | write | `0` | Right brake pedal (0 = released, 1 = fully pressed; the larger of both pilots) |

## Controls / Buttons (hardware)

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `ctl.button.athrDisconnect` | float | analog | write | `0` | The A/THR instinctive disconnect pushbutton on thrust lever 1 |
| `ctl.button.athrDisconnect2` | float | analog | write | `0` | The A/THR instinctive disconnect pushbutton on thrust lever 2 |
| `ctl.button.brakeLeft` | float | analog | write | `0` | Left brake pedal fully pressed while held; combined with the toe brake axes (the larger wins) |
| `ctl.button.brakeRight` | float | analog | write | `0` | Right brake pedal fully pressed while held; combined with the toe brake axes (the larger wins) |
| `ctl.button.brakesMax` | float | analog | write | `0` | Both brake pedals fully pressed while held (for hardware without toe brake axes); combined with the toe brake axes (the larger wins) |
| `ctl.button.flapsDown` | float | analog | write | `0` | Each press moves the FLAPS lever one position down (towards FULL) |
| `ctl.button.flapsUp` | float | analog | write | `0` | Each press moves the FLAPS lever one position up (towards 0) |
| `ctl.button.pedalsDiscCapt` | float | analog | write | `0` | The rudder PEDALS DISC pb on the captain's steering hand wheel: the rudder pedals do not steer the nose wheel while held (towing, rudder checks); ORed with ctl.pedalsDisc.capt |
| `ctl.button.pedalsDiscFo` | float | analog | write | `0` | The rudder PEDALS DISC pb on the F/O's steering hand wheel: the rudder pedals do not steer the nose wheel while held (towing, rudder checks); ORed with ctl.pedalsDisc.fo |
| `ctl.button.pitchTrimNoseDown` | float | analog | write | `0` | Turns the pitch trim wheel nose down while held (manual trim: only on ground or when the law needs it, gates.pitchTrimMotorEnabled = 0) |
| `ctl.button.pitchTrimNoseUp` | float | analog | write | `0` | Turns the pitch trim wheel nose up while held (manual trim: only on ground or when the law needs it, gates.pitchTrimMotorEnabled = 0) |
| `ctl.button.pttIntCapt` | float | analog | write | `0` | Captain push-to-talk on the interphone (an R/T–INT switch at INT): the boom / mask mike on the flight interphone while held, like the ACP INT/RAD switch at INT |
| `ctl.button.pttIntFo` | float | analog | write | `0` | F/O push-to-talk on the interphone (an R/T–INT switch at INT): the boom / mask mike on the flight interphone while held, like the ACP INT/RAD switch at INT |
| `ctl.button.pttRadioCapt` | float | analog | write | `0` | Captain push-to-talk on the radio (the sidestick radio selector or a glareshield R/T switch): transmits on the ACP's selected transmission key while held; ORed with ctl.sidestickRadio.capt |
| `ctl.button.pttRadioFo` | float | analog | write | `0` | F/O push-to-talk on the radio (the sidestick radio selector or a glareshield R/T switch): transmits on the ACP's selected transmission key while held; ORed with ctl.sidestickRadio.fo |
| `ctl.button.sidestickPriorityCapt` | float | analog | write | `0` | The captain sidestick takeover pushbutton (red): AP disconnect, sidestick priority while held (latched after 40 s) |
| `ctl.button.sidestickPriorityFo` | float | analog | write | `0` | The F/O sidestick takeover pushbutton (red): AP disconnect, sidestick priority while held (latched after 40 s) |
| `ctl.button.speedBrakeArm` | float | analog | write | `0` | Each press arms the ground spoilers (the speed brake lever pulled up at RET; armed only with the lever at RET) |
| `ctl.button.speedBrakeDisarm` | float | analog | write | `0` | Each press disarms the ground spoilers (the speed brake lever pushed down) |

## Controls / PTT

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `ctl.handMicPtt.capt` | bool | pushbutton | momentary | `0` | Captain hand mike PTT (1 = held) |
| `ctl.handMicPtt.fo` | bool | pushbutton | momentary | `0` | F/O hand mike PTT (1 = held) |
| `ctl.sidestickRadio.capt` | bool | pushbutton | momentary | `0` | Captain sidestick radio selector (1 = RADIO, held) |
| `ctl.sidestickRadio.fo` | bool | pushbutton | momentary | `0` | F/O sidestick radio selector (1 = RADIO, held) |

## Controls / steering hand wheels

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `ctl.pedalsDisc.capt` | bool | pushbutton | momentary | `0` | Captain steering hand wheel rudder PEDALS DISC pb (momentary: 1 while held): the rudder pedals do not steer the nose wheel |
| `ctl.pedalsDisc.fo` | bool | pushbutton | momentary | `0` | F/O steering hand wheel rudder PEDALS DISC pb (momentary: 1 while held): the rudder pedals do not steer the nose wheel |

## DDRMI

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `ddrmi.dme1` | float | output | read | `0` | DDRMI DME 1 window distance (NM as shown: tenths below 20 NM, whole NM above; -1 when not a distance) |
| `ddrmi.dme1Text` | string | output | read | `"012.4"` | DDRMI DME 1 LCD as shown ("012.4", "240", "----" no computed data, "888.8" ANN LT TEST, "" blank) |
| `ddrmi.dme1Valid` | bool | output | read | `0` | DDRMI DME 1 window shows a distance |
| `ddrmi.dme2` | float | output | read | `0` | DDRMI DME 2 window distance (NM as shown; -1 when not a distance) |
| `ddrmi.dme2Text` | string | output | read | `""` | DDRMI DME 2 LCD as shown (same format as ddrmi.dme1Text) |
| `ddrmi.dme2Valid` | bool | output | read | `0` | DDRMI DME 2 window shows a distance |
| `ddrmi.hdgFlag` | bool | output | read | `0` | DDRMI HDG flag in view (heading not valid, unpowered, failed) |
| `ddrmi.heading` | float | output | read | `0` | DDRMI compass card: magnetic heading under the lubber line (degrees 0..360, servo position; frozen when unpowered or flagged) |
| `ddrmi.light` | float | output | read | `0` | DDRMI dial and LCD lighting (its lamps on the main panel integral lighting, INTEG LT MAIN PNL & PED: 0 off, 0.27 .. 1) |
| `ddrmi.powered` | bool | output | read | `0` | DDRMI powered (115 V AC ESS, C/B 12FN) and working |
| `ddrmi.ptr1Bearing` | float | output | read | `0` | DDRMI single dotted bar pointer (VOR 1 / ADF 1): bearing it points to on the card (degrees 0..360); its angle on the dial from the lubber line = ptr1Bearing - heading (90 = parked at 3 o'clock) |
| `ddrmi.ptr1Flag` | bool | output | read | `0` | DDRMI VOR 1/ADF 1 flag in view (receiver failed, heading not valid, unpowered) |
| `ddrmi.ptr1Valid` | bool | output | read | `0` | DDRMI single bar pointer shows a received station (else parked at 3 o'clock) |
| `ddrmi.ptr2Bearing` | float | output | read | `0` | DDRMI double bar pointer (VOR 2 / ADF 2): bearing it points to on the card (degrees 0..360); dial angle = ptr2Bearing - heading |
| `ddrmi.ptr2Flag` | bool | output | read | `0` | DDRMI VOR 2/ADF 2 flag in view (receiver failed, heading not valid, unpowered) |
| `ddrmi.ptr2Valid` | bool | output | read | `0` | DDRMI double bar pointer shows a received station (else parked at 3 o'clock) |

## Doors

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `doors.aftCargo.hold` | int | output | read | `0` | AFT cargo door selector held but not moving: 0 no, 1 locking handle down, 2 no electric power for the yellow pump, 3 no yellow pressure |
| `doors.aftCargo.lockingHandle` | bool | service | write | `0` | AFT cargo door locking handle down: latched and locked (only with the door closed) |
| `doors.aftCargo.open` | bool | service | write | `0` | AFT cargo door open (1 = not closed and locked) |
| `doors.aftCargo.openLockedLight` | bool | output | read | `0` | AFT cargo door green OPEN AND LOCKED indicator light |
| `doors.aftCargo.position` | float | output | read | `0` | AFT cargo door position (0 closed .. 1 open) |
| `doors.aftCargo.request` | int | service | write | `0` | AFT cargo door ground crew request: 1 open, -1 close, 0 none or cancel (back to 0 when done) |
| `doors.aftCargo.selector` | int | service | write | `0` | AFT cargo door manual selector valve lever, held (-1 CLOSE, 0 neutral, 1 OPEN) |
| `doors.aftCargo.state` | int | output | read | `0` | AFT cargo door: 0 closed and locked, 1 closed unlocked, 2 opening, 3 closing, 4 open and locked, 5 stopped part open |
| `doors.aftLeftCabin.open` | bool | service | write | `0` | AFT LEFT passenger door open (1 = not closed and locked) |
| `doors.aftLeftCabin.slideArmed` | bool | service | write | `0` | AFT LEFT passenger door slide arming lever at ARMED (only with the door closed: opening the door disarms it) |
| `doors.aftRightCabin.open` | bool | service | write | `0` | AFT RIGHT passenger door open (1 = not closed and locked) |
| `doors.aftRightCabin.slideArmed` | bool | service | write | `0` | AFT RIGHT passenger door slide arming lever at ARMED (only with the door closed: opening the door disarms it) |
| `doors.avionics1.open` | bool | service | write | `0` | Avionics compartment access door 1 (forward) open (1 = not closed and locked) |
| `doors.avionics2.open` | bool | service | write | `0` | Avionics compartment access door 2 (left) open (1 = not closed and locked) |
| `doors.avionics3.open` | bool | service | write | `0` | Avionics compartment access door 3 (right) open (1 = not closed and locked) |
| `doors.avionics4.open` | bool | service | write | `0` | Avionics compartment access door 4 (aft) open (1 = not closed and locked) |
| `doors.bulkCargo.open` | bool | service | write | `0` | BULK cargo door open (1 = not closed and locked) |
| `doors.fwdCargo.hold` | int | output | read | `0` | FWD cargo door selector held but not moving: 0 no, 1 locking handle down, 2 no electric power for the yellow pump, 3 no yellow pressure |
| `doors.fwdCargo.lockingHandle` | bool | service | write | `0` | FWD cargo door locking handle down: latched and locked (only with the door closed) |
| `doors.fwdCargo.open` | bool | service | write | `0` | FWD cargo door open (1 = not closed and locked) |
| `doors.fwdCargo.openLockedLight` | bool | output | read | `0` | FWD cargo door green OPEN AND LOCKED indicator light |
| `doors.fwdCargo.position` | float | output | read | `0` | FWD cargo door position (0 closed .. 1 open) |
| `doors.fwdCargo.request` | int | service | write | `0` | FWD cargo door ground crew request: 1 open, -1 close, 0 none or cancel (back to 0 when done) |
| `doors.fwdCargo.selector` | int | service | write | `0` | FWD cargo door manual selector valve lever, held (-1 CLOSE, 0 neutral, 1 OPEN) |
| `doors.fwdCargo.state` | int | output | read | `0` | FWD cargo door: 0 closed and locked, 1 closed unlocked, 2 opening, 3 closing, 4 open and locked, 5 stopped part open |
| `doors.fwdLeftCabin.open` | bool | service | write | `0` | FWD LEFT passenger door open (1 = not closed and locked) |
| `doors.fwdLeftCabin.slideArmed` | bool | service | write | `0` | FWD LEFT passenger door slide arming lever at ARMED (only with the door closed: opening the door disarms it) |
| `doors.fwdRightCabin.open` | bool | service | write | `0` | FWD RIGHT passenger door open (1 = not closed and locked) |
| `doors.fwdRightCabin.slideArmed` | bool | service | write | `0` | FWD RIGHT passenger door slide arming lever at ARMED (only with the door closed: opening the door disarms it) |
| `doors.leftEmerExit1.open` | bool | service | write | `0` | LEFT forward overwing emergency exit open (1 = not closed and locked) |
| `doors.leftEmerExit2.open` | bool | service | write | `0` | LEFT aft overwing emergency exit open (1 = not closed and locked) |
| `doors.rightEmerExit1.open` | bool | service | write | `0` | RIGHT forward overwing emergency exit open (1 = not closed and locked) |
| `doors.rightEmerExit2.open` | bool | service | write | `0` | RIGHT aft overwing emergency exit open (1 = not closed and locked) |

## Doors / cockpit door (cabin side)

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `doors.cockpit.buzzer` | bool | output | read | `0` | Cockpit door access request buzzer sounding in the cockpit |
| `doors.cockpit.cdlsPowered` | bool | output | read | `0` | CDLS control unit powered and working (else the latches are unlocked) |
| `doors.cockpit.cdss.display` | int | output | read | `0` | CDSS screen (0 standby / off, 1 camera 1, 2 cameras 2 and 3 split screen) |
| `doors.cockpit.cdss.powered` | bool | output | read | `0` | CDSS energized (overhead COCKPIT DOOR VIDEO pb not OFF, supply powered) |
| `doors.cockpit.close` | bool | service | momentary | `0` | The cockpit door is closed (momentary): the latches lock it again when commanded locked |
| `doors.cockpit.emergencyPending` | bool | output | read | `0` | Emergency access request waiting for the flight crew (the door unlocks at the end of the time delay) |
| `doors.cockpit.keypad.emergency` | bool | service | momentary | `0` | Keypad: emergency access code + '#' entered (momentary): continuous buzzer, OPEN flashing, auto unlock after the delay |
| `doors.cockpit.keypad.green` | int | output | read | `0` | Keypad green light (0 off, 1 steady: door unlocked, 2 flashing: emergency request pending) |
| `doors.cockpit.keypad.red` | bool | output | read | `0` | Keypad red light (access denied: LOCK selected, keypad inhibited) |
| `doors.cockpit.keypad.request` | bool | service | momentary | `0` | Keypad: routine access code + '#' entered (momentary: 1 while pressed): the cockpit buzzer for 3 s |
| `doors.cockpit.lockInhibitS` | float | output | read | `0` | Time left of the LOCK inhibition of the keypad, buzzer and emergency access (s, 0 = none) |
| `doors.cockpit.locked` | bool | output | read | `0` | Cockpit door closed and locked (at least one strike engaged): cannot be pushed open from the cabin |
| `doors.cockpit.open` | bool | output | read | `0` | Cockpit door open (not closed) |
| `doors.cockpit.openFromCockpit` | bool | service | momentary | `0` | A pilot opens the cockpit door from the cockpit side (handle / mechanical override; momentary): always opens |
| `doors.cockpit.pushFromCabin` | bool | service | momentary | `0` | Someone in the cabin pushes the cockpit door (momentary): it opens only when unlocked |
| `doors.cockpit.strikeBotLocked` | bool | output | read | `0` | Cockpit door BOT strike engaged (locked) |
| `doors.cockpit.strikeMidLocked` | bool | output | read | `0` | Cockpit door MID strike engaged (locked) |
| `doors.cockpit.strikeTopLocked` | bool | output | read | `0` | Cockpit door TOP strike engaged (locked) |

## EFB

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `efb.settingsRevision` | int | output | read | `0` | Revision of the EFB settings kept by Systems (GET /api/efb/settings): raised by every change, the EFBs fetch them again |

## EIS (parameters)

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `eis.sdUtc` | string | output | read | `"HH:MM"` | UTC on the lower part of the SD as "HH:MM" ("23:12"; the SD writes "23 H 12"), "" before the CFDIU has a time |
| `eis.sdUtcSeconds` | int | output | read | `-1` | UTC on the lower part of the SD (seconds since midnight; -1 none): the CFDIU's time, synchronized with the cockpit clock while it sends a time (GPS, internal or set), running on its own when the clock fails or shows dashes |

## Electrical (parameters)

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `elec.apuGen.hz` | float | output | read | `0` | APU GEN frequency (Hz, ELEC page) |
| `elec.apuGen.loadPercent` | float | output | read | `0` | APU GEN load (%, ELEC page) |
| `elec.apuGen.volts` | float | output | read | `0` | APU GEN voltage (V, ELEC page) |
| `elec.bat1.amps` | float | output | read | `0` | BAT 1 current (A, ELEC page; + discharging, − charging, 0 with its contactor open) |
| `elec.bat1.volts` | float | output | read | `0` | BAT 1 voltage (V, ELEC page) |
| `elec.bat2.amps` | float | output | read | `0` | BAT 2 current (A, ELEC page; + discharging, − charging, 0 with its contactor open) |
| `elec.bat2.volts` | float | output | read | `0` | BAT 2 voltage (V, ELEC page) |
| `elec.emerGen.hz` | float | output | read | `0` | EMER GEN frequency (Hz, ELEC page) |
| `elec.emerGen.volts` | float | output | read | `0` | EMER GEN voltage (V, ELEC page) |
| `elec.essTr.amps` | float | output | read | `0` | ESS TR current (A, ELEC page) |
| `elec.essTr.inputPowered` | bool | output | read | `0` | ESS TR input supplied: from the AC ESS BUS (not while the AC ESS BUS is on the static inverter) or the EMER GEN (elec.contactor.emerGenLine); the ESS TR feeds DC ESS when elec.contactor.essTr is closed. The aircraft has no separate ESS TR input contactor (C/B 4PE) |
| `elec.essTr.volts` | float | output | read | `0` | ESS TR voltage (V, ELEC page) |
| `elec.extPwr.hz` | float | output | read | `0` | EXT PWR frequency (Hz, ELEC page) |
| `elec.extPwr.volts` | float | output | read | `0` | EXT PWR voltage (V, ELEC page) |
| `elec.gen1.hz` | float | output | read | `0` | GEN 1 frequency (Hz, ELEC page) |
| `elec.gen1.loadPercent` | float | output | read | `0` | GEN 1 load (%, ELEC page) |
| `elec.gen1.volts` | float | output | read | `0` | GEN 1 voltage (V, ELEC page) |
| `elec.gen2.hz` | float | output | read | `0` | GEN 2 frequency (Hz, ELEC page) |
| `elec.gen2.loadPercent` | float | output | read | `0` | GEN 2 load (%, ELEC page) |
| `elec.gen2.volts` | float | output | read | `0` | GEN 2 voltage (V, ELEC page) |
| `elec.statInv.hz` | float | output | read | `0` | STAT INV frequency (Hz, ELEC page) |
| `elec.statInv.volts` | float | output | read | `0` | STAT INV voltage (V, ELEC page) |
| `elec.tr1.amps` | float | output | read | `0` | TR 1 current (A, ELEC page) |
| `elec.tr1.volts` | float | output | read | `0` | TR 1 voltage (V, ELEC page) |
| `elec.tr2.amps` | float | output | read | `0` | TR 2 current (A, ELEC page) |
| `elec.tr2.volts` | float | output | read | `0` | TR 2 voltage (V, ELEC page) |

## Electrical contactors

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `elec.contactor.acEssFeedAltn` | bool | output | read | `0` | AC ESS feed contactor from AC BUS 2 (3XC2) closed |
| `elec.contactor.acEssFeedNormal` | bool | output | read | `0` | AC ESS feed contactor from AC BUS 1 (3XC1) closed |
| `elec.contactor.acEssShed` | bool | output | read | `0` | AC ESS SHED contactor (8XH) closed |
| `elec.contactor.apuGlc` | bool | output | read | `0` | APU GEN line contactor (3XS) closed |
| `elec.contactor.bat1` | bool | output | read | `0` | Battery 1 line contactor (6PB1) closed |
| `elec.contactor.bat2` | bool | output | read | `0` | Battery 2 line contactor (6PB2) closed |
| `elec.contactor.btc1` | bool | output | read | `0` | Bus tie contactor 1 (11XU1) closed |
| `elec.contactor.btc2` | bool | output | read | `0` | Bus tie contactor 2 (11XU2) closed |
| `elec.contactor.dcEssShed` | bool | output | read | `0` | DC ESS SHED contactor (8PH) closed |
| `elec.contactor.dcTie1` | bool | output | read | `0` | DC BUS 1 - DC BAT BUS tie contactor (1PC1) closed |
| `elec.contactor.dcTie2` | bool | output | read | `0` | DC BUS 2 - DC BAT BUS tie contactor (1PC2) closed |
| `elec.contactor.emerGenLine` | bool | output | read | `0` | Emergency generator line contactor (2XE) closed |
| `elec.contactor.essDcTie` | bool | output | read | `0` | DC BAT BUS - DC ESS BUS tie contactor (4PC) closed |
| `elec.contactor.essTr` | bool | output | read | `0` | ESS TR contactor (3PE) closed |
| `elec.contactor.extPwr` | bool | output | read | `0` | External power contactor (3XG) closed |
| `elec.contactor.glc1` | bool | output | read | `0` | GEN 1 line contactor (9XU1) closed |
| `elec.contactor.glc2` | bool | output | read | `0` | GEN 2 line contactor (9XU2) closed |
| `elec.contactor.maintBus` | bool | output | read | `0` | Maintenance bus (GND/FLT) contactor (12XX) closed |
| `elec.contactor.statInv` | bool | output | read | `0` | Static inverter contactor (2XB) closed |
| `elec.contactor.statInvToAcEss` | bool | output | read | `0` | AC ESS BUS switching contactor at its static inverter position (15XE) closed |
| `elec.contactor.tr1` | bool | output | read | `0` | TR 1 contactor (5PU1) closed |
| `elec.contactor.tr2` | bool | output | read | `0` | TR 2 contactor (5PU2) closed |

## Engines (parameters)

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `engine1.egtC` | float | output | read | `0` | Engine 1 EGT (°C) |
| `engine1.fuelFlowKgH` | float | output | read | `0` | Engine 1 fuel flow (kg/h) |
| `engine1.nacelleTempC` | float | output | read | `0` | Engine 1 nacelle temperature (°C; ESTIMATED first-order model, as on the ENG SD page) |
| `engine1.oilPressurePsi` | float | output | read | `0` | Engine 1 oil pressure (psi) |
| `engine1.oilQuantityQt` | float | output | read | `0` | Engine 1 oil quantity (qt) |
| `engine1.oilTempC` | float | output | read | `0` | Engine 1 oil temperature (°C) |
| `engine2.egtC` | float | output | read | `0` | Engine 2 EGT (°C) |
| `engine2.fuelFlowKgH` | float | output | read | `0` | Engine 2 fuel flow (kg/h) |
| `engine2.nacelleTempC` | float | output | read | `0` | Engine 2 nacelle temperature (°C; ESTIMATED first-order model, as on the ENG SD page) |
| `engine2.oilPressurePsi` | float | output | read | `0` | Engine 2 oil pressure (psi) |
| `engine2.oilQuantityQt` | float | output | read | `0` | Engine 2 oil quantity (qt) |
| `engine2.oilTempC` | float | output | read | `0` | Engine 2 oil temperature (°C) |

## FADEC (parameters)

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `engine1.fadecPowered` | bool | output | read | `0` | Engine 1 FADEC (ECU / EEC) powered: by the aircraft (ENG FADEC GND PWR, start, the ground timing rules) or its own alternator (N2 above 15 %) |
| `engine1.n1TlaPct` | float | output | read |  | Engine 1 N1 the thrust lever asks for (%; the lever's N1 between the detents, idle N1 at IDLE, reverse not included; NaN when its FADEC is not powered or IAE in N1 unrated mode) |
| `engine2.fadecPowered` | bool | output | read | `0` | Engine 2 FADEC (ECU / EEC) powered: by the aircraft (ENG FADEC GND PWR, start, the ground timing rules) or its own alternator (N2 above 15 %) |
| `engine2.n1TlaPct` | float | output | read |  | Engine 2 N1 the thrust lever asks for (%; the lever's N1 between the detents, idle N1 at IDLE, reverse not included; NaN when its FADEC is not powered or IAE in N1 unrated mode) |
| `fadec.n1LimitPct` | float | output | read |  | N1 limit of fadec.thrustLimitMode (%; NaN with no FADEC powered, in MREV or none). IAE in EPR mode: the E/WD shows the EPR equivalent of this limit |
| `fadec.thrustLimitMode` | int | output | read | `0` | FADEC thrust limit mode (E/WD): 0 none (no FADEC powered, or IAE in N1 unrated mode on both engines), 1 TOGA, 2 FLX, 3 CLB, 4 MCT, 5 MREV; the higher of the two FADECs |

## Failures / ADIRS

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.adirs.adr1AltFrozen` | bool | failure | write | `0` | ADR 1 static pressure measurement frozen, undetected: altitude frozen, CAS / Mach erroneous |
| `failures.adirs.adr1Fault` | bool | failure | write | `0` | ADR 1 fault (detected: FAULT light and ECAM caution) |
| `failures.adirs.adr1SpeedError` | bool | failure | write | `0` | ADR 1 airspeed erroneous, undetected (Value: kt CAS error, default -30): unreliable speed / ADR DISAGREE |
| `failures.adirs.adr2AltFrozen` | bool | failure | write | `0` | ADR 2 static pressure measurement frozen, undetected: altitude frozen, CAS / Mach erroneous |
| `failures.adirs.adr2Fault` | bool | failure | write | `0` | ADR 2 fault (detected: FAULT light and ECAM caution) |
| `failures.adirs.adr2SpeedError` | bool | failure | write | `0` | ADR 2 airspeed erroneous, undetected (Value: kt CAS error, default -30): unreliable speed / ADR DISAGREE |
| `failures.adirs.adr3AltFrozen` | bool | failure | write | `0` | ADR 3 static pressure measurement frozen, undetected: altitude frozen, CAS / Mach erroneous |
| `failures.adirs.adr3Fault` | bool | failure | write | `0` | ADR 3 fault (detected: FAULT light and ECAM caution) |
| `failures.adirs.adr3SpeedError` | bool | failure | write | `0` | ADR 3 airspeed erroneous, undetected (Value: kt CAS error, default -30): unreliable speed / ADR DISAGREE |
| `failures.adirs.aoaCaptFault` | bool | failure | write | `0` | CAPT AOA sensor failed: ADR 1 AOA not available (NAV CAPT AOA FAULT) |
| `failures.adirs.aoaCaptStuck` | bool | failure | write | `0` | CAPT AOA vane stuck (undetected): at its present angle, or at Value degrees (a damaged vane, e.g. 35 for the spurious normal law stall warning); ADR 1 AOA erroneous |
| `failures.adirs.aoaFoFault` | bool | failure | write | `0` | F/O AOA sensor failed: ADR 2 AOA not available (NAV F/O AOA FAULT) |
| `failures.adirs.aoaFoStuck` | bool | failure | write | `0` | F/O AOA vane stuck (undetected): at its present angle, or at Value degrees (a damaged vane, e.g. 35 for the spurious normal law stall warning); ADR 2 AOA erroneous |
| `failures.adirs.aoaStbyFault` | bool | failure | write | `0` | STBY AOA sensor failed: ADR 3 AOA not available (NAV STBY AOA FAULT) |
| `failures.adirs.aoaStbyStuck` | bool | failure | write | `0` | STBY AOA vane stuck (undetected): at its present angle, or at Value degrees (a damaged vane, e.g. 35 for the spurious normal law stall warning); ADR 3 AOA erroneous |
| `failures.adirs.ir1AlignFault` | bool | failure | write | `0` | IR 1 alignment fault: alignment cannot complete (NAV IR NOT ALIGNED) |
| `failures.adirs.ir1AttDrift` | bool | failure | write | `0` | IR 1 attitude drift, undetected (Value: °/min, default 1): pitch and roll errors grow (ATT DISCREPANCY, IR DISAGREE) |
| `failures.adirs.ir1Fault` | bool | failure | write | `0` | IR 1 hard fault: IR lost in every mode (FAULT steady) |
| `failures.adirs.ir1HdgDrift` | bool | failure | write | `0` | IR 1 heading drift, undetected (Value: °/min, default 0.5): heading error grows (HDG DISCREPANCY) |
| `failures.adirs.ir1NavFault` | bool | failure | write | `0` | IR 1 navigation fault: attitude and heading available in ATT (FAULT flashing) |
| `failures.adirs.ir1PosDrift` | bool | failure | write | `0` | IR 1 excessive position drift, undetected (Value: NM/h, default 15): MIX IRS / FM position in IRS only navigation |
| `failures.adirs.ir2AlignFault` | bool | failure | write | `0` | IR 2 alignment fault: alignment cannot complete (NAV IR NOT ALIGNED) |
| `failures.adirs.ir2AttDrift` | bool | failure | write | `0` | IR 2 attitude drift, undetected (Value: °/min, default 1): pitch and roll errors grow (ATT DISCREPANCY, IR DISAGREE) |
| `failures.adirs.ir2Fault` | bool | failure | write | `0` | IR 2 hard fault: IR lost in every mode (FAULT steady) |
| `failures.adirs.ir2HdgDrift` | bool | failure | write | `0` | IR 2 heading drift, undetected (Value: °/min, default 0.5): heading error grows (HDG DISCREPANCY) |
| `failures.adirs.ir2NavFault` | bool | failure | write | `0` | IR 2 navigation fault: attitude and heading available in ATT (FAULT flashing) |
| `failures.adirs.ir2PosDrift` | bool | failure | write | `0` | IR 2 excessive position drift, undetected (Value: NM/h, default 15): MIX IRS / FM position in IRS only navigation |
| `failures.adirs.ir3AlignFault` | bool | failure | write | `0` | IR 3 alignment fault: alignment cannot complete (NAV IR NOT ALIGNED) |
| `failures.adirs.ir3AttDrift` | bool | failure | write | `0` | IR 3 attitude drift, undetected (Value: °/min, default 1): pitch and roll errors grow (ATT DISCREPANCY, IR DISAGREE) |
| `failures.adirs.ir3Fault` | bool | failure | write | `0` | IR 3 hard fault: IR lost in every mode (FAULT steady) |
| `failures.adirs.ir3HdgDrift` | bool | failure | write | `0` | IR 3 heading drift, undetected (Value: °/min, default 0.5): heading error grows (HDG DISCREPANCY) |
| `failures.adirs.ir3NavFault` | bool | failure | write | `0` | IR 3 navigation fault: attitude and heading available in ATT (FAULT flashing) |
| `failures.adirs.ir3PosDrift` | bool | failure | write | `0` | IR 3 excessive position drift, undetected (Value: NM/h, default 15): MIX IRS / FM position in IRS only navigation |
| `failures.adirs.pitotCaptBlocked` | bool | failure | write | `0` | CAPT pitot probe blocked (total pressure frozen) |
| `failures.adirs.pitotCaptObstructed` | bool | failure | write | `0` | CAPT pitot probe obstructed (ice), drain open: total pressure bleeds to static, ADR 1 CAS falls towards 0 (undetected) |
| `failures.adirs.pitotFoBlocked` | bool | failure | write | `0` | F/O pitot probe blocked (total pressure frozen) |
| `failures.adirs.pitotFoObstructed` | bool | failure | write | `0` | F/O pitot probe obstructed (ice), drain open: total pressure bleeds to static, ADR 2 CAS falls towards 0 (undetected) |
| `failures.adirs.pitotStbyBlocked` | bool | failure | write | `0` | STBY pitot probe blocked (total pressure frozen) |
| `failures.adirs.pitotStbyObstructed` | bool | failure | write | `0` | STBY pitot probe obstructed (ice), drain open: total pressure bleeds to static, ADR 3 CAS falls towards 0 (undetected) |
| `failures.adirs.staticCaptBlocked` | bool | failure | write | `0` | CAPT static ports blocked (static pressure frozen) |
| `failures.adirs.staticCaptLFault` | bool | failure | write | `0` | CAPT left static probe (ADM) lost: ADR 1 on the right probe only (NAV L CAPT STATIC FAULT) |
| `failures.adirs.staticCaptRFault` | bool | failure | write | `0` | CAPT right static probe (ADM) lost: ADR 1 on the left probe only (NAV R CAPT STATIC FAULT) |
| `failures.adirs.staticFoBlocked` | bool | failure | write | `0` | F/O static ports blocked (static pressure frozen) |
| `failures.adirs.staticFoLFault` | bool | failure | write | `0` | F/O left static probe (ADM) lost: ADR 2 on the right probe only (NAV L F/O STATIC FAULT) |
| `failures.adirs.staticFoRFault` | bool | failure | write | `0` | F/O right static probe (ADM) lost: ADR 2 on the left probe only (NAV R F/O STATIC FAULT) |
| `failures.adirs.staticStbyBlocked` | bool | failure | write | `0` | STBY static ports blocked (static pressure frozen) |

## Failures / Air conditioning

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.aircond.acsc1LaneA` | bool | failure | write | `0` | Air conditioning system controller 1, lane A failure |
| `failures.aircond.acsc1LaneB` | bool | failure | write | `0` | Air conditioning system controller 1, lane B failure |
| `failures.aircond.acsc2LaneA` | bool | failure | write | `0` | Air conditioning system controller 2, lane A failure |
| `failures.aircond.acsc2LaneB` | bool | failure | write | `0` | Air conditioning system controller 2, lane B failure |
| `failures.aircond.cabFan1` | bool | failure | write | `0` | Cabin recirculation fan 1 failure |
| `failures.aircond.cabFan2` | bool | failure | write | `0` | Cabin recirculation fan 2 failure |
| `failures.aircond.crgAftHeatCtl` | bool | failure | write | `0` | Aft cargo heat controller failure (AFT CRG HEAT FAULT) |
| `failures.aircond.crgAftTrimValve` | bool | failure | write | `0` | Aft cargo trim air valve failed open (AFT CARGO DUCT OVHT with hot air) |
| `failures.aircond.crgFwdHeatCtl` | bool | failure | write | `0` | Forward cargo heat controller failure (FWD CRG HEAT FAULT) |
| `failures.aircond.crgFwdTrimValve` | bool | failure | write | `0` | Forward cargo trim air valve failed open (FWD CARGO DUCT OVHT with hot air) |
| `failures.aircond.hotAirValveClosed` | bool | failure | write | `0` | Hot air pressure regulating valve failed closed |
| `failures.aircond.lavGalleyFan` | bool | failure | write | `0` | Lavatory and galley extraction fan failure |
| `failures.aircond.pack1BypassValve` | bool | failure | write | `0` | Pack 1 bypass valve stuck (regulation degraded) |
| `failures.aircond.pack1Ovht` | bool | failure | write | `0` | Pack 1 overheat (heat exchanger cooling lost) |
| `failures.aircond.pack1ValveClosed` | bool | failure | write | `0` | Pack 1 flow control valve failed closed |
| `failures.aircond.pack2BypassValve` | bool | failure | write | `0` | Pack 2 bypass valve stuck (regulation degraded) |
| `failures.aircond.pack2Ovht` | bool | failure | write | `0` | Pack 2 overheat (heat exchanger cooling lost) |
| `failures.aircond.pack2ValveClosed` | bool | failure | write | `0` | Pack 2 flow control valve failed closed |
| `failures.aircond.trimValveAft` | bool | failure | write | `0` | Aft cabin trim air valve failure (stuck) |
| `failures.aircond.trimValveCkpt` | bool | failure | write | `0` | Cockpit trim air valve failure (stuck) |
| `failures.aircond.trimValveFwd` | bool | failure | write | `0` | Forward cabin trim air valve failure (stuck) |

## Failures / APU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.apu.ecb` | bool | failure | write | `0` | ECB failure |
| `failures.apu.egtOvertemp` | bool | failure | write | `0` | Hot section degradation: EGT 400 °C high |
| `failures.apu.egtThermocouples` | bool | failure | write | `0` | Loss of the EGT thermocouples (automatic shutdown) |
| `failures.apu.flapJammed` | bool | failure | write | `0` | Air intake flap jammed in its present position |
| `failures.apu.fuelPump` | bool | failure | write | `0` | APU fuel pump failure |
| `failures.apu.ignition` | bool | failure | write | `0` | Ignition failure (no light-off) |
| `failures.apu.igv` | bool | failure | write | `0` | Inlet guide vane failure (automatic shutdown) |
| `failures.apu.inletOverheat` | bool | failure | write | `0` | Inlet overheat (automatic shutdown) |
| `failures.apu.noSpeed` | bool | failure | write | `0` | No speed signal (automatic shutdown) |
| `failures.apu.oilFilterClogged` | bool | failure | write | `0` | Clogged oil filter (automatic shutdown) |
| `failures.apu.oilHighTemp` | bool | failure | write | `0` | High oil temperature |
| `failures.apu.oilLowLevel` | bool | failure | write | `0` | Low oil level (advisory) |
| `failures.apu.oilLowPress` | bool | failure | write | `0` | Low oil pressure |
| `failures.apu.oilSystem` | bool | failure | write | `0` | Oil system failure (automatic shutdown) |
| `failures.apu.overcurrent` | bool | failure | write | `0` | Overcurrent (automatic shutdown) |
| `failures.apu.overspeed` | bool | failure | write | `0` | Speed governing failure: runaway to overspeed |
| `failures.apu.overspeedProtection` | bool | failure | write | `0` | Loss of the overspeed protection |
| `failures.apu.reverseFlow` | bool | failure | write | `0` | Load compressor reverse flow |
| `failures.apu.sensor` | bool | failure | write | `0` | ECB sensor failure (automatic shutdown) |
| `failures.apu.slowStart` | bool | failure | write | `0` | Degraded acceleration during start |
| `failures.apu.starter` | bool | failure | write | `0` | Starter motor failure (no torque) |
| `failures.apu.underspeed` | bool | failure | write | `0` | Loss of power: speed cannot be held |

## Failures / ATSU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.atsu.atsu` | bool | failure | write | `0` | ATSU failure (no datalink) |

## Failures / CFDS

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.cfds.cfdiu` | bool | failure | write | `0` | CFDIU main channel failure (CFDS backup mode: on the ground, MCDU 1, SYSTEM REPORT/TEST only) |

## Failures / Circuit breakers

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.cb.10ca1` | bool | failure | write | `0` | C/B 10CA1 AUTO FLT FMGC 1 (49VU B2) tripped |
| `failures.cb.10ca2` | bool | failure | write | `0` | C/B 10CA2 AUTO FLT FMGC 2 (121VU M17) tripped |
| `failures.cb.10cv` | bool | failure | write | `0` | C/B 10CV FLT CTL WTB FLP SYS1 (122VU S7) tripped |
| `failures.cb.10fp` | bool | failure | write | `0` | C/B 10FP ADIRS ADIRU 2 PWR SHED (121VU N11) tripped |
| `failures.cb.10lv` | bool | failure | write | `0` | C/B 10LV STROBE WING STROBE (122VU V5) tripped |
| `failures.cb.10qa` | bool | failure | write | `0` | C/B 10QA FUEL PUMPS 2 R CTL & L IND (121VU R29) tripped |
| `failures.cb.10tw` | bool | failure | write | `0` | C/B 10TW CFDS TEST PLUG 2 (121VU J20) tripped |
| `failures.cb.10wt1` | bool | failure | write | `0` | C/B 10WT1 EIS DMC 1 SPLY (49VU E11) tripped |
| `failures.cb.10wt2` | bool | failure | write | `0` | C/B 10WT2 EIS DMC 2 SPLY (121VU Q8) tripped |
| `failures.cb.10wt3` | bool | failure | write | `0` | C/B 10WT3 EIS DMC 3 SPLY (121VU Q9) tripped |
| `failures.cb.10wv` | bool | failure | write | `0` | C/B 10WV SDAC 26VAC SYNC AC BUS 1 (121VU Q5) tripped |
| `failures.cb.10xe` | bool | failure | write | `0` | C/B 10XE ELEC AC ESS EMER STBY CNTOR (106VU 23) tripped |
| `failures.cb.10xn` | bool | failure | write | `0` | C/B 10XN ELEC BUS2 212XP SPLY (123VU AD3) tripped |
| `failures.cb.110gg` | bool | failure | write | `0` | C/B 110GG BRAKES ABCU HOT BUS SPLY (121VU P30) tripped |
| `failures.cb.11ca1` | bool | failure | write | `0` | C/B 11CA1 AUTO FLT MCDU 1 (49VU B1) tripped |
| `failures.cb.11ca2` | bool | failure | write | `0` | C/B 11CA2 AUTO FLT MCDU 2 (121VU N20) tripped |
| `failures.cb.11ca3` | bool | failure | write | `0` | C/B 11CA3 AUTO FLT MCDU 2 SPLY 2 (121VU N21) tripped |
| `failures.cb.11cv` | bool | failure | write | `0` | C/B 11CV FLIGHT CONTROLS WTB SLT SYS 2 (121VU P19) tripped |
| `failures.cb.11da1` | bool | failure | write | `0` | C/B 11DA1 ANTI ICE P2/T2 ENG 1 (122VU Z10) tripped |
| `failures.cb.11da2` | bool | failure | write | `0` | C/B 11DA2 ANTI ICE P2/T2 ENG 2 (122VU Y10) tripped |
| `failures.cb.11hg` | bool | failure | write | `0` | C/B 11HG AIR COND RECIRC FAN R CTL (122VU W20) tripped |
| `failures.cb.11ls` | bool | failure | write | `0` | C/B 11LS LIGHTING AVNCS COMPT OUT 28VDC (122VU Z8) tripped |
| `failures.cb.11pb` | bool | failure | write | `0` | C/B 11PB ELEC BAT BUS 301PP SPLY (125VU CC1) tripped |
| `failures.cb.11qa` | bool | failure | write | `0` | C/B 11QA FUEL L WING TK PUMP1 STBY SPLY (123VU AD12) tripped |
| `failures.cb.11wq` | bool | failure | write | `0` | C/B 11WQ AIR COND SDCU CHAN 1 (49VU C6) tripped |
| `failures.cb.11wt1` | bool | failure | write | `0` | C/B 11WT1 EIS PFD CAPT SPLY (49VU E3) tripped |
| `failures.cb.11wt2` | bool | failure | write | `0` | C/B 11WT2 EIS PFD F/O SPLY (121VU R3) tripped |
| `failures.cb.11xe` | bool | failure | write | `0` | C/B 11XE ELEC EMER GEN AUTO 1 (122VU Z25) tripped |
| `failures.cb.11xg` | bool | failure | write | `0` | C/B 11XG ELEC EXT PWR CTL (122VU X29) tripped |
| `failures.cb.12cv` | bool | failure | write | `0` | C/B 12CV FLIGHT CONTROLS WTB FLP SYS 2 (121VU P20) tripped |
| `failures.cb.12fn` | bool | failure | write | `0` | C/B 12FN NAV VOR/ADF/ DME RMI (49VU F13) tripped |
| `failures.cb.12ls` | bool | failure | write | `0` | C/B 12LS LIGHTING AVNCS COMPT OUT 115VAC (122VU Z9) tripped |
| `failures.cb.12mc` | bool | failure | write | `0` | C/B 12MC GALLEY AFT GALLEY FEEDER B (123VU AD9) tripped |
| `failures.cb.12pb1` | bool | failure | write | `0` | C/B 12PB1 ELEC HOT BUS 701PP SPLY (105VU 25) tripped |
| `failures.cb.12pb2` | bool | failure | write | `0` | C/B 12PB2 ELEC HOT BUS 702PP SPLY (105VU 15) tripped |
| `failures.cb.12qa` | bool | failure | write | `0` | C/B 12QA FUEL R WING TK PUMP1 STBY SPLY (123VU AE12) tripped |
| `failures.cb.12wq` | bool | failure | write | `0` | C/B 12WQ AIR COND SDCU CHAN2 (122VU T18) tripped |
| `failures.cb.12wt1` | bool | failure | write | `0` | C/B 12WT1 EIS ND CAPT SPLY (49VU E1) tripped |
| `failures.cb.12wt2` | bool | failure | write | `0` | C/B 12WT2 EIS ND F/O SPLY (121VU R4) tripped |
| `failures.cb.12wv` | bool | failure | write | `0` | C/B 12WV SDAC 1&2 28VDC ESS BUS (49VU F5) tripped |
| `failures.cb.12xb` | bool | failure | write | `0` | C/B 12XB ELEC STAT INV BUS SPLY (105VU 18) tripped |
| `failures.cb.12xg` | bool | failure | write | `0` | C/B 12XG ELEC EXT PWR CKPT AVAIL LT (122VU X28) tripped |
| `failures.cb.13ca` | bool | failure | write | `0` | C/B 13CA AUTO FLT STICK LOCK (121VU N16) tripped |
| `failures.cb.13wn` | bool | failure | write | `0` | C/B 13WN SLIDES ARM & WARN GND (121VU P10) tripped |
| `failures.cb.13wt1` | bool | failure | write | `0` | C/B 13WT1 EIS ECAM UPPER SPLY (49VU E5) tripped |
| `failures.cb.13wt2` | bool | failure | write | `0` | C/B 13WT2 EIS ECAM LOWER SPLY (121VU R11) tripped |
| `failures.cb.13xg` | bool | failure | write | `0` | C/B 13XG ELEC LT CTL (49VU H10) tripped |
| `failures.cb.14ca` | bool | failure | write | `0` | C/B 14CA AUTO FLT RUDDER ARTF FEEL (121VU N17) tripped |
| `failures.cb.14cc1` | bool | failure | write | `0` | C/B 14CC1 AUTO FLT FAC 1 26VAC (49VU B3) tripped |
| `failures.cb.14cc2` | bool | failure | write | `0` | C/B 14CC2 AUTO FLT FAC 2 26VAC (121VU M18) tripped |
| `failures.cb.14fn` | bool | failure | write | `0` | C/B 14FN NAV 14FN (121VU K4) tripped |
| `failures.cb.14mc` | bool | failure | write | `0` | C/B 14MC GALLEY AFT GALLEY FEEDER E (123VU AF9) tripped |
| `failures.cb.14pc` | bool | failure | write | `0` | C/B 14PC ELEC DC BUS TIE 1 FAULT (122VU U24) tripped |
| `failures.cb.14wt1` | bool | failure | write | `0` | C/B 14WT1 EIS DMC 3 STBY SPLY (49VU E10) tripped |
| `failures.cb.14wv` | bool | failure | write | `0` | C/B 14WV SDAC 1 & 2 BUS 1 28VDC (121VU P4) tripped |
| `failures.cb.14xb` | bool | failure | write | `0` | C/B 14XB ELEC STAT INV CNTOR CTL (105VU 17) tripped |
| `failures.cb.14xu` | bool | failure | write | `0` | C/B 14XU ELEC GEN 1 OFF BTC 2 (122VU T30) tripped |
| `failures.cb.150rh` | bool | failure | write | `0` | C/B 150RH COM CIDS COM DIR ESS 1 (49VU G1) tripped |
| `failures.cb.151rh` | bool | failure | write | `0` | C/B 151RH COM CIDS DIR/ NORM 1 (121VU M5) tripped |
| `failures.cb.153rh` | bool | failure | write | `0` | C/B 153RH COM CIDS DEU B ESS (49VU G3) tripped |
| `failures.cb.154rh` | bool | failure | write | `0` | C/B 154RH COM DEU A ESS LINE 1 (49VU G4) tripped |
| `failures.cb.155rh` | bool | failure | write | `0` | C/B 155RH COM DEU A ESS LINE 2 (49VU G5) tripped |
| `failures.cb.156rh` | bool | failure | write | `0` | C/B 156RH COM CIDS DIR/ NORM 2 (121VU M6) tripped |
| `failures.cb.157rh` | bool | failure | write | `0` | C/B 157RH COM CIDS COM DIR ESS 2 (49VU G2) tripped |
| `failures.cb.15cc` | bool | failure | write | `0` | C/B 15CC AUTO FLT RUDDER TRIM IND (121VU M20) tripped |
| `failures.cb.15ce1` | bool | failure | write | `0` | C/B 15CE1 FLIGHT CONTROLS ELAC 1 NORM SPLY (49VU B11) tripped |
| `failures.cb.15ce2` | bool | failure | write | `0` | C/B 15CE2 FLIGHT CONTROLS ELAC 2 NORM SPLY (121VU R20) tripped |
| `failures.cb.15pc` | bool | failure | write | `0` | C/B 15PC ELEC AC ESS BUS EMER CNTOR (106VU 21) tripped |
| `failures.cb.15wn` | bool | failure | write | `0` | C/B 15WN SLIDES ARM & WARN FLT (121VU P11) tripped |
| `failures.cb.15wt` | bool | failure | write | `0` | C/B 15WT EIS ECAM CTL PNL (49VU E12) tripped |
| `failures.cb.15xu` | bool | failure | write | `0` | C/B 15XU ELEC GEN 2 OFF BTC 1 SPLY (122VU T29) tripped |
| `failures.cb.161rh` | bool | failure | write | `0` | C/B 161RH COM PROG & TST PNL (121VU M7) tripped |
| `failures.cb.162rh` | bool | failure | write | `0` | C/B 162RH COM DEU B NORM (121VU M8) tripped |
| `failures.cb.163rh` | bool | failure | write | `0` | C/B 163RH COM DEU A L FWD (121VU M9) tripped |
| `failures.cb.164rh` | bool | failure | write | `0` | C/B 164RH COM DEU A R FWD (121VU M10) tripped |
| `failures.cb.165rh` | bool | failure | write | `0` | C/B 165RH COM DEU A L MID (121VU M11) tripped |
| `failures.cb.166rh` | bool | failure | write | `0` | C/B 166RH COM DEU A R MID (121VU M12) tripped |
| `failures.cb.167rh` | bool | failure | write | `0` | C/B 167RH COM DEU A L AFT (121VU M13) tripped |
| `failures.cb.168rh` | bool | failure | write | `0` | C/B 168RH COM DEU A R AFT (121VU M14) tripped |
| `failures.cb.16ce1` | bool | failure | write | `0` | C/B 16CE1 FLT CTL ELAC 1 STBY SPLY (105VU 21) tripped |
| `failures.cb.16ce2` | bool | failure | write | `0` | C/B 16CE2 FLT CTL ELAC 2 STBY SPLY (105VU 11) tripped |
| `failures.cb.16fn` | bool | failure | write | `0` | C/B 16FN NAV STBY ALTM (49VU F14) tripped |
| `failures.cb.16mc` | bool | failure | write | `0` | C/B 16MC GALLEY FWD GALLEY FEEDER F (123VU AC10) tripped |
| `failures.cb.1701gk` | bool | failure | write | `0` | C/B 1701GK HYDRAULIC G HYD PUMP ENG1 CTL (121VU R35) tripped |
| `failures.cb.1702gk` | bool | failure | write | `0` | C/B 1702GK HYDRAULIC G HYD PUMP ENG1 MONG (121VU R34) tripped |
| `failures.cb.1703gk` | bool | failure | write | `0` | C/B 1703GK HYD FIRE VALVE G ENG 1 (49VU C13) tripped |
| `failures.cb.170rh` | bool | failure | write | `0` | C/B 170RH COM FWD ATTND PNL (121VU Q14) tripped |
| `failures.cb.17wt1` | bool | failure | write | `0` | C/B 17WT1 EIS RLY BOX CAPT (49VU E8) tripped |
| `failures.cb.17wt2` | bool | failure | write | `0` | C/B 17WT2 EIS RLY BOX F/O (121VU R7) tripped |
| `failures.cb.17xn1` | bool | failure | write | `0` | C/B 17XN1 ELEC AC BUS 1 CTL (122VU V25) tripped |
| `failures.cb.17xn2` | bool | failure | write | `0` | C/B 17XN2 ELEC AC BUS 2 CTL (122VU V27) tripped |
| `failures.cb.1801gl` | bool | failure | write | `0` | C/B 1801GL HYDRAULIC SOL VALVES G/Y PTU (121VU N34) tripped |
| `failures.cb.1831gq` | bool | failure | write | `0` | C/B 1831GQ HYDRAULIC HYD QTY IND (121VU P35) tripped |
| `failures.cb.1832gq` | bool | failure | write | `0` | C/B 1832GQ HYDRAULIC LOW LVL IND (121VU N32) tripped |
| `failures.cb.1841gn` | bool | failure | write | `0` | C/B 1841GN HYD HYD PRESS XMTR (49VU C11) tripped |
| `failures.cb.1881gp` | bool | failure | write | `0` | C/B 1881GP HYDRAULIC SOL VALVES G/Y/B LEAK TST (121VU N35) tripped |
| `failures.cb.18pc` | bool | failure | write | `0` | C/B 18PC ELEC DC BUS TIE CONFIG (122VU W31) tripped |
| `failures.cb.19ce1` | bool | failure | write | `0` | C/B 19CE1 FLIGHT CONTROLS THS ACTR MOT 1 (121VU Q16) tripped |
| `failures.cb.19ce2` | bool | failure | write | `0` | C/B 19CE2 FLIGHT CONTROLS THS ACTR MOT 2 (49VU B9) tripped |
| `failures.cb.19ce3` | bool | failure | write | `0` | C/B 19CE3 FLIGHT CONTROLS THS ACTR MOT 3 (121VU Q17) tripped |
| `failures.cb.1cn` | bool | failure | write | `0` | C/B 1CN FLIGHT CONTROLS SLT FLP 1 POS IND (49VU B12) tripped |
| `failures.cb.1da1` | bool | failure | write | `0` | C/B 1DA1 ANTI ICE TAT 1 (122VU Z12) tripped |
| `failures.cb.1da2` | bool | failure | write | `0` | C/B 1DA2 ANTI ICE TAT 2 (122VU Y15) tripped |
| `failures.cb.1db1` | bool | failure | write | `0` | C/B 1DB1 ANTI ICE RAIN RPLNT CAPT (49VU D1) tripped |
| `failures.cb.1db2` | bool | failure | write | `0` | C/B 1DB2 ANTI ICE RAIN RPLNT (122VU W11) tripped |
| `failures.cb.1dg1` | bool | failure | write | `0` | C/B 1DG1 ANTI ICE L WSHLD (123VU AF10) tripped |
| `failures.cb.1dg2` | bool | failure | write | `0` | C/B 1DG2 ANTI ICE R WSHIELD (123VU AF3) tripped |
| `failures.cb.1dl` | bool | failure | write | `0` | C/B 1DL ANTI ICE WING MONG (49VU C1) tripped |
| `failures.cb.1dn1` | bool | failure | write | `0` | C/B 1DN1 ANTI ICE ENG 1 (122VU X10) tripped |
| `failures.cb.1dn2` | bool | failure | write | `0` | C/B 1DN2 ANTI ICE ENG 2 (122VU W10) tripped |
| `failures.cb.1dr` | bool | failure | write | `0` | C/B 1DR ANTI ICE FOOT WARMER (122VU X15) tripped |
| `failures.cb.1eg1` | bool | failure | write | `0` | C/B 1EG1 ENGINE ENG1 REV LOCK (121VU N44) tripped |
| `failures.cb.1eg2` | bool | failure | write | `0` | C/B 1EG2 ENGINE ENG2 REV LOCK (121VU N45) tripped |
| `failures.cb.1en1` | bool | failure | write | `0` | C/B 1EN1 ENGINE ENG1 OIL QTY & REV SNSR B (121VU N39) tripped |
| `failures.cb.1en2` | bool | failure | write | `0` | C/B 1EN2 ENGINE ENG2 OIL QTY & REV SNSR B (121VU N41) tripped |
| `failures.cb.1ev` | bool | failure | write | `0` | C/B 1EV ENGINE ENG1&2 EVMU (121VU R44) tripped |
| `failures.cb.1ga` | bool | failure | write | `0` | C/B 1GA L/G LGCIU SYS 1 (49VU C9) tripped |
| `failures.cb.1gg` | bool | failure | write | `0` | C/B 1GG BRAKING & STEERING SYS1 CTL (121VU M34) tripped |
| `failures.cb.1gs` | bool | failure | write | `0` | C/B 1GS BRAKES BRK FAN WHEELS 1&2 (121VU L32) tripped |
| `failures.cb.1gv` | bool | failure | write | `0` | C/B 1GV BRAKES TYRE PRESS (121VU M31) tripped |
| `failures.cb.1gw` | bool | failure | write | `0` | C/B 1GW BRAKES BRK TEMP DET UNIT (121VU M37) tripped |
| `failures.cb.1hb` | bool | failure | write | `0` | C/B 1HB AIR COND FLOW CTL & IND 1 (49VU D7) tripped |
| `failures.cb.1hg` | bool | failure | write | `0` | C/B 1HG AIR COND RECIRC FAN L SPLY (122VU X18) tripped |
| `failures.cb.1hh` | bool | failure | write | `0` | C/B 1HH AIR COND PACK TEMP CTL SYS1 1 115VAC (122VU X22) tripped |
| `failures.cb.1hk` | bool | failure | write | `0` | C/B 1HK AIR COND ZONE TEMP CTL 115VAC SYS1 (122VU V17) tripped |
| `failures.cb.1hl` | bool | failure | write | `0` | C/B 1HL AIR COND CAB PRESS CTL 1 (49VU D9) tripped |
| `failures.cb.1hq` | bool | failure | write | `0` | C/B 1HQ AVNCS VENT BLOWER FAN (123VU AD10) tripped |
| `failures.cb.1ht` | bool | failure | write | `0` | C/B 1HT OXYGEN CREW OXY SPLY (49VU HA1) tripped |
| `failures.cb.1hv` | bool | failure | write | `0` | C/B 1HV AIR BLEED X FEED VALVE NORM (122VU Z20) tripped |
| `failures.cb.1hz` | bool | failure | write | `0` | C/B 1HZ AIR COND RAM AIR INLET (49VU D10) tripped |
| `failures.cb.1jh` | bool | failure | write | `0` | C/B 1JH ENGINE IGN 1&2 SYS A (49VU A3) tripped |
| `failures.cb.1kc1` | bool | failure | write | `0` | C/B 1KC1 ENGINE HP FUEL SOV 1 (49VU A1) tripped |
| `failures.cb.1kc2` | bool | failure | write | `0` | C/B 1KC2 ENGINE HP FUEL SOV 2 (49VU A2) tripped |
| `failures.cb.1kd` | bool | failure | write | `0` | C/B 1KD APU ECB SPLY (121VU L41) tripped |
| `failures.cb.1kt` | bool | failure | write | `0` | C/B 1KT APU APU OIL OIL HTR SPLY (121VU K41) tripped |
| `failures.cb.1la` | bool | failure | write | `0` | C/B 1LA NAV NAV1 LT (122VU T3) tripped |
| `failures.cb.1lb` | bool | failure | write | `0` | C/B 1LB LANDING LT LDG LT L SPLY (122VU T4) tripped |
| `failures.cb.1lc1` | bool | failure | write | `0` | C/B 1LC1 EXT LT RWY TURN OFF L (122VU W6) tripped |
| `failures.cb.1lc2` | bool | failure | write | `0` | C/B 1LC2 EXT LT RWY TURN OFF R (122VU W5) tripped |
| `failures.cb.1le` | bool | failure | write | `0` | C/B 1LE LIGHTING EMER LT CKPT DOME (49VU H8) tripped |
| `failures.cb.1lf` | bool | failure | write | `0` | C/B 1LF LIGHTING ICE & STBY COMP LT (49VU H4) tripped |
| `failures.cb.1ll` | bool | failure | write | `0` | C/B 1LL LIGHTING WHL WELL LTG OUT (122VU X7) tripped |
| `failures.cb.1lr` | bool | failure | write | `0` | C/B 1LR EXT LT TAXI & TAKE OFF TAXI (122VU W8) tripped |
| `failures.cb.1ls` | bool | failure | write | `0` | C/B 1LS LIGHTING AVNCS COMPT DOME (122VU Z7) tripped |
| `failures.cb.1lv` | bool | failure | write | `0` | C/B 1LV BEACON BEACON UPPER (122VU U6) tripped |
| `failures.cb.1lx` | bool | failure | write | `0` | C/B 1LX EXT LT WING & ENG SCAN R (122VU W3) tripped |
| `failures.cb.1ly` | bool | failure | write | `0` | C/B 1LY LOGO LOGO R (122VU V2) tripped |
| `failures.cb.1mc` | bool | failure | write | `0` | C/B 1MC GALLEY FWD GALLEY FEEDER C (123VU AE10) tripped |
| `failures.cb.1mj` | bool | failure | write | `0` | C/B 1MJ DOORS CARGO (122VU T12) tripped |
| `failures.cb.1mq` | bool | failure | write | `0` | C/B 1MQ DOORS PAX MONG (122VU T13) tripped |
| `failures.cb.1ms1` | bool | failure | write | `0` | C/B 1MS1 COCKPIT SEATS CAPT SEAT CTL (122VU U11) tripped |
| `failures.cb.1ms2` | bool | failure | write | `0` | C/B 1MS2 COCKPIT SEATS F/O SEAT CTL (122VU U14) tripped |
| `failures.cb.1ph` | bool | failure | write | `0` | C/B 1PH ELEC EMER SHED CNTOR SPLY (106VU 22) tripped |
| `failures.cb.1pn1` | bool | failure | write | `0` | C/B 1PN1 ELEC 101PP SPLY (125VU CD1) tripped |
| `failures.cb.1pn2` | bool | failure | write | `0` | C/B 1PN2 ELEC 202PP SPLY (124VU BG1) tripped |
| `failures.cb.1pr` | bool | failure | write | `0` | C/B 1PR ELEC REFLNG ON BAT (122VU U28) tripped |
| `failures.cb.1px` | bool | failure | write | `0` | C/B 1PX ELEC SVCE 601PP/ 602PP SPLY (124VU BB1) tripped |
| `failures.cb.1qa` | bool | failure | write | `0` | C/B 1QA FUEL L WING TK PUMP1 SPLY (121VU N23) tripped |
| `failures.cb.1qc` | bool | failure | write | `0` | C/B 1QC APU FUEL BLOW OFF CTL (121VU K39) tripped |
| `failures.cb.1qe` | bool | failure | write | `0` | C/B 1QE FUEL X FEED VALVE MOT2 (121VU M24) tripped |
| `failures.cb.1qf` | bool | failure | write | `0` | C/B 1QF APU FUEL LP VALVE CTL (121VU M40) tripped |
| `failures.cb.1qg` | bool | failure | write | `0` | C/B 1QG FUEL LP VALVE MOT1 ENG 1 (49VU A8) tripped |
| `failures.cb.1qj` | bool | failure | write | `0` | C/B 1QJ FUEL HI LVL SPLY (121VU L25) tripped |
| `failures.cb.1qp` | bool | failure | write | `0` | C/B 1QP FUEL XFR VALVE 1 WING L (49VU A10) tripped |
| `failures.cb.1qt` | bool | failure | write | `0` | C/B 1QT FUEL FQI CHAN 1 (49VU A13) tripped |
| `failures.cb.1qu` | bool | failure | write | `0` | C/B 1QU FUEL RFL/DFL XFR DEFUEL VALVE (121VU L23) tripped |
| `failures.cb.1re1` | bool | failure | write | `0` | C/B 1RE1 COM HF 1 (49VU HA14) tripped |
| `failures.cb.1re2` | bool | failure | write | `0` | C/B 1RE2 COM HF 2 (121VU L13) tripped |
| `failures.cb.1rp1` | bool | failure | write | `0` | C/B 1RP1 NAV ADF 1 (49VU H14) tripped |
| `failures.cb.1rp2` | bool | failure | write | `0` | C/B 1RP2 NAV ADF 2 (121VU K2) tripped |
| `failures.cb.1rt1` | bool | failure | write | `0` | C/B 1RT1 NAV ILS 1 (49VU G12) tripped |
| `failures.cb.1rt2` | bool | failure | write | `0` | C/B 1RT2 NAV ILS 2 (121VU K9) tripped |
| `failures.cb.1sa1` | bool | failure | write | `0` | C/B 1SA1 NAV RAD ALTM 1 (121VU K11) tripped |
| `failures.cb.1sa2` | bool | failure | write | `0` | C/B 1SA2 NAV RAD ALTM 2 (121VU K12) tripped |
| `failures.cb.1sd1` | bool | failure | write | `0` | C/B 1SD1 NAV DME 1 (49VU G14) tripped |
| `failures.cb.1sd2` | bool | failure | write | `0` | C/B 1SD2 NAV DME 2 (121VU K6) tripped |
| `failures.cb.1we1` | bool | failure | write | `0` | C/B 1WE1 ENGINE FIRE EXTIG BTL1 SQUIB A (121VU Q43) tripped |
| `failures.cb.1we2` | bool | failure | write | `0` | C/B 1WE2 ENGINE FIRE EXTIG BTL2 SQUIB A (121VU Q41) tripped |
| `failures.cb.1wf` | bool | failure | write | `0` | C/B 1WF APU FIRE EXTIG SQUIB A (121VU L38) tripped |
| `failures.cb.1wg` | bool | failure | write | `0` | C/B 1WG APU FIRE & OVHT DET LOOP A (121VU L43) tripped |
| `failures.cb.1wl` | bool | failure | write | `0` | C/B 1WL LIGHTING EMER LT CABIN (49VU H5) tripped |
| `failures.cb.1wr` | bool | failure | write | `0` | C/B 1WR OXYGEN PAX CTL & WARN (49VU HA2) tripped |
| `failures.cb.1wx` | bool | failure | write | `0` | C/B 1WX CARGO FIRE CARGO FIRE EXTIG (122VU T19) tripped |
| `failures.cb.1xa` | bool | failure | write | `0` | C/B 1XA GALLEY GALLEY CTL (122VU S26) tripped |
| `failures.cb.1xc` | bool | failure | write | `0` | C/B 1XC ELEC AC ESS BUS ON BUS1 (123VU AC12) tripped |
| `failures.cb.1xh` | bool | failure | write | `0` | C/B 1XH ELEC AC SHED ESS CNTOR CTL (106VU 25) tripped |
| `failures.cb.1xn1` | bool | failure | write | `0` | C/B 1XN1 ELEC BUS1 101XP SPLY (123VU AD11) tripped |
| `failures.cb.1xn2` | bool | failure | write | `0` | C/B 1XN2 ELEC BUS2 202XP SPLY (123VU AD2) tripped |
| `failures.cb.1xt` | bool | failure | write | `0` | C/B 1XT ELEC IDG 1 DISC (122VU T24) tripped |
| `failures.cb.1xx` | bool | failure | write | `0` | C/B 1XX ELEC TR2/SVCE BUS2 SPLY (123VU AB8) tripped |
| `failures.cb.20ce1` | bool | failure | write | `0` | C/B 20CE1 FLIGHT CONTROLS FCDC 1 SPLY (49VU B10) tripped |
| `failures.cb.20ce2` | bool | failure | write | `0` | C/B 20CE2 FLIGHT CONTROLS FCDC 2 SPLY (121VU Q20) tripped |
| `failures.cb.21ce1` | bool | failure | write | `0` | C/B 21CE1 FLIGHT CONTROLS SEC 1 NORM SPLY (49VU B8) tripped |
| `failures.cb.21ce2` | bool | failure | write | `0` | C/B 21CE2 FLIGHT CONTROLS SEC 2 SPLY (121VU Q18) tripped |
| `failures.cb.21ce3` | bool | failure | write | `0` | C/B 21CE3 FLIGHT CONTROLS SEC 3 SPLY (121VU Q19) tripped |
| `failures.cb.21hh` | bool | failure | write | `0` | C/B 21HH AIR COND PACK TEMP CTL SYS1 2 115VAC (122VU W22) tripped |
| `failures.cb.21wt1` | bool | failure | write | `0` | C/B 21WT1 EIS DMC 1 SWTG (49VU E9) tripped |
| `failures.cb.21wt2` | bool | failure | write | `0` | C/B 21WT2 EIS DMC 2 SWTG (121VU R8) tripped |
| `failures.cb.21wt3` | bool | failure | write | `0` | C/B 21WT3 EIS DMC 3 SWTG (49VU E7) tripped |
| `failures.cb.22ce` | bool | failure | write | `0` | C/B 22CE FLT CTL SEC 1 STBY SPLY (105VU 22) tripped |
| `failures.cb.22hh` | bool | failure | write | `0` | C/B 22HH AIR COND PACK TEMP CTL SYS2 2 115VAC (122VU Y20) tripped |
| `failures.cb.22wt1` | bool | failure | write | `0` | C/B 22WT1 EIS PFD CAPT SWTG (49VU E4) tripped |
| `failures.cb.22wt2` | bool | failure | write | `0` | C/B 22WT2 EIS PFD F/O SWTG (121VU R5) tripped |
| `failures.cb.23fn` | bool | failure | write | `0` | C/B 23FN NAV STBY INST BAT (105VU 28) tripped |
| `failures.cb.23hh` | bool | failure | write | `0` | C/B 23HH AIR COND PACK TEMP CTL SYS1 2 28VDC (122VU W21) tripped |
| `failures.cb.23wt1` | bool | failure | write | `0` | C/B 23WT1 EIS ND CAPT SWTG (49VU E2) tripped |
| `failures.cb.23wt2` | bool | failure | write | `0` | C/B 23WT2 EIS ND F/O SWTG (121VU R6) tripped |
| `failures.cb.23xg` | bool | failure | write | `0` | C/B 23XG ELEC EXT PWR EGIU1 115VAC (123VU AA7) tripped |
| `failures.cb.23xs` | bool | failure | write | `0` | C/B 23XS ELEC APU GEN EGIU2 115VAC (123VU AA8) tripped |
| `failures.cb.23xu1` | bool | failure | write | `0` | C/B 23XU1 ELEC GEN1 EGIU1 115VAC (123VU AF12) tripped |
| `failures.cb.23xu2` | bool | failure | write | `0` | C/B 23XU2 ELEC GEN2 EGIU2 115VAC (123VU AF1) tripped |
| `failures.cb.24hh` | bool | failure | write | `0` | C/B 24HH AIR COND PACK TEMP CTL SYS2 2 28VDC (122VU Y21) tripped |
| `failures.cb.24wt1` | bool | failure | write | `0` | C/B 24WT1 EIS ECAM UPPER SWTG (49VU E6) tripped |
| `failures.cb.24wt2` | bool | failure | write | `0` | C/B 24WT2 EIS ECAM LOWER SWTG (121VU R10) tripped |
| `failures.cb.24xu1` | bool | failure | write | `0` | C/B 24XU1 ELEC EGIU 1 GEN 1 28VDC (122VU Z30) tripped |
| `failures.cb.24xu2` | bool | failure | write | `0` | C/B 24XU2 ELEC EGIU 2 GEN 2 28VDC (122VU Y30) tripped |
| `failures.cb.26lp` | bool | failure | write | `0` | C/B 26LP LIGHTING ANN LT SPLY XFMR BUS1 (122VU X4) tripped |
| `failures.cb.26xu1` | bool | failure | write | `0` | C/B 26XU1 ELEC EGIU 1 EXT PWR 28VDC (122VU Z31) tripped |
| `failures.cb.26xu2` | bool | failure | write | `0` | C/B 26XU2 ELEC EGIU 2 APU GEN 28VDC (122VU Y31) tripped |
| `failures.cb.2701gj` | bool | failure | write | `0` | C/B 2701GJ HYD B HYD ELEC PUMP (123VU AB9) tripped |
| `failures.cb.2702gj` | bool | failure | write | `0` | C/B 2702GJ HYD HYD PWR B WARN & CTL (49VU C12) tripped |
| `failures.cb.27lp` | bool | failure | write | `0` | C/B 27LP LIGHTING ANN LT SPLY XFMR BUS2 (122VU X5) tripped |
| `failures.cb.27wv` | bool | failure | write | `0` | C/B 27WV ELEC EMER GEN REF (106VU 14) tripped |
| `failures.cb.2801ge` | bool | failure | write | `0` | C/B 2801GE HYD RAT CTL (49VU D14) tripped |
| `failures.cb.2803ge` | bool | failure | write | `0` | C/B 2803GE HYDRAULIC RAT EXTN SOL1 (121VU P33) tripped |
| `failures.cb.28lp` | bool | failure | write | `0` | C/B 28LP LIGHTING ANN LT SPLY XFMR STAT INV (122VU X3) tripped |
| `failures.cb.29lp` | bool | failure | write | `0` | C/B 29LP LIGHTING XFMR 115V.5V ESS BUS (49VU H3) tripped |
| `failures.cb.29qa` | bool | failure | write | `0` | C/B 29QA FUEL CTR TK PUMP1 SPLY (121VU P23) tripped |
| `failures.cb.2cn` | bool | failure | write | `0` | C/B 2CN FLIGHT CONTROLS SLT FLP 2 POS IND (121VU P16) tripped |
| `failures.cb.2da1` | bool | failure | write | `0` | C/B 2DA1 ANTI ICE PHC 1 (49VU D3) tripped |
| `failures.cb.2da2` | bool | failure | write | `0` | C/B 2DA2 ANTI ICE PHC 2 (122VU Y12) tripped |
| `failures.cb.2da3` | bool | failure | write | `0` | C/B 2DA3 ANTI ICE PHC 3 (122VU Y16) tripped |
| `failures.cb.2dl` | bool | failure | write | `0` | C/B 2DL ANTI ICE WING CTL (49VU C2) tripped |
| `failures.cb.2en1` | bool | failure | write | `0` | C/B 2EN1 ENGINE ENG1 OIL PRESS & REV SNSR A (121VU N40) tripped |
| `failures.cb.2en2` | bool | failure | write | `0` | C/B 2EN2 ENGINE ENG2 OIL PRESS & REV SNSR A (121VU N42) tripped |
| `failures.cb.2ga` | bool | failure | write | `0` | C/B 2GA L/G LGCIU SYS2 (121VU Q35) tripped |
| `failures.cb.2gg` | bool | failure | write | `0` | C/B 2GG BRAKING & STEERING SYS1 IND & SPLY (121VU M33) tripped |
| `failures.cb.2gs` | bool | failure | write | `0` | C/B 2GS BRAKES BRK FAN WHEELS 3&4 (121VU L35) tripped |
| `failures.cb.2ha1` | bool | failure | write | `0` | C/B 2HA1 AIR BLEED ENG 1 MONG (49VU D11) tripped |
| `failures.cb.2ha2` | bool | failure | write | `0` | C/B 2HA2 AIR BLEED ENG2 MONG (122VU Z22) tripped |
| `failures.cb.2hb` | bool | failure | write | `0` | C/B 2HB AIR COND FLOW CTL & IND 2 (122VU V21) tripped |
| `failures.cb.2hg` | bool | failure | write | `0` | C/B 2HG AIR COND RECIRC FAN L CTL (122VU X20) tripped |
| `failures.cb.2hh` | bool | failure | write | `0` | C/B 2HH AIR COND PACK TEMP CTL SYS2 1 115VAC (122VU Y18) tripped |
| `failures.cb.2hk` | bool | failure | write | `0` | C/B 2HK AIR COND ZONE TEMP CTL 115VAC SYS2 (122VU V18) tripped |
| `failures.cb.2hl` | bool | failure | write | `0` | C/B 2HL AIR COND CAB PRESS CTL 2 (122VU Y22) tripped |
| `failures.cb.2hq` | bool | failure | write | `0` | C/B 2HQ AVNCS VENT EXTC FAN (123VU AE2) tripped |
| `failures.cb.2hv` | bool | failure | write | `0` | C/B 2HV AIR BLEED X FEED VALVE BAT (49VU D13) tripped |
| `failures.cb.2jh1` | bool | failure | write | `0` | C/B 2JH1 ENGINE IGN ENG1 SYS A BAT (121VU P39) tripped |
| `failures.cb.2jh2` | bool | failure | write | `0` | C/B 2JH2 ENGINE IGN ENG2 SYS A BAT (121VU P40) tripped |
| `failures.cb.2kd` | bool | failure | write | `0` | C/B 2KD APU APU CTL (121VU L42) tripped |
| `failures.cb.2ks1` | bool | failure | write | `0` | C/B 2KS1 ENGINE FADEC A & EIU 1 (49VU A4) tripped |
| `failures.cb.2ks2` | bool | failure | write | `0` | C/B 2KS2 ENGINE FADEC A & EIU 2 (49VU A5) tripped |
| `failures.cb.2la` | bool | failure | write | `0` | C/B 2LA NAV NAV2 LT (122VU T2) tripped |
| `failures.cb.2lb` | bool | failure | write | `0` | C/B 2LB LANDING LT LDG LT R SPLY (122VU T6) tripped |
| `failures.cb.2le` | bool | failure | write | `0` | C/B 2LE LIGHTING FLOOD CTR INST PNL (122VU Z4) tripped |
| `failures.cb.2ll` | bool | failure | write | `0` | C/B 2LL LIGHTING WHL WELL LTG DOME (122VU X8) tripped |
| `failures.cb.2lr` | bool | failure | write | `0` | C/B 2LR EXT LT TAXI & TAKE OFF CTL (122VU W9) tripped |
| `failures.cb.2ly` | bool | failure | write | `0` | C/B 2LY LOGO LOGO L (122VU V3) tripped |
| `failures.cb.2mc` | bool | failure | write | `0` | C/B 2MC GALLEY FWD GALLEY FEEDER D (123VU AD4) tripped |
| `failures.cb.2pr` | bool | failure | write | `0` | C/B 2PR ELEC REFLNG NORM (122VU S27) tripped |
| `failures.cb.2pu1` | bool | failure | write | `0` | C/B 2PU1 ELEC TR1 SPLY (123VU AB10) tripped |
| `failures.cb.2pu2` | bool | failure | write | `0` | C/B 2PU2 ELEC TR2/214XP SPLY (123VU AB4) tripped |
| `failures.cb.2qa` | bool | failure | write | `0` | C/B 2QA FUEL R WING TK PUMP1 SPLY (121VU Q23) tripped |
| `failures.cb.2qc` | bool | failure | write | `0` | C/B 2QC APU FUEL BLOW OFF PUMP (49VU B14) tripped |
| `failures.cb.2qe` | bool | failure | write | `0` | C/B 2QE FUEL X FEED VALVE MOT 1 (49VU A12) tripped |
| `failures.cb.2qf` | bool | failure | write | `0` | C/B 2QF APU FUEL LP VALVE SPLY (121VU M39) tripped |
| `failures.cb.2qg` | bool | failure | write | `0` | C/B 2QG FUEL LP VALVE MOT1 ENG 2 (49VU A9) tripped |
| `failures.cb.2qp` | bool | failure | write | `0` | C/B 2QP FUEL XFR VALVE 1 WING R (49VU A11) tripped |
| `failures.cb.2qt` | bool | failure | write | `0` | C/B 2QT FUEL FQI CHAN 2 (121VU M27) tripped |
| `failures.cb.2qu` | bool | failure | write | `0` | C/B 2QU FUEL RFL/DFL SPLY (121VU L24) tripped |
| `failures.cb.2rb` | bool | failure | write | `0` | C/B 2RB COM ACARS MU (121VU L6) tripped |
| `failures.cb.2rc1` | bool | failure | write | `0` | C/B 2RC1 COM VHF 1 (49VU G9) tripped |
| `failures.cb.2rc2` | bool | failure | write | `0` | C/B 2RC2 COM VHF 2 (121VU L4) tripped |
| `failures.cb.2rc3` | bool | failure | write | `0` | C/B 2RC3 COM VHF 3 (121VU L5) tripped |
| `failures.cb.2rg1` | bool | failure | write | `0` | C/B 2RG1 COM RMP 1 (49VU G10) tripped |
| `failures.cb.2rg2` | bool | failure | write | `0` | C/B 2RG2 COM RMP 2 (121VU L2) tripped |
| `failures.cb.2rg3` | bool | failure | write | `0` | C/B 2RG3 COM RMP 3 (121VU L3) tripped |
| `failures.cb.2rk` | bool | failure | write | `0` | C/B 2RK COM CVR SPLY (49VU E14) tripped |
| `failures.cb.2rs1` | bool | failure | write | `0` | C/B 2RS1 NAV VOR 1 (49VU G13) tripped |
| `failures.cb.2rs2` | bool | failure | write | `0` | C/B 2RS2 NAV VOR 2 (121VU K8) tripped |
| `failures.cb.2tw` | bool | failure | write | `0` | C/B 2TW CFDS CFDIU SPLY (121VU J18) tripped |
| `failures.cb.2wc` | bool | failure | write | `0` | C/B 2WC COM HORN SPLY (121VU P9) tripped |
| `failures.cb.2we1` | bool | failure | write | `0` | C/B 2WE1 ENGINE FIRE EXTIG BTL1 SQUIB B (121VU Q44) tripped |
| `failures.cb.2we2` | bool | failure | write | `0` | C/B 2WE2 ENGINE FIRE EXTIG BTL2 SQUIB B (121VU Q42) tripped |
| `failures.cb.2wf` | bool | failure | write | `0` | C/B 2WF APU FIRE EXTIG SQUIB B (121VU L39) tripped |
| `failures.cb.2wg` | bool | failure | write | `0` | C/B 2WG APU FIRE & OVHT DET LOOP B (121VU L44) tripped |
| `failures.cb.2wl` | bool | failure | write | `0` | C/B 2WL LIGHTING EMER LT CABIN (49VU H6) tripped |
| `failures.cb.2wr` | bool | failure | write | `0` | C/B 2WR OXYGEN PAX CTL & WARN (49VU HA3) tripped |
| `failures.cb.2wv` | bool | failure | write | `0` | C/B 2WV SDAC 2 SPLY (121VU Q6) tripped |
| `failures.cb.2ww` | bool | failure | write | `0` | C/B 2WW FWS FWC 2 SPLY (121VU Q7) tripped |
| `failures.cb.2wz` | bool | failure | write | `0` | C/B 2WZ NAV GPWS 28VDC (121VU P6) tripped |
| `failures.cb.2xc` | bool | failure | write | `0` | C/B 2XC ELEC AC ESS BUS ON BUS2 (123VU AC1) tripped |
| `failures.cb.2xg` | bool | failure | write | `0` | C/B 2XG ELEC GND PWR PROT (123VU AB7) tripped |
| `failures.cb.2xh` | bool | failure | write | `0` | C/B 2XH ELEC AC ESS BUS MONG SPLY (106VU 24) tripped |
| `failures.cb.2xt` | bool | failure | write | `0` | C/B 2XT ELEC IDG 2 DISC (122VU T25) tripped |
| `failures.cb.2xu1` | bool | failure | write | `0` | C/B 2XU1 ELEC GCU 1 (122VU T26) tripped |
| `failures.cb.2xu2` | bool | failure | write | `0` | C/B 2XU2 ELEC GCU 2 (122VU T27) tripped |
| `failures.cb.2xx` | bool | failure | write | `0` | C/B 2XX ELEC SVCE BUS2 212XP SPLY (123VU AB5) tripped |
| `failures.cb.30hn` | bool | failure | write | `0` | C/B 30HN AIR COND AFT CARGO VENT FAN (122VU S22) tripped |
| `failures.cb.30lp` | bool | failure | write | `0` | C/B 30LP LIGHTING TST BOARD SPLY (122VU X6) tripped |
| `failures.cb.30qa` | bool | failure | write | `0` | C/B 30QA FUEL CTR TK PUMP2 SPLY (121VU P26) tripped |
| `failures.cb.30wf` | bool | failure | write | `0` | C/B 30WF APU AUTO EXTIG GND TEST (121VU L40) tripped |
| `failures.cb.31hn` | bool | failure | write | `0` | C/B 31HN AIR COND AFT CARGO VENT CTL & MONG (49VU C7) tripped |
| `failures.cb.31qa` | bool | failure | write | `0` | C/B 31QA FUEL CTR TK PUMP 1 CTL & IND (121VU R25) tripped |
| `failures.cb.32qa` | bool | failure | write | `0` | C/B 32QA FUEL CTR TK PUMP 2 CTL & IND (121VU R26) tripped |
| `failures.cb.3700gd` | bool | failure | write | `0` | C/B 3700GD HYDRAULIC Y HYD PUMP ENG2 MONG (121VU Q37) tripped |
| `failures.cb.3701gd` | bool | failure | write | `0` | C/B 3701GD HYDRAULIC Y HYD PUMP ENG2 CTL (121VU Q36) tripped |
| `failures.cb.3702gd` | bool | failure | write | `0` | C/B 3702GD HYD FIRE VALVE Y ENG 2 (49VU C14) tripped |
| `failures.cb.3801gx` | bool | failure | write | `0` | C/B 3801GX HYD Y HYD ELEC PUMP NORM (123VU AB3) tripped |
| `failures.cb.3802gx` | bool | failure | write | `0` | C/B 3802GX HYD Y HYD ELEC PUMP (123VU AB6) tripped |
| `failures.cb.3803gx` | bool | failure | write | `0` | C/B 3803GX HYDRAULIC HYD POWER Y (121VU N30) tripped |
| `failures.cb.3da1` | bool | failure | write | `0` | C/B 3DA1 ANTI ICE PITOT 1 (49VU D2) tripped |
| `failures.cb.3da2` | bool | failure | write | `0` | C/B 3DA2 ANTI ICE PITOT 2 (122VU Y14) tripped |
| `failures.cb.3da3` | bool | failure | write | `0` | C/B 3DA3 ANTI ICE PITOT 3 (122VU Z16) tripped |
| `failures.cb.3gg` | bool | failure | write | `0` | C/B 3GG BRAKING & STEERING SYS2 CTL (121VU M35) tripped |
| `failures.cb.3gs` | bool | failure | write | `0` | C/B 3GS BRAKES BRK FAN CTL (121VU M32) tripped |
| `failures.cb.3ha1` | bool | failure | write | `0` | C/B 3HA1 AIR BLEED ENG 1 CTL (49VU D12) tripped |
| `failures.cb.3ha2` | bool | failure | write | `0` | C/B 3HA2 AIR BLEED ENG2 CTL (122VU Z23) tripped |
| `failures.cb.3hb` | bool | failure | write | `0` | C/B 3HB AIR COND MIXER FLAP (122VU V22) tripped |
| `failures.cb.3hg` | bool | failure | write | `0` | C/B 3HG AIR COND RECIRC FAN R SPLY (122VU W18) tripped |
| `failures.cb.3hh` | bool | failure | write | `0` | C/B 3HH AIR COND PACK TEMP CTL SYS1 1 28VDC (122VU X21) tripped |
| `failures.cb.3hk` | bool | failure | write | `0` | C/B 3HK AIR COND ZONE TEMP CTL 28VDC SYS1 (122VU V19) tripped |
| `failures.cb.3hl` | bool | failure | write | `0` | C/B 3HL AIR COND CAB PRESS CTL MAN (122VU Y23) tripped |
| `failures.cb.3hq` | bool | failure | write | `0` | C/B 3HQ AIR COND AVNCS VENT MONG (122VU Y17) tripped |
| `failures.cb.3jh1` | bool | failure | write | `0` | C/B 3JH1 ENGINE IGN ENG1 SYS B (121VU P41) tripped |
| `failures.cb.3jh2` | bool | failure | write | `0` | C/B 3JH2 ENGINE IGN ENG2 SYS B (121VU P42) tripped |
| `failures.cb.3lb` | bool | failure | write | `0` | C/B 3LB LANDING LT LDG LT L CTL (122VU T5) tripped |
| `failures.cb.3le` | bool | failure | write | `0` | C/B 3LE LIGHTING CKPT DOME (122VU Y6) tripped |
| `failures.cb.3lf` | bool | failure | write | `0` | C/B 3LF LIGHTING INST LT OVHT PNL (122VU Y3) tripped |
| `failures.cb.3lr` | bool | failure | write | `0` | C/B 3LR EXT LT TAXI & TAKE OFF TO (122VU W7) tripped |
| `failures.cb.3mc` | bool | failure | write | `0` | C/B 3MC GALLEY AFT GALLEY FEEDER A (123VU AF4) tripped |
| `failures.cb.3pc` | bool | failure | write | `0` | C/B 3PC ELEC CNTOR ESS DC BUS TIE (122VU W26) tripped |
| `failures.cb.3pn1` | bool | failure | write | `0` | C/B 3PN1 ELEC 103PP SPLY (125VU CE1) tripped |
| `failures.cb.3pn2` | bool | failure | write | `0` | C/B 3PN2 ELEC 204PP SPLY (124VU BF1) tripped |
| `failures.cb.3pu1` | bool | failure | write | `0` | C/B 3PU1 ELEC TR 1 MONG (122VU X25) tripped |
| `failures.cb.3pu2` | bool | failure | write | `0` | C/B 3PU2 ELEC TR 2 MONG (122VU X26) tripped |
| `failures.cb.3qa` | bool | failure | write | `0` | C/B 3QA FUEL PUMPS 1 L CTL & R IND (121VU R23) tripped |
| `failures.cb.3qc` | bool | failure | write | `0` | C/B 3QC APU FUEL PUMP CTL (121VU M38) tripped |
| `failures.cb.3qg` | bool | failure | write | `0` | C/B 3QG FUEL LP VALVE MOT2 ENG1 (121VU M25) tripped |
| `failures.cb.3qp` | bool | failure | write | `0` | C/B 3QP FUEL XFR VALVE 2 WING L (121VU M22) tripped |
| `failures.cb.3td` | bool | failure | write | `0` | C/B 3TD CFDS DATA LOADER SPLY (121VU J16) tripped |
| `failures.cb.3tx1` | bool | failure | write | `0` | C/B 3TX1 ATSU ATSU 1 115VAC (121VU L16) tripped |
| `failures.cb.3wf` | bool | failure | write | `0` | C/B 3WF APU FIRE STBY (121VU M41) tripped |
| `failures.cb.3wl` | bool | failure | write | `0` | C/B 3WL EMER LT CAB EMER LT (122VU V7) tripped |
| `failures.cb.3wr` | bool | failure | write | `0` | C/B 3WR OXYGEN PAX CTL & WARN (49VU HA4) tripped |
| `failures.cb.3wv` | bool | failure | write | `0` | C/B 3WV SDAC 1 SPLY (49VU F4) tripped |
| `failures.cb.3ww` | bool | failure | write | `0` | C/B 3WW FWS FWC 1 SPLY (49VU F1) tripped |
| `failures.cb.3wz` | bool | failure | write | `0` | C/B 3WZ NAV GPWS 115VAC (121VU P7) tripped |
| `failures.cb.3xn1` | bool | failure | write | `0` | C/B 3XN1 ELEC BUS1 103XP SPLY (123VU AB11) tripped |
| `failures.cb.3xn2` | bool | failure | write | `0` | C/B 3XN2 ELEC BUS2 204XP SPLY (123VU AB2) tripped |
| `failures.cb.3xx` | bool | failure | write | `0` | C/B 3XX ELEC AC PWR SVCE CTL (122VU V29) tripped |
| `failures.cb.44wv` | bool | failure | write | `0` | C/B 44WV SDAC 1 & 2 BUS 2 28VDC (121VU P3) tripped |
| `failures.cb.46wv` | bool | failure | write | `0` | C/B 46WV SDAC 1 & 2 DOOR DET AVNCS (121VU P2) tripped |
| `failures.cb.47qa` | bool | failure | write | `0` | C/B 47QA FUEL CTR TK AUTO CTL (121VU R27) tripped |
| `failures.cb.48wv` | bool | failure | write | `0` | C/B 48WV SDAC 1 & 2 DOOR DET PAX (121VU P5) tripped |
| `failures.cb.4da1` | bool | failure | write | `0` | C/B 4DA1 ANTI ICE AOA 1 (49VU D4) tripped |
| `failures.cb.4da2` | bool | failure | write | `0` | C/B 4DA2 ANTI ICE AOA 2 (122VU Y13) tripped |
| `failures.cb.4da3` | bool | failure | write | `0` | C/B 4DA3 ANTI ICE AOA 3 (122VU Z15) tripped |
| `failures.cb.4db1` | bool | failure | write | `0` | C/B 4DB1 ANTI ICE WIPER CAPT (122VU X12) tripped |
| `failures.cb.4db2` | bool | failure | write | `0` | C/B 4DB2 ANTI ICE WIPER F/O (122VU W12) tripped |
| `failures.cb.4dd1` | bool | failure | write | `0` | C/B 4DD1 ANTI ICE ICE DET L (122VU V12) tripped |
| `failures.cb.4dd2` | bool | failure | write | `0` | C/B 4DD2 ANTI ICE ICE DET R (122VU V13) tripped |
| `failures.cb.4dg1` | bool | failure | write | `0` | C/B 4DG1 ANTI ICE WINDOWS L (122VU X14) tripped |
| `failures.cb.4dg2` | bool | failure | write | `0` | C/B 4DG2 ANTI ICE WINDOWS R (122VU W14) tripped |
| `failures.cb.4fp1` | bool | failure | write | `0` | C/B 4FP1 NAV & PROBES ADIRU 1 115VAC (49VU F6) tripped |
| `failures.cb.4fp2` | bool | failure | write | `0` | C/B 4FP2 ADIRS ADIRU 2 115VAC (121VU N7) tripped |
| `failures.cb.4fp3` | bool | failure | write | `0` | C/B 4FP3 ADIRS ADIRU 3 115VAC (121VU N6) tripped |
| `failures.cb.4fs` | bool | failure | write | `0` | C/B 4FS NAV CLOCK STBY SPLY (121VU N3) tripped |
| `failures.cb.4gg` | bool | failure | write | `0` | C/B 4GG BRAKING & STEERING SYS2 SPLY (121VU M36) tripped |
| `failures.cb.4hh` | bool | failure | write | `0` | C/B 4HH AIR COND PACK TEMP CTL SYS2 1 28VDC (122VU Y19) tripped |
| `failures.cb.4hk` | bool | failure | write | `0` | C/B 4HK AIR COND ZONE TEMP CTL 28VDC SYS2 (122VU V20) tripped |
| `failures.cb.4ks1` | bool | failure | write | `0` | C/B 4KS1 ENGINE ENG1 FADEC B & EIU1 (121VU R41) tripped |
| `failures.cb.4ks2` | bool | failure | write | `0` | C/B 4KS2 ENGINE ENG2 FADEC B & EIU2 (121VU Q40) tripped |
| `failures.cb.4lb` | bool | failure | write | `0` | C/B 4LB LANDING LT LDG LT R CTL (122VU T7) tripped |
| `failures.cb.4le` | bool | failure | write | `0` | C/B 4LE LIGHTING FLOOD F/O SIDE (122VU Z6) tripped |
| `failures.cb.4lf` | bool | failure | write | `0` | C/B 4LF LIGHTING INST LT MAIN INST PNL&PED (122VU Y4) tripped |
| `failures.cb.4pe` | bool | failure | write | `0` | C/B 4PE ELEC ESS TR SPLY (106VU 28) tripped |
| `failures.cb.4pr` | bool | failure | write | `0` | C/B 4PR ELEC RFL SPLY LOGIC (122VU U29) tripped |
| `failures.cb.4pu1` | bool | failure | write | `0` | C/B 4PU1 ELEC TR1 CNTOR SPLY (125VU CF1) tripped |
| `failures.cb.4pu2` | bool | failure | write | `0` | C/B 4PU2 ELEC TR2 CNTOR SPLY (124VU BC1) tripped |
| `failures.cb.4qa` | bool | failure | write | `0` | C/B 4QA FUEL PUMPS 1 R CTL & L IND (121VU R28) tripped |
| `failures.cb.4qg` | bool | failure | write | `0` | C/B 4QG FUEL LP VALVE MOT2 ENG2 (121VU M26) tripped |
| `failures.cb.4qp` | bool | failure | write | `0` | C/B 4QP FUEL XFR VALVE 2 WING R (121VU M23) tripped |
| `failures.cb.4rk` | bool | failure | write | `0` | C/B 4RK COM CVR CTL (49VU E13) tripped |
| `failures.cb.4rn` | bool | failure | write | `0` | C/B 4RN COM ACP CAPT (49VU G6) tripped |
| `failures.cb.4sg` | bool | failure | write | `0` | C/B 4SG NAV TCAS (121VU K10) tripped |
| `failures.cb.4tv` | bool | failure | write | `0` | C/B 4TV AIDS DMU (121VU K15) tripped |
| `failures.cb.4wf` | bool | failure | write | `0` | C/B 4WF APU FIRE NORM (121VU M42) tripped |
| `failures.cb.4wr` | bool | failure | write | `0` | C/B 4WR OXYGEN PAX ACTUATION (49VU HA5) tripped |
| `failures.cb.4ww` | bool | failure | write | `0` | C/B 4WW COM F/O LOUD SPKR (121VU P8) tripped |
| `failures.cb.4xc` | bool | failure | write | `0` | C/B 4XC ELEC AC ESS BUS NORM CNTOR (106VU 16) tripped |
| `failures.cb.4xg` | bool | failure | write | `0` | C/B 4XG ELEC EXT PWR LT AVAIL (122VU X31) tripped |
| `failures.cb.4xh` | bool | failure | write | `0` | C/B 4XH ELEC 26VAC ESS BUS SPLY (106VU 13) tripped |
| `failures.cb.4xx` | bool | failure | write | `0` | C/B 4XX ELEC SVCE BUS2 214XP SPLY (123VU AA5) tripped |
| `failures.cb.52ga` | bool | failure | write | `0` | C/B 52GA L/G LGCIU SYS1 GND SPLY (121VU Q34) tripped |
| `failures.cb.55qa` | bool | failure | write | `0` | C/B 55QA FUEL SMOKE CONFIG PUMP CTL (49VU A14) tripped |
| `failures.cb.5cc1` | bool | failure | write | `0` | C/B 5CC1 AUTO FLT FAC 1 28VDC (49VU B4) tripped |
| `failures.cb.5cc2` | bool | failure | write | `0` | C/B 5CC2 AUTO FLT FAC 2 28VDC (121VU M19) tripped |
| `failures.cb.5cv` | bool | failure | write | `0` | C/B 5CV FLIGHT CONTROLS SLT CTL & MONG SYS 1 (49VU B6) tripped |
| `failures.cb.5da1` | bool | failure | write | `0` | C/B 5DA1 ANTI ICE STATIC 1 (122VU Z13) tripped |
| `failures.cb.5da2` | bool | failure | write | `0` | C/B 5DA2 ANTI ICE STATIC 2 (122VU Y11) tripped |
| `failures.cb.5da3` | bool | failure | write | `0` | C/B 5DA3 ANTI ICE STATIC 3 (122VU Z14) tripped |
| `failures.cb.5dg1` | bool | failure | write | `0` | C/B 5DG1 ANTI ICE WHC 1 (122VU X13) tripped |
| `failures.cb.5dg2` | bool | failure | write | `0` | C/B 5DG2 ANTI ICE WHC 2 (122VU W13) tripped |
| `failures.cb.5fn` | bool | failure | write | `0` | C/B 5FN NAV ISIS (49VU F12) tripped |
| `failures.cb.5fp1` | bool | failure | write | `0` | C/B 5FP1 NAV & PROBES ADIRU 1 26VAC & AOA 1 (49VU F7) tripped |
| `failures.cb.5fp2` | bool | failure | write | `0` | C/B 5FP2 ADIRS ADIRU 2 26VAC & AOA (121VU N9) tripped |
| `failures.cb.5fp3` | bool | failure | write | `0` | C/B 5FP3 ADIRS ADIRU 3 26VAC & AOA (121VU N8) tripped |
| `failures.cb.5hq` | bool | failure | write | `0` | C/B 5HQ AIR COND AVNCS VENT CTL (49VU D5) tripped |
| `failures.cb.5hu` | bool | failure | write | `0` | C/B 5HU AIR COND LAV/GALLEY VENT EXTRACT FAN CTL (122VU U21) tripped |
| `failures.cb.5le` | bool | failure | write | `0` | C/B 5LE LIGHTING FLOOD CAPT SIDE (122VU Z5) tripped |
| `failures.cb.5lf` | bool | failure | write | `0` | C/B 5LF LIGHTING INST LT GLARE SHLD (122VU Y5) tripped |
| `failures.cb.5lv` | bool | failure | write | `0` | C/B 5LV BEACON BEACON LOWER (122VU U3) tripped |
| `failures.cb.5lx` | bool | failure | write | `0` | C/B 5LX EXT LT WING & ENG SCAN L (122VU W2) tripped |
| `failures.cb.5pb1` | bool | failure | write | `0` | C/B 5PB1 ELEC HOT BUS 701PP SPLY (105VU 24) tripped |
| `failures.cb.5pb2` | bool | failure | write | `0` | C/B 5PB2 ELEC HOT BUS 702PP SPLY (105VU 14) tripped |
| `failures.cb.5pe` | bool | failure | write | `0` | C/B 5PE ELEC ESS TR CNTOR CTL (106VU 27) tripped |
| `failures.cb.5pn` | bool | failure | write | `0` | C/B 5PN ELEC DC SVCE BUS (122VU X24) tripped |
| `failures.cb.5px` | bool | failure | write | `0` | C/B 5PX ELEC DC SVCE BUS ON TR 2 (122VU U30) tripped |
| `failures.cb.5rn` | bool | failure | write | `0` | C/B 5RN COM ACP F/O (49VU G7) tripped |
| `failures.cb.5sh1` | bool | failure | write | `0` | C/B 5SH1 NAV ATC 1 (49VU G11) tripped |
| `failures.cb.5sh2` | bool | failure | write | `0` | C/B 5SH2 NAV ATC 2 (121VU K7) tripped |
| `failures.cb.5sq1` | bool | failure | write | `0` | C/B 5SQ1 NAV RADAR 1 (121VU K13) tripped |
| `failures.cb.5sq2` | bool | failure | write | `0` | C/B 5SQ2 NAV RADAR 2 (121VU K14) tripped |
| `failures.cb.5tx1` | bool | failure | write | `0` | C/B 5TX1 ATSU ATSU 1 28VDC (121VU L15) tripped |
| `failures.cb.5wr` | bool | failure | write | `0` | C/B 5WR OXYGEN PAX ACTUATION (49VU HA6) tripped |
| `failures.cb.5wv` | bool | failure | write | `0` | C/B 5WV SDAC 1 26VAC SYNC AC ESS (49VU F2) tripped |
| `failures.cb.5ww` | bool | failure | write | `0` | C/B 5WW NAV & PROBES CAPT LOUD SPKR (49VU F10) tripped |
| `failures.cb.5xc` | bool | failure | write | `0` | C/B 5XC ELEC AC ESS BUS STBY CNTOR (106VU 11) tripped |
| `failures.cb.5xe` | bool | failure | write | `0` | C/B 5XE ELEC AC ESS BUS EMER CNTOR (106VU 12) tripped |
| `failures.cb.5xn1` | bool | failure | write | `0` | C/B 5XN1 ELEC BUS1 131XP-A SPLY (123VU AB12) tripped |
| `failures.cb.5xn2` | bool | failure | write | `0` | C/B 5XN2 ELEC BUS2 231XP-A SPLY (123VU AB1) tripped |
| `failures.cb.5xu` | bool | failure | write | `0` | C/B 5XU ELEC GEN 1 OFF BTC 1 (122VU T28) tripped |
| `failures.cb.61gg` | bool | failure | write | `0` | C/B 61GG L/G Y BRK PRESS IND (49VU C10) tripped |
| `failures.cb.68wv` | bool | failure | write | `0` | C/B 68WV ELEC DC BUS 1&2 MONG (106VU 26) tripped |
| `failures.cb.6cv` | bool | failure | write | `0` | C/B 6CV FLIGHT CONTROLS FLP CTL & MONG SYS 1 (49VU B7) tripped |
| `failures.cb.6fp1` | bool | failure | write | `0` | C/B 6FP1 ADIRS ADIRU 1 28VDC (105VU 13) tripped |
| `failures.cb.6fp2` | bool | failure | write | `0` | C/B 6FP2 ADIRS ADIRU 2 28VDC (121VU N5) tripped |
| `failures.cb.6fp3` | bool | failure | write | `0` | C/B 6FP3 ADIRS ADIRU 3 28VDC (121VU N4) tripped |
| `failures.cb.6fs` | bool | failure | write | `0` | C/B 6FS NAV & PROBES CLOCK NORM SPLY (49VU F11) tripped |
| `failures.cb.6hq` | bool | failure | write | `0` | C/B 6HQ AIR COND AVNCS VENT CTL (49VU D6) tripped |
| `failures.cb.6hu` | bool | failure | write | `0` | C/B 6HU AIR COND LAV/GALLEY VENT EXTRACT FAN SPLY (122VU U19) tripped |
| `failures.cb.6pn` | bool | failure | write | `0` | C/B 6PN ELEC 206PP/208PP SPLY (124VU BE1) tripped |
| `failures.cb.6rn` | bool | failure | write | `0` | C/B 6RN COM ACP THIRD OCCPNT (121VU M2) tripped |
| `failures.cb.6tw` | bool | failure | write | `0` | C/B 6TW CFDS PTR SPLY (121VU J21) tripped |
| `failures.cb.6tx1` | bool | failure | write | `0` | C/B 6TX1 ATSU DCDU 1 (121VU L17) tripped |
| `failures.cb.6tx2` | bool | failure | write | `0` | C/B 6TX2 ATSU DCDU 2 (121VU L18) tripped |
| `failures.cb.6wr` | bool | failure | write | `0` | C/B 6WR OXYGEN PAX ACTUATION (49VU HA7) tripped |
| `failures.cb.6wv` | bool | failure | write | `0` | C/B 6WV SDAC 2 26VAC SYNC AC ESS (49VU F3) tripped |
| `failures.cb.6xe` | bool | failure | write | `0` | C/B 6XE ELEC CSM/G EV MAN SPLY (106VU 15) tripped |
| `failures.cb.6xg` | bool | failure | write | `0` | C/B 6XG ELEC EXT PWR LT NOT IN USE (122VU X30) tripped |
| `failures.cb.6xh` | bool | failure | write | `0` | C/B 6XH ELEC AC BUS 8XP MONG (49VU H11) tripped |
| `failures.cb.6xs` | bool | failure | write | `0` | C/B 6XS ELEC APU GCU (122VU Y25) tripped |
| `failures.cb.70gg` | bool | failure | write | `0` | C/B 70GG HYDRAULIC PARK BRK CTL NORM (121VU N36) tripped |
| `failures.cb.71gg` | bool | failure | write | `0` | C/B 71GG HYDRAULIC PARK BRK CTL STBY (121VU N37) tripped |
| `failures.cb.79wl` | bool | failure | write | `0` | C/B 79WL LIGHTING EMER LT CABIN (49VU H7) tripped |
| `failures.cb.7cv` | bool | failure | write | `0` | C/B 7CV FLIGHT CONTROLS SLT CTL SYS 2 (121VU R21) tripped |
| `failures.cb.7mc` | bool | failure | write | `0` | C/B 7MC GALLEY GALLEY CNTOR (122VU S28) tripped |
| `failures.cb.7pc1` | bool | failure | write | `0` | C/B 7PC1 ELEC TR 1 FAULT CONFIG (122VU W29) tripped |
| `failures.cb.7pc2` | bool | failure | write | `0` | C/B 7PC2 ELEC TR 2 FAULT CONFIG (122VU W30) tripped |
| `failures.cb.7pn` | bool | failure | write | `0` | C/B 7PN ELEC DC SVCE 6PP SPLY (124VU BD1) tripped |
| `failures.cb.7qa` | bool | failure | write | `0` | C/B 7QA FUEL L WING TK PUMP2 SPLY (121VU N26) tripped |
| `failures.cb.7rn` | bool | failure | write | `0` | C/B 7RN COM ACP AVNCS COMPT (121VU M3) tripped |
| `failures.cb.7tu` | bool | failure | write | `0` | C/B 7TU RCDR DFDR (121VU K16) tripped |
| `failures.cb.7wd1` | bool | failure | write | `0` | C/B 7WD1 ENGINE FIRE DET 1 LOOP A (49VU A6) tripped |
| `failures.cb.7wd2` | bool | failure | write | `0` | C/B 7WD2 ENGINE ENG2 FIRE DET LOOP A (121VU Q39) tripped |
| `failures.cb.7wr` | bool | failure | write | `0` | C/B 7WR OXYGEN PAX ACTUATION (49VU HA8) tripped |
| `failures.cb.7wv` | bool | failure | write | `0` | C/B 7WV SDAC 26VAC SYNC AC BUS 2 (121VU Q3) tripped |
| `failures.cb.7xa` | bool | failure | write | `0` | C/B 7XA GALLEY GND/FLT LOGIC (122VU S24) tripped |
| `failures.cb.7xe` | bool | failure | write | `0` | C/B 7XE ELEC CSM/G EV AUTO SPLY (105VU 23) tripped |
| `failures.cb.7xg` | bool | failure | write | `0` | C/B 7XG ELEC GPCU (122VU Y24) tripped |
| `failures.cb.7xn1` | bool | failure | write | `0` | C/B 7XN1 ELEC BUS1 110XP SPLY (123VU AF11) tripped |
| `failures.cb.7xn2` | bool | failure | write | `0` | C/B 7XN2 ELEC BUS2 210XP SPLY (123VU AF2) tripped |
| `failures.cb.8cv` | bool | failure | write | `0` | C/B 8CV FLIGHT CONTROLS FLP CTL & MONG SYS 2 (121VU Q21) tripped |
| `failures.cb.8fp` | bool | failure | write | `0` | C/B 8FP NAV & PROBES ADIRU 3 SWTG SPLY (49VU F9) tripped |
| `failures.cb.8pb1` | bool | failure | write | `0` | C/B 8PB1 ELEC BAT BUS REF BCL 1 (105VU 27) tripped |
| `failures.cb.8pb2` | bool | failure | write | `0` | C/B 8PB2 ELEC BAT BUS REF BCL 2 (105VU 19) tripped |
| `failures.cb.8qa` | bool | failure | write | `0` | C/B 8QA FUEL R WING TK PUMP2 SPLY (121VU Q26) tripped |
| `failures.cb.8qt` | bool | failure | write | `0` | C/B 8QT FUEL FQI CHAN 1&2 (121VU L26) tripped |
| `failures.cb.8rn` | bool | failure | write | `0` | C/B 8RN COM SELCAL (121VU M4) tripped |
| `failures.cb.8tu` | bool | failure | write | `0` | C/B 8TU RCDR FDIU & QAR (121VU K17) tripped |
| `failures.cb.8tw` | bool | failure | write | `0` | C/B 8TW CFDS CFDIU BACK UP (121VU J17) tripped |
| `failures.cb.8wd1` | bool | failure | write | `0` | C/B 8WD1 ENGINE ENG1 FIRE DET LOOP B (121VU Q38) tripped |
| `failures.cb.8wd2` | bool | failure | write | `0` | C/B 8WD2 ENGINE FIRE DET 2 LOOP B (49VU A7) tripped |
| `failures.cb.8wv` | bool | failure | write | `0` | C/B 8WV SDAC 26VAC SYNC AC BUS 2 (121VU Q2) tripped |
| `failures.cb.8xa` | bool | failure | write | `0` | C/B 8XA GALLEY FAULT LT CTL (122VU S25) tripped |
| `failures.cb.8xu` | bool | failure | write | `0` | C/B 8XU ELEC GEN 2 OFF BTC 2 SPLY (122VU T31) tripped |
| `failures.cb.9ca1` | bool | failure | write | `0` | C/B 9CA1 AUTO FLT FCU 1 (49VU B5) tripped |
| `failures.cb.9ca2` | bool | failure | write | `0` | C/B 9CA2 AUTO FLT FCU 2 (121VU M21) tripped |
| `failures.cb.9cv` | bool | failure | write | `0` | C/B 9CV FLT CTL WTB SLT SYS1 (122VU S6) tripped |
| `failures.cb.9fp` | bool | failure | write | `0` | C/B 9FP ADIRS ADIRU 3 SWTG SPLY (121VU N10) tripped |
| `failures.cb.9pb1` | bool | failure | write | `0` | C/B 9PB1 ELEC BAT REF BCL 1 (105VU 26) tripped |
| `failures.cb.9pb2` | bool | failure | write | `0` | C/B 9PB2 ELEC BAT REF BCL 2 (105VU 16) tripped |
| `failures.cb.9pc` | bool | failure | write | `0` | C/B 9PC ELEC CNTOR DC BUS TIE 1 (122VU W25) tripped |
| `failures.cb.9qa` | bool | failure | write | `0` | C/B 9QA FUEL PUMPS 2 L CTL & R IND (121VU R24) tripped |
| `failures.cb.9rn` | bool | failure | write | `0` | C/B 9RN COM FLT INTPH (49VU G8) tripped |
| `failures.cb.9tu` | bool | failure | write | `0` | C/B 9TU RCDR ACCLRM (121VU K18) tripped |
| `failures.cb.9tw` | bool | failure | write | `0` | C/B 9TW CFDS TEST PLUG 1 (121VU J19) tripped |
| `failures.cb.9wv` | bool | failure | write | `0` | C/B 9WV SDAC 26VAC SYNC AC BUS 1 (121VU Q4) tripped |
| `failures.cb.9xe` | bool | failure | write | `0` | C/B 9XE ELEC EMER GEN AUTO 2 (122VU Z26) tripped |

## Failures / Clock

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.clock.failure` | bool | failure | write | `0` | Cockpit clock failed (displays blank, no time output) |

## Failures / Communications

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.com.acp1` | bool | failure | write | `0` | ACP 1 failure (its crew station loses the audio) |
| `failures.com.acp1PttStuck` | bool | failure | write | `0` | ACP 1 INT/RAD switch jammed at RAD (COM SINGLE PTT STUCK) |
| `failures.com.acp2` | bool | failure | write | `0` | ACP 2 failure (its crew station loses the audio) |
| `failures.com.acp2PttStuck` | bool | failure | write | `0` | ACP 2 INT/RAD switch jammed at RAD (COM SINGLE PTT STUCK) |
| `failures.com.acp3` | bool | failure | write | `0` | ACP 3 failure (its crew station loses the audio) |
| `failures.com.acp3PttStuck` | bool | failure | write | `0` | ACP 3 INT/RAD switch jammed at RAD (COM SINGLE PTT STUCK) |
| `failures.com.amu1` | bool | failure | write | `0` | AMU audio channel 1 failure (captain channel) |
| `failures.com.amu2` | bool | failure | write | `0` | AMU audio channel 2 failure (F/O channel) |
| `failures.com.amu3` | bool | failure | write | `0` | AMU audio channel 3 failure (third occupant channel) |
| `failures.com.cids1` | bool | failure | write | `0` | CIDS director 1 failure (MAINTENANCE CIDS 1; COM CIDS 1+2 FAULT with the other) |
| `failures.com.cids2` | bool | failure | write | `0` | CIDS director 2 failure (MAINTENANCE CIDS 2; COM CIDS 1+2 FAULT with the other) |
| `failures.com.fltIntph` | bool | failure | write | `0` | Flight interphone failure (no interphone between the crew stations and the ground mechanic) |
| `failures.com.pttCaptHandMic` | bool | failure | write | `0` | Captain hand mike PTT jammed in transmit (COM SINGLE PTT STUCK) |
| `failures.com.pttCaptSidestick` | bool | failure | write | `0` | Captain sidestick radio selector jammed in transmit (COM SINGLE PTT STUCK) |
| `failures.com.pttFoHandMic` | bool | failure | write | `0` | F/O hand mike PTT jammed in transmit (COM SINGLE PTT STUCK) |
| `failures.com.pttFoSidestick` | bool | failure | write | `0` | F/O sidestick radio selector jammed in transmit (COM SINGLE PTT STUCK) |
| `failures.com.selcal` | bool | failure | write | `0` | SELCAL decoder failure (no CALL light, no SELCAL buzzer) |
| `failures.radio.vhf1StuckTx` | bool | failure | write | `0` | VHF 1 transceiver stuck transmitting (COM VHF 1 EMITTING) |
| `failures.radio.vhf2StuckTx` | bool | failure | write | `0` | VHF 2 transceiver stuck transmitting (COM VHF 2 EMITTING) |
| `failures.radio.vhf3StuckTx` | bool | failure | write | `0` | VHF 3 transceiver stuck transmitting (COM VHF 3 EMITTING) |

## Failures / Doors

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.door.ckptControlUnit` | bool | failure | write | `0` | Cockpit door control unit failed: latches unlocked, no buzzer (COCKPIT DOOR FAULT) |
| `failures.door.ckptPressSensor1` | bool | failure | write | `0` | Cockpit door differential pressure sensor 1 failed (CHAN 1 light, COCKPIT DOOR FAULT) |
| `failures.door.ckptPressSensor2` | bool | failure | write | `0` | Cockpit door differential pressure sensor 2 failed (CHAN 2 light, COCKPIT DOOR FAULT) |
| `failures.door.ckptStrikeBot` | bool | failure | write | `0` | Cockpit door BOT locking strike (latch) failed: stays unlocked (STRIKE BOT light, COCKPIT DOOR FAULT) |
| `failures.door.ckptStrikeMid` | bool | failure | write | `0` | Cockpit door MID locking strike (latch) failed: stays unlocked (STRIKE MID light, COCKPIT DOOR FAULT) |
| `failures.door.ckptStrikeTop` | bool | failure | write | `0` | Cockpit door TOP locking strike (latch) failed: stays unlocked (STRIKE TOP light, COCKPIT DOOR FAULT) |

## Failures / EIS

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.eis.dmc1` | bool | failure | write | `0` | DMC 1 failure |
| `failures.eis.dmc2` | bool | failure | write | `0` | DMC 2 failure |
| `failures.eis.dmc3` | bool | failure | write | `0` | DMC 3 failure |
| `failures.eis.dmcFwcBus1` | bool | failure | write | `0` | DMC 1/3 to FWC bus lost (with bus 2: EIS DMC/FWC COM FAULT) |
| `failures.eis.dmcFwcBus2` | bool | failure | write | `0` | DMC 2/3 to FWC bus lost (with bus 1: EIS DMC/FWC COM FAULT) |
| `failures.eis.duCaptNd` | bool | failure | write | `0` | CAPT ND display unit failure |
| `failures.eis.duCaptNdMonitor` | bool | failure | write | `0` | CAPT ND display discrepancy found by the DMC feedback monitoring (amber CHECK message) |
| `failures.eis.duCaptPfd` | bool | failure | write | `0` | CAPT PFD display unit failure |
| `failures.eis.duCaptPfdMonitor` | bool | failure | write | `0` | CAPT PFD display discrepancy found by the DMC feedback monitoring (amber CHECK message) |
| `failures.eis.duFoNd` | bool | failure | write | `0` | F/O ND display unit failure |
| `failures.eis.duFoNdMonitor` | bool | failure | write | `0` | F/O ND display discrepancy found by the DMC feedback monitoring (amber CHECK message) |
| `failures.eis.duFoPfd` | bool | failure | write | `0` | F/O PFD display unit failure |
| `failures.eis.duFoPfdMonitor` | bool | failure | write | `0` | F/O PFD display discrepancy found by the DMC feedback monitoring (amber CHECK message) |
| `failures.eis.duLowerEcam` | bool | failure | write | `0` | LOWER ECAM display unit failure |
| `failures.eis.duLowerEcamMonitor` | bool | failure | write | `0` | LOWER ECAM display discrepancy found by the DMC feedback monitoring (amber CHECK message) |
| `failures.eis.duUpperEcam` | bool | failure | write | `0` | UPPER ECAM display unit failure |
| `failures.eis.duUpperEcamMonitor` | bool | failure | write | `0` | UPPER ECAM display discrepancy found by the DMC feedback monitoring (amber CHECK message) |

## Failures / Electrical

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.elec.acBus1` | bool | failure | write | `0` | AC BUS 1 fault |
| `failures.elec.acBus2` | bool | failure | write | `0` | AC BUS 2 fault |
| `failures.elec.acEssBus` | bool | failure | write | `0` | AC ESS BUS fault |
| `failures.elec.apuGen` | bool | failure | write | `0` | APU GEN failure (GCU trip) |
| `failures.elec.bat1` | bool | failure | write | `0` | BAT 1 fault (charging current out of limits) |
| `failures.elec.bat2` | bool | failure | write | `0` | BAT 2 fault (charging current out of limits) |
| `failures.elec.bcl1` | bool | failure | write | `0` | Battery charge limiter 1 failure (BAT 1 contactor stays open) |
| `failures.elec.bcl2` | bool | failure | write | `0` | Battery charge limiter 2 failure (BAT 2 contactor stays open) |
| `failures.elec.dcBatBus` | bool | failure | write | `0` | DC BAT BUS fault |
| `failures.elec.dcBus1` | bool | failure | write | `0` | DC BUS 1 fault |
| `failures.elec.dcBus2` | bool | failure | write | `0` | DC BUS 2 fault |
| `failures.elec.dcEssBus` | bool | failure | write | `0` | DC ESS BUS fault |
| `failures.elec.emerGen` | bool | failure | write | `0` | Emergency generator failure |
| `failures.elec.essTr` | bool | failure | write | `0` | ESS TR failure |
| `failures.elec.gen1` | bool | failure | write | `0` | GEN 1 failure (GCU trip) |
| `failures.elec.gen2` | bool | failure | write | `0` | GEN 2 failure (GCU trip) |
| `failures.elec.gpu` | bool | failure | write | `0` | Ground power out of limits (voltage, frequency or phase sequence) |
| `failures.elec.idg1Disc` | bool | failure | write | `0` | IDG 1 disconnected (IDG pb or thermal disconnection: GEN 1 lost; clear = reconnected, in flight too) |
| `failures.elec.idg1FilterClog` | bool | failure | write | `0` | IDG 1 oil filter clogged |
| `failures.elec.idg1OilLoLvl` | bool | failure | write | `0` | IDG 1 oil low level (runs hotter) |
| `failures.elec.idg1OilLoPr` | bool | failure | write | `0` | IDG 1 oil low pressure |
| `failures.elec.idg1OilOvht` | bool | failure | write | `0` | IDG 1 oil overheat |
| `failures.elec.idg2Disc` | bool | failure | write | `0` | IDG 2 disconnected (IDG pb or thermal disconnection: GEN 2 lost; clear = reconnected, in flight too) |
| `failures.elec.idg2FilterClog` | bool | failure | write | `0` | IDG 2 oil filter clogged |
| `failures.elec.idg2OilLoLvl` | bool | failure | write | `0` | IDG 2 oil low level (runs hotter) |
| `failures.elec.idg2OilLoPr` | bool | failure | write | `0` | IDG 2 oil low pressure |
| `failures.elec.idg2OilOvht` | bool | failure | write | `0` | IDG 2 oil overheat |
| `failures.elec.statInv` | bool | failure | write | `0` | Static inverter failure |
| `failures.elec.tr1` | bool | failure | write | `0` | TR 1 failure |
| `failures.elec.tr2` | bool | failure | write | `0` | TR 2 failure |

## Failures / Electrical contactors

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.elec.acEssFeedAltnCoil` | bool | failure | write | `0` | AC ESS feed contactor from AC BUS 2 (3XC2) coil failure (open circuit) |
| `failures.elec.acEssFeedAltnStuckClosed` | bool | failure | write | `0` | AC ESS feed contactor from AC BUS 2 (3XC2) stuck closed (welded) |
| `failures.elec.acEssFeedAltnStuckOpen` | bool | failure | write | `0` | AC ESS feed contactor from AC BUS 2 (3XC2) stuck open |
| `failures.elec.acEssFeedNormCoil` | bool | failure | write | `0` | AC ESS feed contactor from AC BUS 1 (3XC1) coil failure (open circuit) |
| `failures.elec.acEssFeedNormStuckClosed` | bool | failure | write | `0` | AC ESS feed contactor from AC BUS 1 (3XC1) stuck closed (welded) |
| `failures.elec.acEssFeedNormStuckOpen` | bool | failure | write | `0` | AC ESS feed contactor from AC BUS 1 (3XC1) stuck open |
| `failures.elec.acEssShedCoil` | bool | failure | write | `0` | AC ESS SHED contactor (8XH) coil failure (open circuit) |
| `failures.elec.acEssShedStuckClosed` | bool | failure | write | `0` | AC ESS SHED contactor (8XH) stuck closed (welded) |
| `failures.elec.acEssShedStuckOpen` | bool | failure | write | `0` | AC ESS SHED contactor (8XH) stuck open |
| `failures.elec.apuGlcCoil` | bool | failure | write | `0` | APU GEN line contactor (3XS) coil failure (open circuit) |
| `failures.elec.apuGlcStuckClosed` | bool | failure | write | `0` | APU GEN line contactor (3XS) stuck closed (welded) |
| `failures.elec.apuGlcStuckOpen` | bool | failure | write | `0` | APU GEN line contactor (3XS) stuck open |
| `failures.elec.bat1LineCoil` | bool | failure | write | `0` | Battery 1 line contactor (6PB1) coil failure (open circuit) |
| `failures.elec.bat1LineStuckClosed` | bool | failure | write | `0` | Battery 1 line contactor (6PB1) stuck closed (welded) |
| `failures.elec.bat1LineStuckOpen` | bool | failure | write | `0` | Battery 1 line contactor (6PB1) stuck open |
| `failures.elec.bat2LineCoil` | bool | failure | write | `0` | Battery 2 line contactor (6PB2) coil failure (open circuit) |
| `failures.elec.bat2LineStuckClosed` | bool | failure | write | `0` | Battery 2 line contactor (6PB2) stuck closed (welded) |
| `failures.elec.bat2LineStuckOpen` | bool | failure | write | `0` | Battery 2 line contactor (6PB2) stuck open |
| `failures.elec.btc1Coil` | bool | failure | write | `0` | Bus tie contactor 1 (11XU1) coil failure (open circuit) |
| `failures.elec.btc1StuckClosed` | bool | failure | write | `0` | Bus tie contactor 1 (11XU1) stuck closed (welded) |
| `failures.elec.btc1StuckOpen` | bool | failure | write | `0` | Bus tie contactor 1 (11XU1) stuck open |
| `failures.elec.btc2Coil` | bool | failure | write | `0` | Bus tie contactor 2 (11XU2) coil failure (open circuit) |
| `failures.elec.btc2StuckClosed` | bool | failure | write | `0` | Bus tie contactor 2 (11XU2) stuck closed (welded) |
| `failures.elec.btc2StuckOpen` | bool | failure | write | `0` | Bus tie contactor 2 (11XU2) stuck open |
| `failures.elec.dcEssShedCoil` | bool | failure | write | `0` | DC ESS SHED contactor (8PH) coil failure (open circuit) |
| `failures.elec.dcEssShedStuckClosed` | bool | failure | write | `0` | DC ESS SHED contactor (8PH) stuck closed (welded) |
| `failures.elec.dcEssShedStuckOpen` | bool | failure | write | `0` | DC ESS SHED contactor (8PH) stuck open |
| `failures.elec.dcTie1Coil` | bool | failure | write | `0` | DC BUS 1 - DC BAT BUS tie contactor (1PC1) coil failure (open circuit) |
| `failures.elec.dcTie1StuckClosed` | bool | failure | write | `0` | DC BUS 1 - DC BAT BUS tie contactor (1PC1) stuck closed (welded) |
| `failures.elec.dcTie1StuckOpen` | bool | failure | write | `0` | DC BUS 1 - DC BAT BUS tie contactor (1PC1) stuck open |
| `failures.elec.dcTie2Coil` | bool | failure | write | `0` | DC BUS 2 - DC BAT BUS tie contactor (1PC2) coil failure (open circuit) |
| `failures.elec.dcTie2StuckClosed` | bool | failure | write | `0` | DC BUS 2 - DC BAT BUS tie contactor (1PC2) stuck closed (welded) |
| `failures.elec.dcTie2StuckOpen` | bool | failure | write | `0` | DC BUS 2 - DC BAT BUS tie contactor (1PC2) stuck open |
| `failures.elec.emerGlcCoil` | bool | failure | write | `0` | Emergency generator line contactor (2XE) coil failure (open circuit) |
| `failures.elec.emerGlcStuckClosed` | bool | failure | write | `0` | Emergency generator line contactor (2XE) stuck closed (welded) |
| `failures.elec.emerGlcStuckOpen` | bool | failure | write | `0` | Emergency generator line contactor (2XE) stuck open |
| `failures.elec.epcCoil` | bool | failure | write | `0` | External power contactor (3XG) coil failure (open circuit) |
| `failures.elec.epcStuckClosed` | bool | failure | write | `0` | External power contactor (3XG) stuck closed (welded) |
| `failures.elec.epcStuckOpen` | bool | failure | write | `0` | External power contactor (3XG) stuck open |
| `failures.elec.essDcTieCoil` | bool | failure | write | `0` | DC BAT BUS - DC ESS BUS tie contactor (4PC) coil failure (open circuit) |
| `failures.elec.essDcTieStuckClosed` | bool | failure | write | `0` | DC BAT BUS - DC ESS BUS tie contactor (4PC) stuck closed (welded) |
| `failures.elec.essDcTieStuckOpen` | bool | failure | write | `0` | DC BAT BUS - DC ESS BUS tie contactor (4PC) stuck open |
| `failures.elec.essTrCoil` | bool | failure | write | `0` | ESS TR contactor (3PE) coil failure (open circuit) |
| `failures.elec.essTrStuckClosed` | bool | failure | write | `0` | ESS TR contactor (3PE) stuck closed (welded) |
| `failures.elec.essTrStuckOpen` | bool | failure | write | `0` | ESS TR contactor (3PE) stuck open |
| `failures.elec.glc1Coil` | bool | failure | write | `0` | GEN 1 line contactor (9XU1) coil failure (open circuit) |
| `failures.elec.glc1StuckClosed` | bool | failure | write | `0` | GEN 1 line contactor (9XU1) stuck closed (welded) |
| `failures.elec.glc1StuckOpen` | bool | failure | write | `0` | GEN 1 line contactor (9XU1) stuck open |
| `failures.elec.glc2Coil` | bool | failure | write | `0` | GEN 2 line contactor (9XU2) coil failure (open circuit) |
| `failures.elec.glc2StuckClosed` | bool | failure | write | `0` | GEN 2 line contactor (9XU2) stuck closed (welded) |
| `failures.elec.glc2StuckOpen` | bool | failure | write | `0` | GEN 2 line contactor (9XU2) stuck open |
| `failures.elec.maintBusCoil` | bool | failure | write | `0` | Maintenance bus (GND/FLT) contactor (12XX) coil failure (open circuit) |
| `failures.elec.maintBusStuckClosed` | bool | failure | write | `0` | Maintenance bus (GND/FLT) contactor (12XX) stuck closed (welded) |
| `failures.elec.maintBusStuckOpen` | bool | failure | write | `0` | Maintenance bus (GND/FLT) contactor (12XX) stuck open |
| `failures.elec.statInvAcEssCoil` | bool | failure | write | `0` | AC ESS BUS switching contactor at its static inverter position (15XE) coil failure (open circuit) |
| `failures.elec.statInvAcEssStuckClosed` | bool | failure | write | `0` | AC ESS BUS switching contactor at its static inverter position (15XE) stuck closed (welded) |
| `failures.elec.statInvAcEssStuckOpen` | bool | failure | write | `0` | AC ESS BUS switching contactor at its static inverter position (15XE) stuck open |
| `failures.elec.statInvCoil` | bool | failure | write | `0` | Static inverter contactor (2XB) coil failure (open circuit) |
| `failures.elec.statInvStuckClosed` | bool | failure | write | `0` | Static inverter contactor (2XB) stuck closed (welded) |
| `failures.elec.statInvStuckOpen` | bool | failure | write | `0` | Static inverter contactor (2XB) stuck open |
| `failures.elec.tr1Coil` | bool | failure | write | `0` | TR 1 contactor (5PU1) coil failure (open circuit) |
| `failures.elec.tr1StuckClosed` | bool | failure | write | `0` | TR 1 contactor (5PU1) stuck closed (welded) |
| `failures.elec.tr1StuckOpen` | bool | failure | write | `0` | TR 1 contactor (5PU1) stuck open |
| `failures.elec.tr2Coil` | bool | failure | write | `0` | TR 2 contactor (5PU2) coil failure (open circuit) |
| `failures.elec.tr2StuckClosed` | bool | failure | write | `0` | TR 2 contactor (5PU2) stuck closed (welded) |
| `failures.elec.tr2StuckOpen` | bool | failure | write | `0` | TR 2 contactor (5PU2) stuck open |

## Failures / Engines

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.eng.bleedStatus1` | bool | failure | write | `0` | Engine 1 bleed valve status lost by the FADEC |
| `failures.eng.bleedStatus2` | bool | failure | write | `0` | Engine 2 bleed valve status lost by the FADEC |
| `failures.eng.compressorVane1` | bool | failure | write | `0` | Engine 1 variable bleed / stator vane actuation failure |
| `failures.eng.compressorVane2` | bool | failure | write | `0` | Engine 2 variable bleed / stator vane actuation failure |
| `failures.eng.egtHigh1` | bool | failure | write | `0` | Engine 1 hot section deterioration: EGT higher (Value: degrees C, default 120) |
| `failures.eng.egtHigh2` | bool | failure | write | `0` | Engine 2 hot section deterioration: EGT higher (Value: degrees C, default 120) |
| `failures.eng.egtSensorA1` | bool | failure | write | `0` | Engine 1 FADEC channel A EGT sensor error (Value: bias degrees C, default 150) |
| `failures.eng.egtSensorA2` | bool | failure | write | `0` | Engine 2 FADEC channel A EGT sensor error (Value: bias degrees C, default 150) |
| `failures.eng.egtSensorB1` | bool | failure | write | `0` | Engine 1 FADEC channel B EGT sensor error (Value: bias degrees C, default 150) |
| `failures.eng.egtSensorB2` | bool | failure | write | `0` | Engine 2 FADEC channel B EGT sensor error (Value: bias degrees C, default 150) |
| `failures.eng.eiu1` | bool | failure | write | `0` | Engine 1 EIU failure (EIU-FADEC bus lost: no start, no mode selector) |
| `failures.eng.eiu2` | bool | failure | write | `0` | Engine 2 EIU failure (EIU-FADEC bus lost: no start, no mode selector) |
| `failures.eng.evmu` | bool | failure | write | `0` | Engine vibration monitoring unit (EVMU) failure: VIB lost |
| `failures.eng.fadecA1` | bool | failure | write | `0` | Engine 1 FADEC channel A failure |
| `failures.eng.fadecA2` | bool | failure | write | `0` | Engine 2 FADEC channel A failure |
| `failures.eng.fadecAlternator1` | bool | failure | write | `0` | Engine 1 FADEC alternator failure (self supply lost) |
| `failures.eng.fadecAlternator2` | bool | failure | write | `0` | Engine 2 FADEC alternator failure (self supply lost) |
| `failures.eng.fadecB1` | bool | failure | write | `0` | Engine 1 FADEC channel B failure |
| `failures.eng.fadecB2` | bool | failure | write | `0` | Engine 2 FADEC channel B failure |
| `failures.eng.fadecOvht1` | bool | failure | write | `0` | Engine 1 FADEC (ECU) overheat |
| `failures.eng.fadecOvht2` | bool | failure | write | `0` | Engine 2 FADEC (ECU) overheat |
| `failures.eng.fanDamage1` | bool | failure | write | `0` | Engine 1 fan blade damage (bird / foreign object): high N1 and N2 vibration (Value: N1 VIB units at 100 % N1, default 8) |
| `failures.eng.fanDamage2` | bool | failure | write | `0` | Engine 2 fan blade damage (bird / foreign object): high N1 and N2 vibration (Value: N1 VIB units at 100 % N1, default 8) |
| `failures.eng.fanSeized1` | bool | failure | write | `0` | Engine 1 fan (N1 rotor) seized: no N1 rotation, the engine cannot run (LOW N1 / NO N1 ROTATION at start) |
| `failures.eng.fanSeized2` | bool | failure | write | `0` | Engine 2 fan (N1 rotor) seized: no N1 rotation, the engine cannot run (LOW N1 / NO N1 ROTATION at start) |
| `failures.eng.ffSensorA1` | bool | failure | write | `0` | Engine 1 FADEC channel A fuel flow sensor error (Value: bias kg/h, default 800) |
| `failures.eng.ffSensorA2` | bool | failure | write | `0` | Engine 2 FADEC channel A fuel flow sensor error (Value: bias kg/h, default 800) |
| `failures.eng.ffSensorB1` | bool | failure | write | `0` | Engine 1 FADEC channel B fuel flow sensor error (Value: bias kg/h, default 800) |
| `failures.eng.ffSensorB2` | bool | failure | write | `0` | Engine 2 FADEC channel B fuel flow sensor error (Value: bias kg/h, default 800) |
| `failures.eng.flameout1` | bool | failure | write | `0` | Engine 1 flameout: combustion lost, the engine runs down (the FADEC's relight succeeds once the failure is cleared) |
| `failures.eng.flameout2` | bool | failure | write | `0` | Engine 2 flameout: combustion lost, the engine runs down (the FADEC's relight succeeds once the failure is cleared) |
| `failures.eng.fuelCtl1` | bool | failure | write | `0` | Engine 1 fuel metering valve control failure |
| `failures.eng.fuelCtl2` | bool | failure | write | `0` | Engine 2 fuel metering valve control failure |
| `failures.eng.fuelFilter1` | bool | failure | write | `0` | Engine 1 fuel filter clogged |
| `failures.eng.fuelFilter2` | bool | failure | write | `0` | Engine 2 fuel filter clogged |
| `failures.eng.hpFuelValve1` | bool | failure | write | `0` | Engine 1 HP fuel valve failed closed |
| `failures.eng.hpFuelValve2` | bool | failure | write | `0` | Engine 2 HP fuel valve failed closed |
| `failures.eng.ignA1` | bool | failure | write | `0` | Engine 1 ignition circuit A (igniter A) failure |
| `failures.eng.ignA2` | bool | failure | write | `0` | Engine 2 ignition circuit A (igniter A) failure |
| `failures.eng.ignB1` | bool | failure | write | `0` | Engine 1 ignition circuit B (igniter B) failure |
| `failures.eng.ignB2` | bool | failure | write | `0` | Engine 2 ignition circuit B (igniter B) failure |
| `failures.eng.n1SensorA1` | bool | failure | write | `0` | Engine 1 FADEC channel A N1 sensor error (Value: bias %, default 10) |
| `failures.eng.n1SensorA2` | bool | failure | write | `0` | Engine 2 FADEC channel A N1 sensor error (Value: bias %, default 10) |
| `failures.eng.n1SensorB1` | bool | failure | write | `0` | Engine 1 FADEC channel B N1 sensor error (Value: bias %, default 10) |
| `failures.eng.n1SensorB2` | bool | failure | write | `0` | Engine 2 FADEC channel B N1 sensor error (Value: bias %, default 10) |
| `failures.eng.n2SensorA1` | bool | failure | write | `0` | Engine 1 FADEC channel A N2 sensor error (Value: bias %, default 10) |
| `failures.eng.n2SensorA2` | bool | failure | write | `0` | Engine 2 FADEC channel A N2 sensor error (Value: bias %, default 10) |
| `failures.eng.n2SensorB1` | bool | failure | write | `0` | Engine 1 FADEC channel B N2 sensor error (Value: bias %, default 10) |
| `failures.eng.n2SensorB2` | bool | failure | write | `0` | Engine 2 FADEC channel B N2 sensor error (Value: bias %, default 10) |
| `failures.eng.oilCooling1` | bool | failure | write | `0` | Engine 1 oil cooling loss (fuel/oil heat exchanger): oil temperature rises |
| `failures.eng.oilCooling2` | bool | failure | write | `0` | Engine 2 oil cooling loss (fuel/oil heat exchanger): oil temperature rises |
| `failures.eng.oilFilter1` | bool | failure | write | `0` | Engine 1 oil filter clogged |
| `failures.eng.oilFilter2` | bool | failure | write | `0` | Engine 2 oil filter clogged |
| `failures.eng.oilPump1` | bool | failure | write | `0` | Engine 1 oil pump failure: oil pressure lost |
| `failures.eng.oilPump2` | bool | failure | write | `0` | Engine 2 oil pump failure: oil pressure lost |
| `failures.eng.ovspdProt1` | bool | failure | write | `0` | Engine 1 N2 overspeed protection failure |
| `failures.eng.ovspdProt2` | bool | failure | write | `0` | Engine 2 N2 overspeed protection failure |
| `failures.eng.revHcuValveOpen1` | bool | failure | write | `0` | Engine 1 thrust reverser HCU pressurizing valve failed open (pressurized whenever the isolation valve is open) |
| `failures.eng.revHcuValveOpen2` | bool | failure | write | `0` | Engine 2 thrust reverser HCU pressurizing valve failed open (pressurized whenever the isolation valve is open) |
| `failures.eng.revIsolValveClosed1` | bool | failure | write | `0` | Engine 1 thrust reverser hydraulic isolation valve failed closed (no deployment) |
| `failures.eng.revIsolValveClosed2` | bool | failure | write | `0` | Engine 2 thrust reverser hydraulic isolation valve failed closed (no deployment) |
| `failures.eng.revIsolValveOpen1` | bool | failure | write | `0` | Engine 1 thrust reverser hydraulic isolation valve failed open |
| `failures.eng.revIsolValveOpen2` | bool | failure | write | `0` | Engine 2 thrust reverser hydraulic isolation valve failed open |
| `failures.eng.revJammed1` | bool | failure | write | `0` | Engine 1 thrust reverser jammed stowed (does not deploy) |
| `failures.eng.revJammed2` | bool | failure | write | `0` | Engine 2 thrust reverser jammed stowed (does not deploy) |
| `failures.eng.revSwitch1` | bool | failure | write | `0` | Engine 1 thrust reverser permission (lever) switch failure |
| `failures.eng.revSwitch2` | bool | failure | write | `0` | Engine 2 thrust reverser permission (lever) switch failure |
| `failures.eng.revUnlocked1` | bool | failure | write | `0` | Engine 1 thrust reverser lock failure: door unlocked (Value: door opening 0..1, default 0) |
| `failures.eng.revUnlocked2` | bool | failure | write | `0` | Engine 2 thrust reverser lock failure: door unlocked (Value: door opening 0..1, default 0) |
| `failures.eng.sensors1` | bool | failure | write | `0` | Engine 1 FADEC sensors lost on both channels (PS3, T25, T3) |
| `failures.eng.sensors2` | bool | failure | write | `0` | Engine 2 FADEC sensors lost on both channels (PS3, T25, T3) |
| `failures.eng.stall1` | bool | failure | write | `0` | Engine 1 compressor stall: surges above a thrust threshold (Value: N1 %, default 65; N1 / N2 fluctuations, thrust loss, EGT and VIB rise, ENG STALL; idle recovers; a start in progress aborts) |
| `failures.eng.stall2` | bool | failure | write | `0` | Engine 2 compressor stall: surges above a thrust threshold (Value: N1 %, default 65; N1 / N2 fluctuations, thrust loss, EGT and VIB rise, ENG STALL; idle recovers; a start in progress aborts) |
| `failures.eng.startValveClosed1` | bool | failure | write | `0` | Engine 1 start valve stuck closed |
| `failures.eng.startValveClosed2` | bool | failure | write | `0` | Engine 2 start valve stuck closed |
| `failures.eng.startValveOpen1` | bool | failure | write | `0` | Engine 1 start valve stuck open |
| `failures.eng.startValveOpen2` | bool | failure | write | `0` | Engine 2 start valve stuck open |
| `failures.eng.thrustControl1` | bool | failure | write | `0` | Engine 1 FADEC thrust control malfunction (FAULT light, thrust frozen) |
| `failures.eng.thrustControl2` | bool | failure | write | `0` | Engine 2 FADEC thrust control malfunction (FAULT light, thrust frozen) |
| `failures.eng.tlaResolverA1` | bool | failure | write | `0` | Thrust lever 1 resolver A (FADEC 1 channel A) failure |
| `failures.eng.tlaResolverA2` | bool | failure | write | `0` | Thrust lever 2 resolver A (FADEC 2 channel A) failure |
| `failures.eng.tlaResolverB1` | bool | failure | write | `0` | Thrust lever 1 resolver B (FADEC 1 channel B) failure |
| `failures.eng.tlaResolverB2` | bool | failure | write | `0` | Thrust lever 2 resolver B (FADEC 2 channel B) failure |
| `failures.eng.tlaResolverDrift1` | bool | failure | write | `0` | Thrust lever 1 resolver B drift: both resolvers disagree (Value: degrees, default 10) |
| `failures.eng.tlaResolverDrift2` | bool | failure | write | `0` | Thrust lever 2 resolver B drift: both resolvers disagree (Value: degrees, default 10) |

## Failures / Engines (CFM)

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.eng.ctlValve1` | bool | failure | write | `0` | Engine 1 burner staging / clearance control valve failure (CFM) |
| `failures.eng.ctlValve2` | bool | failure | write | `0` | Engine 2 burner staging / clearance control valve failure (CFM) |
| `failures.eng.fuelReturnValve1` | bool | failure | write | `0` | Engine 1 fuel return valve failure (CFM) |
| `failures.eng.fuelReturnValve2` | bool | failure | write | `0` | Engine 2 fuel return valve failure (CFM) |
| `failures.eng.probes1` | bool | failure | write | `0` | Engine 1 inlet probes lost on both channels (T12, P0, PT2; CFM) |
| `failures.eng.probes2` | bool | failure | write | `0` | Engine 2 inlet probes lost on both channels (T12, P0, PT2; CFM) |

## Failures / Engines (IAE)

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.eng.airExchgrClosed1` | bool | failure | write | `0` | Engine 1 air cooled oil cooler valve failed closed (IAE) |
| `failures.eng.airExchgrClosed2` | bool | failure | write | `0` | Engine 2 air cooled oil cooler valve failed closed (IAE) |
| `failures.eng.airExchgrOpen1` | bool | failure | write | `0` | Engine 1 air cooled oil cooler valve failed open (IAE) |
| `failures.eng.airExchgrOpen2` | bool | failure | write | `0` | Engine 2 air cooled oil cooler valve failed open (IAE) |
| `failures.eng.bearing4ScavengeValve1` | bool | failure | write | `0` | Engine 1 No. 4 bearing scavenge valve stuck (IAE) |
| `failures.eng.bearing4ScavengeValve2` | bool | failure | write | `0` | Engine 2 No. 4 bearing scavenge valve stuck (IAE) |
| `failures.eng.bearing4Seal1` | bool | failure | write | `0` | Engine 1 No. 4 bearing failed seal / clogged restrictor: high pressure (IAE) |
| `failures.eng.bearing4Seal2` | bool | failure | write | `0` | Engine 2 No. 4 bearing failed seal / clogged restrictor: high pressure (IAE) |
| `failures.eng.epr1` | bool | failure | write | `0` | Engine 1 EPR sensing lost (P2 / P5): automatic N1 rated mode (IAE) |
| `failures.eng.epr2` | bool | failure | write | `0` | Engine 2 EPR sensing lost (P2 / P5): automatic N1 rated mode (IAE) |
| `failures.eng.eprSensorA1` | bool | failure | write | `0` | Engine 1 FADEC channel A EPR sensor error (Value: bias, default 0.10; IAE) |
| `failures.eng.eprSensorA2` | bool | failure | write | `0` | Engine 2 FADEC channel A EPR sensor error (Value: bias, default 0.10; IAE) |
| `failures.eng.eprSensorB1` | bool | failure | write | `0` | Engine 1 FADEC channel B EPR sensor error (Value: bias, default 0.10; IAE) |
| `failures.eng.eprSensorB2` | bool | failure | write | `0` | Engine 2 FADEC channel B EPR sensor error (Value: bias, default 0.10; IAE) |
| `failures.eng.fuelDiverterValve1` | bool | failure | write | `0` | Engine 1 fuel diverter valve fault (IAE) |
| `failures.eng.fuelDiverterValve2` | bool | failure | write | `0` | Engine 2 fuel diverter valve fault (IAE) |
| `failures.eng.fuelOvht1` | bool | failure | write | `0` | Engine 1 fuel overheat: the EEC off-loads the IDG (IAE HOT FUEL) |
| `failures.eng.fuelOvht2` | bool | failure | write | `0` | Engine 2 fuel overheat: the EEC off-loads the IDG (IAE HOT FUEL) |
| `failures.eng.fuelSpillValve1` | bool | failure | write | `0` | Engine 1 fuel heat management spill (return) valve fault (IAE) |
| `failures.eng.fuelSpillValve2` | bool | failure | write | `0` | Engine 2 fuel heat management spill (return) valve fault (IAE) |
| `failures.eng.fuelTempSensors1` | bool | failure | write | `0` | Engine 1 fuel and oil temperature sensors lost on both channels (IAE) |
| `failures.eng.fuelTempSensors2` | bool | failure | write | `0` | Engine 2 fuel and oil temperature sensors lost on both channels (IAE) |
| `failures.eng.startValveControl1` | bool | failure | write | `0` | Engine 1 EEC start valve control lost: valve manual only on ground, windmill start in flight (IAE) |
| `failures.eng.startValveControl2` | bool | failure | write | `0` | Engine 2 EEC start valve control lost: valve manual only on ground, windmill start in flight (IAE) |
| `failures.eng.sysFault1` | bool | failure | write | `0` | Engine 1 EEC solenoid group overcurrent: risk of high EGT (IAE) |
| `failures.eng.sysFault2` | bool | failure | write | `0` | Engine 2 EEC solenoid group overcurrent: risk of high EGT (IAE) |
| `failures.eng.t21` | bool | failure | write | `0` | Engine 1 inlet temperature T2 / ambient sensing lost: N1 unrated (degraded) mode (IAE) |
| `failures.eng.t22` | bool | failure | write | `0` | Engine 2 inlet temperature T2 / ambient sensing lost: N1 unrated (degraded) mode (IAE) |

## Failures / FCU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.fcu.channel1` | bool | failure | write | `0` | FCU channel 1 failed (FCU 1 FAULT) |
| `failures.fcu.channel2` | bool | failure | write | `0` | FCU channel 2 failed (FCU 2 FAULT) |

## Failures / Fire

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.fire.apu` | bool | failure | write | `0` | APU fire, out after the agent |
| `failures.fire.apuBottleDischarged` | bool | failure | write | `0` | APU AGENT discharged (bottle empty, DISCH light; clear = bottle refilled) |
| `failures.fire.apuBottleLeak` | bool | failure | write | `0` | APU bottle leaking: loses its agent (DISCH light) |
| `failures.fire.apuBottleSquib` | bool | failure | write | `0` | APU bottle squib failed (no discharge, no SQUIB light at the test) |
| `failures.fire.apuFdu` | bool | failure | write | `0` | APU fire detection unit failed |
| `failures.fire.apuLoopA` | bool | failure | write | `0` | APU fire detection loop A failed (break) |
| `failures.fire.apuLoopB` | bool | failure | write | `0` | APU fire detection loop B failed (break) |
| `failures.fire.apuUnextinguishable` | bool | failure | write | `0` | APU fire, not extinguishable (still burning after the agent) |
| `failures.fire.avionicsSmoke` | bool | failure | write | `0` | Smoke in the avionics ventilation extraction duct (AVIONICS SMOKE) |
| `failures.fire.avionicsSmokeDet` | bool | failure | write | `0` | Avionics smoke detector failed (no detection) |
| `failures.fire.cargoAftDetA` | bool | failure | write | `0` | Aft cargo smoke detectors, channel 1 loop, failed |
| `failures.fire.cargoAftDetB` | bool | failure | write | `0` | Aft cargo smoke detectors, channel 2 loop, failed |
| `failures.fire.cargoAftSmoke` | bool | failure | write | `0` | Smoke in the aft cargo compartment (SMOKE AFT CARGO SMOKE) |
| `failures.fire.cargoBottleDischarged` | bool | failure | write | `0` | CARGO bottle discharged (bottle empty, DISCH light; clear = bottle refilled) |
| `failures.fire.cargoBottleLeak` | bool | failure | write | `0` | Cargo bottle leaking: loses its agent (DISCH light) |
| `failures.fire.cargoFwdDetA` | bool | failure | write | `0` | Forward cargo smoke detector, channel 1 loop, failed |
| `failures.fire.cargoFwdDetB` | bool | failure | write | `0` | Forward cargo smoke detector, channel 2 loop, failed |
| `failures.fire.cargoFwdSmoke` | bool | failure | write | `0` | Smoke in the forward cargo compartment (SMOKE FWD CARGO SMOKE) |
| `failures.fire.cargoSquibAft` | bool | failure | write | `0` | Cargo bottle AFT discharge head squib failed (SMOKE AFT CRG BTL FAULT) |
| `failures.fire.cargoSquibFwd` | bool | failure | write | `0` | Cargo bottle FWD discharge head squib failed (SMOKE FWD CRG BTL FAULT) |
| `failures.fire.eng1` | bool | failure | write | `0` | Engine 1 fire, out after one agent |
| `failures.fire.eng1Bottle1Discharged` | bool | failure | write | `0` | ENG 1 AGENT 1 discharged (bottle empty, DISCH light; clear = bottle refilled) |
| `failures.fire.eng1Bottle1Leak` | bool | failure | write | `0` | Engine 1 bottle 1 leaking: loses its agent (DISCH light) |
| `failures.fire.eng1Bottle1Squib` | bool | failure | write | `0` | Engine 1 bottle 1 squib failed (no discharge, no SQUIB light at the test) |
| `failures.fire.eng1Bottle2Discharged` | bool | failure | write | `0` | ENG 1 AGENT 2 discharged (bottle empty, DISCH light; clear = bottle refilled) |
| `failures.fire.eng1Bottle2Leak` | bool | failure | write | `0` | Engine 1 bottle 2 leaking: loses its agent (DISCH light) |
| `failures.fire.eng1Bottle2Squib` | bool | failure | write | `0` | Engine 1 bottle 2 squib failed (no discharge, no SQUIB light at the test) |
| `failures.fire.eng1Fdu` | bool | failure | write | `0` | Engine 1 fire detection unit failed |
| `failures.fire.eng1LoopA` | bool | failure | write | `0` | Engine 1 fire detection loop A failed (break) |
| `failures.fire.eng1LoopB` | bool | failure | write | `0` | Engine 1 fire detection loop B failed (break) |
| `failures.fire.eng1TwoAgents` | bool | failure | write | `0` | Engine 1 fire, out only after both agents |
| `failures.fire.eng1Unextinguishable` | bool | failure | write | `0` | Engine 1 fire, not extinguishable (still burning after both agents) |
| `failures.fire.eng2` | bool | failure | write | `0` | Engine 2 fire, out after one agent |
| `failures.fire.eng2Bottle1Discharged` | bool | failure | write | `0` | ENG 2 AGENT 1 discharged (bottle empty, DISCH light; clear = bottle refilled) |
| `failures.fire.eng2Bottle1Leak` | bool | failure | write | `0` | Engine 2 bottle 1 leaking: loses its agent (DISCH light) |
| `failures.fire.eng2Bottle1Squib` | bool | failure | write | `0` | Engine 2 bottle 1 squib failed (no discharge, no SQUIB light at the test) |
| `failures.fire.eng2Bottle2Discharged` | bool | failure | write | `0` | ENG 2 AGENT 2 discharged (bottle empty, DISCH light; clear = bottle refilled) |
| `failures.fire.eng2Bottle2Leak` | bool | failure | write | `0` | Engine 2 bottle 2 leaking: loses its agent (DISCH light) |
| `failures.fire.eng2Bottle2Squib` | bool | failure | write | `0` | Engine 2 bottle 2 squib failed (no discharge, no SQUIB light at the test) |
| `failures.fire.eng2Fdu` | bool | failure | write | `0` | Engine 2 fire detection unit failed |
| `failures.fire.eng2LoopA` | bool | failure | write | `0` | Engine 2 fire detection loop A failed (break) |
| `failures.fire.eng2LoopB` | bool | failure | write | `0` | Engine 2 fire detection loop B failed (break) |
| `failures.fire.eng2TwoAgents` | bool | failure | write | `0` | Engine 2 fire, out only after both agents |
| `failures.fire.eng2Unextinguishable` | bool | failure | write | `0` | Engine 2 fire, not extinguishable (still burning after both agents) |
| `failures.fire.lavDet` | bool | failure | write | `0` | Lavatory smoke detection failed (SMOKE LAVATORY DET FAULT) |
| `failures.fire.lavSmoke` | bool | failure | write | `0` | Smoke in a lavatory (SMOKE LAVATORY SMOKE) |
| `failures.fire.sdcu1` | bool | failure | write | `0` | Smoke detection control unit channel 1 failed |
| `failures.fire.sdcu2` | bool | failure | write | `0` | Smoke detection control unit channel 2 failed |

## Failures / Flight controls

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.fctl.ailL` | bool | failure | write | `0` | Left aileron: both servo jacks failed (L AIL FAULT) |
| `failures.fctl.ailLServoB` | bool | failure | write | `0` | Left aileron blue servo jack failed (F/CTL AIL SERVO FAULT) |
| `failures.fctl.ailLServoG` | bool | failure | write | `0` | Left aileron green servo jack failed (F/CTL AIL SERVO FAULT) |
| `failures.fctl.ailR` | bool | failure | write | `0` | Right aileron: both servo jacks failed (R AIL FAULT) |
| `failures.fctl.ailRServoB` | bool | failure | write | `0` | Right aileron blue servo jack failed (F/CTL AIL SERVO FAULT) |
| `failures.fctl.ailRServoG` | bool | failure | write | `0` | Right aileron green servo jack failed (F/CTL AIL SERVO FAULT) |
| `failures.fctl.elac1` | bool | failure | write | `0` | ELAC 1 failure (FAULT light, computer lost) |
| `failures.fctl.elac1Pitch` | bool | failure | write | `0` | ELAC 1 pitch channel failure: elevators / THS control lost, ailerons kept (F/CTL ELAC 1 PITCH FAULT) |
| `failures.fctl.elac2` | bool | failure | write | `0` | ELAC 2 failure (FAULT light, computer lost) |
| `failures.fctl.elac2Pitch` | bool | failure | write | `0` | ELAC 2 pitch channel failure: elevators / THS control lost, ailerons kept (F/CTL ELAC 2 PITCH FAULT) |
| `failures.fctl.elevL` | bool | failure | write | `0` | Left elevator: both servo jacks failed (L ELEV FAULT) |
| `failures.fctl.elevLServoB` | bool | failure | write | `0` | Left elevator blue servo jack failed (F/CTL ELEV SERVO FAULT) |
| `failures.fctl.elevLServoG` | bool | failure | write | `0` | Left elevator green servo jack failed (F/CTL ELEV SERVO FAULT) |
| `failures.fctl.elevR` | bool | failure | write | `0` | Right elevator: both servo jacks failed (R ELEV FAULT) |
| `failures.fctl.elevRServoB` | bool | failure | write | `0` | Right elevator blue servo jack failed (F/CTL ELEV SERVO FAULT) |
| `failures.fctl.elevRServoY` | bool | failure | write | `0` | Right elevator yellow servo jack failed (F/CTL ELEV SERVO FAULT) |
| `failures.fctl.fac1` | bool | failure | write | `0` | FAC 1 failure (FAULT light: yaw functions and flight envelope lost) |
| `failures.fctl.fac1RudTrim` | bool | failure | write | `0` | Rudder trim actuator 1 failed (AUTO FLT RUD TRIM 1 FAULT; with the other one: RUD TRIM SYS) |
| `failures.fctl.fac1RudTrvLim` | bool | failure | write | `0` | Rudder travel limiter actuator 1 failed (AUTO FLT RUD TRV LIM 1; with the other one: RUD TRV LIM SYS) |
| `failures.fctl.fac1Windshear` | bool | failure | write | `0` | FAC 1 reactive windshear detection failure (both FACs: AUTO FLT REAC W/S DET FAULT) |
| `failures.fctl.fac1YawDamper` | bool | failure | write | `0` | Yaw damper actuator 1 failed (AUTO FLT YAW DAMPER 1; with the other one: YAW DAMPER SYS) |
| `failures.fctl.fac2` | bool | failure | write | `0` | FAC 2 failure (FAULT light: yaw functions and flight envelope lost) |
| `failures.fctl.fac2RudTrim` | bool | failure | write | `0` | Rudder trim actuator 2 failed (AUTO FLT RUD TRIM 2 FAULT; with the other one: RUD TRIM SYS) |
| `failures.fctl.fac2RudTrvLim` | bool | failure | write | `0` | Rudder travel limiter actuator 2 failed (AUTO FLT RUD TRV LIM 2; with the other one: RUD TRV LIM SYS) |
| `failures.fctl.fac2Windshear` | bool | failure | write | `0` | FAC 2 reactive windshear detection failure (both FACs: AUTO FLT REAC W/S DET FAULT) |
| `failures.fctl.fac2YawDamper` | bool | failure | write | `0` | Yaw damper actuator 2 failed (AUTO FLT YAW DAMPER 2; with the other one: YAW DAMPER SYS) |
| `failures.fctl.fcdc1` | bool | failure | write | `0` | FCDC 1 failure |
| `failures.fctl.fcdc2` | bool | failure | write | `0` | FCDC 2 failure |
| `failures.fctl.flapAttachSensor` | bool | failure | write | `0` | Flap attachment failure detection sensor failed (F/CTL FLAP ATTACH SENSOR) |
| `failures.fctl.flapWtb` | bool | failure | write | `0` | Flap wing tip brakes applied (FLAPS LOCKED) |
| `failures.fctl.flapWtbFault` | bool | failure | write | `0` | One flap wing tip brake failed: cannot be applied (F/CTL FLAP TIP BRK FAULT) |
| `failures.fctl.sec1` | bool | failure | write | `0` | SEC 1 failure (FAULT light, computer lost) |
| `failures.fctl.sec1GndSplr` | bool | failure | write | `0` | SEC 1 ground spoiler function lost (F/CTL GND SPLR 3+4 FAULT) |
| `failures.fctl.sec1SpdBrk` | bool | failure | write | `0` | Speed brakes 3+4 do not extend: SEC 1 speed brake order lost, roll and ground spoilers kept (F/CTL SPD BRK DISAGREE) |
| `failures.fctl.sec1SpdBrkLever` | bool | failure | write | `0` | Speed brake lever transducer to SEC 1 failed (F/CTL SPD BRK 3+4 FAULT) |
| `failures.fctl.sec2` | bool | failure | write | `0` | SEC 2 failure (FAULT light, computer lost) |
| `failures.fctl.sec2GndSplr` | bool | failure | write | `0` | SEC 2 ground spoiler function lost (F/CTL GND SPLR 5 FAULT) |
| `failures.fctl.sec3` | bool | failure | write | `0` | SEC 3 failure (FAULT light, computer lost) |
| `failures.fctl.sec3GndSplr` | bool | failure | write | `0` | SEC 3 ground spoiler function lost (F/CTL GND SPLR 1+2 FAULT) |
| `failures.fctl.sec3SpdBrk` | bool | failure | write | `0` | Speed brakes 2 do not extend: SEC 3 speed brake order lost, roll and ground spoilers kept (F/CTL SPD BRK DISAGREE) |
| `failures.fctl.sec3SpdBrkLever` | bool | failure | write | `0` | Speed brake lever transducer to SEC 3 failed (F/CTL SPD BRK 2 FAULT) |
| `failures.fctl.sfcc1` | bool | failure | write | `0` | SFCC 1 failure (slat and flap channels) |
| `failures.fctl.sfcc1Flap` | bool | failure | write | `0` | SFCC 1 flap channel failure (FLAP SYS 1 FAULT) |
| `failures.fctl.sfcc1Slat` | bool | failure | write | `0` | SFCC 1 slat channel failure (SLAT SYS 1 FAULT) |
| `failures.fctl.sfcc2` | bool | failure | write | `0` | SFCC 2 failure (slat and flap channels) |
| `failures.fctl.sfcc2Flap` | bool | failure | write | `0` | SFCC 2 flap channel failure (FLAP SYS 2 FAULT) |
| `failures.fctl.sfcc2Slat` | bool | failure | write | `0` | SFCC 2 slat channel failure (SLAT SYS 2 FAULT) |
| `failures.fctl.sidestickCapt` | bool | failure | write | `0` | Captain sidestick transducers failed (L SIDESTICK FAULT) |
| `failures.fctl.sidestickCaptLock` | bool | failure | write | `0` | Captain sidestick deactivated: F/O takeover pb held > 40 s (red arrow CAPT; clear = reactivated, as a takeover pb press) |
| `failures.fctl.sidestickFo` | bool | failure | write | `0` | F/O sidestick transducers failed (R SIDESTICK FAULT) |
| `failures.fctl.sidestickFoLock` | bool | failure | write | `0` | F/O sidestick deactivated: captain takeover pb held > 40 s (red arrow F/O; clear = reactivated, as a takeover pb press) |
| `failures.fctl.sidestickPriorityLogic` | bool | failure | write | `0` | Sidestick priority logic circuit failure (F/CTL SIDESTICK PRIORITY) |
| `failures.fctl.slatWtb` | bool | failure | write | `0` | Slat wing tip brakes applied (SLATS LOCKED) |
| `failures.fctl.slatWtbFault` | bool | failure | write | `0` | One slat wing tip brake failed: cannot be applied (F/CTL SLAT TIP BRK FAULT) |
| `failures.fctl.splr1L` | bool | failure | write | `0` | Left spoiler 1 servo failed |
| `failures.fctl.splr1R` | bool | failure | write | `0` | Right spoiler 1 servo failed |
| `failures.fctl.splr2L` | bool | failure | write | `0` | Left spoiler 2 servo failed |
| `failures.fctl.splr2R` | bool | failure | write | `0` | Right spoiler 2 servo failed |
| `failures.fctl.splr3L` | bool | failure | write | `0` | Left spoiler 3 servo failed |
| `failures.fctl.splr3R` | bool | failure | write | `0` | Right spoiler 3 servo failed |
| `failures.fctl.splr4L` | bool | failure | write | `0` | Left spoiler 4 servo failed |
| `failures.fctl.splr4R` | bool | failure | write | `0` | Right spoiler 4 servo failed |
| `failures.fctl.splr5L` | bool | failure | write | `0` | Left spoiler 5 servo failed |
| `failures.fctl.splr5R` | bool | failure | write | `0` | Right spoiler 5 servo failed |
| `failures.fctl.thsJam` | bool | failure | write | `0` | Stabilizer jammed (STABILIZER JAM) |
| `failures.fctl.yawDamper` | bool | failure | write | `0` | Yaw damper servo actuator failed (YAW DAMPER SYS) |

## Failures / FMGC

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.autoFlt.athrLock` | bool | failure | write | `0` | A/THR lost: instinctive disconnect pb held > 15 s (A/THR and alpha floor lost; clear = reset, otherwise until an FMGC power-up on ground) |
| `failures.fmgc.fmgc1` | bool | failure | write | `0` | FMGC 1 failure |
| `failures.fmgc.fmgc2` | bool | failure | write | `0` | FMGC 2 failure |

## Failures / Fuel

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.fuel.apuLpValveClosed` | bool | failure | write | `0` | APU LP fuel valve jammed closed: APU without fuel (FUEL APU LP VALVE FAULT) |
| `failures.fuel.apuLpValveOpen` | bool | failure | write | `0` | APU LP fuel valve jammed open (FUEL APU LP VALVE FAULT) |
| `failures.fuel.autoFeed` | bool | failure | write | `0` | Center tank pump AUTO control failure (pumps do not stop) |
| `failures.fuel.ctrTkPump1` | bool | failure | write | `0` | Center tank pump 1 failure |
| `failures.fuel.ctrTkPump2` | bool | failure | write | `0` | Center tank pump 2 failure |
| `failures.fuel.fqiCadensiconL` | bool | failure | write | `0` | Left inner tank densitometer (cadensicon) failed (alone: the right one is used) |
| `failures.fuel.fqiCadensiconR` | bool | failure | write | `0` | Right inner tank densitometer (cadensicon) failed (both: every tank degraded) |
| `failures.fuel.fqiCh1` | bool | failure | write | `0` | FQI channel 1 failure |
| `failures.fuel.fqiCh2` | bool | failure | write | `0` | FQI channel 2 failure |
| `failures.fuel.fqiProbeCenter` | bool | failure | write | `0` | FQI probes of the center tank failed (FQI degraded mode: quantity and FOB dashed) |
| `failures.fuel.fqiProbeLInner` | bool | failure | write | `0` | FQI probes of the left inner cell failed (FQI degraded mode: quantity and FOB dashed) |
| `failures.fuel.fqiProbeLOuter` | bool | failure | write | `0` | FQI probes of the left outer cell failed (FQI degraded mode: quantity and FOB dashed) |
| `failures.fuel.fqiProbeRInner` | bool | failure | write | `0` | FQI probes of the right inner cell failed (FQI degraded mode: quantity and FOB dashed) |
| `failures.fuel.fqiProbeROuter` | bool | failure | write | `0` | FQI probes of the right outer cell failed (FQI degraded mode: quantity and FOB dashed) |
| `failures.fuel.lTkPump1` | bool | failure | write | `0` | Left tank pump 1 failure |
| `failures.fuel.lTkPump2` | bool | failure | write | `0` | Left tank pump 2 failure |
| `failures.fuel.leakEng1` | bool | failure | write | `0` | Fuel leak on engine 1, downstream of its LP valve (2000 kg/h) |
| `failures.fuel.leakEng2` | bool | failure | write | `0` | Fuel leak on engine 2, downstream of its LP valve (2000 kg/h) |
| `failures.fuel.leakLWing` | bool | failure | write | `0` | Fuel leak in the left wing feed line while pressurized (2000 kg/h) |
| `failures.fuel.leakRWing` | bool | failure | write | `0` | Fuel leak in the right wing feed line while pressurized (2000 kg/h) |
| `failures.fuel.overflowSensorL` | bool | failure | write | `0` | Left surge tank overflow sensor failure (FUEL OVERFLOW PROT FAULT) |
| `failures.fuel.overflowSensorR` | bool | failure | write | `0` | Right surge tank overflow sensor failure (FUEL OVERFLOW PROT FAULT) |
| `failures.fuel.rTkPump1` | bool | failure | write | `0` | Right tank pump 1 failure |
| `failures.fuel.rTkPump2` | bool | failure | write | `0` | Right tank pump 2 failure |
| `failures.fuel.xfeedValve` | bool | failure | write | `0` | X FEED valve jammed where it is |
| `failures.fuel.xfrValveL1` | bool | failure | write | `0` | Left transfer valve 1 failed closed |
| `failures.fuel.xfrValveL2` | bool | failure | write | `0` | Left transfer valve 2 failed closed |
| `failures.fuel.xfrValveR1` | bool | failure | write | `0` | Right transfer valve 1 failed closed |
| `failures.fuel.xfrValveR2` | bool | failure | write | `0` | Right transfer valve 2 failed closed |

## Failures / FWS

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.fws.fwc1` | bool | failure | write | `0` | FWC 1 failure |
| `failures.fws.fwc2` | bool | failure | write | `0` | FWC 2 failure |
| `failures.fws.sdac1` | bool | failure | write | `0` | SDAC 1 failure (FWS SDAC 1 FAULT) |
| `failures.fws.sdac2` | bool | failure | write | `0` | SDAC 2 failure (FWS SDAC 2 FAULT) |

## Failures / Hydraulic

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.hyd.bElecPump` | bool | failure | write | `0` | Blue electric pump failure |
| `failures.hyd.bElecPumpOvht` | bool | failure | write | `0` | Blue electric pump overheat |
| `failures.hyd.bLeak` | bool | failure | write | `0` | Blue system external leak |
| `failures.hyd.bRsvrAir` | bool | failure | write | `0` | Blue reservoir air pressure loss |
| `failures.hyd.bRsvrOvht` | bool | failure | write | `0` | Blue fluid overheat |
| `failures.hyd.gEdp` | bool | failure | write | `0` | Engine 1 pump (green) failure |
| `failures.hyd.gLeak` | bool | failure | write | `0` | Green system external leak |
| `failures.hyd.gRsvrAir` | bool | failure | write | `0` | Green reservoir air pressure loss |
| `failures.hyd.gRsvrOvht` | bool | failure | write | `0` | Green fluid overheat |
| `failures.hyd.ptu` | bool | failure | write | `0` | PTU failure (does not run) |
| `failures.hyd.rat` | bool | failure | write | `0` | RAT pump failure |
| `failures.hyd.yEdp` | bool | failure | write | `0` | Engine 2 pump (yellow) failure |
| `failures.hyd.yElecPump` | bool | failure | write | `0` | Yellow electric pump failure |
| `failures.hyd.yElecPumpOvht` | bool | failure | write | `0` | Yellow electric pump overheat |
| `failures.hyd.yLeak` | bool | failure | write | `0` | Yellow system external leak |
| `failures.hyd.yRsvrAir` | bool | failure | write | `0` | Yellow reservoir air pressure loss |
| `failures.hyd.yRsvrOvht` | bool | failure | write | `0` | Yellow fluid overheat |

## Failures / Ice and rain

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.wiper.captMotor` | bool | failure | write | `0` | Captain wiper motor-converter failure (the blade stops where it is) |
| `failures.wiper.captRplntValve` | bool | failure | write | `0` | Captain rain repellent solenoid valve failed closed (no spray) |
| `failures.wiper.foMotor` | bool | failure | write | `0` | First officer wiper motor-converter failure (the blade stops where it is) |
| `failures.wiper.foRplntValve` | bool | failure | write | `0` | First officer rain repellent solenoid valve failed closed (no spray) |
| `failures.wshld.birdSplatL` | bool | failure | write | `0` | Captain windshield: bird remains on the glass (blood and feathers; the wipers do not remove them) |
| `failures.wshld.birdSplatR` | bool | failure | write | `0` | First officer windshield: bird remains on the glass (blood and feathers; the wipers do not remove them) |

## Failures / ISIS

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.isis.attFault` | bool | failure | write | `0` | ISIS inertial sensors failed (red ATT flag) |
| `failures.isis.failure` | bool | failure | write | `0` | ISIS internal failure (OUT OF ORDER page) |
| `failures.isis.maint` | bool | failure | write | `0` | ISIS configuration / pin programming parity error (white MAINT flag on ground) |
| `failures.isis.psSensor` | bool | failure | write | `0` | ISIS static pressure sensor failed (ALT, SPD and M flags) |
| `failures.isis.ptSensor` | bool | failure | write | `0` | ISIS total pressure sensor failed (SPD and M flags) |

## Failures / Landing gear

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.brakes.abcu` | bool | failure | write | `0` | Alternate braking control unit failure (BRAKES ALTN BRK FAULT) |
| `failures.brakes.accuLeak` | bool | failure | write | `0` | Yellow brake accumulator leak (empties in about 1 h without yellow pressure) |
| `failures.brakes.accuPrechargeLow` | bool | failure | write | `0` | Yellow brake accumulator nitrogen precharge lost (few brake applications) |
| `failures.brakes.altnReleasedL` | bool | failure | write | `0` | Left gear brakes released in alternate braking (BRAKES ALTN L RELEASED) |
| `failures.brakes.altnReleasedR` | bool | failure | write | `0` | Right gear brakes released in alternate braking (BRAKES ALTN R RELEASED) |
| `failures.brakes.antiSkid` | bool | failure | write | `0` | Anti-skid failure (detected by the BSCU) |
| `failures.brakes.autoBrk` | bool | failure | write | `0` | Autobrake failure |
| `failures.brakes.bscuCh1` | bool | failure | write | `0` | BSCU channel 1 failure (BRAKES SYS 1 FAULT) |
| `failures.brakes.bscuCh2` | bool | failure | write | `0` | BSCU channel 2 failure (BRAKES SYS 2 FAULT) |
| `failures.brakes.bscuMinor` | bool | failure | write | `0` | BSCU minor brake / steering fault, no operational effect (BRAKES-N/WS MINOR FAULT) |
| `failures.brakes.normSelValveClosed` | bool | failure | write | `0` | Brake normal selector valve failed closed: normal braking lost (WHEEL HYD SEL FAULT) |
| `failures.brakes.normSelValveOpen` | bool | failure | write | `0` | Brake normal selector valve failed open (WHEEL HYD SEL FAULT) |
| `failures.brakes.parkBrkValve` | bool | failure | write | `0` | Parking brake control valve jammed where it is (BRAKES PARK BRK FAULT) |
| `failures.brakes.released1` | bool | failure | write | `0` | Brake 1 released in normal braking (BRAKES RELEASED) |
| `failures.brakes.released2` | bool | failure | write | `0` | Brake 2 released in normal braking (BRAKES RELEASED) |
| `failures.brakes.released3` | bool | failure | write | `0` | Brake 3 released in normal braking (BRAKES RELEASED) |
| `failures.brakes.released4` | bool | failure | write | `0` | Brake 4 released in normal braking (BRAKES RELEASED) |
| `failures.lg.lgciu1` | bool | failure | write | `0` | LGCIU 1 failure |
| `failures.lg.lgciu2` | bool | failure | write | `0` | LGCIU 2 failure |
| `failures.lg.uplockLeft` | bool | failure | write | `0` | left gear uplock stays in the locked position after extension (L/G GEAR UPLOCK FAULT) |
| `failures.lg.uplockNose` | bool | failure | write | `0` | nose gear uplock stays in the locked position after extension (L/G GEAR UPLOCK FAULT) |
| `failures.lg.uplockRight` | bool | failure | write | `0` | right gear uplock stays in the locked position after extension (L/G GEAR UPLOCK FAULT) |
| `failures.wheel.nws` | bool | failure | write | `0` | Nose wheel steering failure (detected by the BSCU) |
| `failures.wheel.nwsSelValveOpen` | bool | failure | write | `0` | Nose wheel steering selector valve failed open: steering pressurized (WHEEL HYD SEL FAULT) |
| `failures.wheel.tire1` | bool | failure | write | `0` | Main wheel 1 tire deflated / burst (also set by the model: fusible plugs melted or locked wheel skid; clear = new wheel, its brake cooled) |
| `failures.wheel.tire2` | bool | failure | write | `0` | Main wheel 2 tire deflated / burst (also set by the model: fusible plugs melted or locked wheel skid; clear = new wheel, its brake cooled) |
| `failures.wheel.tire3` | bool | failure | write | `0` | Main wheel 3 tire deflated / burst (also set by the model: fusible plugs melted or locked wheel skid; clear = new wheel, its brake cooled) |
| `failures.wheel.tire4` | bool | failure | write | `0` | Main wheel 4 tire deflated / burst (also set by the model: fusible plugs melted or locked wheel skid; clear = new wheel, its brake cooled) |
| `failures.wheel.tireNoseL` | bool | failure | write | `0` | Nose wheel left tire deflated / burst (clear = new wheel) |
| `failures.wheel.tireNoseR` | bool | failure | write | `0` | Nose wheel right tire deflated / burst (clear = new wheel) |
| `failures.wheel.tpis` | bool | failure | write | `0` | Tire pressure indicating system failure (TPIS option: WHEEL page pressures amber XX) |

## Failures / Lights

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.lights.beaconLower` | bool | failure | write | `0` | Lower beacon failed |
| `failures.lights.beaconUpper` | bool | failure | write | `0` | Upper beacon failed |
| `failures.lights.ldgLtLLamp` | bool | failure | write | `0` | Left landing light lamp failed |
| `failures.lights.ldgLtLMotor` | bool | failure | write | `0` | Left landing light extension motor jammed (stays where it is) |
| `failures.lights.ldgLtRLamp` | bool | failure | write | `0` | Right landing light lamp failed |
| `failures.lights.ldgLtRMotor` | bool | failure | write | `0` | Right landing light extension motor jammed (stays where it is) |
| `failures.lights.logoLLamp` | bool | failure | write | `0` | Left logo light lamp failed |
| `failures.lights.logoRLamp` | bool | failure | write | `0` | Right logo light lamp failed |
| `failures.lights.nav1Lamps` | bool | failure | write | `0` | Navigation lights set 1 failed (wing tips and tail) |
| `failures.lights.nav2Lamps` | bool | failure | write | `0` | Navigation lights set 2 failed (wing tips and tail) |
| `failures.lights.rwyTurnOffLLamp` | bool | failure | write | `0` | Left runway turn-off light lamp failed |
| `failures.lights.rwyTurnOffRLamp` | bool | failure | write | `0` | Right runway turn-off light lamp failed |
| `failures.lights.strobePsu` | bool | failure | write | `0` | Strobe light power supply failed (no strobes) |
| `failures.lights.taxiLamp` | bool | failure | write | `0` | Nose taxi light lamp failed |
| `failures.lights.toLamp` | bool | failure | write | `0` | Nose take-off light lamp failed |
| `failures.lights.wingLLamp` | bool | failure | write | `0` | Left wing and engine scan light lamp failed |
| `failures.lights.wingRLamp` | bool | failure | write | `0` | Right wing and engine scan light lamp failed |

## Failures / MCDU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.mcdu.mcdu1` | bool | failure | write | `0` | MCDU 1 failure |
| `failures.mcdu.mcdu2` | bool | failure | write | `0` | MCDU 2 failure |

## Failures / Oxygen

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.oxy.crewRegulator` | bool | failure | write | `0` | Crew oxygen pressure regulator failure (low pressure circuit lost) |
| `failures.oxy.paxDoorLatch` | bool | failure | write | `0` | Passenger oxygen mask door latches jammed (the masks do not drop) |
| `failures.oxy.paxPressureSwitch` | bool | failure | write | `0` | Passenger oxygen cabin pressure switch failed open (no automatic mask release; MASK MAN ON works) |
| `failures.oxy.paxSpuriousRelease` | bool | failure | write | `0` | Passenger oxygen cabin pressure switch failed closed (uncommanded mask release) |
| `failures.oxy.paxTimer` | bool | failure | write | `0` | Passenger oxygen time delay relay failure (door latch solenoids stay energized: TMR RESET FAULT) |

## Failures / Pneumatic

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.bleed.apuLeak` | bool | failure | write | `0` | APU bleed duct leak |
| `failures.bleed.apuLeakLoop` | bool | failure | write | `0` | APU bleed leak detection loop inoperative |
| `failures.bleed.apuValveClosed` | bool | failure | write | `0` | APU bleed valve failed closed |
| `failures.bleed.bleedValve1Closed` | bool | failure | write | `0` | Engine 1 bleed valve failed closed |
| `failures.bleed.bleedValve1Open` | bool | failure | write | `0` | Engine 1 bleed valve stuck open (no closure, no regulation) |
| `failures.bleed.bleedValve1Regul` | bool | failure | write | `0` | Engine 1 bleed valve pressure regulation failed (open) |
| `failures.bleed.bleedValve2Closed` | bool | failure | write | `0` | Engine 2 bleed valve failed closed |
| `failures.bleed.bleedValve2Open` | bool | failure | write | `0` | Engine 2 bleed valve stuck open (no closure, no regulation) |
| `failures.bleed.bleedValve2Regul` | bool | failure | write | `0` | Engine 2 bleed valve pressure regulation failed (open) |
| `failures.bleed.bmc1` | bool | failure | write | `0` | Bleed monitoring computer 1 failure |
| `failures.bleed.bmc2` | bool | failure | write | `0` | Bleed monitoring computer 2 failure |
| `failures.bleed.eng1Leak` | bool | failure | write | `0` | Engine 1 pylon bleed duct leak |
| `failures.bleed.eng1LeakLoop` | bool | failure | write | `0` | Engine 1 pylon leak detection loop inoperative |
| `failures.bleed.eng2Leak` | bool | failure | write | `0` | Engine 2 pylon bleed duct leak |
| `failures.bleed.eng2LeakLoop` | bool | failure | write | `0` | Engine 2 pylon leak detection loop inoperative |
| `failures.bleed.engAntiIce1Closed` | bool | failure | write | `0` | Engine 1 anti-ice valve failed closed |
| `failures.bleed.engAntiIce2Closed` | bool | failure | write | `0` | Engine 2 anti-ice valve failed closed |
| `failures.bleed.fanAirValve1` | bool | failure | write | `0` | Engine 1 fan air valve failed closed (no precooling) |
| `failures.bleed.fanAirValve2` | bool | failure | write | `0` | Engine 2 fan air valve failed closed (no precooling) |
| `failures.bleed.hpValve1Closed` | bool | failure | write | `0` | Engine 1 HP valve failed closed |
| `failures.bleed.hpValve2Closed` | bool | failure | write | `0` | Engine 2 HP valve failed closed |
| `failures.bleed.lWingLeak` | bool | failure | write | `0` | Left wing bleed duct leak |
| `failures.bleed.lWingLeakLoopA` | bool | failure | write | `0` | Left wing leak detection loop A inoperative |
| `failures.bleed.lWingLeakLoopB` | bool | failure | write | `0` | Left wing leak detection loop B inoperative |
| `failures.bleed.rWingLeak` | bool | failure | write | `0` | Right wing bleed duct leak |
| `failures.bleed.rWingLeakLoopA` | bool | failure | write | `0` | Right wing leak detection loop A inoperative |
| `failures.bleed.rWingLeakLoopB` | bool | failure | write | `0` | Right wing leak detection loop B inoperative |
| `failures.bleed.wingAntiIce1Closed` | bool | failure | write | `0` | Left wing anti-ice valve failed closed |
| `failures.bleed.wingAntiIce2Closed` | bool | failure | write | `0` | Right wing anti-ice valve failed closed |
| `failures.bleed.xbleedJammed` | bool | failure | write | `0` | Crossbleed valve jammed in its present position |

## Failures / Pressurization

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.press.cpc1` | bool | failure | write | `0` | Cabin pressure controller 1 failure |
| `failures.press.cpc2` | bool | failure | write | `0` | Cabin pressure controller 2 failure |
| `failures.press.doorSealLeak` | bool | failure | write | `0` | Excessive cabin leakage (door seal) |
| `failures.press.outflowValveJammed` | bool | failure | write | `0` | Outflow valve jammed in its present position (all motors) |
| `failures.press.safetyValve1Open` | bool | failure | write | `0` | Cabin safety valve 1 failed open |
| `failures.press.safetyValve2Open` | bool | failure | write | `0` | Cabin safety valve 2 failed open |

## Failures / Probe / window heat

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.antiIce.captAoaHeat` | bool | failure | write | `0` | Captain AOA probe heater failed (ANTI ICE caution) |
| `failures.antiIce.captLStatHeat` | bool | failure | write | `0` | Captain left static port heater failed (ANTI ICE caution) |
| `failures.antiIce.captPitotHeat` | bool | failure | write | `0` | Captain pitot probe heater failed (ANTI ICE caution) |
| `failures.antiIce.captRStatHeat` | bool | failure | write | `0` | Captain right static port heater failed (ANTI ICE caution) |
| `failures.antiIce.captTatHeat` | bool | failure | write | `0` | Captain TAT probe heater failed (ANTI ICE caution) |
| `failures.antiIce.foAoaHeat` | bool | failure | write | `0` | F/O AOA probe heater failed (ANTI ICE caution) |
| `failures.antiIce.foLStatHeat` | bool | failure | write | `0` | F/O left static port heater failed (ANTI ICE caution) |
| `failures.antiIce.foPitotHeat` | bool | failure | write | `0` | F/O pitot probe heater failed (ANTI ICE caution) |
| `failures.antiIce.foRStatHeat` | bool | failure | write | `0` | F/O right static port heater failed (ANTI ICE caution) |
| `failures.antiIce.foTatHeat` | bool | failure | write | `0` | F/O TAT probe heater failed (ANTI ICE caution) |
| `failures.antiIce.lWndwHeat` | bool | failure | write | `0` | Left side window heater failed (ANTI ICE caution) |
| `failures.antiIce.lWshldHeat` | bool | failure | write | `0` | Left windshield heater failed (ANTI ICE caution) |
| `failures.antiIce.phc1` | bool | failure | write | `0` | Probe heat computer 1 failed: CAPT probes not heated (ANTI ICE CAPT PROBES) |
| `failures.antiIce.phc2` | bool | failure | write | `0` | Probe heat computer 2 failed: F/O probes not heated (ANTI ICE F/O PROBES) |
| `failures.antiIce.phc3` | bool | failure | write | `0` | Probe heat computer 3 failed: STBY probes not heated (ANTI ICE STBY PROBES) |
| `failures.antiIce.rWndwHeat` | bool | failure | write | `0` | Right side window heater failed (ANTI ICE caution) |
| `failures.antiIce.rWshldHeat` | bool | failure | write | `0` | Right windshield heater failed (ANTI ICE caution) |
| `failures.antiIce.stbyAoaHeat` | bool | failure | write | `0` | Standby AOA probe heater failed (ANTI ICE caution) |
| `failures.antiIce.stbyLStatHeat` | bool | failure | write | `0` | Standby left static port heater failed (ANTI ICE caution) |
| `failures.antiIce.stbyPitotHeat` | bool | failure | write | `0` | Standby pitot probe heater failed (ANTI ICE caution) |
| `failures.antiIce.stbyRStatHeat` | bool | failure | write | `0` | Standby right static port heater failed (ANTI ICE caution) |

## Failures / Radio

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.nav.ddrmiFault` | bool | failure | write | `0` | DDRMI internal failure (every flag in view, DME windows blank) |
| `failures.nav.gps1Fault` | bool | failure | write | `0` | GPS 1 receiver failed (detected: NAV GPS 1 FAULT, the ADIRUs use the other GPS) |
| `failures.nav.gps1PosError` | bool | failure | write | `0` | GPS 1 position error, undetected (Value: NM, default 1): GPIRS / FM position wrong, NAV FM/GPS POS DISAGREE |
| `failures.nav.gps2Fault` | bool | failure | write | `0` | GPS 2 receiver failed (detected: NAV GPS 2 FAULT, the ADIRUs use the other GPS) |
| `failures.nav.gps2PosError` | bool | failure | write | `0` | GPS 2 position error, undetected (Value: NM, default 1): GPIRS / FM position wrong, NAV FM/GPS POS DISAGREE |
| `failures.nav.gpsIntegrityLost` | bool | failure | write | `0` | GPS integrity lost (satellite constellation degraded, HIL too high): GPS PRIMARY LOST, IRS only navigation |
| `failures.radio.adf1` | bool | failure | write | `0` | ADF 1 receiver failure |
| `failures.radio.adf2` | bool | failure | write | `0` | ADF 2 receiver failure |
| `failures.radio.dme1` | bool | failure | write | `0` | DME 1 interrogator failure |
| `failures.radio.dme2` | bool | failure | write | `0` | DME 2 interrogator failure |
| `failures.radio.mmr1` | bool | failure | write | `0` | MMR 1 failure |
| `failures.radio.mmr2` | bool | failure | write | `0` | MMR 2 failure |
| `failures.radio.ra1` | bool | failure | write | `0` | Radio altimeter 1 failure |
| `failures.radio.ra2` | bool | failure | write | `0` | Radio altimeter 2 failure |
| `failures.radio.rmp1` | bool | failure | write | `0` | RMP 1 failure |
| `failures.radio.rmp2` | bool | failure | write | `0` | RMP 2 failure |
| `failures.radio.rmp3` | bool | failure | write | `0` | RMP 3 failure |
| `failures.radio.vhf1` | bool | failure | write | `0` | VHF 1 transceiver failure |
| `failures.radio.vhf2` | bool | failure | write | `0` | VHF 2 transceiver failure |
| `failures.radio.vhf3` | bool | failure | write | `0` | VHF 3 transceiver failure |
| `failures.radio.vor1` | bool | failure | write | `0` | VOR 1 receiver failure |
| `failures.radio.vor2` | bool | failure | write | `0` | VOR 2 receiver failure |

## Failures / Recorders

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.recorder.cvr` | bool | failure | write | `0` | Cockpit voice recorder failure (RECORDER CVR FAULT; no CVR test tone) |
| `failures.recorder.dfdr` | bool | failure | write | `0` | Digital flight data recorder failure (RECORDER DFDR FAULT) |
| `failures.recorder.fdiu` | bool | failure | write | `0` | Flight data interface unit failure (RECORDER SYS FAULT) |

## Failures / Surveillance

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.autoFlt.tcasMode` | bool | failure | write | `0` | AP/FD TCAS mode inoperative (AUTO FLT TCAS MODE FAULT) |
| `failures.nav.gpws` | bool | failure | write | `0` | GPWS failure: basic modes 1 to 5 lost (SYS FAULT, NAV GPWS FAULT) |
| `failures.nav.gpwsTerr` | bool | failure | write | `0` | EGPWS terrain functions (TAD / TCF) lost (TERR FAULT, NAV GPWS TERR DET FAULT) |
| `failures.nav.tcas` | bool | failure | write | `0` | TCAS internal failure (NAV TCAS FAULT) |
| `failures.nav.tcasBearing` | bool | failure | write | `0` | TCAS directional antenna failure (intruders without bearing: TA / RA digits at the bottom of the ND) |
| `failures.nav.xpdr1` | bool | failure | write | `0` | ATC transponder 1 failure (NAV ATC/XPDR 1 FAULT) |
| `failures.nav.xpdr2` | bool | failure | write | `0` | ATC transponder 2 failure (NAV ATC/XPDR 2 FAULT) |

## Failures / Ventilation

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.vent.aevc` | bool | failure | write | `0` | Avionics equipment ventilation controller failure |
| `failures.vent.aircondInletValve` | bool | failure | write | `0` | Avionics ventilation air conditioning inlet valve stuck |
| `failures.vent.blowerFan` | bool | failure | write | `0` | Avionics ventilation blower fan failure (low blowing pressure) |
| `failures.vent.crgAftFan` | bool | failure | write | `0` | Aft cargo extraction fan failure (AFT CRG VENT FAULT) |
| `failures.vent.crgAftIsolValve` | bool | failure | write | `0` | Aft cargo inlet isolation valve jammed where it is (AFT CRG ISOL VALVE) |
| `failures.vent.crgFwdFan` | bool | failure | write | `0` | Forward cargo extraction fan failure (FWD CRG VENT FAULT) |
| `failures.vent.crgFwdIsolValve` | bool | failure | write | `0` | Forward cargo inlet isolation valve jammed where it is (FWD CRG ISOL VALVE) |
| `failures.vent.extractFan` | bool | failure | write | `0` | Avionics ventilation extract fan failure (low extract pressure) |
| `failures.vent.inletValve` | bool | failure | write | `0` | Avionics ventilation skin air inlet valve stuck |
| `failures.vent.outletValve` | bool | failure | write | `0` | Avionics ventilation skin air outlet (extract) valve stuck |
| `failures.vent.skinExchInletBypassValve` | bool | failure | write | `0` | Avionics ventilation skin exchange inlet bypass valve stuck |
| `failures.vent.skinExchIsolValve` | bool | failure | write | `0` | Avionics ventilation skin exchange isolation valve stuck |
| `failures.vent.skinExchOutletBypassValve` | bool | failure | write | `0` | Avionics ventilation skin exchange outlet bypass valve stuck |

## Failures / Water / waste

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.waste.vacuumGen` | bool | failure | write | `0` | Vacuum generator failure (toilets inoperative on ground and below 16 000 ft) |
| `failures.waste.vsc` | bool | failure | write | `0` | Vacuum system controller failure (toilets inoperative, VSC fault on the FAP) |
| `failures.water.leak` | bool | failure | write | `0` | Potable water leak (2 l/min while pressurized) |
| `failures.water.qtyInd` | bool | failure | write | `0` | Potable water quantity indication failure (no quantity on the FAP and service panel) |

## Failures / Weather radar

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `failures.wxr.antenna` | bool | failure | write | `0` | Weather radar antenna failure (WXR ANT) |
| `failures.wxr.controlPanel` | bool | failure | write | `0` | Weather radar control panel failure (WXR CTL) |
| `failures.wxr.multiscan` | bool | failure | write | `0` | Multiscan automatic tilt failure (NO AUTO TILT) |
| `failures.wxr.pws` | bool | failure | write | `0` | Predictive windshear function failure (PRED W/S) |
| `failures.wxr.rt1` | bool | failure | write | `0` | Weather radar transceiver 1 failure (WXR RT) |
| `failures.wxr.rt2` | bool | failure | write | `0` | Weather radar transceiver 2 failure (WXR RT) |

## FG (indications)

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `fadec.throttle1` | float | output | read | `0` | FADEC 1 throttle command to the simulator (0..1) |
| `fadec.throttle2` | float | output | read | `0` | FADEC 2 throttle command to the simulator (0..1) |
| `fg.appNav` | bool | output | read | `0` | NAV (engaged or armed) is APP NAV (non-ILS approach); with fg.verticalMode FINAL engaged and NAV engaged the FMA shows FINAL APP |
| `fg.approachCapability` | int | output | read | `0` | Landing capability (FMA column 4 lines 1-2, with APPR armed or engaged): 0 none, 1 CAT 1, 2 CAT 2, 3 CAT 3 SINGLE, 4 CAT 3 DUAL |
| `fg.athrMode` | int | output | read | `0` | A/THR mode of FMA column 1 lines 1-2: 0 none, 1 MAN TOGA, 2 MAN FLX (temperature: fmgc.perf.flexTempC), 3 MAN MCT, 4 MAN THR (A/THR armed, levers beyond CL), 5 SPEED, 6 MACH, 7 THR CLB, 8 THR MCT, 9 THR IDLE, 10 THR LVR, 11 IDLE (RETARD), 12 A. FLOOR, 13 TOGA LK (A/THR active) |
| `fg.athrN1Pct` | float | output | read | `0` | A/THR N1 target |
| `fg.athrStatus` | int | output | read | `0` | A/THR status: 0 off, 1 armed (FMA "A/THR" blue, FCU light on), 2 active (FMA "A/THR" white) |
| `fg.fd.capt.engaged` | bool | output | read | `0` | Captain FD engaged (shown on the Captain PFD: FD pb on and an FMGC driving it; FMA column 5 "1 FD 2") |
| `fg.fd.capt.flag` | bool | output | read | `0` | Captain PFD red FD flag (FD pb on with the FD not engaged, or both FMGCs lost) |
| `fg.fd.capt.pitchBar` | bool | output | read | `0` | Captain FD pitch bar shown (FD engaged with a vertical mode; the PFD also needs a valid attitude) |
| `fg.fd.capt.pitchBarDeg` | float | output | read | `0` | Captain FD pitch bar deflection (degrees, + = bar above the aircraft symbol: pitch up ordered; FPD in TRK-FPA: FPA order − FPA); 0 without the bar |
| `fg.fd.capt.rollBar` | bool | output | read | `0` | Captain FD roll bar shown (FD engaged with a lateral mode, not in RWY; the PFD also needs a valid attitude) |
| `fg.fd.capt.rollBarDeg` | float | output | read | `0` | Captain FD roll bar deflection (degrees, ordered bank − bank, + = bar right: roll right ordered); 0 without the bar |
| `fg.fd.capt.yawBar` | bool | output | read | `0` | Captain FD yaw bar shown (below 30 ft with a LOC signal, RWY at takeoff, FLARE, ROLL OUT) |
| `fg.fd.capt.yawBarDeg` | float | output | read | `0` | Captain FD yaw bar (degrees, heading order − heading, + = bar right); 0 without the bar |
| `fg.fd.fo.engaged` | bool | output | read | `0` | F/O FD engaged (shown on the F/O PFD: FD pb on and an FMGC driving it; FMA column 5 "1 FD 2") |
| `fg.fd.fo.flag` | bool | output | read | `0` | F/O PFD red FD flag (FD pb on with the FD not engaged, or both FMGCs lost) |
| `fg.fd.fo.pitchBar` | bool | output | read | `0` | F/O FD pitch bar shown (FD engaged with a vertical mode; the PFD also needs a valid attitude) |
| `fg.fd.fo.pitchBarDeg` | float | output | read | `0` | F/O FD pitch bar deflection (degrees, + = bar above the aircraft symbol: pitch up ordered; FPD in TRK-FPA: FPA order − FPA); 0 without the bar |
| `fg.fd.fo.rollBar` | bool | output | read | `0` | F/O FD roll bar shown (FD engaged with a lateral mode, not in RWY; the PFD also needs a valid attitude) |
| `fg.fd.fo.rollBarDeg` | float | output | read | `0` | F/O FD roll bar deflection (degrees, ordered bank − bank, + = bar right: roll right ordered); 0 without the bar |
| `fg.fd.fo.yawBar` | bool | output | read | `0` | F/O FD yaw bar shown (below 30 ft with a LOC signal, RWY at takeoff, FLARE, ROLL OUT) |
| `fg.fd.fo.yawBarDeg` | float | output | read | `0` | F/O FD yaw bar (degrees, heading order − heading, + = bar right); 0 without the bar |
| `fg.fma.col1.line1` | string | output | read | `""` | FMA column 1, line 1 text ("" = blank) |
| `fg.fma.col1.line2` | string | output | read | `""` | FMA column 1, line 2 text ("" = blank) |
| `fg.fma.col1.line3` | string | output | read | `""` | FMA column 1, line 3 text ("" = blank) |
| `fg.fma.col2.line1` | string | output | read | `""` | FMA column 2, line 1 text ("" = blank) |
| `fg.fma.col2.line2` | string | output | read | `""` | FMA column 2, line 2 text ("" = blank) |
| `fg.fma.col2.line3` | string | output | read | `""` | FMA column 2, line 3 text ("" = blank) |
| `fg.fma.col3.line1` | string | output | read | `""` | FMA column 3, line 1 text ("" = blank) |
| `fg.fma.col3.line2` | string | output | read | `""` | FMA column 3, line 2 text ("" = blank) |
| `fg.fma.col3.line3` | string | output | read | `""` | FMA column 3, line 3 text ("" = blank) |
| `fg.fma.col4.line1` | string | output | read | `""` | FMA column 4, line 1 text ("" = blank) |
| `fg.fma.col4.line2` | string | output | read | `""` | FMA column 4, line 2 text ("" = blank) |
| `fg.fma.col4.line3` | string | output | read | `""` | FMA column 4, line 3 text ("" = blank) |
| `fg.fma.col5.line1` | string | output | read | `""` | FMA column 5, line 1 text ("" = blank) |
| `fg.fma.col5.line2` | string | output | read | `""` | FMA column 5, line 2 text ("" = blank) |
| `fg.fma.col5.line3` | string | output | read | `""` | FMA column 5, line 3 text ("" = blank) |
| `fg.landMode` | bool | output | read | `0` | LAND engaged (FMA columns 2-3 LAND, then FLARE with fg.verticalMode 17, ROLL OUT with fg.lateralMode 9) |
| `fg.landingInop` | int | output | read | `0` | FMGC landing capability inop discretes from the equipment (bit flags; the FWC STATUS INOP SYS CAT lines): 1 CAT 2 inop (LAND 2), 2 CAT 3 inop (LAND 3 FAIL PASSIVE), 4 CAT 3 DUAL inop (LAND 3 FAIL OPERATIVE), 8 GLS AUTOLAND inop (GLS option); 0 none |
| `fg.lateralArmed` | int | output | read | `0` | Armed lateral modes (bit flags, FMA column 3 line 2): 1 NAV (APP NAV with fg.appNav), 2 LOC; 0 none |
| `fg.lateralMode` | int | output | read | `0` | Engaged lateral mode: 0 none, 1 HDG, 2 TRK, 3 NAV (APP NAV with fg.appNav), 4 RWY, 5 RWY TRK, 6 GA TRK, 7 LOC*, 8 LOC, 9 ROLL OUT |
| `fg.locCaptureAssist` | int | output | read | `0` | LOC capture assistance now (DSC-22_30-80-30-10): 0 none, 1 LOC convergence (NAV engaged, LOC armed: 20° converging track), 2 LOC* in the pre-capture zone (beyond 2.3 dots, GPS PRIMARY: 15° convergence), 3 LOC* from a pre-capture on the beam |
| `fg.pitchCommandDeg` | float | output | read | `0` | Ordered pitch attitude (degrees, + nose up) of the engaged vertical mode, AP or FD. Without a pitch order (no AP / FD, no vertical mode, on ground) it is not an order (about the present pitch); frozen while both FMGCs are lost. Whether a bar is shown: fg.fd.capt / fo.pitchBar |
| `fg.rollCommandDeg` | float | output | read | `0` | Ordered bank angle (degrees, + right wing down) of the engaged lateral mode, AP or FD. Without a roll order (no AP / FD, no lateral mode, RWY, ROLL OUT, on ground) it is not an order: 0 without a lateral law, else the law's bank; frozen while both FMGCs are lost. Whether a bar is shown: fg.fd.capt / fo.rollBar |
| `fg.speedTargetKt` | float | output | read | `0` | Speed target as a CAS (managed or selected) |
| `fg.verticalArmed` | int | output | read | `0` | Armed vertical modes (bit flags, FMA column 2 line 2): 1 CLB, 2 DES, 4 ALT (blue: FCU altitude), 8 ALT as a constraint (magenta; shown instead of the blue ALT), 16 G/S, 32 FINAL; 0 none |
| `fg.verticalMode` | int | output | read | `0` | Engaged vertical mode: 0 none, 1 SRS, 2 CLB, 3 OP CLB, 4 DES, 5 OP DES, 6 EXP CLB, 7 EXP DES, 8 ALT*, 9 ALT, 10 ALT CST*, 11 ALT CST, 12 ALT CRZ, 13 V/S, 14 FPA, 15 G/S*, 16 G/S, 17 FLARE, 18 FINAL, 19 TCAS (V/S 0 after a level-off shows ALT; LAND / FINAL APP span columns 2-3: fg.landMode, fg.appNav) |

## Fire protection (indications)

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `fire.apu.bottle` | float | light | read | `0` | APU bottle agent (1 full .. 0 empty) |
| `fire.apu.burning` | bool | light | read | `0` | APU fire burning (simulation: the failure, until extinguished) |
| `fire.apu.warning` | bool | light | read | `0` | APU fire warning (FDU: detection or TEST) |
| `fire.avionicsSmoke` | bool | light | read | `0` | Avionics smoke detected (extraction duct detector, > 5 s) |
| `fire.cargo.bottle` | float | light | read | `0` | Cargo bottle agent (1 full .. 0 empty) |
| `fire.cargoAftSmoke` | bool | light | read | `0` | Aft cargo smoke warning (SDCU, or TEST) |
| `fire.cargoFwdSmoke` | bool | light | read | `0` | Forward cargo smoke warning (SDCU, or TEST) |
| `fire.eng1.bottle1` | float | light | read | `0` | ENG 1 bottle 1 agent (1 full .. 0 empty) |
| `fire.eng1.bottle2` | float | light | read | `0` | ENG 1 bottle 2 agent (1 full .. 0 empty) |
| `fire.eng1.burning` | bool | light | read | `0` | Engine 1 fire burning (simulation: the failure, until extinguished) |
| `fire.eng1.warning` | bool | light | read | `0` | ENG 1 fire warning (FDU: detection or TEST) |
| `fire.eng2.bottle1` | float | light | read | `0` | ENG 2 bottle 1 agent (1 full .. 0 empty) |
| `fire.eng2.bottle2` | float | light | read | `0` | ENG 2 bottle 2 agent (1 full .. 0 empty) |
| `fire.eng2.burning` | bool | light | read | `0` | Engine 2 fire burning (simulation: the failure, until extinguished) |
| `fire.eng2.warning` | bool | light | read | `0` | ENG 2 fire warning (FDU: detection or TEST) |
| `fire.lavSmoke` | bool | light | read | `0` | Lavatory smoke detected (SDCU) |

## Flight controls / State (read-only)

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `fac.alphaFloor` | bool | output | read | `0` | FAC alpha floor signal |
| `fac.alphaMaxKt` | float | output | read | `0` | FAC VαMAX (kt) |
| `fac.alphaProtKt` | float | output | read | `0` | FAC VαPROT (kt) |
| `fac.betaTargetDeg` | float | output | read |  | FAC β target (degrees, same sign as fac.sideslipDeg): the blue PFD index (engine-out asymmetry at takeoff / go-around thrust); NaN when not shown |
| `fac.greenDotKt` | float | output | read | `0` | FAC green dot (kt): always computed (from the weight and altitude, whatever the configuration; the PFD shows it with the FLAPS lever at 0); 0 with both FACs lost |
| `fac.sideslipDeg` | float | output | read |  | FAC sideslip (degrees; the PFD sideslip index in flight is the lateral acceleration −0.015 g per degree, limited to ±0.3 g; negative with the wind from the right or an engine 1 failure: index to the right); NaN when not valid (no ADR or IR). On ground the PFD index shows minus the IR lateral acceleration instead (adirs.irN.lateralAccelG) |
| `fac.vfeNextKt` | float | output | read | `0` | FAC VFE of the next FLAPS lever position (kt; 0 = none: lever FULL, or above 15000 ft; the PFD shows it in flight) |
| `fac.vlsKt` | float | output | read | `0` | FAC VLS (kt) |
| `fac.vmaxKt` | float | output | read | `0` | FAC VMAX (kt) |
| `fac.vswKt` | float | output | read | `0` | FAC VSW (kt) |
| `fac.windshear` | bool | output | read | `0` | FAC reactive windshear warning (WINDSHEAR) |
| `fac.windshearActive` | bool | output | read | `0` | FAC reactive windshear detection armed (takeoff / approach window, CONF 1 or more) |
| `fac.windshearFactor` | float | output | read | `0` | FAC windshear energy loss rate (averaged F-factor, g; warning above 0.10, ESTIMATED) |
| `fctl.aileronLeftDeg` | float | output | read | `0` | Actual aileronLeftDeg (sign conventions: SystemsCommands) |
| `fctl.aileronRightDeg` | float | output | read | `0` | Actual aileronRightDeg (sign conventions: SystemsCommands) |
| `fctl.alphaProtection` | bool | output | read | `0` | High AoA protection active |
| `fctl.autotrim` | bool | output | read | `0` | Pitch computer: autotrim active (normal / alternate law, flight mode, no flare, RA, nz, bank; not its freezes) |
| `fctl.config` | int | output | read | `0` | Slat/flap configuration: 0 CONF 0, 1 CONF 1, 2 1+F, 3 CONF 2, 4 CONF 3, 5 FULL |
| `fctl.elevatorLeftDeg` | float | output | read | `0` | Actual elevatorLeftDeg (sign conventions: SystemsCommands) |
| `fctl.elevatorRightDeg` | float | output | read | `0` | Actual elevatorRightDeg (sign conventions: SystemsCommands) |
| `fctl.flapsDeg` | float | output | read | `0` | Actual flapsDeg (sign conventions: SystemsCommands) |
| `fctl.flare` | bool | output | read | `0` | Pitch computer: normal law flare mode |
| `fctl.flightModeW` | float | output | read | `0` | Pitch computer: flight mode weight (0 ground mode .. 1 flight mode) |
| `fctl.groundSpoilersExtended` | bool | output | read | `0` | Ground spoilers extended (SEC order) |
| `fctl.highSpeedProtection` | bool | output | read | `0` | High speed protection active |
| `fctl.manualPitchTrim` | bool | output | read | `0` | Manual pitch trim order active (trim wheel / buttons accepted: gates.pitchTrimMotorEnabled 0) |
| `fctl.pitchLaw` | int | output | read | `0` | Pitch law: 0 mechanical, 1 normal, 2 alternate, 3 alternate without protection, 4 direct |
| `fctl.rollLaw` | int | output | read | `0` | Roll law: 0 none, 1 normal, 2 direct |
| `fctl.rudderDeg` | float | output | read | `0` | Actual rudderDeg (sign conventions: SystemsCommands) |
| `fctl.rudderTrimDeg` | float | output | read | `0` | Actual rudderTrimDeg (sign conventions: SystemsCommands) |
| `fctl.slatsDeg` | float | output | read | `0` | Actual slatsDeg (sign conventions: SystemsCommands) |
| `fctl.speedBrakeInhibition` | string | output | read | `""` | Why the SECs keep the speed brakes retracted (SEC 1, else SEC 3; empty: none) |
| `fctl.spoilerLeft1Deg` | float | output | read | `0` | Actual spoilerLeft1Deg (sign conventions: SystemsCommands) |
| `fctl.spoilerLeft2Deg` | float | output | read | `0` | Actual spoilerLeft2Deg (sign conventions: SystemsCommands) |
| `fctl.spoilerLeft3Deg` | float | output | read | `0` | Actual spoilerLeft3Deg (sign conventions: SystemsCommands) |
| `fctl.spoilerLeft4Deg` | float | output | read | `0` | Actual spoilerLeft4Deg (sign conventions: SystemsCommands) |
| `fctl.spoilerLeft5Deg` | float | output | read | `0` | Actual spoilerLeft5Deg (sign conventions: SystemsCommands) |
| `fctl.spoilerRight1Deg` | float | output | read | `0` | Actual spoilerRight1Deg (sign conventions: SystemsCommands) |
| `fctl.spoilerRight2Deg` | float | output | read | `0` | Actual spoilerRight2Deg (sign conventions: SystemsCommands) |
| `fctl.spoilerRight3Deg` | float | output | read | `0` | Actual spoilerRight3Deg (sign conventions: SystemsCommands) |
| `fctl.spoilerRight4Deg` | float | output | read | `0` | Actual spoilerRight4Deg (sign conventions: SystemsCommands) |
| `fctl.spoilerRight5Deg` | float | output | read | `0` | Actual spoilerRight5Deg (sign conventions: SystemsCommands) |
| `fctl.thsControlled` | bool | output | read | `0` | THS driven (hydraulic motor G or Y and a computer's electric motor, or the manual wheel) |
| `fctl.thsDeg` | float | output | read | `0` | Actual thsDeg (sign conventions: SystemsCommands) |
| `fctl.thsOrderDegS` | float | output | read | `0` | Pitch computer: THS rate order (deg/s, + nose up; autotrim or the trim reset after landing) |
| `fctl.travelLimitDeg` | float | output | read | `0` | Actual travelLimitDeg (sign conventions: SystemsCommands) |
| `fctl.yawLaw` | int | output | read | `0` | Yaw: 0 mechanical, 1 normal, 2 alternate |

## FMGC (indications)

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `fmgc.activeLeg` | int | output | read | `0` | Index of the active leg in the flight plan |
| `fmgc.alternate` | string | output | read | `""` | Alternate airport (INIT A ALTN; "" = none) |
| `fmgc.departure.elevationFt` | float | output | read | `0` | Takeoff runway threshold elevation (ft) |
| `fmgc.departure.headingDeg` | float | output | read | `0` | Takeoff runway magnetic heading (°) |
| `fmgc.departure.runway` | string | output | read | `""` | Takeoff runway of the active flight plan ("" = none) |
| `fmgc.departure.sid` | string | output | read | `""` | SID of the active flight plan ("" = none or NO SID) |
| `fmgc.departure.slopePct` | float | output | read | `0` | Takeoff runway slope (%, + uphill) |
| `fmgc.departure.toraM` | float | output | read | `0` | Takeoff runway length from the navigation database (m; 0 = no runway) |
| `fmgc.destination` | string | output | read | `""` | Destination airport of the active flight plan (TO; "" = none) |
| `fmgc.initB.block` | string | output | read | `"9.0"` | INIT B BLOCK "9.0" as the MCDU shows it ("" = none) |
| `fmgc.initB.taxi` | string | output | read | `"0.2"` | INIT B TAXI "0.2" as the MCDU shows it ("" = none) |
| `fmgc.initB.zfwZfwCg` | string | output | read | `"58.0/31.2"` | INIT B ZFW/ZFWCG "58.0/31.2" as the MCDU shows it ("" = none) |
| `fmgc.origin` | string | output | read | `""` | Origin airport of the active flight plan (FROM; "" = none) |
| `fmgc.perf.apprQnh` | string | output | read | `"1013"` | PERF APPR QNH "1013" / "29.92" as the MCDU shows it ("" = none) |
| `fmgc.perf.apprTemp` | string | output | read | `""` | PERF APPR TEMP (°C) as the MCDU shows it ("" = none) |
| `fmgc.perf.apprWind` | string | output | read | `"240/012"` | PERF APPR MAG WIND "240/012" as the MCDU shows it ("" = none) |
| `fmgc.perf.baroFt` | int | output | read | `0` | PERF APPR BARO minimum (MDA, ft, -1 = not entered) |
| `fmgc.perf.engOutAcc` | string | output | read | `""` | PERF TAKE OFF ENG OUT ACC (ft) as the MCDU shows it ("" = none) |
| `fmgc.perf.flaps` | int | output | read | `0` | PERF TAKE OFF FLAPS (1..3, -1 = not entered) |
| `fmgc.perf.flapsThsText` | string | output | read | `"1/DN0.8"` | PERF TAKE OFF FLAPS/THS "1/DN0.8" as the MCDU shows it ("" = none) |
| `fmgc.perf.flexTempC` | float | output | read | `0` | PERF TAKE OFF FLEX TO TEMP (°C, NaN = not entered) |
| `fmgc.perf.flexText` | string | output | read | `"63"` | PERF TAKE OFF FLEX TO TEMP "63" as the MCDU shows it ("" = none) |
| `fmgc.perf.ldgConf` | string | output | read | `"FULL"` | PERF APPR LDG CONF "FULL" / "3" as the MCDU shows it ("" = none) |
| `fmgc.perf.radioFt` | int | output | read | `0` | PERF APPR RADIO minimum (DH, ft, -1 = not entered, -2 = NO) |
| `fmgc.perf.thrRedAcc` | string | output | read | `"1510/1510"` | PERF TAKE OFF THR RED/ACC "1510/1510" as the MCDU shows it ("" = none) |
| `fmgc.perf.thsDeg` | float | output | read | `0` | PERF TAKE OFF THS (°, + UP, NaN = not entered) |
| `fmgc.perf.toShift` | string | output | read | `""` | PERF TAKE OFF TO SHIFT (m) as the MCDU shows it ("" = none) |
| `fmgc.perf.transAlt` | string | output | read | `""` | PERF TAKE OFF TRANS ALT (ft) as the MCDU shows it ("" = none) |
| `fmgc.perf.v1` | int | output | read | `0` | PERF TAKE OFF V1 (kt, 0 = not entered) |
| `fmgc.perf.v2` | int | output | read | `0` | PERF TAKE OFF V2 (kt, 0 = not entered) |
| `fmgc.perf.vapp` | string | output | read | `""` | PERF APPR VAPP (kt, entered or computed) as the MCDU shows it ("" = none) |
| `fmgc.perf.vr` | int | output | read | `0` | PERF TAKE OFF VR (kt, 0 = not entered) |
| `fmgc.to.bearingTrueDeg` | float | output | read | `0` | True bearing from the FM position (captain side) to the TO waypoint |
| `fmgc.to.distanceNm` | float | output | read | `0` | Distance from the FM position (captain side) to the TO waypoint (NM) |
| `fmgc.to.ident` | string | output | read | `""` | TO waypoint of the active flight plan ("" = none) |

## FMGS stand-in

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `fmgc.standIn.directTo` | string | service | write | `""` | DIR TO convenience (the MCDU DIR key is the aircraft way): ident of a flight plan waypoint (Systems writes it back empty) |
| `fmgc.standIn.route` | string | service | write | `""` | Flight plan convenience (the MCDU is the aircraft way): ORIGIN[/RWY] [SID] {WPT \| AWY WPT \| DCT WPT} [STAR] DEST[/RWY] [APPROACH] |
| `fmgc.standIn.status` | string | output | read | `""` | Result of the last route entry |

## Forward entrance

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `fwdEntrance.maintBus.pressed` | bool | pushbutton | write | `0` | MAINT BUS pushbutton (1 = in) |

## Fuel (indications)

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `fuel.alerts` | int | light | read | `0` | Alert conditions for the FWC (FuelAlerts bit mask) |
| `fuel.engine1Fed` | bool | light | read | `0` | Fuel reaches engine 1 (pump pressure or suction feed); 0 = starved |
| `fuel.engine1Suction` | bool | light | read | `0` | Engine 1 fed by suction (gravity) only |
| `fuel.engine2Fed` | bool | light | read | `0` | Fuel reaches engine 2 (pump pressure or suction feed); 0 = starved |
| `fuel.engine2Suction` | bool | light | read | `0` | Engine 2 fed by suction (gravity) only |
| `fuel.fobKg` | float | light | read | `0` | Fuel on board (kg, FQI; -1 without the FQI) |
| `fuel.fqiDegraded` | bool | light | read | `0` | FQI in degraded mode: the FOB's last two digits dashed (DSC-28-20) |
| `fuel.fqiDegradedTanks` | int | light | read | `0` | Tanks in FQI degraded mode, bit mask (1 L outer, 2 L inner, 4 center, 8 R inner, 16 R outer): quantity dashed on the FUEL page |
| `fuel.fqiValid` | bool | light | read | `0` | FQI computing (a channel powered and working) |
| `fuel.frv1Open` | bool | light | read | `0` | Engine 1 IDG fuel return valve open |
| `fuel.frv2Open` | bool | light | read | `0` | Engine 2 IDG fuel return valve open |
| `fuel.gravityCeilingFt` | float | light | read | `0` | Gravity (suction) feed ceiling (ft; 99999 with the fuel deaerated) |
| `fuel.pump.ctr1.pressure` | bool | light | read | `0` | Pump ctr1 delivery pressure normal |
| `fuel.pump.ctr1.running` | bool | light | read | `0` | Pump ctr1 running |
| `fuel.pump.ctr2.pressure` | bool | light | read | `0` | Pump ctr2 delivery pressure normal |
| `fuel.pump.ctr2.running` | bool | light | read | `0` | Pump ctr2 running |
| `fuel.pump.l1.pressure` | bool | light | read | `0` | Pump l1 delivery pressure normal |
| `fuel.pump.l1.running` | bool | light | read | `0` | Pump l1 running |
| `fuel.pump.l2.pressure` | bool | light | read | `0` | Pump l2 delivery pressure normal |
| `fuel.pump.l2.running` | bool | light | read | `0` | Pump l2 running |
| `fuel.pump.r1.pressure` | bool | light | read | `0` | Pump r1 delivery pressure normal |
| `fuel.pump.r1.running` | bool | light | read | `0` | Pump r1 running |
| `fuel.pump.r2.pressure` | bool | light | read | `0` | Pump r2 delivery pressure normal |
| `fuel.pump.r2.running` | bool | light | read | `0` | Pump r2 running |
| `fuel.qty.centerKg` | float | light | read | `0` | Fuel in the center tank cell (kg) |
| `fuel.qty.lInnerKg` | float | light | read | `0` | Fuel in the lInner tank cell (kg) |
| `fuel.qty.lOuterKg` | float | light | read | `0` | Fuel in the lOuter tank cell (kg) |
| `fuel.qty.rInnerKg` | float | light | read | `0` | Fuel in the rInner tank cell (kg) |
| `fuel.qty.rOuterKg` | float | light | read | `0` | Fuel in the rOuter tank cell (kg) |
| `fuel.refueling` | bool | light | read | `0` | Refuel in progress (REFUELG) |
| `fuel.temp.centerC` | float | light | read | `0` | Fuel temperature in the center tank cell (°C) |
| `fuel.temp.lInnerC` | float | light | read | `0` | Fuel temperature in the lInner tank cell (°C) |
| `fuel.temp.lOuterC` | float | light | read | `0` | Fuel temperature in the lOuter tank cell (°C) |
| `fuel.temp.rInnerC` | float | light | read | `0` | Fuel temperature in the rInner tank cell (°C) |
| `fuel.temp.rOuterC` | float | light | read | `0` | Fuel temperature in the rOuter tank cell (°C) |
| `fuel.used1Kg` | float | light | read | `0` | Fuel used by engine 1 (kg) |
| `fuel.used2Kg` | float | light | read | `0` | Fuel used by engine 2 (kg) |
| `fuel.xFeedValve` | float | light | read | `0` | X FEED valve (0 closed .. 1 open) |
| `fuel.xfrValvesLeft` | float | light | read | `0` | Left transfer valves open (0, 1 or 2; fractions in transit) |
| `fuel.xfrValvesRight` | float | light | read | `0` | Right transfer valves open (0, 1 or 2; fractions in transit) |

## FWC / ALERTS

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `fwc.alertCount` | int | output | read | `0` | Number of warnings and cautions in fwc.alerts (on the E/WD, not cleared) |
| `fwc.alerts` | string | output | read | `"[]"` | The warnings and cautions the FWC in use shows on the E/WD (not cleared by CLR, not canceled), in display order (level 3, 2, 1, each in the FWC priority order), as a JSON array written when it changes: [{"id":"ELEC.GEN1_FAULT","code":"24-00-020","level":2,"system":"ELEC","title":"GEN 1 FAULT","primary":true,"lines":[{"text":"-GEN 1..........OFF THEN ON","color":"cyan"}]}]. level 3 red warning, 2 amber caution with MASTER CAUT, 1 amber caution without; code: the FWC logic code (null if none); primary: boxed title (primary failure); lines: the action lines in force (conditions met, not done yet), colors cyan / white / amber / green / red / magenta. All of them, also those scrolled below the E/WD's seven lines. "[]": none or both FWCs lost |

## FWC / AURAL

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `fwc.aural.cChord` | bool | output | read | `0` | C chord sounding (altitude alert): loop while true |
| `fwc.aural.cavalryCharge` | bool | output | read | `0` | Cavalry charge sounding (AP disconnection): loop while true |
| `fwc.aural.crc` | bool | output | read | `0` | Continuous repetitive chime of a level 3 warning sounding (false when silenced or when the warning ends) |
| `fwc.aural.cricket` | bool | output | read | `0` | Cricket sounding (stall warning; the STALL words come through fwc.aural.voice): loop while true |
| `fwc.aural.raas` | string | output | read | `""` | Phrase of the voice message started (RAAS, FWC intermediate callout; sequence:level:word ids, RaasPhrase): the words Audio says one after the other when fwc.aural.voice has that sequence |
| `fwc.aural.singleChime` | int | output | read | `0` | Single chime requests of level 2 cautions (counter, +1 per chime, wraps at 65536) |
| `fwc.aural.tripleClick` | int | output | read | `0` | Triple click requests (counter, +1 per triple click, wraps at 65536) |
| `fwc.aural.voice` | int | output | read | `0` | Synthetic voice: sequence * 128 + AuralVoice id of the last message started (a change: say it now) |
| `fwc.callouts` | int | service | write | `0` | Automatic callouts (FWC pin programming, setting saved in systems.json): bit mask 0 TWO THOUSAND FIVE HUNDRED, 1 retired (former TWENTY FIVE HUNDRED, read as bit 0), 2 2000, 3 1000, 4 500, 5 400, 6 300, 7 200, 8 100, 9 50, 10 40, 11 30, 12 20, 13 10, 14 5, 15 HUNDRED ABOVE, 16 MINIMUM, 17 intermediate callout |
| `fwc.flightPhase` | int | output | read | `0` | FWC flight phase (1-10, 0 = FWCs lost) |

## Gates

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `gates.gearDownLocked` | bool | gate | read | `0` | Every gear down and locked (LGCIU) |
| `gates.gearDownLocked.leftMain` | bool | gate | read | `0` | Left main gear down and locked (LGCIU) |
| `gates.gearDownLocked.nose` | bool | gate | read | `0` | Nose gear down and locked (LGCIU) |
| `gates.gearDownLocked.rightMain` | bool | gate | read | `0` | Right main gear down and locked (LGCIU) |
| `gates.gearUpLocked` | bool | gate | read | `0` | Every gear up and locked (LGCIU) |
| `gates.pitchTrimMotorEnabled` | bool | gate | read | `0` | Electric pitch trim motor owns the THS (1: in flight with autotrim, manual trim ignored; 0: on ground, direct law, mechanical back-up...: manual trim accepted) |
| `gates.slatsExtended` | bool | gate | read | `0` | Slats extended (SFCC: slats beyond the retracted position) |
| `gates.weightOnWheels` | bool | gate | read | `0` | Weight on wheels: either main gear strut compressed (aircraft on ground; LGCIU) |
| `gates.weightOnWheels.leftMain` | bool | gate | read | `0` | Left main gear strut compressed (LGCIU) |
| `gates.weightOnWheels.nose` | bool | gate | read | `0` | Nose gear strut compressed (LGCIU) |
| `gates.weightOnWheels.rightMain` | bool | gate | read | `0` | Right main gear strut compressed (LGCIU) |

## Glareshield

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `glare.autoland.capt` | bool | light | read | `0` | Captain AUTO LAND red light (flashing) |
| `glare.autoland.fo` | bool | light | read | `0` | F/O AUTO LAND red light (flashing) |

## Glareshield / ATC MSG

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `glare.atcMsg.capt.lit` | bool | light | read | `0` | CAPT ATC MSG light (flashing: a new ATC uplink not acknowledged) |
| `glare.atcMsg.capt.pressed` | bool | pushbutton | momentary | `0` | CAPT ATC MSG pushbutton (momentary: 1 while held) |
| `glare.atcMsg.fo.lit` | bool | light | read | `0` | F/O ATC MSG light (flashing: a new ATC uplink not acknowledged) |
| `glare.atcMsg.fo.pressed` | bool | pushbutton | momentary | `0` | F/O ATC MSG pushbutton (momentary: 1 while held) |

## Glareshield / ATTENTION GETTERS

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `glare.masterCaut.capt.lit` | bool | light | read | `0` | CAPT MASTER CAUT LIT light |
| `glare.masterCaut.capt.pressed` | bool | pushbutton | momentary | `0` | CAPT MASTER CAUT pushbutton (momentary: 1 while held) |
| `glare.masterCaut.fo.lit` | bool | light | read | `0` | F/O MASTER CAUT LIT light |
| `glare.masterCaut.fo.pressed` | bool | pushbutton | momentary | `0` | F/O MASTER CAUT pushbutton (momentary: 1 while held) |
| `glare.masterWarn.capt.lit` | bool | light | read | `0` | CAPT MASTER WARN LIT light |
| `glare.masterWarn.capt.pressed` | bool | pushbutton | momentary | `0` | CAPT MASTER WARN pushbutton (momentary: 1 while held) |
| `glare.masterWarn.fo.lit` | bool | light | read | `0` | F/O MASTER WARN LIT light |
| `glare.masterWarn.fo.pressed` | bool | pushbutton | momentary | `0` | F/O MASTER WARN pushbutton (momentary: 1 while held) |

## Glareshield / CHART LT

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `glare.intLt.chartLtCapt` | float | analog | write | `0` | Captain sliding table / map holder (chart) light brightness knob (0 .. 1 = BRT) |
| `glare.intLt.chartLtCaptSwitch` | bool | switch | write | `0` | Captain chart light switch (1 = ON, 0 = OFF; the knob's OFF stop) |
| `glare.intLt.chartLtFo` | float | analog | write | `0` | First officer sliding table / map holder (chart) light brightness knob (0 .. 1 = BRT) |
| `glare.intLt.chartLtFoSwitch` | bool | switch | write | `0` | First officer chart light switch (1 = ON, 0 = OFF; the knob's OFF stop) |

## Glareshield / CHRONO

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `glare.chrono.capt.display` | string | output | read | `"05'21\\"` | Captain ND chronometer as the ND shows it ("05'21\"", "01H05'"; "" not shown) |
| `glare.chrono.capt.pressed` | bool | pushbutton | momentary | `0` | Captain CHRONO pushbutton (momentary: 1 while held; start, stop, reset) |
| `glare.chrono.capt.seconds` | float | output | read | `0` | Captain ND chronometer elapsed time (s) |
| `glare.chrono.capt.state` | int | output | read | `0` | Captain ND chronometer (0 reset: not shown, 1 running, 2 stopped: value frozen) |
| `glare.chrono.fo.display` | string | output | read | `"05'21\\"` | F/O ND chronometer as the ND shows it ("05'21\"", "01H05'"; "" not shown) |
| `glare.chrono.fo.pressed` | bool | pushbutton | momentary | `0` | F/O CHRONO pushbutton (momentary: 1 while held; start, stop, reset) |
| `glare.chrono.fo.seconds` | float | output | read | `0` | F/O ND chronometer elapsed time (s) |
| `glare.chrono.fo.state` | int | output | read | `0` | F/O ND chronometer (0 reset: not shown, 1 running, 2 stopped: value frozen) |

## Glareshield / FCU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `glare.fcu.displayBrightness` | float | output | read | `0` | FCU displays brightness (0 = dark, FCU not displaying .. 1 = full): the knob while the FCU displays |
| `glare.fcu.displayBrt` | float | analog | write | `0` | FCU displays brightness knob (0 = dimmest .. 1 = BRT) |
| `glare.fcu.metricAlt.on` | bool | output | read | `0` | METRIC ALT selected (the ECAM and PFD altitudes also in meters; the pushbutton has no light) |
| `glare.fcu.trkFpa.on` | bool | output | read | `0` | TRK-FPA selected (HDG-V/S / TRK-FPA pushbutton state, not the legend: no ANN LT TEST) |

## Glareshield / FCU 13VU (AFS control panel)

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `glare.fcu.altIncrement` | int | rotary | write | `0` | ALT knob outer ring (0 = 100 ft, 1 = 1000 ft) |
| `glare.fcu.altKnob` | int | encoder | write | `0` | ALT knob rotation counter (+1 per clockwise click) |
| `glare.fcu.altLabel` | bool | light | read | `0` | ALT legend of the AFS display |
| `glare.fcu.altPull` | bool | pushbutton | momentary | `0` | ALT knob pulled (open climb / descent) (momentary: 1 while held) |
| `glare.fcu.altPush` | bool | pushbutton | momentary | `0` | ALT knob pushed (managed climb / descent) (momentary: 1 while held) |
| `glare.fcu.altWindow` | string | light | read | `"24000"` | ALT window: "24000" (never dashed), "" dark |
| `glare.fcu.ap1.on` | bool | light | read | `0` | AP 1 ON light |
| `glare.fcu.ap1.pressed` | bool | pushbutton | momentary | `0` | AP 1 pushbutton (momentary: 1 while held) |
| `glare.fcu.ap2.on` | bool | light | read | `0` | AP 2 ON light |
| `glare.fcu.ap2.pressed` | bool | pushbutton | momentary | `0` | AP 2 pushbutton (momentary: 1 while held) |
| `glare.fcu.appr.on` | bool | light | read | `0` | APPR ON light |
| `glare.fcu.appr.pressed` | bool | pushbutton | momentary | `0` | APPR pushbutton (momentary: 1 while held) |
| `glare.fcu.athr.on` | bool | light | read | `0` | A/THR ON light |
| `glare.fcu.athr.pressed` | bool | pushbutton | momentary | `0` | A/THR pushbutton (momentary: 1 while held) |
| `glare.fcu.exped.on` | bool | light | read | `0` | EXPED ON light |
| `glare.fcu.exped.pressed` | bool | pushbutton | momentary | `0` | EXPED pushbutton (momentary: 1 while held) |
| `glare.fcu.fpaLabel` | bool | light | read | `0` | FPA legend of the AFS display |
| `glare.fcu.hdgKnob` | int | encoder | write | `0` | HDG/TRK knob rotation counter (+1 per clockwise click) |
| `glare.fcu.hdgLabel` | bool | light | read | `0` | HDG legend of the AFS display |
| `glare.fcu.hdgPull` | bool | pushbutton | momentary | `0` | HDG/TRK knob pulled (selected heading / track) (momentary: 1 while held) |
| `glare.fcu.hdgPush` | bool | pushbutton | momentary | `0` | HDG/TRK knob pushed (NAV) (momentary: 1 while held) |
| `glare.fcu.hdgValue` | int | encoder | write | `-1` | HDG/TRK value as the window shows it (degrees 0..359, heading or track: glare.fcu.trkFpa.on; a preview while managed; -1 dashed or dark). Writable for external FCU panels: a new value acts as the knob turned to it (while managed: the 45 s preview, a pull selects it), nothing without FCU power; 360 = 0 |
| `glare.fcu.hdgVsLabel` | bool | light | read | `0` | HDG V/S legend of the AFS display |
| `glare.fcu.hdgVsTrkFpa.pressed` | bool | pushbutton | momentary | `0` | HDG-V/S / TRK-FPA pushbutton (momentary: 1 while held) |
| `glare.fcu.hdgWindow` | string | light | read | `"005"` | HDG/TRK window: "005", "---" (managed), "" dark |
| `glare.fcu.latDot` | bool | light | read | `0` | Managed lateral dot |
| `glare.fcu.latLabel` | bool | light | read | `0` | LAT legend of the AFS display |
| `glare.fcu.loc.on` | bool | light | read | `0` | LOC ON light |
| `glare.fcu.loc.pressed` | bool | pushbutton | momentary | `0` | LOC pushbutton (momentary: 1 while held) |
| `glare.fcu.lvlChDot` | bool | light | read | `0` | Managed level change dot |
| `glare.fcu.lvlChLabel` | bool | light | read | `0` | LVL/CH legend of the AFS display |
| `glare.fcu.machLabel` | bool | light | read | `0` | MACH legend of the AFS display |
| `glare.fcu.metricAlt.pressed` | bool | pushbutton | momentary | `0` | METRIC ALT pushbutton (momentary: 1 while held) |
| `glare.fcu.spdDot` | bool | light | read | `0` | Managed speed dot |
| `glare.fcu.spdKnob` | int | encoder | write | `0` | SPD/MACH knob rotation counter (+1 per clockwise click) |
| `glare.fcu.spdLabel` | bool | light | read | `0` | SPD legend of the AFS display |
| `glare.fcu.spdMach.pressed` | bool | pushbutton | momentary | `0` | SPD/MACH pushbutton (momentary: 1 while held) |
| `glare.fcu.spdPull` | bool | pushbutton | momentary | `0` | SPD/MACH knob pulled (selected speed) (momentary: 1 while held) |
| `glare.fcu.spdPush` | bool | pushbutton | momentary | `0` | SPD/MACH knob pushed (managed speed) (momentary: 1 while held) |
| `glare.fcu.spdWindow` | string | light | read | `"250"` | SPD/MACH window: "250", "0.78", "---" (managed), "" dark |
| `glare.fcu.trkFpaLabel` | bool | light | read | `0` | TRK FPA legend of the AFS display |
| `glare.fcu.trkLabel` | bool | light | read | `0` | TRK legend of the AFS display |
| `glare.fcu.vsKnob` | int | encoder | write | `0` | V/S-FPA knob rotation counter (+1 per clockwise click) |
| `glare.fcu.vsLabel` | bool | light | read | `0` | V/S legend of the AFS display |
| `glare.fcu.vsPull` | bool | pushbutton | momentary | `0` | V/S-FPA knob pulled (V/S or FPA) (momentary: 1 while held) |
| `glare.fcu.vsPush` | bool | pushbutton | momentary | `0` | V/S-FPA knob pushed (level off) (momentary: 1 while held) |
| `glare.fcu.vsWindow` | string | light | read | `"+25oo"` | V/S-FPA window: "+25oo" (ft/min: sign, hundreds, the last two digits as small "oo"; "+00oo" at 0), "-1.5 " (FPA: sign, units, tenths and a trailing space; " 0.0 " at 0), "-----" dashed, "+8888" ANN LT TEST, "" dark |

## Glareshield / FCU 13VU (EFIS control panels)

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `efis.syncSides` | bool | service | write | `0` | Sync CPT and F/O EFIS (simulator setting saved in systems.json, for cockpits with one EFIS control panel): both EFIS control panels act as one; switching it on aligns the F/O side on the captain's |
| `glare.efisCapt.arpt.on` | bool | light | read | `0` | Captain EFIS ARPT ON light |
| `glare.efisCapt.arpt.pressed` | bool | pushbutton | momentary | `0` | Captain EFIS ARPT pushbutton (momentary: 1 while held) |
| `glare.efisCapt.baroHpa` | float | encoder | write | `-1` | Captain EFIS baro reference set (hPa, the window's value in hPa whatever the unit; -1 in STD or dark). Writable for external EFIS panels: a new value acts as the BARO knob turned to it (745..1050, in the window's unit and resolution; nothing in STD or without FCU power) |
| `glare.efisCapt.baroInHg` | float | encoder | write | `-1` | Captain EFIS baro reference set (in Hg, the window's value in in Hg whatever the unit; -1 in STD or dark). Writable as baroHpa (21.99..31.00) |
| `glare.efisCapt.baroKnob` | int | encoder | write | `0` | Captain EFIS BARO knob rotation counter (+1 per clockwise click: 1 hPa or 0.01 in Hg) |
| `glare.efisCapt.baroPull` | bool | pushbutton | momentary | `0` | Captain EFIS BARO knob pulled (STD) (momentary: 1 while held) |
| `glare.efisCapt.baroPush` | bool | pushbutton | momentary | `0` | Captain EFIS BARO knob pushed (QNH) (momentary: 1 while held) |
| `glare.efisCapt.baroQfe` | bool | light | read | `0` | Captain EFIS QFE legend of the baro window (lit in QFE: QFE option, efis.qfe.installed) |
| `glare.efisCapt.baroQnh` | bool | light | read | `0` | Captain EFIS QNH legend of the baro window (lit in QNH) |
| `glare.efisCapt.baroUnit` | int | rotary | write | `0` | Captain EFIS BARO outer ring (0 = in Hg, 1 = hPa) |
| `glare.efisCapt.baroWindow` | string | light | read | `"1013"` | Captain EFIS baro reference window: "1013" (hPa, 4 digits: "0745".."1050"), "29.92" (in Hg, "21.99".."31.00"), "Std", "8888" ANN LT TEST, "" dark |
| `glare.efisCapt.cstr.on` | bool | light | read | `0` | Captain EFIS CSTR ON light |
| `glare.efisCapt.cstr.pressed` | bool | pushbutton | momentary | `0` | Captain EFIS CSTR pushbutton (momentary: 1 while held) |
| `glare.efisCapt.fd.on` | bool | light | read | `0` | Captain EFIS FD ON light |
| `glare.efisCapt.fd.pressed` | bool | pushbutton | momentary | `0` | Captain EFIS FD pushbutton (momentary: 1 while held) |
| `glare.efisCapt.ls.on` | bool | light | read | `0` | Captain EFIS LS ON light |
| `glare.efisCapt.ls.pressed` | bool | pushbutton | momentary | `0` | Captain EFIS LS pushbutton (momentary: 1 while held) |
| `glare.efisCapt.navaid1` | int | switch | write | `0` | Captain EFIS ADF-VOR 1 selector (0 = ADF, 1 = OFF, 2 = VOR) |
| `glare.efisCapt.navaid2` | int | switch | write | `0` | Captain EFIS ADF-VOR 2 selector (0 = ADF, 1 = OFF, 2 = VOR) |
| `glare.efisCapt.ndMode` | int | rotary | write | `0` | Captain EFIS ND mode selector (0 = ROSE ILS, 1 = ROSE VOR, 2 = ROSE NAV, 3 = ARC, 4 = PLAN) |
| `glare.efisCapt.ndRange` | int | rotary | write | `0` | Captain EFIS ND range selector (0..5 = 10, 20, 40, 80, 160, 320 NM) |
| `glare.efisCapt.ndb.on` | bool | light | read | `0` | Captain EFIS NDB ON light |
| `glare.efisCapt.ndb.pressed` | bool | pushbutton | momentary | `0` | Captain EFIS NDB pushbutton (momentary: 1 while held) |
| `glare.efisCapt.vorD.on` | bool | light | read | `0` | Captain EFIS VOR.D ON light |
| `glare.efisCapt.vorD.pressed` | bool | pushbutton | momentary | `0` | Captain EFIS VOR.D pushbutton (momentary: 1 while held) |
| `glare.efisCapt.wpt.on` | bool | light | read | `0` | Captain EFIS WPT ON light |
| `glare.efisCapt.wpt.pressed` | bool | pushbutton | momentary | `0` | Captain EFIS WPT pushbutton (momentary: 1 while held) |
| `glare.efisFo.arpt.on` | bool | light | read | `0` | First officer EFIS ARPT ON light |
| `glare.efisFo.arpt.pressed` | bool | pushbutton | momentary | `0` | First officer EFIS ARPT pushbutton (momentary: 1 while held) |
| `glare.efisFo.baroHpa` | float | encoder | write | `-1` | First officer EFIS baro reference set (hPa, the window's value in hPa whatever the unit; -1 in STD or dark). Writable for external EFIS panels: a new value acts as the BARO knob turned to it (745..1050, in the window's unit and resolution; nothing in STD or without FCU power) |
| `glare.efisFo.baroInHg` | float | encoder | write | `-1` | First officer EFIS baro reference set (in Hg, the window's value in in Hg whatever the unit; -1 in STD or dark). Writable as baroHpa (21.99..31.00) |
| `glare.efisFo.baroKnob` | int | encoder | write | `0` | First officer EFIS BARO knob rotation counter (+1 per clockwise click: 1 hPa or 0.01 in Hg) |
| `glare.efisFo.baroPull` | bool | pushbutton | momentary | `0` | First officer EFIS BARO knob pulled (STD) (momentary: 1 while held) |
| `glare.efisFo.baroPush` | bool | pushbutton | momentary | `0` | First officer EFIS BARO knob pushed (QNH) (momentary: 1 while held) |
| `glare.efisFo.baroQfe` | bool | light | read | `0` | First officer EFIS QFE legend of the baro window (lit in QFE: QFE option, efis.qfe.installed) |
| `glare.efisFo.baroQnh` | bool | light | read | `0` | First officer EFIS QNH legend of the baro window (lit in QNH) |
| `glare.efisFo.baroUnit` | int | rotary | write | `0` | First officer EFIS BARO outer ring (0 = in Hg, 1 = hPa) |
| `glare.efisFo.baroWindow` | string | light | read | `"1013"` | First officer EFIS baro reference window: "1013" (hPa, 4 digits: "0745".."1050"), "29.92" (in Hg, "21.99".."31.00"), "Std", "8888" ANN LT TEST, "" dark |
| `glare.efisFo.cstr.on` | bool | light | read | `0` | First officer EFIS CSTR ON light |
| `glare.efisFo.cstr.pressed` | bool | pushbutton | momentary | `0` | First officer EFIS CSTR pushbutton (momentary: 1 while held) |
| `glare.efisFo.fd.on` | bool | light | read | `0` | First officer EFIS FD ON light |
| `glare.efisFo.fd.pressed` | bool | pushbutton | momentary | `0` | First officer EFIS FD pushbutton (momentary: 1 while held) |
| `glare.efisFo.ls.on` | bool | light | read | `0` | First officer EFIS LS ON light |
| `glare.efisFo.ls.pressed` | bool | pushbutton | momentary | `0` | First officer EFIS LS pushbutton (momentary: 1 while held) |
| `glare.efisFo.navaid1` | int | switch | write | `0` | First officer EFIS ADF-VOR 1 selector (0 = ADF, 1 = OFF, 2 = VOR) |
| `glare.efisFo.navaid2` | int | switch | write | `0` | First officer EFIS ADF-VOR 2 selector (0 = ADF, 1 = OFF, 2 = VOR) |
| `glare.efisFo.ndMode` | int | rotary | write | `0` | First officer EFIS ND mode selector (0 = ROSE ILS, 1 = ROSE VOR, 2 = ROSE NAV, 3 = ARC, 4 = PLAN) |
| `glare.efisFo.ndRange` | int | rotary | write | `0` | First officer EFIS ND range selector (0..5 = 10, 20, 40, 80, 160, 320 NM) |
| `glare.efisFo.ndb.on` | bool | light | read | `0` | First officer EFIS NDB ON light |
| `glare.efisFo.ndb.pressed` | bool | pushbutton | momentary | `0` | First officer EFIS NDB pushbutton (momentary: 1 while held) |
| `glare.efisFo.vorD.on` | bool | light | read | `0` | First officer EFIS VOR.D ON light |
| `glare.efisFo.vorD.pressed` | bool | pushbutton | momentary | `0` | First officer EFIS VOR.D pushbutton (momentary: 1 while held) |
| `glare.efisFo.wpt.on` | bool | light | read | `0` | First officer EFIS WPT ON light |
| `glare.efisFo.wpt.pressed` | bool | pushbutton | momentary | `0` | First officer EFIS WPT pushbutton (momentary: 1 while held) |

## Glareshield / INTEG LT

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `glare.intLt.integLt` | float | analog | write | `0` | Glareshield integral lighting thumbwheel under the FCU (0 = OFF .. 1 = BRT) |

## Glareshield / SIDE STICK PRIORITY

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `glare.sidestickPriority.capt.green` | bool | light | read | `0` | CAPT green SIDE STICK PRIORITY light |
| `glare.sidestickPriority.capt.red` | bool | light | read | `0` | CAPT red arrow (captain's sidestick deactivated) |
| `glare.sidestickPriority.fo.green` | bool | light | read | `0` | F/O green SIDE STICK PRIORITY light |
| `glare.sidestickPriority.fo.red` | bool | light | read | `0` | F/O red arrow (F/O sidestick deactivated) |

## GPWS

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `gpws.alert` | bool | output | read | `0` | A GPWS aural alert is active |
| `gpws.obstacleAlert` | bool | output | read | `0` | The predictive alert (gpws.tad) is an obstacle's: OBSTACLE AHEAD (PULL UP), OBST AHEAD on the NDs |
| `gpws.obstacleDatabase` | string | output | read | `"MISSING (/home/maduranma/Projects/nvan/a320-professional/a320-professional/src/Systems/bin/Debug/net10.0/obstacles)"` | Obstacle database (OpenStreetMap, ODbL): folder and state (READY, MISSING: none installed, no obstacle function; OFF: option off) |
| `gpws.obstacles` | int | output | read | `0` | Obstacles in the loaded obstacle database |
| `gpws.tad` | int | output | read | `0` | Predictive terrain alert: 0 none, 1 caution (TERRAIN AHEAD), 2 warning (PULL UP) |
| `gpws.terrainDatabase` | string | output | read | `""` | Terrain database: folder and state (READY, MISSING: no terrain data installed → TERR FAULT) |
| `gpws.terrainTiles` | int | output | read | `0` | Terrain database tiles (1°) loaded around the aircraft |

## GPWS / RAAS

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `gpws.raas.available` | bool | output | read | `0` | RAAS enabled and available (powered, GPS position, a database runway near) |
| `gpws.raas.distanceStart` | int | service | write | `0` | RAAS distance remaining from: 0 half the runway, 1..5 = 1000..5000 ft (300..1500 m) from its end |
| `gpws.raas.holdInitialS` | int | service | write | `0` | RAAS extended holding on runway: first advisory after (s): 0 off, 60, 90, 120, 180, 240, 300 |
| `gpws.raas.holdRepeatS` | int | service | write | `0` | RAAS extended holding on runway: repeated every (s): 0 off, 30, 60, 90, 120, 180, 240, 300 |
| `gpws.raas.longLandingFt` | int | service | write | `0` | RAAS long landing monitor: no touchdown this far beyond the threshold (ft) |
| `gpws.raas.message` | string | output | read | `""` | The last RAAS phrase requested, in words |
| `gpws.raas.nominalLandingFt` | int | service | write | `0` | RAAS nominal landing runway length (ft): short runway below it |
| `gpws.raas.nominalTakeoffFt` | int | service | write | `0` | RAAS nominal takeoff runway length (ft): insufficient runway below it |
| `gpws.raas.options` | int | service | write | `0` | RAAS options (EGPWS option, setting saved in systems.json): bit mask 0 enabled, 1 meters, 2 announce units, 3 approaching (ground), 4 on runway, 5 approaching (air), 6 distance remaining landing, 7 runway end, 8 taxiway takeoff, 9 its caution, 10 insufficient runway (ground), 11 short runway caution (ground), 12 always the length (ground), 13 extended holding, 14 distance remaining RTO, 15 short runway (air), 16 short runway caution (air), 17 always the length (air), 18 taxiway landing, 19 takeoff flap monitor, 20 long landing, 21 Airbus suppression zone 450-350 ft |

## Ground / Calls

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `ground.calls.mechReset` | bool | service | momentary | `0` | External power panel RESET pb (ground mechanic: COCKPIT CALL light off; 1 = pressed) |
| `ground.calls.mechToCockpit` | bool | service | momentary | `0` | Ground mechanic COCKPIT call pb (external power panel, 1 = held) |
| `ground.calls.selcal` | int | service | write | `0` | SELCAL call received on a radio: 1..3 VHF n, 4..5 HF n (with ground.calls.selcalCode; Systems writes 0 back once taken) |
| `ground.calls.selcalCode` | int | service | write | `0` | Code of the next SELCAL call: -1 = the aircraft's own code (aircraft.selcal), else the packed code (4 letters of ABCDEFGHJKLMPQRS, each 0..15: L1 × 4096 + L2 × 256 + L3 × 16 + L4) |
| `ground.extPwrPanel.cockpitCall` | bool | light | read | `0` | External power panel COCKPIT CALL light (blue: the cockpit called the ground mechanic) |

## Ground / EXTERNAL POWER panel

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `ground.extPwrPanel.adiruAvncs` | bool | light | read | `0` | ADIRU and AVNCS VENT light (amber, 108VU; 2019 DSC-34-NAV-10-20, DSC-21-30-60): an ADIRU on battery or the avionics ventilation warning, on the ground |
| `ground.extPwrPanel.horn` | bool | light | read | `0` | External horn (nose gear bay): an ADIRU on battery on the ground (after 15 s), the avionics ventilation low pressure on the ground with the engines stopped (after 30 s), the cockpit MECH call, an APU fire on the ground |

## Ground / Refuel panel 800VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `ground.refuelPanel.actualKg` | float | output | read | `-1` | ACTUAL display: fuel on board (kg, FQI; display x 1000; -1 = blank) |
| `ground.refuelPanel.battPower` | bool | switch | momentary | `0` | BATT POWER toggle held at ON (momentary; 0 = NORM): HOT BUS 1 supplies the FQI |
| `ground.refuelPanel.battSupply` | bool | output | read | `0` | FQI supplied by HOT BUS 1 through BATT POWER (about 40 s of tests before the indications) |
| `ground.refuelPanel.displayTest` | bool | output | read | `0` | TEST LTS: every display shows all 8s |
| `ground.refuelPanel.doorOpen` | bool | switch | write | `0` | Refuel panel access door open (panel energized; REFUELG memo) |
| `ground.refuelPanel.end` | bool | light | read | `0` | END light (green): steady when the automatic refuel is complete, flashing when it was aborted (lamp state) |
| `ground.refuelPanel.hiLvl.center` | bool | light | read | `0` | HI LVL CENTER light (blue): high level sensor wet, its refuel valve closed |
| `ground.refuelPanel.hiLvl.left` | bool | light | read | `0` | HI LVL LEFT light (blue): high level sensor wet, its refuel valve closed |
| `ground.refuelPanel.hiLvl.right` | bool | light | read | `0` | HI LVL RIGHT light (blue): high level sensor wet, its refuel valve closed |
| `ground.refuelPanel.modeSelect` | int | rotary | write | `1` | MODE SELECT (0 = REFUEL, 1 = OFF, 2 = DEFUEL XFR; guarded at OFF) |
| `ground.refuelPanel.open` | bool | light | read | `0` | OPEN light (amber): defuel / transfer valve open |
| `ground.refuelPanel.powered` | bool | output | read | `0` | Panel energized (door open and the FQI computing): displays and lights alive |
| `ground.refuelPanel.preselectedDisplayKg` | float | output | read | `-1` | PRESELECTED display (kg; display x 1000; -1 = blank) |
| `ground.refuelPanel.preselectedKg` | float | encoder | write | `0` | Preselected total fuel (kg, 0 to 18968); also moved by the INC / DEC switch |
| `ground.refuelPanel.preselectorDec` | bool | pushbutton | momentary | `0` | Preselector switch pressed on DEC (momentary: -100 kg, repeating while held) |
| `ground.refuelPanel.preselectorInc` | bool | pushbutton | momentary | `0` | Preselector switch pressed on INC (momentary: +100 kg, repeating while held) |
| `ground.refuelPanel.qty.centerKg` | float | output | read | `-1` | FUEL QTY indicator CENTER (kg, FQI; display x 1000; -1 = blank) |
| `ground.refuelPanel.qty.leftKg` | float | output | read | `-1` | FUEL QTY indicator LEFT (kg, FQI; display x 1000; -1 = blank) |
| `ground.refuelPanel.qty.rightKg` | float | output | read | `-1` | FUEL QTY indicator RIGHT (kg, FQI; display x 1000; -1 = blank) |
| `ground.refuelPanel.test` | int | switch | write | `1` | TEST switch (0 = HI LVL, 1 = neutral, 2 = LTS; spring-loaded to neutral) |
| `ground.refuelPanel.valve.center` | int | switch | write | `1` | REFUEL VALVES CENTER (0 = OPEN, 1 = NORM, 2 = SHUT; guarded in NORM) |
| `ground.refuelPanel.valve.left` | int | switch | write | `1` | REFUEL VALVES LEFT (0 = OPEN, 1 = NORM, 2 = SHUT; guarded in NORM) |
| `ground.refuelPanel.valve.right` | int | switch | write | `1` | REFUEL VALVES RIGHT (0 = OPEN, 1 = NORM, 2 = SHUT; guarded in NORM) |

## Ground / Water and waste

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `ground.waste.drain` | bool | service | write | `0` | Waste tank draining and rinsing (on ground only, back to 0 when empty) |
| `ground.water.panelQuantityPct` | float | output | read | `0` | Water quantity on the aft service panel indicator (%, -1 = no indication) |
| `ground.water.service` | int | service | write | `0` | Potable water service (0 idle, 1 fill, 2 drain; on ground only, back to 0 when full / empty) |

## Ground services

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `ground.cargoDoorOperating` | bool | output | read | `0` | A cargo door manual selector valve at OPEN or CLOSE (starts the yellow electric pump) |
| `ground.externalTow` | int | service | read | `0` | Tug that is not ours, as the simulator says (bits: 1 simulator pushback tug attached, 2 simulator tow in progress, 4 BetterPushback connected, 8 BetterPushback started; 0 none) |
| `ground.fire.refillBottles` | bool | service | momentary | `0` | Recharge every fire extinguisher bottle (engines, APU, cargo; 1 while servicing) |
| `ground.gate.armedSlides` | int | output | read | `0` | Automatic doors with the beacon: passenger doors not opened because their slide was armed (bit per door: 1 FWD L, 2 FWD R, 4 AFT L, 8 AFT R) |
| `ground.gate.autoDoors` | bool | service | write | `0` | Systems option: automatic doors and jetway with the beacon (BEACON OFF while parked: L1, FWD / AFT / BULK cargo doors open, jetway called; BEACON ON: every door closed, jetway retracted). Saved in systems.json |
| `ground.gate.jetway` | int | output | read | `0` | Automatic doors with the beacon: last jetway request sent to the simulator (0 none, 1 dock, 2 retract) |
| `ground.gate.status` | int | output | read | `0` | Automatic doors with the beacon: 0 idle, 1 beacon off, waiting for the aircraft to be parked (engines spooled down, PARK BRK set), 2 arrival doors opened, 3 doors closed for departure |
| `ground.gpu.autoConnect` | bool | output | read | `0` | Systems option: the ground crew connects the GPU when the parking brake is set on ground with the engines spooled down and the BEACON off, and removes it when the brake is released |
| `ground.gpu.connected` | bool | service | write | `0` | Ground power unit plugged in |
| `ground.gpu.refused` | int | output | read | `0` | Last GPU connection refused by the ground crew while its reason lasts: 0 none, 1 airborne, 2 moving, 3 engines running, 4 BEACON on |
| `ground.gpu.withEnginesRunning` | bool | service | write | `0` | Systems option: the ground crew connects the GPU even with the engines running (not standard practice; still refused airborne or moving). Saved in systems.json |
| `ground.hpAir.connected` | bool | service | write | `0` | HP ground air cart connected and supplying (GND HP connection, engine start air) |
| `ground.idgReconnect` | bool | service | momentary | `0` | Maintenance: reconnect disconnected IDGs (on ground, engine stopped) |
| `ground.maint.idg1Disconnected` | bool | output | read | `0` | IDG 1 disconnected (reconnected by maintenance only) |
| `ground.maint.idg2Disconnected` | bool | output | read | `0` | IDG 2 disconnected (reconnected by maintenance only) |
| `ground.maint.ratPosition` | float | output | read | `0` | RAT position (0 stowed .. 1 extended) |
| `ground.nwsTowing` | bool | service | write | `0` | Nose wheel steering bypass pin (tow pin) inserted: steering disconnected for towing |
| `ground.oxygen.paxRestow` | bool | service | momentary | `0` | Maintenance: restow the passenger oxygen masks and replace the used generators (on ground; then TMR RESET) |
| `ground.pushback.activeOption` | int | service | read | `0` | Pushback: the option being flown (1..3) from start until idle again, else 0 |
| `ground.pushback.debug.airport` | string | service | read | `""` | Pushback tuning: the airport those lines belong to |
| `ground.pushback.debug.crossTrackM` | float | service | read | `0` | Pushback tuning: main gear off the path (m, + = right of it facing the direction of travel) |
| `ground.pushback.debug.finalCrossTrackM` | float | service | read | `0` | Pushback tuning: main gear off the line when the last push ended (m) |
| `ground.pushback.debug.finalHeadingErrorDeg` | float | service | read | `0` | Pushback tuning: heading against the line when the last push ended (deg) |
| `ground.pushback.debug.forceN` | float | service | read | `0` | Pushback tuning: tug force sent to the simulator (N, + = forward: negative while pushing back) |
| `ground.pushback.debug.headingErrorDeg` | float | service | read | `0` | Pushback tuning: aircraft heading against the path (deg, + = clockwise) |
| `ground.pushback.debug.lineSegments` | int | service | read | `0` | Pushback tuning: taxi line pieces the simulator gave for the last plan |
| `ground.pushback.debug.measuredReferenceOffsetM` | float | service | read | `0` | Pushback tuning: the same, measured from the aircraft's motion in the turn (m; 0 until it has turned 12 deg) |
| `ground.pushback.debug.referenceOffsetM` | float | service | read | `0` | Pushback tuning: main gear behind the simulator's position reference, as used (m) |
| `ground.pushback.debug.speedMs` | float | service | read | `0` | Pushback tuning: speed along the path (m/s) |
| `ground.pushback.debug.steeringDeg` | float | service | read | `0` | Pushback tuning: nose wheel angle sent to the simulator (deg, + = right) |
| `ground.pushback.debug.targetSpeedMs` | float | service | read | `0` | Pushback tuning: speed ordered along the path (m/s, backwards for the aircraft) |
| `ground.pushback.lineDistanceM` | float | service | read | `0` | Pushback: from the main gear to the line along the aircraft axis (m, 0 with the generic options) |
| `ground.pushback.manualDistanceM` | float | service | write | `0` | Pushback: straight travel of the generic options (m, 20..150) |
| `ground.pushback.message` | string | service | read | `""` | Pushback: one line for the crew / instructor |
| `ground.pushback.option1.available` | bool | service | read | `0` | Pushback option 1: can be started (0: the line is too close for that turn; the label says so) |
| `ground.pushback.option1.headingDeg` | float | service | read | `0` | Pushback option 1: magnetic heading the nose faces at the end (0..360) |
| `ground.pushback.option1.label` | string | service | read | `"Taxiway LD"` | Pushback option 1: what it is ("Taxiway LD", "Straight back") |
| `ground.pushback.option1.lengthM` | float | service | read | `0` | Pushback option 1: length of the whole path of the main gear (m) |
| `ground.pushback.option1.radiusM` | float | service | read | `0` | Pushback option 1: turn radius of its path (m, 0 = no turn) |
| `ground.pushback.option1.straightM` | float | service | read | `0` | Pushback option 1: straight travel of the main gear along the aircraft axis before the turn (m) |
| `ground.pushback.option1.turnDeg` | float | service | read | `0` | Pushback option 1: change of heading from the present one (+ = clockwise) |
| `ground.pushback.option2.available` | bool | service | read | `0` | Pushback option 2: can be started (0: the line is too close for that turn; the label says so) |
| `ground.pushback.option2.headingDeg` | float | service | read | `0` | Pushback option 2: magnetic heading the nose faces at the end (0..360) |
| `ground.pushback.option2.label` | string | service | read | `"Taxiway LD"` | Pushback option 2: what it is ("Taxiway LD", "Straight back") |
| `ground.pushback.option2.lengthM` | float | service | read | `0` | Pushback option 2: length of the whole path of the main gear (m) |
| `ground.pushback.option2.radiusM` | float | service | read | `0` | Pushback option 2: turn radius of its path (m, 0 = no turn) |
| `ground.pushback.option2.straightM` | float | service | read | `0` | Pushback option 2: straight travel of the main gear along the aircraft axis before the turn (m) |
| `ground.pushback.option2.turnDeg` | float | service | read | `0` | Pushback option 2: change of heading from the present one (+ = clockwise) |
| `ground.pushback.option3.available` | bool | service | read | `0` | Pushback option 3: can be started (0: the line is too close for that turn; the label says so) |
| `ground.pushback.option3.headingDeg` | float | service | read | `0` | Pushback option 3: magnetic heading the nose faces at the end (0..360) |
| `ground.pushback.option3.label` | string | service | read | `"Taxiway LD"` | Pushback option 3: what it is ("Taxiway LD", "Straight back") |
| `ground.pushback.option3.lengthM` | float | service | read | `0` | Pushback option 3: length of the whole path of the main gear (m) |
| `ground.pushback.option3.radiusM` | float | service | read | `0` | Pushback option 3: turn radius of its path (m, 0 = no turn) |
| `ground.pushback.option3.straightM` | float | service | read | `0` | Pushback option 3: straight travel of the main gear along the aircraft axis before the turn (m) |
| `ground.pushback.option3.turnDeg` | float | service | read | `0` | Pushback option 3: change of heading from the present one (+ = clockwise) |
| `ground.pushback.optionCount` | int | service | read | `0` | Pushback: options offered (0, 2 or 3) |
| `ground.pushback.progress` | float | service | read | `0` | Pushback: traveled part of the path (0..1) |
| `ground.pushback.radiusM` | float | service | read | `0` | Pushback: turn radius of the option being flown, else of option 1 (m) |
| `ground.pushback.remainingM` | float | service | read | `0` | Pushback: path still to travel (m) |
| `ground.pushback.request` | bool | service | write | `0` | Pushback: work out the options for where the aircraft stands (written back to 0) |
| `ground.pushback.source` | int | service | read | `0` | Pushback: where the line comes from: 0 none, 1 taxi network, 2 painted centerline, 3 no line found (generic options) |
| `ground.pushback.start` | int | service | write | `0` | Pushback: start with this option (1..3; only when ready; written back to 0) |
| `ground.pushback.state` | int | service | read | `0` | Pushback: 0 idle, 1 planning, 2 ready, 3 connecting, 4 waiting for parking brake release, 5 pushing, 6 waiting for parking brake set, 7 disconnecting, 8 complete |
| `ground.pushback.stop` | bool | service | write | `0` | Pushback: stop now (the tug brakes, then waits for the parking brake and disconnects; written back to 0) |
| `ground.pushback.taxiway` | string | service | read | `""` | Pushback: name of the taxi line, when the scenery gives one |
| `ground.ratStow` | bool | service | momentary | `0` | Stow the RAT (on ground only; 1 while stowing) |
| `ground.wheelChange` | bool | service | momentary | `0` | Maintenance: change every deflated or burst wheel (on ground; clears the tire failures, the new wheels' brakes cooled) |
| `ground.yellowHandPump` | bool | service | write | `0` | Yellow hydraulic hand pump being worked (cargo doors without the yellow electric pump; 1 while pumping) |

## Ground services / Fuel

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `ground.fuel.instant` | bool | service | write | `0` | Set the targets at once (simulator convenience; back to 0 when done) |
| `ground.fuel.perTank` | bool | service | write | `0` | Use the per-tank targets instead of the total |
| `ground.fuel.refuel` | bool | service | write | `0` | Refuel / defuel to the targets at the normal rate (on ground; back to 0 when done) |
| `ground.fuel.target.centerKg` | float | service | write | `0` | Per-tank target (kg, 0 to 6474) |
| `ground.fuel.target.lInnerKg` | float | service | write | `0` | Per-tank target (kg, 0 to 5567) |
| `ground.fuel.target.lOuterKg` | float | service | write | `0` | Per-tank target (kg, 0 to 680) |
| `ground.fuel.target.rInnerKg` | float | service | write | `0` | Per-tank target (kg, 0 to 5567) |
| `ground.fuel.target.rOuterKg` | float | service | write | `0` | Per-tank target (kg, 0 to 680) |
| `ground.fuel.targetTotalKg` | float | service | write | `0` | Preselected total fuel (kg, 0 to 18968), distributed outer cells, inner cells, then center |

## Ground services / Load

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `ground.load.bagMassKg` | float | service | write | `0` | Checked bags per passenger (kg, 0 to 50), loaded in the forward and aft holds |
| `ground.load.board` | bool | service | write | `0` | Board / load to the targets at the normal rate (on ground; back to 0 when done) |
| `ground.load.cargo.target.aftKg` | float | service | write | `0` | Cargo in the aft hold (kg, without the bags; up to 4536 kg with them) |
| `ground.load.cargo.target.bulkKg` | float | service | write | `0` | Cargo in the bulk hold (kg, without the bags; up to 1497 kg with them) |
| `ground.load.cargo.target.fwdKg` | float | service | write | `0` | Cargo in the fwd hold (kg, without the bags; up to 3402 kg with them) |
| `ground.load.instant` | bool | service | write | `0` | Set the targets at once (simulator convenience; back to 0 when done) |
| `ground.load.pax.target.oa` | int | service | write | `0` | Passengers to board in cabin zone OA (0 to 60) |
| `ground.load.pax.target.ob` | int | service | write | `0` | Passengers to board in cabin zone OB (0 to 60) |
| `ground.load.pax.target.oc` | int | service | write | `0` | Passengers to board in cabin zone OC (0 to 60) |
| `ground.load.paxMassKg` | float | service | write | `0` | Standard mass per passenger with hand baggage (kg, 50 to 150) |
| `ground.load.paxTarget` | int | service | write | `0` | Passengers to board (0 to 180), spread evenly over the cabin zones OA, OB, OC |
| `ground.load.perZone` | bool | service | write | `0` | Use the per-zone passenger targets instead of the total |

## Hydraulic (parameters)

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `hyd.blue.pressurePsi` | float | output | read | `0` | Blue hydraulic system pressure (psi) |
| `hyd.blue.reservoirL` | float | output | read | `6.5` | Blue reservoir fluid quantity (litres; normal 6.5, low level 2.4) |
| `hyd.blueElecPump.lowPressure` | bool | output | read | `1` | Blue electric pump pressure switch LO (HYD SD page LO; ≤ 1450 psi, reset ≥ 1750 psi) |
| `hyd.eng1Pump.lowPressure` | bool | output | read | `1` | ENG 1 (green) pump pressure switch LO (HYD SD page LO; ≤ 1750 psi, reset ≥ 2200 psi) |
| `hyd.eng2Pump.lowPressure` | bool | output | read | `1` | ENG 2 (yellow) pump pressure switch LO (HYD SD page LO; ≤ 1750 psi, reset ≥ 2200 psi) |
| `hyd.green.pressurePsi` | float | output | read | `0` | Green hydraulic system pressure (psi) |
| `hyd.green.reservoirL` | float | output | read | `14.5` | Green reservoir fluid quantity (litres; normal 14.5, low level 3.5) |
| `hyd.rat.turbineAngleDeg` | float | output | read | `0` | RAT turbine angle (degrees 0..360, turning with its speed; for an exterior model) |
| `hyd.rat.turbineRpm` | float | output | read | `0` | RAT turbine speed (rpm; 0 stowed or without airflow; ESTIMATED governed 6000 rpm from 140 kt) |
| `hyd.yellow.pressurePsi` | float | output | read | `0` | Yellow hydraulic system pressure (psi) |
| `hyd.yellow.reservoirL` | float | output | read | `12.5` | Yellow reservoir fluid quantity (litres; normal 12.5, low level 3.5) |
| `hyd.yellowElecPump.lowPressure` | bool | output | read | `1` | Yellow electric pump pressure switch LO (≤ 1450 psi, reset ≥ 1750 psi; the SD shows no LO for it) |

## Instructor

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `instructor.apuQuickStart` | bool | service | write | `0` | IOS: APU running at once (BAT and APU MASTER SW ON, AVAIL), written back to 0 |
| `instructor.engineQuickStart` | bool | service | write | `0` | IOS: both engines running at once (ENG MASTERs ON), written back to 0 |
| `instructor.instantAlign` | bool | service | write | `0` | IOS: the three IR mode selectors to NAV and every IR aligning finishes its alignment now (as adirs.instantAlign), written back to 0 |
| `instructor.preset` | int | service | write | `0` | IOS state preset, applied once (on ground) and written back to 0: 1 COLD & DARK, 2 APU RUNNING, 3 ENGINES RUNNING |
| `instructor.simRate` | int | service | write | `0` | IOS sim rate, writable by any client (the IOS header's x1 / x2 / x4 / x8): 1, 2, 4 or 8 (x1 real time; any other value is refused and the last valid one kept). Commanded x1 while slewing (the selection is kept); the rate reached is instructor.sim.rateAchieved |
| `instructor.status` | string | output | read | `""` | Result of the last instructor command |
| `instructor.statusCounter` | int | output | read | `0` | Incremented with every instructor.status message |

## Instructor / Simulator

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `instructor.sim.altitudeFt` | float | output | read | `0` | Aircraft altitude (ft MSL, simulator truth) |
| `instructor.sim.bridgeConnected` | bool | output | read | `0` | A simulator bridge sends its truth (no news for 1 s = not connected) |
| `instructor.sim.crashed` | bool | output | read | `0` | The simulator says the aircraft has crashed (simulator truth; X-Plane has_crashed): the IOS crash alert |
| `instructor.sim.groundSpeedKt` | float | output | read | `0` | Ground speed (kt, simulator truth) |
| `instructor.sim.headingTrue` | float | output | read | `0` | True heading (degrees, simulator truth) |
| `instructor.sim.iasKt` | float | output | read | `0` | Indicated airspeed (kt, simulator truth) |
| `instructor.sim.latitude` | float | output | read | `0` | Aircraft latitude (degrees, simulator truth) |
| `instructor.sim.localOffsetMin` | float | output | read | `0` | The simulator's time zone at the aircraft: its local time minus UTC (minutes, simulator truth; valid with instructor.sim.utcSeconds) |
| `instructor.sim.longitude` | float | output | read | `0` | Aircraft longitude (degrees, simulator truth) |
| `instructor.sim.onGround` | bool | output | read | `0` | A main gear on the ground (simulator truth) |
| `instructor.sim.paused` | bool | service | write | `0` | The simulator is paused (simulator truth). Write 1 to pause, 0 to resume: sent to the simulator as the IOS PAUSE / PLAY (instructor.status gives its answer); the value stays the simulator's truth (it changes when the simulator has paused or resumed); refused while no simulator is connected and while the demo period holds it paused |
| `instructor.sim.pitchDeg` | float | output | read | `0` | Pitch attitude (degrees, nose up +, simulator truth) |
| `instructor.sim.rateAchieved` | float | output | read | `0` | Rate the simulator really reaches (simulator truth; X-Plane sim_speed_actual; 1 when not reported or no simulator) |
| `instructor.sim.rateSystems` | float | output | read | `0` | Rate Systems' own time runs at (simulated ticks per real tick: follows the achieved rate; 0 while the simulator is paused: the aircraft systems frozen) |
| `instructor.sim.rollDeg` | float | output | read | `0` | Bank angle (degrees, right wing down +, simulator truth) |
| `instructor.sim.utcDayOfYear` | float | output | read | `0` | Simulator date (day of the year UTC, 0 = 1 January, simulator truth; -1 = unknown) |
| `instructor.sim.utcSeconds` | float | output | read | `0` | Simulator time (seconds since midnight UTC, simulator truth; -1 = unknown) |
| `instructor.sim.webApi` | int | output | read | `0` | The simulator's local web API as the bridge probes it (X-Plane: needed for a variant / livery change): 1 reachable, 0 not reachable, -1 not known (no bridge, a bridge without one, not probed yet) |
| `instructor.sim.webApiPort` | int | output | read | `0` | Port of the simulator's local web API the bridge probes (0: none) |
| `instructor.sim.webApiReason` | int | output | read | `0` | Why the simulator's local web API is not usable: 1 not reachable on the port, 2 refused (403: X-Plane's incoming traffic disabled in Settings > Network), 3 off (X-Plane started with --no_web_server); 0 usable or not known |

## Instructor / Slew

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `instructor.slew.active` | bool | service | write | `0` | IOS slew mode: 1 = the aircraft is held out of the simulator's flight dynamics and moved by the slew rates; 0 = it flies again |
| `instructor.slew.bank` | float | service | write | `0` | Slew bank: right (+) / left (−), −1..1 (in the air) |
| `instructor.slew.forward` | float | service | write | `0` | Slew forward (+) / back (−), −1..1 |
| `instructor.slew.heartbeat` | int | service | write | `0` | Raised at least every 0.5 s by a client while it holds a slew control; none for 1 s = every slew rate back to 0 |
| `instructor.slew.level` | bool | service | write | `0` | Slew LEVEL: pitch and bank back to 0 (in the air), written back to 0 |
| `instructor.slew.pitch` | float | service | write | `0` | Slew pitch: nose up (+) / down (−), −1..1 (in the air) |
| `instructor.slew.right` | float | service | write | `0` | Slew right (+) / left (−), −1..1 |
| `instructor.slew.speed` | float | service | write | `0` | Slew speed scale 0..1 (full-deflection rates, logarithmic): 0 FINE (~6 kt, 300 ft/min, 2°/s), 1 COARSE (~290 kt, 5000 ft/min, 10°/s) |
| `instructor.slew.turn` | float | service | write | `0` | Slew heading: right (+) / left (−), −1..1 |
| `instructor.slew.up` | float | service | write | `0` | Slew up (+) / down (−), −1..1 |

## Landing gear / State (read-only)

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `gear.left.doorPosition` | float | output | read | `0` | left gear hydraulic doors position (0 = closed and locked, 1 = fully open) |
| `gear.left.position` | float | light | read | `0` | left gear position (0 = up and locked, 1 = down and locked) |
| `gear.left.transit` | float | output | read | `0` | left gear transit for an exterior model (0 = down with the doors closed, 0.2 = down with the doors open, 0.8 = up with the doors open, 1 = up and locked with the doors closed; gravity extension stays at 0.2) |
| `gear.nose.doorPosition` | float | output | read | `0` | nose gear hydraulic doors position (0 = closed and locked, 1 = fully open) |
| `gear.nose.position` | float | light | read | `0` | nose gear position (0 = up and locked, 1 = down and locked) |
| `gear.nose.transit` | float | output | read | `0` | nose gear transit for an exterior model (0 = down with the doors closed, 0.2 = down with the doors open, 0.8 = up with the doors open, 1 = up and locked with the doors closed; gravity extension stays at 0.2) |
| `gear.right.doorPosition` | float | output | read | `0` | right gear hydraulic doors position (0 = closed and locked, 1 = fully open) |
| `gear.right.position` | float | light | read | `0` | right gear position (0 = up and locked, 1 = down and locked) |
| `gear.right.transit` | float | output | read | `0` | right gear transit for an exterior model (0 = down with the doors closed, 0.2 = down with the doors open, 0.8 = up with the doors open, 1 = up and locked with the doors closed; gravity extension stays at 0.2) |
| `wheel.brakeTemp1` | float | light | read | `0` | Brake 1 temperature (°C, as the BSCU measures it) |
| `wheel.brakeTemp2` | float | light | read | `0` | Brake 2 temperature (°C, as the BSCU measures it) |
| `wheel.brakeTemp3` | float | light | read | `0` | Brake 3 temperature (°C, as the BSCU measures it) |
| `wheel.brakeTemp4` | float | light | read | `0` | Brake 4 temperature (°C, as the BSCU measures it) |
| `wheel.rimTemp1` | float | light | read | `0` | Main wheel 1 rim temperature (°C; no cockpit indication: its fusible plugs melt at 177 °C) |
| `wheel.rimTemp2` | float | light | read | `0` | Main wheel 2 rim temperature (°C; no cockpit indication: its fusible plugs melt at 177 °C) |
| `wheel.rimTemp3` | float | light | read | `0` | Main wheel 3 rim temperature (°C; no cockpit indication: its fusible plugs melt at 177 °C) |
| `wheel.rimTemp4` | float | light | read | `0` | Main wheel 4 rim temperature (°C; no cockpit indication: its fusible plugs melt at 177 °C) |
| `wheel.tirePsi1` | float | light | read | `0` | Tire 1 pressure as the TPIS measures it (psi; -1 without a working TPIS) |
| `wheel.tirePsi2` | float | light | read | `0` | Tire 2 pressure as the TPIS measures it (psi; -1 without a working TPIS) |
| `wheel.tirePsi3` | float | light | read | `0` | Tire 3 pressure as the TPIS measures it (psi; -1 without a working TPIS) |
| `wheel.tirePsi4` | float | light | read | `0` | Tire 4 pressure as the TPIS measures it (psi; -1 without a working TPIS) |
| `wheel.tirePsiNoseL` | float | light | read | `0` | Tire NoseL pressure as the TPIS measures it (psi; -1 without a working TPIS) |
| `wheel.tirePsiNoseR` | float | light | read | `0` | Tire NoseR pressure as the TPIS measures it (psi; -1 without a working TPIS) |

## Lights

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `lights.annunciatorIntensity` | float | light | read | `0` | Intensity of every flight deck annunciator light set by ANN LT (1 = BRT, 0.45 = DIM): clients scale the lit legends by it |

## Lights / avionics compartment

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `lights.avionicsCompt.lit` | bool | output | read | `0` | Avionics compartment lighting on (AVIONICS COMPT LT ON, or AUTO with an avionics compartment access door open; supply powered) |

## Lights / cockpit

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `lights.cockpit.ambient` | float | output | read | `0` | Daylight in the cockpit from the sun elevation (0 night .. 1 day; 1 without simulator time) |
| `lights.cockpit.chartCapt` | float | output | read | `0` | Captain chart light brightness (0 .. 1: the knob when lit, 0 off or unpowered) |
| `lights.cockpit.chartCaptLit` | bool | output | read | `0` | Captain chart light lit (switch ON, supply powered) |
| `lights.cockpit.chartFo` | float | output | read | `0` | First officer chart light brightness (0 .. 1: the knob when lit, 0 off or unpowered) |
| `lights.cockpit.chartFoLit` | bool | output | read | `0` | First officer chart light lit (switch ON, supply powered) |
| `lights.cockpit.consoleCapt` | float | output | read | `0` | Captain side console and briefcase lights (0 .. 1) |
| `lights.cockpit.consoleFo` | float | output | read | `0` | First officer side console and briefcase lights (0 .. 1) |
| `lights.cockpit.flood.mainPanelCapt` | float | output | read | `0` | Main instrument panel flood lights, captain side (0 .. 1) |
| `lights.cockpit.flood.mainPanelCenter` | float | output | read | `0` | Main instrument panel flood lights, center panel (0 .. 1) |
| `lights.cockpit.flood.mainPanelFo` | float | output | read | `0` | Main instrument panel flood lights, first officer side (0 .. 1) |
| `lights.cockpit.flood.pedestal` | float | output | read | `0` | Pedestal flood light (0 .. 1) |
| `lights.cockpit.floorCapt` | float | output | read | `0` | Captain floor light (0 .. 1) |
| `lights.cockpit.floorFo` | float | output | read | `0` | First officer floor light (0 .. 1) |
| `lights.cockpit.integral.glareshield` | float | output | read | `0` | Glareshield integral lighting (lamp voltage / maximum: 0 off, 0.27 .. 1) |
| `lights.cockpit.integral.mainPanel` | float | output | read | `0` | Main instrument panel integral lighting, captain, center and first officer (lamp voltage / maximum: 0 off, 0.27 .. 1) |
| `lights.cockpit.integral.overhead` | float | output | read | `0` | Overhead panel integral lighting (lamp voltage / maximum: 0 off, 0.27 .. 1) |
| `lights.cockpit.integral.pedestal` | float | output | read | `0` | Pedestal integral lighting (lamp voltage / maximum: 0 off, 0.27 .. 1) |
| `lights.cockpit.readingCapt` | float | output | read | `0` | Captain reading light (0 .. 1) |
| `lights.cockpit.readingFo` | float | output | read | `0` | First officer reading light (0 .. 1) |

## Lights / exterior lamps

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `lights.lamps.beaconCycleS` | float | output | read | `0` | Beacon flasher: seconds since it came on (0 = off) |
| `lights.lamps.beaconLower` | float | output | read | `0` | Exterior lamp BeaconLower: brightness 0 .. 1 (power received; flash applied for strobes and beacons) |
| `lights.lamps.beaconUpper` | float | output | read | `0` | Exterior lamp BeaconUpper: brightness 0 .. 1 (power received; flash applied for strobes and beacons) |
| `lights.lamps.landingL` | float | output | read | `0` | Exterior lamp LandingL: brightness 0 .. 1 (power received; flash applied for strobes and beacons) |
| `lights.lamps.landingR` | float | output | read | `0` | Exterior lamp LandingR: brightness 0 .. 1 (power received; flash applied for strobes and beacons) |
| `lights.lamps.logoL` | float | output | read | `0` | Exterior lamp LogoL: brightness 0 .. 1 (power received; flash applied for strobes and beacons) |
| `lights.lamps.logoR` | float | output | read | `0` | Exterior lamp LogoR: brightness 0 .. 1 (power received; flash applied for strobes and beacons) |
| `lights.lamps.nav1` | float | output | read | `0` | Exterior lamp Nav1: brightness 0 .. 1 (power received; flash applied for strobes and beacons) |
| `lights.lamps.nav2` | float | output | read | `0` | Exterior lamp Nav2: brightness 0 .. 1 (power received; flash applied for strobes and beacons) |
| `lights.lamps.rwyTurnOffL` | float | output | read | `0` | Exterior lamp RwyTurnOffL: brightness 0 .. 1 (power received; flash applied for strobes and beacons) |
| `lights.lamps.rwyTurnOffR` | float | output | read | `0` | Exterior lamp RwyTurnOffR: brightness 0 .. 1 (power received; flash applied for strobes and beacons) |
| `lights.lamps.strobeCycleS` | float | output | read | `0` | Strobe flasher: seconds since it came on (0 = off) |
| `lights.lamps.strobeTail` | float | output | read | `0` | Exterior lamp StrobeTail: brightness 0 .. 1 (power received; flash applied for strobes and beacons) |
| `lights.lamps.strobeWingL` | float | output | read | `0` | Exterior lamp StrobeWingL: brightness 0 .. 1 (power received; flash applied for strobes and beacons) |
| `lights.lamps.strobeWingR` | float | output | read | `0` | Exterior lamp StrobeWingR: brightness 0 .. 1 (power received; flash applied for strobes and beacons) |
| `lights.lamps.takeOff` | float | output | read | `0` | Exterior lamp TakeOff: brightness 0 .. 1 (power received; flash applied for strobes and beacons) |
| `lights.lamps.taxi` | float | output | read | `0` | Exterior lamp Taxi: brightness 0 .. 1 (power received; flash applied for strobes and beacons) |
| `lights.lamps.wingL` | float | output | read | `0` | Exterior lamp WingL: brightness 0 .. 1 (power received; flash applied for strobes and beacons) |
| `lights.lamps.wingR` | float | output | read | `0` | Exterior lamp WingR: brightness 0 .. 1 (power received; flash applied for strobes and beacons) |

## Lights / state

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `lights.cabin.emergency` | bool | output | read | `0` | Overhead emergency lights lit |
| `lights.cabin.exit` | bool | output | read | `0` | EXIT signs lit |
| `lights.cabin.noSmoking` | bool | output | read | `0` | NO SMOKING signs lit |
| `lights.cabin.proximityMarking` | bool | output | read | `0` | Proximity emergency escape path marking and exit markers lit |
| `lights.cabin.seatBelts` | bool | output | read | `0` | FASTEN SEAT BELT / RETURN TO SEAT signs lit |
| `lights.cockpit.domeL` | float | output | read | `0` | Left dome light intensity (0 .. 1) |
| `lights.cockpit.domeR` | float | output | read | `0` | Right dome light intensity (0 .. 1) |
| `lights.exterior.beaconLower` | bool | output | read | `0` | Exterior light lit: beaconLower |
| `lights.exterior.beaconUpper` | bool | output | read | `0` | Exterior light lit: beaconUpper |
| `lights.exterior.landingL` | bool | output | read | `0` | Exterior light lit: landingL |
| `lights.exterior.landingLExtension` | float | output | read | `0` | Left landing light extension (0 retracted .. 1 extended) |
| `lights.exterior.landingR` | bool | output | read | `0` | Exterior light lit: landingR |
| `lights.exterior.landingRExtension` | float | output | read | `0` | Right landing light extension (0 retracted .. 1 extended) |
| `lights.exterior.logoL` | bool | output | read | `0` | Exterior light lit: logoL |
| `lights.exterior.logoR` | bool | output | read | `0` | Exterior light lit: logoR |
| `lights.exterior.nav1` | bool | output | read | `0` | Exterior light lit: nav1 |
| `lights.exterior.nav2` | bool | output | read | `0` | Exterior light lit: nav2 |
| `lights.exterior.rwyTurnOffL` | bool | output | read | `0` | Exterior light lit: rwyTurnOffL |
| `lights.exterior.rwyTurnOffR` | bool | output | read | `0` | Exterior light lit: rwyTurnOffR |
| `lights.exterior.strobe` | bool | output | read | `0` | Exterior light lit: strobe |
| `lights.exterior.takeOff` | bool | output | read | `0` | Exterior light lit: takeOff |
| `lights.exterior.taxi` | bool | output | read | `0` | Exterior light lit: taxi |
| `lights.exterior.wingL` | bool | output | read | `0` | Exterior light lit: wingL |
| `lights.exterior.wingR` | bool | output | read | `0` | Exterior light lit: wingR |

## Load

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `load.boarding` | bool | output | read | `0` | Boarding / loading in progress |
| `load.cgOutOfLimits` | bool | output | read | `0` | ZFW or GW CG outside 17–40 % MAC (flat envelope, ESTIMATED) |
| `load.fuelKg` | float | output | read | `0` | Fuel on board (kg, the fuel system's tanks) |
| `load.gwCgMac` | float | output | read | `0` | Gross weight CG (% MAC, with the fuel) |
| `load.gwKg` | float | output | read | `0` | Gross weight (kg: ZFW + fuel) |
| `load.hold.aftKg` | float | output | read | `0` | Load in the aft hold (kg, cargo + bags) |
| `load.hold.bulkKg` | float | output | read | `0` | Load in the bulk hold (kg, cargo + bags) |
| `load.hold.fwdKg` | float | output | read | `0` | Load in the fwd hold (kg, cargo + bags) |
| `load.overMtow` | bool | output | read | `0` | Gross weight above the MTOW (73500 kg) |
| `load.overMzfw` | bool | output | read | `0` | Zero fuel weight above the MZFW (61000 kg): cargo is limited to it, passengers are not |
| `load.pax.oa` | int | output | read | `0` | Passengers on board in cabin zone OA |
| `load.pax.ob` | int | output | read | `0` | Passengers on board in cabin zone OB |
| `load.pax.oc` | int | output | read | `0` | Passengers on board in cabin zone OC |
| `load.paxTotal` | int | output | read | `0` | Passengers on board |
| `load.payloadKg` | float | output | read | `0` | Total traffic load (kg: passengers, bags and cargo) |
| `load.zfwCgMac` | float | output | read | `0` | Zero fuel weight CG (% MAC) |
| `load.zfwKg` | float | output | read | `0` | Zero fuel weight (kg: OEW 42500 CFM / 42700 IAE + traffic load) |

## Main instrument panel / DCDU 1

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `mip.dcdu1.brightness` | float | output | read | `0` | DCDU 1 screen brightness (0 = dark) |
| `mip.dcdu1.key.brt` | bool | pushbutton | momentary | `0` | DCDU 1 key BRT (momentary: 1 while held) |
| `mip.dcdu1.key.dim` | bool | pushbutton | momentary | `0` | DCDU 1 key DIM (momentary: 1 while held) |
| `mip.dcdu1.key.lsk1l` | bool | pushbutton | momentary | `0` | DCDU 1 key LSK1L (momentary: 1 while held) |
| `mip.dcdu1.key.lsk1r` | bool | pushbutton | momentary | `0` | DCDU 1 key LSK1R (momentary: 1 while held) |
| `mip.dcdu1.key.lsk2l` | bool | pushbutton | momentary | `0` | DCDU 1 key LSK2L (momentary: 1 while held) |
| `mip.dcdu1.key.lsk2r` | bool | pushbutton | momentary | `0` | DCDU 1 key LSK2R (momentary: 1 while held) |
| `mip.dcdu1.key.msgMinus` | bool | pushbutton | momentary | `0` | DCDU 1 key MSGMINUS (momentary: 1 while held) |
| `mip.dcdu1.key.msgPlus` | bool | pushbutton | momentary | `0` | DCDU 1 key MSGPLUS (momentary: 1 while held) |
| `mip.dcdu1.key.pgeMinus` | bool | pushbutton | momentary | `0` | DCDU 1 key PGEMINUS (momentary: 1 while held) |
| `mip.dcdu1.key.pgePlus` | bool | pushbutton | momentary | `0` | DCDU 1 key PGEPLUS (momentary: 1 while held) |
| `mip.dcdu1.key.print` | bool | pushbutton | momentary | `0` | DCDU 1 key PRINT (momentary: 1 while held) |
| `mip.dcdu1.line01.color` | string | output | read | `""` | DCDU 1 screen line 1: one color letter per character (W C G A M Y R), upper case large, lower case small |
| `mip.dcdu1.line01.reverse` | string | output | read | `""` | DCDU 1 screen line 1: 'R' under the characters shown in reverse video (filled box of their color, black text) |
| `mip.dcdu1.line01.text` | string | output | read | `""` | DCDU 1 screen line 1: its 30 monospace characters (blank while dark), for hardware that shows text |
| `mip.dcdu1.line02.color` | string | output | read | `""` | DCDU 1 screen line 2: one color letter per character (W C G A M Y R), upper case large, lower case small |
| `mip.dcdu1.line02.reverse` | string | output | read | `""` | DCDU 1 screen line 2: 'R' under the characters shown in reverse video (filled box of their color, black text) |
| `mip.dcdu1.line02.text` | string | output | read | `""` | DCDU 1 screen line 2: its 30 monospace characters (blank while dark), for hardware that shows text |
| `mip.dcdu1.line03.color` | string | output | read | `""` | DCDU 1 screen line 3: one color letter per character (W C G A M Y R), upper case large, lower case small |
| `mip.dcdu1.line03.reverse` | string | output | read | `""` | DCDU 1 screen line 3: 'R' under the characters shown in reverse video (filled box of their color, black text) |
| `mip.dcdu1.line03.text` | string | output | read | `""` | DCDU 1 screen line 3: its 30 monospace characters (blank while dark), for hardware that shows text |
| `mip.dcdu1.line04.color` | string | output | read | `""` | DCDU 1 screen line 4: one color letter per character (W C G A M Y R), upper case large, lower case small |
| `mip.dcdu1.line04.reverse` | string | output | read | `""` | DCDU 1 screen line 4: 'R' under the characters shown in reverse video (filled box of their color, black text) |
| `mip.dcdu1.line04.text` | string | output | read | `""` | DCDU 1 screen line 4: its 30 monospace characters (blank while dark), for hardware that shows text |
| `mip.dcdu1.line05.color` | string | output | read | `""` | DCDU 1 screen line 5: one color letter per character (W C G A M Y R), upper case large, lower case small |
| `mip.dcdu1.line05.reverse` | string | output | read | `""` | DCDU 1 screen line 5: 'R' under the characters shown in reverse video (filled box of their color, black text) |
| `mip.dcdu1.line05.text` | string | output | read | `""` | DCDU 1 screen line 5: its 30 monospace characters (blank while dark), for hardware that shows text |
| `mip.dcdu1.line06.color` | string | output | read | `""` | DCDU 1 screen line 6: one color letter per character (W C G A M Y R), upper case large, lower case small |
| `mip.dcdu1.line06.reverse` | string | output | read | `""` | DCDU 1 screen line 6: 'R' under the characters shown in reverse video (filled box of their color, black text) |
| `mip.dcdu1.line06.text` | string | output | read | `""` | DCDU 1 screen line 6: its 30 monospace characters (blank while dark), for hardware that shows text |
| `mip.dcdu1.line07.color` | string | output | read | `""` | DCDU 1 screen line 7: one color letter per character (W C G A M Y R), upper case large, lower case small |
| `mip.dcdu1.line07.reverse` | string | output | read | `""` | DCDU 1 screen line 7: 'R' under the characters shown in reverse video (filled box of their color, black text) |
| `mip.dcdu1.line07.text` | string | output | read | `""` | DCDU 1 screen line 7: its 30 monospace characters (blank while dark), for hardware that shows text |
| `mip.dcdu1.line08.color` | string | output | read | `""` | DCDU 1 screen line 8: one color letter per character (W C G A M Y R), upper case large, lower case small |
| `mip.dcdu1.line08.reverse` | string | output | read | `""` | DCDU 1 screen line 8: 'R' under the characters shown in reverse video (filled box of their color, black text) |
| `mip.dcdu1.line08.text` | string | output | read | `""` | DCDU 1 screen line 8: its 30 monospace characters (blank while dark), for hardware that shows text |
| `mip.dcdu1.line09.color` | string | output | read | `""` | DCDU 1 screen line 9: one color letter per character (W C G A M Y R), upper case large, lower case small |
| `mip.dcdu1.line09.reverse` | string | output | read | `""` | DCDU 1 screen line 9: 'R' under the characters shown in reverse video (filled box of their color, black text) |
| `mip.dcdu1.line09.text` | string | output | read | `""` | DCDU 1 screen line 9: its 30 monospace characters (blank while dark), for hardware that shows text |

## Main instrument panel / DCDU 2

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `mip.dcdu2.brightness` | float | output | read | `0` | DCDU 2 screen brightness (0 = dark) |
| `mip.dcdu2.key.brt` | bool | pushbutton | momentary | `0` | DCDU 2 key BRT (momentary: 1 while held) |
| `mip.dcdu2.key.dim` | bool | pushbutton | momentary | `0` | DCDU 2 key DIM (momentary: 1 while held) |
| `mip.dcdu2.key.lsk1l` | bool | pushbutton | momentary | `0` | DCDU 2 key LSK1L (momentary: 1 while held) |
| `mip.dcdu2.key.lsk1r` | bool | pushbutton | momentary | `0` | DCDU 2 key LSK1R (momentary: 1 while held) |
| `mip.dcdu2.key.lsk2l` | bool | pushbutton | momentary | `0` | DCDU 2 key LSK2L (momentary: 1 while held) |
| `mip.dcdu2.key.lsk2r` | bool | pushbutton | momentary | `0` | DCDU 2 key LSK2R (momentary: 1 while held) |
| `mip.dcdu2.key.msgMinus` | bool | pushbutton | momentary | `0` | DCDU 2 key MSGMINUS (momentary: 1 while held) |
| `mip.dcdu2.key.msgPlus` | bool | pushbutton | momentary | `0` | DCDU 2 key MSGPLUS (momentary: 1 while held) |
| `mip.dcdu2.key.pgeMinus` | bool | pushbutton | momentary | `0` | DCDU 2 key PGEMINUS (momentary: 1 while held) |
| `mip.dcdu2.key.pgePlus` | bool | pushbutton | momentary | `0` | DCDU 2 key PGEPLUS (momentary: 1 while held) |
| `mip.dcdu2.key.print` | bool | pushbutton | momentary | `0` | DCDU 2 key PRINT (momentary: 1 while held) |
| `mip.dcdu2.line01.color` | string | output | read | `""` | DCDU 2 screen line 1: one color letter per character (W C G A M Y R), upper case large, lower case small |
| `mip.dcdu2.line01.reverse` | string | output | read | `""` | DCDU 2 screen line 1: 'R' under the characters shown in reverse video (filled box of their color, black text) |
| `mip.dcdu2.line01.text` | string | output | read | `""` | DCDU 2 screen line 1: its 30 monospace characters (blank while dark), for hardware that shows text |
| `mip.dcdu2.line02.color` | string | output | read | `""` | DCDU 2 screen line 2: one color letter per character (W C G A M Y R), upper case large, lower case small |
| `mip.dcdu2.line02.reverse` | string | output | read | `""` | DCDU 2 screen line 2: 'R' under the characters shown in reverse video (filled box of their color, black text) |
| `mip.dcdu2.line02.text` | string | output | read | `""` | DCDU 2 screen line 2: its 30 monospace characters (blank while dark), for hardware that shows text |
| `mip.dcdu2.line03.color` | string | output | read | `""` | DCDU 2 screen line 3: one color letter per character (W C G A M Y R), upper case large, lower case small |
| `mip.dcdu2.line03.reverse` | string | output | read | `""` | DCDU 2 screen line 3: 'R' under the characters shown in reverse video (filled box of their color, black text) |
| `mip.dcdu2.line03.text` | string | output | read | `""` | DCDU 2 screen line 3: its 30 monospace characters (blank while dark), for hardware that shows text |
| `mip.dcdu2.line04.color` | string | output | read | `""` | DCDU 2 screen line 4: one color letter per character (W C G A M Y R), upper case large, lower case small |
| `mip.dcdu2.line04.reverse` | string | output | read | `""` | DCDU 2 screen line 4: 'R' under the characters shown in reverse video (filled box of their color, black text) |
| `mip.dcdu2.line04.text` | string | output | read | `""` | DCDU 2 screen line 4: its 30 monospace characters (blank while dark), for hardware that shows text |
| `mip.dcdu2.line05.color` | string | output | read | `""` | DCDU 2 screen line 5: one color letter per character (W C G A M Y R), upper case large, lower case small |
| `mip.dcdu2.line05.reverse` | string | output | read | `""` | DCDU 2 screen line 5: 'R' under the characters shown in reverse video (filled box of their color, black text) |
| `mip.dcdu2.line05.text` | string | output | read | `""` | DCDU 2 screen line 5: its 30 monospace characters (blank while dark), for hardware that shows text |
| `mip.dcdu2.line06.color` | string | output | read | `""` | DCDU 2 screen line 6: one color letter per character (W C G A M Y R), upper case large, lower case small |
| `mip.dcdu2.line06.reverse` | string | output | read | `""` | DCDU 2 screen line 6: 'R' under the characters shown in reverse video (filled box of their color, black text) |
| `mip.dcdu2.line06.text` | string | output | read | `""` | DCDU 2 screen line 6: its 30 monospace characters (blank while dark), for hardware that shows text |
| `mip.dcdu2.line07.color` | string | output | read | `""` | DCDU 2 screen line 7: one color letter per character (W C G A M Y R), upper case large, lower case small |
| `mip.dcdu2.line07.reverse` | string | output | read | `""` | DCDU 2 screen line 7: 'R' under the characters shown in reverse video (filled box of their color, black text) |
| `mip.dcdu2.line07.text` | string | output | read | `""` | DCDU 2 screen line 7: its 30 monospace characters (blank while dark), for hardware that shows text |
| `mip.dcdu2.line08.color` | string | output | read | `""` | DCDU 2 screen line 8: one color letter per character (W C G A M Y R), upper case large, lower case small |
| `mip.dcdu2.line08.reverse` | string | output | read | `""` | DCDU 2 screen line 8: 'R' under the characters shown in reverse video (filled box of their color, black text) |
| `mip.dcdu2.line08.text` | string | output | read | `""` | DCDU 2 screen line 8: its 30 monospace characters (blank while dark), for hardware that shows text |
| `mip.dcdu2.line09.color` | string | output | read | `""` | DCDU 2 screen line 9: one color letter per character (W C G A M Y R), upper case large, lower case small |
| `mip.dcdu2.line09.reverse` | string | output | read | `""` | DCDU 2 screen line 9: 'R' under the characters shown in reverse video (filled box of their color, black text) |
| `mip.dcdu2.line09.text` | string | output | read | `""` | DCDU 2 screen line 9: its 30 monospace characters (blank while dark), for hardware that shows text |

## MIP / CAPT

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `mip.capt.consoleFloorLt` | int | switch | write | `0` | Captain CONSOLE/FLOOR switch (0 = OFF, 1 = DIM, 2 = BRT) |
| `mip.capt.gpws.gpws` | bool | light | read | `0` | Captain GPWS GPWS light |
| `mip.capt.gpws.pressed` | bool | pushbutton | momentary | `0` | Captain GPWS pushbutton (momentary: 1 while held) |
| `mip.capt.gpws.pullUp` | bool | light | read | `0` | Captain GPWS PULLUP light |
| `mip.capt.ndBrt` | float | analog | write | `0` | Captain ND OFF/BRT knob (0 = OFF, 1 = full bright) |
| `mip.capt.ndImageBrt` | float | analog | write | `0` | Captain ND knob outer ring: WX / terrain image brightness (0 = image dark, 1 = full bright) |
| `mip.capt.pfdBrt` | float | analog | write | `0` | Captain PFD OFF/BRT knob (0 = OFF, 1 = full bright) |
| `mip.capt.pfdNdXfr.pressed` | bool | pushbutton | momentary | `0` | Captain PFD/ND XFR pushbutton (momentary: 1 while held) |

## MIP / CAPT TERR ON ND 403VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `mip.capt.terrOnNd.on` | bool | light | read | `0` | Captain TERR ON ND ON light |
| `mip.capt.terrOnNd.pressed` | bool | pushbutton | momentary | `0` | Captain TERR ON ND pushbutton (momentary: 1 while held) |

## MIP / CLOCK 400VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `mip.clock.chr.pressed` | bool | pushbutton | momentary | `0` | CHR pushbutton (momentary: 1 while held) |
| `mip.clock.chrono` | string | light | read | `"05:21"` | CHR counter minutes:seconds "05:21" ("" reset) |
| `mip.clock.dateSet.pressed` | bool | pushbutton | momentary | `0` | DATE/SET (push) pushbutton (momentary: 1 while held) |
| `mip.clock.et` | string | light | read | `"01:12"` | ET counter hours:minutes "01:12" ("" blank) |
| `mip.clock.etSelector` | int | rotary | write | `0` | ET selector (0 = RUN, 1 = STP, 2 = RST spring-loaded: write 1 again on release) |
| `mip.clock.rst.pressed` | bool | pushbutton | momentary | `0` | RST pushbutton (momentary: 1 while held) |
| `mip.clock.setKnob` | int | encoder | write | `0` | DATE/SET knob rotation counter (+1 per clockwise detent) |
| `mip.clock.utc` | string | light | read | `"14:32"` | UTC counter hours and minutes: "14:32", date "1105" (month, day), "--:--" without GPS, "" dark; a blank field flashes in SET |
| `mip.clock.utcSeconds` | string | light | read | `"07"` | UTC counter seconds "07", or the year "26" in date mode |
| `mip.clock.utcSelector` | int | rotary | write | `0` | UTC selector (0 = GPS, 1 = INT, 2 = SET) |

## MIP / DDRMI

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `mip.ddrmi.selector1` | int | rotary | write | `0` | DDRMI VOR/ADF selector of the single dotted bar pointer (0 = VOR 1, 1 = ADF 1; ignored on a VOR-only DDRMI) |
| `mip.ddrmi.selector2` | int | rotary | write | `0` | DDRMI VOR/ADF selector of the double bar pointer (0 = VOR 2, 1 = ADF 2; ignored on a VOR-only DDRMI) |

## MIP / F/O

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `mip.fo.consoleFloorLt` | int | switch | write | `0` | First officer CONSOLE/FLOOR switch (0 = OFF, 1 = DIM, 2 = BRT) |
| `mip.fo.gpws.gpws` | bool | light | read | `0` | First officer GPWS GPWS light |
| `mip.fo.gpws.pressed` | bool | pushbutton | momentary | `0` | First officer GPWS pushbutton (momentary: 1 while held) |
| `mip.fo.gpws.pullUp` | bool | light | read | `0` | First officer GPWS PULLUP light |
| `mip.fo.ndBrt` | float | analog | write | `0` | First officer ND OFF/BRT knob (0 = OFF, 1 = full bright) |
| `mip.fo.ndImageBrt` | float | analog | write | `0` | First officer ND knob outer ring: WX / terrain image brightness (0 = image dark, 1 = full bright) |
| `mip.fo.pfdBrt` | float | analog | write | `0` | First officer PFD OFF/BRT knob (0 = OFF, 1 = full bright) |
| `mip.fo.pfdNdXfr.pressed` | bool | pushbutton | momentary | `0` | First officer PFD/ND XFR pushbutton (momentary: 1 while held) |

## MIP / ISIS

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `mip.isis.baroKnob` | int | encoder | write | `0` | ISIS BARO knob rotation counter (+1 per clockwise click) |
| `mip.isis.baroPush` | bool | pushbutton | momentary | `0` | ISIS BARO knob push (STD / bug on-off) |
| `mip.isis.key.attRst` | bool | pushbutton | momentary | `0` | ISIS ATT RST (hold > 2 s) pushbutton |
| `mip.isis.key.bugs` | bool | pushbutton | momentary | `0` | ISIS BUGS pushbutton |
| `mip.isis.key.ls` | bool | pushbutton | momentary | `0` | ISIS LS pushbutton |
| `mip.isis.key.minus` | bool | pushbutton | momentary | `0` | ISIS - (brightness / bug selection) pushbutton |
| `mip.isis.key.plus` | bool | pushbutton | momentary | `0` | ISIS + (brightness / bug selection) pushbutton |

## MIP / L/G lever, BRAKES indicator 400VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `mip.brakes.accuPress` | float | light | read | `0` | Triple indicator ACCU PRESS needle (psi) |
| `mip.brakes.leftPress` | float | light | read | `0` | Triple indicator BRAKES left needle (psi) |
| `mip.brakes.rightPress` | float | light | read | `0` | Triple indicator BRAKES right needle (psi) |
| `mip.gear.lever` | bool | switch | write | `0` | L/G lever (0 = UP, 1 = DOWN; locked DOWN on ground) |
| `mip.gear.leverSolenoid` | bool | output | read | `0` | L/G lever lock solenoid engaged: lever locked DOWN (either main gear compressed, DSC-32-10-40 B) |
| `mip.gear.redArrow` | bool | light | read | `0` | L/G lever red arrow (gear not down in landing configuration) |

## MIP / LDG GEAR, AUTO BRK 402VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `mip.autoBrk.lo.decel` | bool | light | read | `0` | AUTO/BRK LO DECEL light |
| `mip.autoBrk.lo.on` | bool | light | read | `0` | AUTO/BRK LO ON light |
| `mip.autoBrk.lo.pressed` | bool | pushbutton | momentary | `0` | AUTO/BRK LO pushbutton (momentary: 1 while held) |
| `mip.autoBrk.max.decel` | bool | light | read | `0` | AUTO/BRK MAX DECEL light |
| `mip.autoBrk.max.on` | bool | light | read | `0` | AUTO/BRK MAX ON light |
| `mip.autoBrk.max.pressed` | bool | pushbutton | momentary | `0` | AUTO/BRK MAX pushbutton (momentary: 1 while held) |
| `mip.autoBrk.med.decel` | bool | light | read | `0` | AUTO/BRK MED DECEL light |
| `mip.autoBrk.med.on` | bool | light | read | `0` | AUTO/BRK MED ON light |
| `mip.autoBrk.med.pressed` | bool | pushbutton | momentary | `0` | AUTO/BRK MED pushbutton (momentary: 1 while held) |
| `mip.brakes.antiSkidNwStrg` | bool | switch | write | `0` | A/SKID & N/W STRG switch (1 = ON) |
| `mip.brkFan.hot` | bool | light | read | `0` | BRK FAN HOT light |
| `mip.brkFan.on` | bool | light | read | `0` | BRK FAN ON light |
| `mip.brkFan.pressed` | bool | pushbutton | write | `0` | BRK FAN pushbutton (1 = in) |
| `mip.fo.terrOnNd.on` | bool | light | read | `0` | First officer TERR ON ND ON light |
| `mip.fo.terrOnNd.pressed` | bool | pushbutton | momentary | `0` | First officer TERR ON ND pushbutton (momentary: 1 while held) |
| `mip.ldgGear.left.down` | bool | light | read | `0` | LDG GEAR left green triangle (down and locked) |
| `mip.ldgGear.left.unlk` | bool | light | read | `0` | LDG GEAR left UNLK light (red) |
| `mip.ldgGear.nose.down` | bool | light | read | `0` | LDG GEAR nose green triangle (down and locked) |
| `mip.ldgGear.nose.unlk` | bool | light | read | `0` | LDG GEAR nose UNLK light (red) |
| `mip.ldgGear.right.down` | bool | light | read | `0` | LDG GEAR right green triangle (down and locked) |
| `mip.ldgGear.right.unlk` | bool | light | read | `0` | LDG GEAR right UNLK light (red) |

## MIP / Loudspeakers

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `mip.loudspeaker.capt` | float | analog | write | `0` | Captain LOUDSPEAKER volume knob (0 = OFF .. 1 = full); the selected receptions (radio, navaids, INT), never the aural alerts |
| `mip.loudspeaker.fo` | float | analog | write | `0` | F/O LOUDSPEAKER volume knob (0 = OFF .. 1 = full); the selected receptions (radio, navaids, INT), never the aural alerts |

## Overhead / 21VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `overhead.rainRplnt.capt.pressed` | bool | pushbutton | momentary | `0` | RAIN RPLNT pushbutton |
| `overhead.wiper.capt` | int | rotary | write | `0` | WIPER selector (0 OFF, 1 SLOW, 2 FAST) |

## Overhead / 22VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `overhead.rainRplnt.fo.pressed` | bool | pushbutton | momentary | `0` | RAIN RPLNT pushbutton |
| `overhead.wiper.fo` | int | rotary | write | `0` | WIPER selector (0 OFF, 1 SLOW, 2 FAST) |

## Overhead / ADIRS 41VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `overhead.adirs.adr1.fault` | bool | light | read | `0` | ADR 1 FAULT light |
| `overhead.adirs.adr1.off` | bool | light | read | `0` | ADR 1 OFF light |
| `overhead.adirs.adr1.pressed` | bool | pushbutton | momentary | `0` | ADR 1 pushbutton (momentary: 1 while held) |
| `overhead.adirs.adr2.fault` | bool | light | read | `0` | ADR 2 FAULT light |
| `overhead.adirs.adr2.off` | bool | light | read | `0` | ADR 2 OFF light |
| `overhead.adirs.adr2.pressed` | bool | pushbutton | momentary | `0` | ADR 2 pushbutton (momentary: 1 while held) |
| `overhead.adirs.adr3.fault` | bool | light | read | `0` | ADR 3 FAULT light |
| `overhead.adirs.adr3.off` | bool | light | read | `0` | ADR 3 OFF light |
| `overhead.adirs.adr3.pressed` | bool | pushbutton | momentary | `0` | ADR 3 pushbutton (momentary: 1 while held) |
| `overhead.adirs.ir1.align` | bool | light | read | `0` | IR 1 ALIGN light (white, the panel with the ADIRS CDU only): steady while aligning (and the 30 s ATT erection), flashing on an alignment problem, off when aligned |
| `overhead.adirs.ir1.fault` | bool | light | read | `0` | IR 1 FAULT light |
| `overhead.adirs.ir1.off` | bool | light | read | `0` | IR 1 OFF light |
| `overhead.adirs.ir1.pressed` | bool | pushbutton | momentary | `0` | IR 1 pushbutton (momentary: 1 while held) |
| `overhead.adirs.ir1Mode` | int | rotary | write | `0` | IR 1 mode selector (0 = OFF, 1 = NAV, 2 = ATT) |
| `overhead.adirs.ir2.align` | bool | light | read | `0` | IR 2 ALIGN light (white, the panel with the ADIRS CDU only): steady while aligning (and the 30 s ATT erection), flashing on an alignment problem, off when aligned |
| `overhead.adirs.ir2.fault` | bool | light | read | `0` | IR 2 FAULT light |
| `overhead.adirs.ir2.off` | bool | light | read | `0` | IR 2 OFF light |
| `overhead.adirs.ir2.pressed` | bool | pushbutton | momentary | `0` | IR 2 pushbutton (momentary: 1 while held) |
| `overhead.adirs.ir2Mode` | int | rotary | write | `0` | IR 2 mode selector (0 = OFF, 1 = NAV, 2 = ATT) |
| `overhead.adirs.ir3.align` | bool | light | read | `0` | IR 3 ALIGN light (white, the panel with the ADIRS CDU only): steady while aligning (and the 30 s ATT erection), flashing on an alignment problem, off when aligned |
| `overhead.adirs.ir3.fault` | bool | light | read | `0` | IR 3 FAULT light |
| `overhead.adirs.ir3.off` | bool | light | read | `0` | IR 3 OFF light |
| `overhead.adirs.ir3.pressed` | bool | pushbutton | momentary | `0` | IR 3 pushbutton (momentary: 1 while held) |
| `overhead.adirs.ir3Mode` | int | rotary | write | `0` | IR 3 mode selector (0 = OFF, 1 = NAV, 2 = ATT) |
| `overhead.adirs.onBat` | bool | light | read | `0` | ON BAT light (amber) |

## Overhead / ADIRS CDU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `overhead.adirs.cdu.clrLight` | bool | light | read | `0` | ADIRS CDU CLR key cue light: the value entered is unreasonable (clear it and key it again); TEST |
| `overhead.adirs.cdu.dataSelector` | int | rotary | write | `2` | ADIRS CDU DATA selector: 0 TEST, 1 TK/GS, 2 PPOS, 3 WIND, 4 HDG, 5 STS (clockwise on the knob: WIND, PPOS, HDG, STS, TK/GS, TEST) |
| `overhead.adirs.cdu.display` | string | output | read | `"N 43\u00b037.3  E  1\u00b022.5"` | ADIRS CDU display, 16 cells as shown: a '°' after a cell is its degree marker, a '.' its decimal point ("N 43°37.3  E  1°22.5"); "" dark (SYS OFF, unpowered, the panel without CDU) |
| `overhead.adirs.cdu.entLight` | bool | light | read | `0` | ADIRS CDU ENT key cue light: a complete value keyed in (N, S, E, W or heading), ready to be entered; TEST |
| `overhead.adirs.cdu.key.0` | bool | pushbutton | momentary | `0` | ADIRS CDU key 0 (momentary: 1 while held) |
| `overhead.adirs.cdu.key.1` | bool | pushbutton | momentary | `0` | ADIRS CDU key 1 (momentary: 1 while held) |
| `overhead.adirs.cdu.key.2` | bool | pushbutton | momentary | `0` | ADIRS CDU key 2 / N (momentary: 1 while held) |
| `overhead.adirs.cdu.key.3` | bool | pushbutton | momentary | `0` | ADIRS CDU key 3 (momentary: 1 while held) |
| `overhead.adirs.cdu.key.4` | bool | pushbutton | momentary | `0` | ADIRS CDU key 4 / W (momentary: 1 while held) |
| `overhead.adirs.cdu.key.5` | bool | pushbutton | momentary | `0` | ADIRS CDU key 5 (momentary: 1 while held) |
| `overhead.adirs.cdu.key.6` | bool | pushbutton | momentary | `0` | ADIRS CDU key 6 / E (momentary: 1 while held) |
| `overhead.adirs.cdu.key.7` | bool | pushbutton | momentary | `0` | ADIRS CDU key 7 (momentary: 1 while held) |
| `overhead.adirs.cdu.key.8` | bool | pushbutton | momentary | `0` | ADIRS CDU key 8 / S (momentary: 1 while held) |
| `overhead.adirs.cdu.key.9` | bool | pushbutton | momentary | `0` | ADIRS CDU key 9 (momentary: 1 while held) |
| `overhead.adirs.cdu.key.clr` | bool | pushbutton | momentary | `0` | ADIRS CDU CLR key: clears the data keyed in but not yet entered (momentary: 1 while held) |
| `overhead.adirs.cdu.key.ent` | bool | pushbutton | momentary | `0` | ADIRS CDU ENT key: enters the keyed data into the ADIRS (momentary: 1 while held) |
| `overhead.adirs.cdu.left` | string | output | read | `""` | ADIRS CDU display, left field (cells 0-7, markers as in overhead.adirs.cdu.display): latitude, track, wind direction, heading |
| `overhead.adirs.cdu.powered` | bool | output | read | `0` | ADIRS CDU display energized (CDU fitted, SYS selector not OFF, an ADIRU energized) |
| `overhead.adirs.cdu.right` | string | output | read | `""` | ADIRS CDU display, right field (cells 8-15, markers as in overhead.adirs.cdu.display): longitude, ground speed, wind speed, minutes to NAV |
| `overhead.adirs.cdu.sysSelector` | int | rotary | write | `1` | ADIRS CDU SYS selector: 0 OFF (display not energized), 1 / 2 / 3 the ADIRU displayed and keyed into (clockwise on the knob: OFF, 1, 3, 2) |

## Overhead / AIR COND 30VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `overhead.airCond.aftCabinTemp` | float | analog | write | `0` | AFT CABIN zone temperature selector (°C, 18 to 30) |
| `overhead.airCond.apuBleed.fault` | bool | light | read | `0` | APU BLEED FAULT light |
| `overhead.airCond.apuBleed.on` | bool | light | read | `0` | APU BLEED ON light |
| `overhead.airCond.apuBleed.pressed` | bool | pushbutton | write | `0` | APU BLEED pushbutton (1 = in) |
| `overhead.airCond.cockpitTemp` | float | analog | write | `0` | COCKPIT zone temperature selector (°C, 18 COLD to 30 HOT, 24 at 12 o'clock) |
| `overhead.airCond.eng1Bleed.fault` | bool | light | read | `0` | ENG 1 BLEED FAULT light |
| `overhead.airCond.eng1Bleed.off` | bool | light | read | `0` | ENG 1 BLEED OFF light |
| `overhead.airCond.eng1Bleed.pressed` | bool | pushbutton | write | `0` | ENG 1 BLEED pushbutton (1 = in) |
| `overhead.airCond.eng2Bleed.fault` | bool | light | read | `0` | ENG 2 BLEED FAULT light |
| `overhead.airCond.eng2Bleed.off` | bool | light | read | `0` | ENG 2 BLEED OFF light |
| `overhead.airCond.eng2Bleed.pressed` | bool | pushbutton | write | `0` | ENG 2 BLEED pushbutton (1 = in) |
| `overhead.airCond.fwdCabinTemp` | float | analog | write | `0` | FWD CABIN zone temperature selector (°C, 18 to 30) |
| `overhead.airCond.hotAir.fault` | bool | light | read | `0` | HOT AIR FAULT light |
| `overhead.airCond.hotAir.off` | bool | light | read | `0` | HOT AIR OFF light |
| `overhead.airCond.hotAir.pressed` | bool | pushbutton | write | `0` | HOT AIR pushbutton (1 = in) |
| `overhead.airCond.pack1.fault` | bool | light | read | `0` | PACK 1 FAULT light |
| `overhead.airCond.pack1.off` | bool | light | read | `0` | PACK 1 OFF light |
| `overhead.airCond.pack1.pressed` | bool | pushbutton | write | `0` | PACK 1 pushbutton (1 = in) |
| `overhead.airCond.pack2.fault` | bool | light | read | `0` | PACK 2 FAULT light |
| `overhead.airCond.pack2.off` | bool | light | read | `0` | PACK 2 OFF light |
| `overhead.airCond.pack2.pressed` | bool | pushbutton | write | `0` | PACK 2 pushbutton (1 = in) |
| `overhead.airCond.packFlow` | int | rotary | write | `0` | PACK FLOW selector (0 = LO, 1 = NORM, 2 = HI) |
| `overhead.airCond.ramAir.on` | bool | light | read | `0` | RAM AIR ON light |
| `overhead.airCond.ramAir.pressed` | bool | pushbutton | write | `0` | RAM AIR pushbutton (1 = in) |
| `overhead.airCond.xBleed` | int | rotary | write | `0` | X BLEED selector (0 = SHUT, 1 = AUTO, 2 = OPEN) |

## Overhead / ANTI ICE 25VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `overhead.antiIce.eng1.fault` | bool | light | read | `0` | ENG 1 ANTI ICE FAULT light |
| `overhead.antiIce.eng1.on` | bool | light | read | `0` | ENG 1 ANTI ICE ON light |
| `overhead.antiIce.eng1.pressed` | bool | pushbutton | write | `0` | ENG 1 ANTI ICE pushbutton (1 = in) |
| `overhead.antiIce.eng2.fault` | bool | light | read | `0` | ENG 2 ANTI ICE FAULT light |
| `overhead.antiIce.eng2.on` | bool | light | read | `0` | ENG 2 ANTI ICE ON light |
| `overhead.antiIce.eng2.pressed` | bool | pushbutton | write | `0` | ENG 2 ANTI ICE pushbutton (1 = in) |
| `overhead.antiIce.wing.fault` | bool | light | read | `0` | WING ANTI ICE FAULT light |
| `overhead.antiIce.wing.on` | bool | light | read | `0` | WING ANTI ICE ON light |
| `overhead.antiIce.wing.pressed` | bool | pushbutton | write | `0` | WING ANTI ICE pushbutton (1 = in) |
| `overhead.probeHeat.on` | bool | light | read | `0` | PROBE/WINDOW HEAT ON light |
| `overhead.probeHeat.pressed` | bool | pushbutton | write | `0` | PROBE/WINDOW HEAT pushbutton (1 = in) |

## Overhead / APU 25VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `overhead.apu.master.fault` | bool | light | read | `0` | APU MASTER SW FAULT light |
| `overhead.apu.master.on` | bool | light | read | `0` | APU MASTER SW ON light |
| `overhead.apu.master.pressed` | bool | pushbutton | write | `0` | APU MASTER SW pushbutton (1 = in) |
| `overhead.apu.start.avail` | bool | light | read | `0` | APU START AVAIL light |
| `overhead.apu.start.on` | bool | light | read | `0` | APU START ON light |
| `overhead.apu.start.pressed` | bool | pushbutton | momentary | `0` | APU START pushbutton (momentary: 1 while held) |

## Overhead / CABIN PRESS 25VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `overhead.press.ditching.on` | bool | light | read | `0` | DITCHING ON light |
| `overhead.press.ditching.pressed` | bool | pushbutton | write | `0` | DITCHING pushbutton (1 = in) |
| `overhead.press.ldgElev` | float | rotary | write | `0` | LDG ELEV selector (ft, -2000 to 14000; -3000 = AUTO detent) |
| `overhead.press.manVsCtl` | int | switch | write | `0` | MAN V/S CTL toggle (0 = DN, 1 = neutral, 2 = UP; spring-loaded: write 1 again on release) |
| `overhead.press.modeSel.fault` | bool | light | read | `0` | MODE SEL FAULT light |
| `overhead.press.modeSel.man` | bool | light | read | `0` | MODE SEL MAN light |
| `overhead.press.modeSel.pressed` | bool | pushbutton | write | `0` | MODE SEL pushbutton (1 = in) |

## Overhead / CALLS 21VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `overhead.calls.aft.pressed` | bool | pushbutton | momentary | `0` | AFT pushbutton (momentary: 1 while held) |
| `overhead.calls.all.pressed` | bool | pushbutton | momentary | `0` | ALL pushbutton (momentary: 1 while held) |
| `overhead.calls.emer.call` | bool | light | read | `0` | EMER CALL light |
| `overhead.calls.emer.on` | bool | light | read | `0` | EMER ON light |
| `overhead.calls.emer.pressed` | bool | pushbutton | momentary | `0` | EMER pushbutton (momentary: 1 while held) |
| `overhead.calls.fwd.pressed` | bool | pushbutton | momentary | `0` | FWD pushbutton (momentary: 1 while held) |
| `overhead.calls.mech.pressed` | bool | pushbutton | momentary | `0` | MECH pushbutton (momentary: 1 while held) |

## Overhead / CARGO HEAT and cargo ventilation (option)

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `overhead.cargo.aftIsolValve.fault` | bool | light | read | `0` | AFT ISOL VALVE FAULT light |
| `overhead.cargo.aftIsolValve.off` | bool | light | read | `0` | AFT ISOL VALVE OFF light |
| `overhead.cargo.aftIsolValve.pressed` | bool | pushbutton | write | `0` | AFT ISOL VALVE pushbutton (1 = in) |
| `overhead.cargo.aftTemp` | float | analog | write | `0` | AFT cargo temperature selector (°C, 5 COLD to 26 HOT) |
| `overhead.cargo.fwdIsolValve.fault` | bool | light | read | `0` | FWD ISOL VALVE FAULT light |
| `overhead.cargo.fwdIsolValve.off` | bool | light | read | `0` | FWD ISOL VALVE OFF light |
| `overhead.cargo.fwdIsolValve.pressed` | bool | pushbutton | write | `0` | FWD ISOL VALVE pushbutton (1 = in) |
| `overhead.cargo.fwdTemp` | float | analog | write | `0` | FWD cargo temperature selector (°C, 5 COLD to 26 HOT) |
| `overhead.cargo.hotAir.fault` | bool | light | read | `0` | CARGO HOT AIR FAULT light |
| `overhead.cargo.hotAir.off` | bool | light | read | `0` | CARGO HOT AIR OFF light |
| `overhead.cargo.hotAir.pressed` | bool | pushbutton | write | `0` | CARGO HOT AIR pushbutton (1 = in) |

## Overhead / CARGO SMOKE 22VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `overhead.cargoSmoke.aft.disch` | bool | light | read | `0` | CARGO SMOKE AFT DISCH light |
| `overhead.cargoSmoke.aft.smoke` | bool | light | read | `0` | CARGO SMOKE AFT SMOKE light |
| `overhead.cargoSmoke.aftDisch.pressed` | bool | pushbutton | momentary | `0` | CARGO SMOKE AFT DISCH pushbutton (momentary: 1 while held) |
| `overhead.cargoSmoke.fwd.disch` | bool | light | read | `0` | CARGO SMOKE FWD DISCH light |
| `overhead.cargoSmoke.fwd.smoke` | bool | light | read | `0` | CARGO SMOKE FWD SMOKE light |
| `overhead.cargoSmoke.fwdDisch.pressed` | bool | pushbutton | momentary | `0` | CARGO SMOKE FWD DISCH pushbutton (momentary: 1 while held) |
| `overhead.cargoSmoke.test.pressed` | bool | pushbutton | momentary | `0` | CARGO SMOKE TEST pushbutton (momentary: 1 while held) |

## Overhead / CKPT DOOR CONT

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `overhead.ckptDoorCont.chan1` | bool | light | read | `0` | CKPT DOOR CONT CHAN 1 pressure sensor status light (faulty) |
| `overhead.ckptDoorCont.chan2` | bool | light | read | `0` | CKPT DOOR CONT CHAN 2 pressure sensor status light (faulty) |
| `overhead.ckptDoorCont.strikeBot` | bool | light | read | `0` | CKPT DOOR CONT STRIKE BOT status light (latch faulty) |
| `overhead.ckptDoorCont.strikeMid` | bool | light | read | `0` | CKPT DOOR CONT STRIKE MID status light (latch faulty) |
| `overhead.ckptDoorCont.strikeTop` | bool | light | read | `0` | CKPT DOOR CONT STRIKE TOP status light (latch faulty) |

## Overhead / COCKPIT DOOR VIDEO 27VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `overhead.ckptDoorVideo.off` | bool | light | read | `0` | COCKPIT DOOR VIDEO OFF light |
| `overhead.ckptDoorVideo.pressed` | bool | pushbutton | write | `0` | COCKPIT DOOR VIDEO pushbutton (1 = in) |

## Overhead / ELEC 35VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `overhead.elec.acEssFeed.altn` | bool | light | read | `0` | AC ESS FEED ALTN light |
| `overhead.elec.acEssFeed.fault` | bool | light | read | `0` | AC ESS FEED FAULT light |
| `overhead.elec.acEssFeed.pressed` | bool | pushbutton | write | `0` | AC ESS FEED pushbutton (1 = in) |
| `overhead.elec.apuGen.fault` | bool | light | read | `0` | APU GEN FAULT light |
| `overhead.elec.apuGen.off` | bool | light | read | `0` | APU GEN OFF light |
| `overhead.elec.apuGen.pressed` | bool | pushbutton | write | `0` | APU GEN pushbutton (1 = in) |
| `overhead.elec.bat1.fault` | bool | light | read | `0` | BAT 1 FAULT light |
| `overhead.elec.bat1.off` | bool | light | read | `0` | BAT 1 OFF light |
| `overhead.elec.bat1.pressed` | bool | pushbutton | write | `0` | BAT 1 pushbutton (1 = in) |
| `overhead.elec.bat1Voltmeter` | float | light | read | `0` | BAT 1 voltmeter (V, 0.1 resolution) |
| `overhead.elec.bat2.fault` | bool | light | read | `0` | BAT 2 FAULT light |
| `overhead.elec.bat2.off` | bool | light | read | `0` | BAT 2 OFF light |
| `overhead.elec.bat2.pressed` | bool | pushbutton | write | `0` | BAT 2 pushbutton (1 = in) |
| `overhead.elec.bat2Voltmeter` | float | light | read | `0` | BAT 2 voltmeter (V, 0.1 resolution) |
| `overhead.elec.busTie.off` | bool | light | read | `0` | BUS TIE OFF light |
| `overhead.elec.busTie.pressed` | bool | pushbutton | write | `0` | BUS TIE pushbutton (1 = in) |
| `overhead.elec.commercial.off` | bool | light | read | `0` | COMMERCIAL OFF light |
| `overhead.elec.commercial.pressed` | bool | pushbutton | write | `0` | COMMERCIAL pushbutton (1 = in) |
| `overhead.elec.extPwr.avail` | bool | light | read | `0` | EXT PWR AVAIL light |
| `overhead.elec.extPwr.on` | bool | light | read | `0` | EXT PWR ON light |
| `overhead.elec.extPwr.pressed` | bool | pushbutton | momentary | `0` | EXT PWR pushbutton (momentary: 1 while held) |
| `overhead.elec.galyCab.fault` | bool | light | read | `0` | GALY & CAB FAULT light |
| `overhead.elec.galyCab.off` | bool | light | read | `0` | GALY & CAB OFF light |
| `overhead.elec.galyCab.pressed` | bool | pushbutton | write | `0` | GALY & CAB pushbutton (1 = in) |
| `overhead.elec.gen1.fault` | bool | light | read | `0` | GEN 1 FAULT light |
| `overhead.elec.gen1.off` | bool | light | read | `0` | GEN 1 OFF light |
| `overhead.elec.gen1.pressed` | bool | pushbutton | write | `0` | GEN 1 pushbutton (1 = in) |
| `overhead.elec.gen2.fault` | bool | light | read | `0` | GEN 2 FAULT light |
| `overhead.elec.gen2.off` | bool | light | read | `0` | GEN 2 OFF light |
| `overhead.elec.gen2.pressed` | bool | pushbutton | write | `0` | GEN 2 pushbutton (1 = in) |
| `overhead.elec.idg1.fault` | bool | light | read | `0` | IDG 1 FAULT light |
| `overhead.elec.idg1.pressed` | bool | pushbutton | momentary | `0` | IDG 1 pushbutton (momentary: 1 while held) |
| `overhead.elec.idg2.fault` | bool | light | read | `0` | IDG 2 FAULT light |
| `overhead.elec.idg2.pressed` | bool | pushbutton | momentary | `0` | IDG 2 pushbutton (momentary: 1 while held) |

## Overhead / EMER ELEC PWR

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `overhead.emerElecPwr.emerGenTest.pressed` | bool | pushbutton | momentary | `0` | EMER GEN TEST pushbutton (momentary: 1 while held) |
| `overhead.emerElecPwr.gen1Line.off` | bool | light | read | `0` | GEN 1 LINE OFF light |
| `overhead.emerElecPwr.gen1Line.pressed` | bool | pushbutton | write | `0` | GEN 1 LINE pushbutton (1 = in) |
| `overhead.emerElecPwr.gen1Line.smoke` | bool | light | read | `0` | GEN 1 LINE SMOKE light |
| `overhead.emerElecPwr.manOn.pressed` | bool | pushbutton | momentary | `0` | MAN ON pushbutton (momentary: 1 while held) |
| `overhead.emerElecPwr.ratAndEmerGen.fault` | bool | light | read | `0` | RAT & EMER GEN FAULT light |

## Overhead / ENG 22VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `overhead.eng.manStart1.on` | bool | light | read | `0` | ENG 1 MAN START ON light |
| `overhead.eng.manStart1.pressed` | bool | pushbutton | write | `0` | ENG 1 MAN START pushbutton (1 = in) |
| `overhead.eng.manStart2.on` | bool | light | read | `0` | ENG 2 MAN START ON light |
| `overhead.eng.manStart2.pressed` | bool | pushbutton | write | `0` | ENG 2 MAN START pushbutton (1 = in) |
| `overhead.eng.n1Mode1.on` | bool | light | read | `0` | ENG 1 N1 MODE ON light |
| `overhead.eng.n1Mode1.pressed` | bool | pushbutton | write | `0` | ENG 1 N1 MODE pushbutton (1 = in) |
| `overhead.eng.n1Mode2.on` | bool | light | read | `0` | ENG 2 N1 MODE ON light |
| `overhead.eng.n1Mode2.pressed` | bool | pushbutton | write | `0` | ENG 2 N1 MODE pushbutton (1 = in) |

## Overhead / EVAC 21VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `overhead.evac.captPurs` | int | switch | write | `0` | EVAC CAPT & PURS / CAPT selector (0 CAPT: cockpit only, 1 CAPT & PURS: cockpit or cabin) |
| `overhead.evac.command.evac` | bool | light | read | `0` | EVAC COMMAND EVAC light |
| `overhead.evac.command.on` | bool | light | read | `0` | EVAC COMMAND ON light |
| `overhead.evac.command.pressed` | bool | pushbutton | write | `0` | EVAC COMMAND pushbutton (1 = in) |
| `overhead.evac.hornShutOff.pressed` | bool | pushbutton | momentary | `0` | HORN SHUT OFF pushbutton (momentary: 1 while held) |

## Overhead / EXT LT 25VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `overhead.extLt.beacon` | bool | switch | write | `0` | BEACON switch (1 = ON) |
| `overhead.extLt.landL` | int | switch | write | `0` | LAND L selector (0 = RETRACT, 1 = OFF, 2 = ON) |
| `overhead.extLt.landR` | int | switch | write | `0` | LAND R selector (0 = RETRACT, 1 = OFF, 2 = ON) |
| `overhead.extLt.navLogo` | int | switch | write | `0` | NAV & LOGO switch (0 = OFF, 1 = 1, 2 = 2) |
| `overhead.extLt.nose` | int | switch | write | `0` | NOSE switch (0 = OFF, 1 = TAXI, 2 = T.O) |
| `overhead.extLt.rwyTurnOff` | bool | switch | write | `0` | RWY TURN OFF switch (1 = ON) |
| `overhead.extLt.strobe` | int | switch | write | `0` | STROBE switch (0 = OFF, 1 = AUTO, 2 = ON) |
| `overhead.extLt.wing` | bool | switch | write | `0` | WING switch (1 = ON) |

## Overhead / FIRE 20VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `overhead.fire.apu.fire` | bool | light | read | `0` | APU FIRE FIRE light |
| `overhead.fire.apu.pressed` | bool | pushbutton | write | `0` | APU FIRE pushbutton (1 = in) |
| `overhead.fire.apuAgent.disch` | bool | light | read | `0` | APU AGENT DISCH light |
| `overhead.fire.apuAgent.pressed` | bool | pushbutton | momentary | `0` | APU AGENT pushbutton (momentary: 1 while held) |
| `overhead.fire.apuAgent.squib` | bool | light | read | `0` | APU AGENT SQUIB light |
| `overhead.fire.apuTest.pressed` | bool | pushbutton | momentary | `0` | APU FIRE TEST pushbutton (momentary: 1 while held) |
| `overhead.fire.eng1.fire` | bool | light | read | `0` | ENG 1 FIRE FIRE light |
| `overhead.fire.eng1.pressed` | bool | pushbutton | write | `0` | ENG 1 FIRE pushbutton (1 = in) |
| `overhead.fire.eng1Agent1.disch` | bool | light | read | `0` | ENG 1 AGENT 1 DISCH light |
| `overhead.fire.eng1Agent1.pressed` | bool | pushbutton | momentary | `0` | ENG 1 AGENT 1 pushbutton (momentary: 1 while held) |
| `overhead.fire.eng1Agent1.squib` | bool | light | read | `0` | ENG 1 AGENT 1 SQUIB light |
| `overhead.fire.eng1Agent2.disch` | bool | light | read | `0` | ENG 1 AGENT 2 DISCH light |
| `overhead.fire.eng1Agent2.pressed` | bool | pushbutton | momentary | `0` | ENG 1 AGENT 2 pushbutton (momentary: 1 while held) |
| `overhead.fire.eng1Agent2.squib` | bool | light | read | `0` | ENG 1 AGENT 2 SQUIB light |
| `overhead.fire.eng1Test.pressed` | bool | pushbutton | momentary | `0` | ENG 1 FIRE TEST pushbutton (momentary: 1 while held) |
| `overhead.fire.eng2.fire` | bool | light | read | `0` | ENG 2 FIRE FIRE light |
| `overhead.fire.eng2.pressed` | bool | pushbutton | write | `0` | ENG 2 FIRE pushbutton (1 = in) |
| `overhead.fire.eng2Agent1.disch` | bool | light | read | `0` | ENG 2 AGENT 1 DISCH light |
| `overhead.fire.eng2Agent1.pressed` | bool | pushbutton | momentary | `0` | ENG 2 AGENT 1 pushbutton (momentary: 1 while held) |
| `overhead.fire.eng2Agent1.squib` | bool | light | read | `0` | ENG 2 AGENT 1 SQUIB light |
| `overhead.fire.eng2Agent2.disch` | bool | light | read | `0` | ENG 2 AGENT 2 DISCH light |
| `overhead.fire.eng2Agent2.pressed` | bool | pushbutton | momentary | `0` | ENG 2 AGENT 2 pushbutton (momentary: 1 while held) |
| `overhead.fire.eng2Agent2.squib` | bool | light | read | `0` | ENG 2 AGENT 2 SQUIB light |
| `overhead.fire.eng2Test.pressed` | bool | pushbutton | momentary | `0` | ENG 2 FIRE TEST pushbutton (momentary: 1 while held) |

## Overhead / FLT CTL 23VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `overhead.fltCtl.elac1.fault` | bool | light | read | `0` | ELAC 1 FAULT light |
| `overhead.fltCtl.elac1.off` | bool | light | read | `0` | ELAC 1 OFF light |
| `overhead.fltCtl.elac1.pressed` | bool | pushbutton | write | `0` | ELAC 1 pushbutton (1 = in) |
| `overhead.fltCtl.fac1.fault` | bool | light | read | `0` | FAC 1 FAULT light |
| `overhead.fltCtl.fac1.off` | bool | light | read | `0` | FAC 1 OFF light |
| `overhead.fltCtl.fac1.pressed` | bool | pushbutton | write | `0` | FAC 1 pushbutton (1 = in) |
| `overhead.fltCtl.sec1.fault` | bool | light | read | `0` | SEC 1 FAULT light |
| `overhead.fltCtl.sec1.off` | bool | light | read | `0` | SEC 1 OFF light |
| `overhead.fltCtl.sec1.pressed` | bool | pushbutton | write | `0` | SEC 1 pushbutton (1 = in) |

## Overhead / FLT CTL 24VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `overhead.fltCtl.elac2.fault` | bool | light | read | `0` | ELAC 2 FAULT light |
| `overhead.fltCtl.elac2.off` | bool | light | read | `0` | ELAC 2 OFF light |
| `overhead.fltCtl.elac2.pressed` | bool | pushbutton | write | `0` | ELAC 2 pushbutton (1 = in) |
| `overhead.fltCtl.fac2.fault` | bool | light | read | `0` | FAC 2 FAULT light |
| `overhead.fltCtl.fac2.off` | bool | light | read | `0` | FAC 2 OFF light |
| `overhead.fltCtl.fac2.pressed` | bool | pushbutton | write | `0` | FAC 2 pushbutton (1 = in) |
| `overhead.fltCtl.sec2.fault` | bool | light | read | `0` | SEC 2 FAULT light |
| `overhead.fltCtl.sec2.off` | bool | light | read | `0` | SEC 2 OFF light |
| `overhead.fltCtl.sec2.pressed` | bool | pushbutton | write | `0` | SEC 2 pushbutton (1 = in) |
| `overhead.fltCtl.sec3.fault` | bool | light | read | `0` | SEC 3 FAULT light |
| `overhead.fltCtl.sec3.off` | bool | light | read | `0` | SEC 3 OFF light |
| `overhead.fltCtl.sec3.pressed` | bool | pushbutton | write | `0` | SEC 3 pushbutton (1 = in) |

## Overhead / FUEL 40VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `overhead.fuel.ctrTkPump1.fault` | bool | light | read | `0` | CTR TK PUMP 1 FAULT light |
| `overhead.fuel.ctrTkPump1.off` | bool | light | read | `0` | CTR TK PUMP 1 OFF light |
| `overhead.fuel.ctrTkPump1.pressed` | bool | pushbutton | write | `0` | CTR TK PUMP 1 pushbutton (1 = in) |
| `overhead.fuel.ctrTkPump2.fault` | bool | light | read | `0` | CTR TK PUMP 2 FAULT light |
| `overhead.fuel.ctrTkPump2.off` | bool | light | read | `0` | CTR TK PUMP 2 OFF light |
| `overhead.fuel.ctrTkPump2.pressed` | bool | pushbutton | write | `0` | CTR TK PUMP 2 pushbutton (1 = in) |
| `overhead.fuel.lTkPump1.fault` | bool | light | read | `0` | L TK PUMP 1 FAULT light |
| `overhead.fuel.lTkPump1.off` | bool | light | read | `0` | L TK PUMP 1 OFF light |
| `overhead.fuel.lTkPump1.pressed` | bool | pushbutton | write | `0` | L TK PUMP 1 pushbutton (1 = in) |
| `overhead.fuel.lTkPump2.fault` | bool | light | read | `0` | L TK PUMP 2 FAULT light |
| `overhead.fuel.lTkPump2.off` | bool | light | read | `0` | L TK PUMP 2 OFF light |
| `overhead.fuel.lTkPump2.pressed` | bool | pushbutton | write | `0` | L TK PUMP 2 pushbutton (1 = in) |
| `overhead.fuel.modeSel.fault` | bool | light | read | `0` | FUEL MODE SEL FAULT light |
| `overhead.fuel.modeSel.man` | bool | light | read | `0` | FUEL MODE SEL MAN light |
| `overhead.fuel.modeSel.pressed` | bool | pushbutton | write | `0` | FUEL MODE SEL pushbutton (1 = in) |
| `overhead.fuel.rTkPump1.fault` | bool | light | read | `0` | R TK PUMP 1 FAULT light |
| `overhead.fuel.rTkPump1.off` | bool | light | read | `0` | R TK PUMP 1 OFF light |
| `overhead.fuel.rTkPump1.pressed` | bool | pushbutton | write | `0` | R TK PUMP 1 pushbutton (1 = in) |
| `overhead.fuel.rTkPump2.fault` | bool | light | read | `0` | R TK PUMP 2 FAULT light |
| `overhead.fuel.rTkPump2.off` | bool | light | read | `0` | R TK PUMP 2 OFF light |
| `overhead.fuel.rTkPump2.pressed` | bool | pushbutton | write | `0` | R TK PUMP 2 pushbutton (1 = in) |
| `overhead.fuel.xFeed.on` | bool | light | read | `0` | FUEL X FEED ON light |
| `overhead.fuel.xFeed.open` | bool | light | read | `0` | FUEL X FEED OPEN light |
| `overhead.fuel.xFeed.pressed` | bool | pushbutton | write | `0` | FUEL X FEED pushbutton (1 = in) |

## Overhead / GPWS 21VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `overhead.gpws.flapMode.off` | bool | light | read | `0` | GPWS FLAP MODE OFF light |
| `overhead.gpws.flapMode.pressed` | bool | pushbutton | write | `0` | GPWS FLAP MODE pushbutton (1 = in) |
| `overhead.gpws.gsMode.off` | bool | light | read | `0` | GPWS G/S MODE OFF light |
| `overhead.gpws.gsMode.pressed` | bool | pushbutton | write | `0` | GPWS G/S MODE pushbutton (1 = in) |
| `overhead.gpws.ldgFlap3.on` | bool | light | read | `0` | GPWS LDG FLAP 3 ON light |
| `overhead.gpws.ldgFlap3.pressed` | bool | pushbutton | write | `0` | GPWS LDG FLAP 3 pushbutton (1 = in) |
| `overhead.gpws.sys.fault` | bool | light | read | `0` | GPWS SYS FAULT light |
| `overhead.gpws.sys.off` | bool | light | read | `0` | GPWS SYS OFF light |
| `overhead.gpws.sys.pressed` | bool | pushbutton | write | `0` | GPWS SYS pushbutton (1 = in) |
| `overhead.gpws.terr.fault` | bool | light | read | `0` | GPWS TERR FAULT light |
| `overhead.gpws.terr.off` | bool | light | read | `0` | GPWS TERR OFF light |
| `overhead.gpws.terr.pressed` | bool | pushbutton | write | `0` | GPWS TERR pushbutton (1 = in) |

## Overhead / HYD 40VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `overhead.hyd.blueElecPump.fault` | bool | light | read | `0` | BLUE ELEC PUMP FAULT light |
| `overhead.hyd.blueElecPump.off` | bool | light | read | `0` | BLUE ELEC PUMP OFF light |
| `overhead.hyd.blueElecPump.pressed` | bool | pushbutton | write | `0` | BLUE ELEC PUMP pushbutton (1 = in) |
| `overhead.hyd.eng1Pump.fault` | bool | light | read | `0` | ENG 1 PUMP FAULT light |
| `overhead.hyd.eng1Pump.off` | bool | light | read | `0` | ENG 1 PUMP OFF light |
| `overhead.hyd.eng1Pump.pressed` | bool | pushbutton | write | `0` | ENG 1 PUMP pushbutton (1 = in) |
| `overhead.hyd.eng2Pump.fault` | bool | light | read | `0` | ENG 2 PUMP FAULT light |
| `overhead.hyd.eng2Pump.off` | bool | light | read | `0` | ENG 2 PUMP OFF light |
| `overhead.hyd.eng2Pump.pressed` | bool | pushbutton | write | `0` | ENG 2 PUMP pushbutton (1 = in) |
| `overhead.hyd.ptu.fault` | bool | light | read | `0` | PTU FAULT light |
| `overhead.hyd.ptu.off` | bool | light | read | `0` | PTU OFF light |
| `overhead.hyd.ptu.pressed` | bool | pushbutton | write | `0` | PTU pushbutton (1 = in) |
| `overhead.hyd.ratManOn.pressed` | bool | pushbutton | momentary | `0` | RAT MAN ON pushbutton (momentary: 1 while held) |
| `overhead.hyd.yellowElecPump.fault` | bool | light | read | `0` | YELLOW ELEC PUMP FAULT light |
| `overhead.hyd.yellowElecPump.on` | bool | light | read | `0` | YELLOW ELEC PUMP ON light |
| `overhead.hyd.yellowElecPump.pressed` | bool | pushbutton | momentary | `0` | YELLOW ELEC PUMP pushbutton (momentary: 1 while held) |

## Overhead / INT LT 25VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `overhead.intLt.annLt` | int | switch | write | `0` | ANN LT switch (0 = DIM, 1 = BRT, 2 = TEST) |
| `overhead.intLt.dome` | int | switch | write | `0` | DOME switch (0 = OFF, 1 = DIM, 2 = BRT) |
| `overhead.intLt.iceIndStbyCompass` | bool | switch | write | `0` | ICE IND & STBY COMPASS switch (1 = ON) |
| `overhead.intLt.ovhdIntegLt` | float | analog | write | `0` | OVHD INTEG LT knob (0 = OFF .. 1 = BRT) |

## Overhead / MAINT 50VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `overhead.maint.apuExtReset.pressed` | bool | pushbutton | momentary | `0` | APU AUTO EXTING RESET pushbutton (momentary: 1 while held) |
| `overhead.maint.apuExtTest.ok` | bool | light | read | `0` | APU AUTO EXTING TEST OK light |
| `overhead.maint.apuExtTest.on` | bool | light | read | `0` | APU AUTO EXTING TEST ON light |
| `overhead.maint.apuExtTest.pressed` | bool | pushbutton | write | `0` | APU AUTO EXTING TEST pushbutton (1 = in) |
| `overhead.maint.avionicsComptLt.on` | bool | light | read | `0` | AVIONICS COMPT LT ON light |
| `overhead.maint.avionicsComptLt.pressed` | bool | pushbutton | write | `0` | AVIONICS COMPT LT pushbutton (1 = in) |
| `overhead.maint.bluePumpOvrd.on` | bool | light | read | `0` | BLUE PUMP OVRD ON light |
| `overhead.maint.bluePumpOvrd.pressed` | bool | pushbutton | write | `0` | BLUE PUMP OVRD pushbutton (1 = in) |
| `overhead.maint.fadecGndPwr1.on` | bool | light | read | `0` | ENG 1 FADEC GND PWR ON light |
| `overhead.maint.fadecGndPwr1.pressed` | bool | pushbutton | write | `0` | ENG 1 FADEC GND PWR pushbutton (1 = in) |
| `overhead.maint.fadecGndPwr2.on` | bool | light | read | `0` | ENG 2 FADEC GND PWR ON light |
| `overhead.maint.fadecGndPwr2.pressed` | bool | pushbutton | write | `0` | ENG 2 FADEC GND PWR pushbutton (1 = in) |
| `overhead.maint.leakMeasurementB.off` | bool | light | read | `0` | LEAK MEAS B OFF light |
| `overhead.maint.leakMeasurementB.pressed` | bool | pushbutton | write | `0` | LEAK MEAS B pushbutton (1 = in) |
| `overhead.maint.leakMeasurementG.off` | bool | light | read | `0` | LEAK MEAS G OFF light |
| `overhead.maint.leakMeasurementG.pressed` | bool | pushbutton | write | `0` | LEAK MEAS G pushbutton (1 = in) |
| `overhead.maint.leakMeasurementY.off` | bool | light | read | `0` | LEAK MEAS Y OFF light |
| `overhead.maint.leakMeasurementY.pressed` | bool | pushbutton | write | `0` | LEAK MEAS Y pushbutton (1 = in) |
| `overhead.maint.oxyTmrReset.fault` | bool | light | read | `0` | OXYGEN TMR RESET FAULT light |
| `overhead.maint.oxyTmrReset.on` | bool | light | read | `0` | OXYGEN TMR RESET ON light |
| `overhead.maint.oxyTmrReset.pressed` | bool | pushbutton | momentary | `0` | OXYGEN TMR RESET pushbutton (momentary: 1 while held) |
| `overhead.maint.svceIntOvrd.on` | bool | light | read | `0` | SVCE INT OVRD ON light |
| `overhead.maint.svceIntOvrd.pressed` | bool | pushbutton | write | `0` | SVCE INT OVRD pushbutton (1 = in) |

## Overhead / OXYGEN 21VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `overhead.oxygen.crewSupply.off` | bool | light | read | `0` | OXYGEN CREW SUPPLY OFF light |
| `overhead.oxygen.crewSupply.pressed` | bool | pushbutton | write | `0` | OXYGEN CREW SUPPLY pushbutton (1 = in) |
| `overhead.oxygen.highAltLanding.on` | bool | light | read | `0` | HIGH ALT LANDING ON light |
| `overhead.oxygen.highAltLanding.pressed` | bool | pushbutton | write | `0` | HIGH ALT LANDING pushbutton (1 = in) |
| `overhead.oxygen.maskManOn.pressed` | bool | pushbutton | momentary | `0` | MASK MAN ON pushbutton (momentary: 1 while held) |
| `overhead.oxygen.passenger.sysOn` | bool | light | read | `0` | PASSENGER SYS ON SYSON light |

## Overhead / RCDR 21VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `overhead.rcdr.cvrErase.pressed` | bool | pushbutton | momentary | `0` | CVR ERASE pushbutton (momentary; held 2 s on the ground with the parking brake on) |
| `overhead.rcdr.cvrTest.pressed` | bool | pushbutton | momentary | `0` | CVR TEST pushbutton (momentary; held: test tone with the CVR on and the parking brake on) |
| `overhead.rcdr.gndCtl.on` | bool | light | read | `0` | RCDR GND CTL blue ON light |
| `overhead.rcdr.gndCtl.pressed` | bool | pushbutton | write | `0` | RCDR GND CTL pb-sw (1 = ON: recorders started on the ground; reverts to 0 = AUTO after engine start or a supply loss) |

## Overhead / READING LT

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `overhead.intLt.readingLtCapt` | float | analog | write | `0` | Captain READING LT knob (0 = OFF .. 1 = BRT) |
| `overhead.intLt.readingLtFo` | float | analog | write | `0` | First officer READING LT knob (0 = OFF .. 1 = BRT) |

## Overhead / RMP 3

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `pedestal.rmp3.active` | string | light | read | `"122.800"` | RMP 3 ACTIVE window ("122.800", "110.30", "415", "" dark) |
| `pedestal.rmp3.adf.on` | bool | light | read | `0` | RMP 3 ADF green light |
| `pedestal.rmp3.adf.pressed` | bool | pushbutton | momentary | `0` | RMP 3 ADF key (momentary) |
| `pedestal.rmp3.am.on` | bool | light | read | `0` | RMP 3 AM green light |
| `pedestal.rmp3.am.pressed` | bool | pushbutton | momentary | `0` | RMP 3 AM key (momentary) |
| `pedestal.rmp3.bfo.on` | bool | light | read | `0` | RMP 3 BFO green light |
| `pedestal.rmp3.bfo.pressed` | bool | pushbutton | momentary | `0` | RMP 3 BFO key (momentary) |
| `pedestal.rmp3.hf1.on` | bool | light | read | `0` | RMP 3 HF 1 green light |
| `pedestal.rmp3.hf1.pressed` | bool | pushbutton | momentary | `0` | RMP 3 HF 1 key (momentary) |
| `pedestal.rmp3.hf2.on` | bool | light | read | `0` | RMP 3 HF 2 green light |
| `pedestal.rmp3.hf2.pressed` | bool | pushbutton | momentary | `0` | RMP 3 HF 2 key (momentary) |
| `pedestal.rmp3.ils.on` | bool | light | read | `0` | RMP 3 ILS green light |
| `pedestal.rmp3.ils.pressed` | bool | pushbutton | momentary | `0` | RMP 3 ILS key (momentary) |
| `pedestal.rmp3.innerKnob` | int | encoder | write | `0` | RMP 3 inner tuning knob counter (+1 per clockwise detent) |
| `pedestal.rmp3.mls.on` | bool | light | read | `0` | RMP 3 MLS green light |
| `pedestal.rmp3.mls.pressed` | bool | pushbutton | momentary | `0` | RMP 3 MLS key (momentary) |
| `pedestal.rmp3.nav.on` | bool | light | read | `0` | RMP 3 NAV (guarded) green light |
| `pedestal.rmp3.nav.pressed` | bool | pushbutton | momentary | `0` | RMP 3 NAV (guarded) key (momentary) |
| `pedestal.rmp3.outerKnob` | int | encoder | write | `0` | RMP 3 outer tuning knob counter (+1 per clockwise detent) |
| `pedestal.rmp3.power` | bool | switch | write | `0` | RMP 3 ON/OFF switch (1 = ON) |
| `pedestal.rmp3.sel` | bool | light | read | `0` | RMP 3 SEL amber light |
| `pedestal.rmp3.standby` | string | light | read | `"121.500"` | RMP 3 STBY/CRS window ("121.500", "C-123", "" dark) |
| `pedestal.rmp3.transfer.on` | bool | light | read | `0` | RMP 3 transfer green light |
| `pedestal.rmp3.transfer.pressed` | bool | pushbutton | momentary | `0` | RMP 3 transfer key (momentary) |
| `pedestal.rmp3.vhf1.on` | bool | light | read | `0` | RMP 3 VHF 1 green light |
| `pedestal.rmp3.vhf1.pressed` | bool | pushbutton | momentary | `0` | RMP 3 VHF 1 key (momentary) |
| `pedestal.rmp3.vhf2.on` | bool | light | read | `0` | RMP 3 VHF 2 green light |
| `pedestal.rmp3.vhf2.pressed` | bool | pushbutton | momentary | `0` | RMP 3 VHF 2 key (momentary) |
| `pedestal.rmp3.vhf3.on` | bool | light | read | `0` | RMP 3 VHF 3 green light |
| `pedestal.rmp3.vhf3.pressed` | bool | pushbutton | momentary | `0` | RMP 3 VHF 3 key (momentary) |
| `pedestal.rmp3.vor.on` | bool | light | read | `0` | RMP 3 VOR green light |
| `pedestal.rmp3.vor.pressed` | bool | pushbutton | momentary | `0` | RMP 3 VOR key (momentary) |

## Overhead / SIGNS 25VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `overhead.signs.emerExitLt` | int | switch | write | `0` | EMER EXIT LT selector (0 = OFF, 1 = ARM, 2 = ON) |
| `overhead.signs.emerExitLtOff` | bool | light | read | `0` | EMER EXIT LT OFF light (amber) |
| `overhead.signs.noSmoking` | int | switch | write | `0` | NO SMOKING switch (0 = OFF, 1 = AUTO, 2 = ON) |
| `overhead.signs.seatBelts` | int | switch | write | `0` | SEAT BELTS switch (0 = OFF, 1 = AUTO, 2 = ON; the photographed panel has OFF / ON only) |

## Overhead / VENTILATION 22VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `overhead.ventilation.blower.fault` | bool | light | read | `0` | BLOWER FAULT light |
| `overhead.ventilation.blower.ovrd` | bool | light | read | `0` | BLOWER OVRD light |
| `overhead.ventilation.blower.pressed` | bool | pushbutton | write | `0` | BLOWER pushbutton (1 = in) |
| `overhead.ventilation.cabFans.off` | bool | light | read | `0` | CAB FANS OFF light |
| `overhead.ventilation.cabFans.pressed` | bool | pushbutton | write | `0` | CAB FANS pushbutton (1 = in) |
| `overhead.ventilation.extract.fault` | bool | light | read | `0` | EXTRACT FAULT light |
| `overhead.ventilation.extract.ovrd` | bool | light | read | `0` | EXTRACT OVRD light |
| `overhead.ventilation.extract.pressed` | bool | pushbutton | write | `0` | EXTRACT pushbutton (1 = in) |

## Oxygen

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `oxygen.crewBottlePsi` | float | service | write | `0` | Crew oxygen cylinder pressure (psi, 0 to 1850: serviced on ground) |
| `oxygen.pax.generatorsUsed` | float | light | read | `0` | Passenger oxygen chemical generators fired (fraction 0..1, burning or exhausted) |
| `oxygen.pax.masksReleased` | float | light | read | `0` | Passenger oxygen mask containers open (fraction 0..1) |
| `oxygen.pax.oxygenMinutesLeft` | float | light | read | `0` | Passenger oxygen: minutes left of the generators burning (0: none) |
| `oxygen.pax.sysOn` | bool | light | read | `0` | Passenger oxygen control activated (SYS ON relay): masks released signal to the SDACs and the CIDS (PASS INFO: PA announcement, cabin lights) |

## Oxygen / crew mask stowage boxes

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `oxygen.mask.capt.blinker` | bool | output | read | `0` | Captain mask box blinker flowmeter yellow (oxygen flowing), black otherwise |
| `oxygen.mask.capt.emergency` | bool | pushbutton | momentary | `0` | Captain mask EMERGENCY pressure selector pressed (overpressure while held; momentary) |
| `oxygen.mask.capt.oxyOnFlag` | bool | output | read | `0` | Captain mask box OXY ON flag (mask stowed, flap closed, still supplied with oxygen) |
| `oxygen.mask.capt.pulled` | bool | switch | write | `0` | Captain oxygen mask out of its stowage box (red grips squeezed, left flap door open; 0 = stowed, flaps closed) |
| `oxygen.mask.capt.reset` | bool | pushbutton | momentary | `0` | Captain mask box RESET/TEST slide pressed (RESET: oxygen and mask microphone cut off; momentary) |
| `oxygen.mask.capt.supplied` | bool | output | read | `0` | Captain mask supplied with oxygen (from the flap opening until RESET; oxygen available on the low pressure circuit) |
| `oxygen.mask.capt.test` | bool | pushbutton | momentary | `0` | Captain mask box RESET/TEST slide pressed and pushed in the arrow direction (TEST; momentary: 1 while held) |
| `oxygen.mask.fo.blinker` | bool | output | read | `0` | First officer mask box blinker flowmeter yellow (oxygen flowing), black otherwise |
| `oxygen.mask.fo.emergency` | bool | pushbutton | momentary | `0` | First officer mask EMERGENCY pressure selector pressed (overpressure while held; momentary) |
| `oxygen.mask.fo.oxyOnFlag` | bool | output | read | `0` | First officer mask box OXY ON flag (mask stowed, flap closed, still supplied with oxygen) |
| `oxygen.mask.fo.pulled` | bool | switch | write | `0` | First officer oxygen mask out of its stowage box (red grips squeezed, left flap door open; 0 = stowed, flaps closed) |
| `oxygen.mask.fo.reset` | bool | pushbutton | momentary | `0` | First officer mask box RESET/TEST slide pressed (RESET: oxygen and mask microphone cut off; momentary) |
| `oxygen.mask.fo.supplied` | bool | output | read | `0` | First officer mask supplied with oxygen (from the flap opening until RESET; oxygen available on the low pressure circuit) |
| `oxygen.mask.fo.test` | bool | pushbutton | momentary | `0` | First officer mask box RESET/TEST slide pressed and pushed in the arrow direction (TEST; momentary: 1 while held) |
| `oxygen.mask.obs.blinker` | bool | output | read | `0` | Third occupant mask box blinker flowmeter yellow (oxygen flowing), black otherwise |
| `oxygen.mask.obs.emergency` | bool | pushbutton | momentary | `0` | Third occupant mask EMERGENCY pressure selector pressed (overpressure while held; momentary) |
| `oxygen.mask.obs.oxyOnFlag` | bool | output | read | `0` | Third occupant mask box OXY ON flag (mask stowed, flap closed, still supplied with oxygen) |
| `oxygen.mask.obs.pulled` | bool | switch | write | `0` | Third occupant oxygen mask out of its stowage box (red grips squeezed, left flap door open; 0 = stowed, flaps closed) |
| `oxygen.mask.obs.reset` | bool | pushbutton | momentary | `0` | Third occupant mask box RESET/TEST slide pressed (RESET: oxygen and mask microphone cut off; momentary) |
| `oxygen.mask.obs.supplied` | bool | output | read | `0` | Third occupant mask supplied with oxygen (from the flap opening until RESET; oxygen available on the low pressure circuit) |
| `oxygen.mask.obs.test` | bool | pushbutton | momentary | `0` | Third occupant mask box RESET/TEST slide pressed and pushed in the arrow direction (TEST; momentary: 1 while held) |

## Pedestal / 111VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `pedestal.intLt.floodLtMainPnl` | float | analog | write | `0` | FLOOD LT MAIN PNL knob (0 = OFF .. 1 = BRT) |
| `pedestal.intLt.integLtMainPnlPed` | float | analog | write | `0` | INTEG LT MAIN PNL & PED knob (0 = OFF .. 1 = BRT) |

## Pedestal / 112VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `pedestal.dfdr.event.pressed` | bool | pushbutton | momentary | `0` | DFDR EVENT pushbutton (momentary: an event mark on the flight data records) |
| `pedestal.intLt.floodLtPed` | float | analog | write | `0` | FLOOD LT PED knob (0 = OFF .. 1 = BRT) |

## Pedestal / ACP

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `pedestal.acp1.att` | bool | light | read | `0` | ACP 1 CAB key ATT legend (amber, flashing) |
| `pedestal.acp1.cab.on` | bool | light | read | `0` | ACP 1 CAB key three green lines |
| `pedestal.acp1.cab.pressed` | bool | pushbutton | momentary | `0` | ACP 1 CAB transmission key (momentary) |
| `pedestal.acp1.hf1.call` | bool | light | read | `0` | ACP 1 HF1 key CALL legend (amber, flashing: SELCAL) |
| `pedestal.acp1.hf1.on` | bool | light | read | `0` | ACP 1 HF1 key three green lines |
| `pedestal.acp1.hf1.pressed` | bool | pushbutton | momentary | `0` | ACP 1 HF1 transmission key (momentary) |
| `pedestal.acp1.hf2.call` | bool | light | read | `0` | ACP 1 HF2 key CALL legend (amber, flashing: SELCAL) |
| `pedestal.acp1.hf2.on` | bool | light | read | `0` | ACP 1 HF2 key three green lines |
| `pedestal.acp1.hf2.pressed` | bool | pushbutton | momentary | `0` | ACP 1 HF2 transmission key (momentary) |
| `pedestal.acp1.int.on` | bool | light | read | `0` | ACP 1 INT key three green lines |
| `pedestal.acp1.int.pressed` | bool | pushbutton | momentary | `0` | ACP 1 INT transmission key (momentary) |
| `pedestal.acp1.intRad` | int | switch | write | `0` | ACP 1 INT/RAD switch (-1 INT, 0 neutral, 1 RAD: press and hold) |
| `pedestal.acp1.mech` | bool | light | read | `0` | ACP 1 INT key MECH legend (amber, flashing) |
| `pedestal.acp1.pa.on` | bool | light | read | `0` | ACP 1 PA key three green lines |
| `pedestal.acp1.pa.pressed` | bool | pushbutton | momentary | `0` | ACP 1 PA key (press and hold) |
| `pedestal.acp1.reset` | bool | pushbutton | momentary | `0` | ACP 1 SELCAL/CALL RESET key |
| `pedestal.acp1.rx.adf1.light` | bool | light | read | `0` | ACP 1 ADF 1 reception knob integral white light (knob out) |
| `pedestal.acp1.rx.adf1.on` | bool | switch | write | `0` | ACP 1 ADF 1 reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp1.rx.adf1.volume` | float | analog | write | `0` | ACP 1 ADF 1 reception knob volume (0..1) |
| `pedestal.acp1.rx.adf2.light` | bool | light | read | `0` | ACP 1 ADF 2 reception knob integral white light (knob out) |
| `pedestal.acp1.rx.adf2.on` | bool | switch | write | `0` | ACP 1 ADF 2 reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp1.rx.adf2.volume` | float | analog | write | `0` | ACP 1 ADF 2 reception knob volume (0..1) |
| `pedestal.acp1.rx.cab.light` | bool | light | read | `0` | ACP 1 CAB reception knob integral white light (knob out) |
| `pedestal.acp1.rx.cab.on` | bool | switch | write | `0` | ACP 1 CAB reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp1.rx.cab.volume` | float | analog | write | `0` | ACP 1 CAB reception knob volume (0..1) |
| `pedestal.acp1.rx.hf1.light` | bool | light | read | `0` | ACP 1 HF 1 reception knob integral white light (knob out) |
| `pedestal.acp1.rx.hf1.on` | bool | switch | write | `0` | ACP 1 HF 1 reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp1.rx.hf1.volume` | float | analog | write | `0` | ACP 1 HF 1 reception knob volume (0..1) |
| `pedestal.acp1.rx.hf2.light` | bool | light | read | `0` | ACP 1 HF 2 reception knob integral white light (knob out) |
| `pedestal.acp1.rx.hf2.on` | bool | switch | write | `0` | ACP 1 HF 2 reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp1.rx.hf2.volume` | float | analog | write | `0` | ACP 1 HF 2 reception knob volume (0..1) |
| `pedestal.acp1.rx.int.light` | bool | light | read | `0` | ACP 1 INT reception knob integral white light (knob out) |
| `pedestal.acp1.rx.int.on` | bool | switch | write | `0` | ACP 1 INT reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp1.rx.int.volume` | float | analog | write | `0` | ACP 1 INT reception knob volume (0..1) |
| `pedestal.acp1.rx.ls.light` | bool | light | read | `0` | ACP 1 LS reception knob integral white light (knob out) |
| `pedestal.acp1.rx.ls.on` | bool | switch | write | `0` | ACP 1 LS reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp1.rx.ls.volume` | float | analog | write | `0` | ACP 1 LS reception knob volume (0..1) |
| `pedestal.acp1.rx.mkr.light` | bool | light | read | `0` | ACP 1 MKR reception knob integral white light (knob out) |
| `pedestal.acp1.rx.mkr.on` | bool | switch | write | `0` | ACP 1 MKR reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp1.rx.mkr.volume` | float | analog | write | `0` | ACP 1 MKR reception knob volume (0..1) |
| `pedestal.acp1.rx.mls.light` | bool | light | read | `0` | ACP 1 MLS reception knob integral white light (knob out) |
| `pedestal.acp1.rx.mls.on` | bool | switch | write | `0` | ACP 1 MLS reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp1.rx.mls.volume` | float | analog | write | `0` | ACP 1 MLS reception knob volume (0..1) |
| `pedestal.acp1.rx.pa.light` | bool | light | read | `0` | ACP 1 PA reception knob integral white light (knob out) |
| `pedestal.acp1.rx.pa.on` | bool | switch | write | `0` | ACP 1 PA reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp1.rx.pa.volume` | float | analog | write | `0` | ACP 1 PA reception knob volume (0..1) |
| `pedestal.acp1.rx.vhf1.light` | bool | light | read | `0` | ACP 1 VHF 1 reception knob integral white light (knob out) |
| `pedestal.acp1.rx.vhf1.on` | bool | switch | write | `0` | ACP 1 VHF 1 reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp1.rx.vhf1.volume` | float | analog | write | `0` | ACP 1 VHF 1 reception knob volume (0..1) |
| `pedestal.acp1.rx.vhf2.light` | bool | light | read | `0` | ACP 1 VHF 2 reception knob integral white light (knob out) |
| `pedestal.acp1.rx.vhf2.on` | bool | switch | write | `0` | ACP 1 VHF 2 reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp1.rx.vhf2.volume` | float | analog | write | `0` | ACP 1 VHF 2 reception knob volume (0..1) |
| `pedestal.acp1.rx.vhf3.light` | bool | light | read | `0` | ACP 1 VHF 3 reception knob integral white light (knob out) |
| `pedestal.acp1.rx.vhf3.on` | bool | switch | write | `0` | ACP 1 VHF 3 reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp1.rx.vhf3.volume` | float | analog | write | `0` | ACP 1 VHF 3 reception knob volume (0..1) |
| `pedestal.acp1.rx.vor1.light` | bool | light | read | `0` | ACP 1 VOR 1 reception knob integral white light (knob out) |
| `pedestal.acp1.rx.vor1.on` | bool | switch | write | `0` | ACP 1 VOR 1 reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp1.rx.vor1.volume` | float | analog | write | `0` | ACP 1 VOR 1 reception knob volume (0..1) |
| `pedestal.acp1.rx.vor2.light` | bool | light | read | `0` | ACP 1 VOR 2 reception knob integral white light (knob out) |
| `pedestal.acp1.rx.vor2.on` | bool | switch | write | `0` | ACP 1 VOR 2 reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp1.rx.vor2.volume` | float | analog | write | `0` | ACP 1 VOR 2 reception knob volume (0..1) |
| `pedestal.acp1.tx` | int | rotary | write | `0` | ACP 1 transmission key selected (0 none, 1..3 VHF 1..3, 4..5 HF 1..2 (not fitted), 6 INT, 7 CAB) |
| `pedestal.acp1.vhf1.call` | bool | light | read | `0` | ACP 1 VHF1 key CALL legend (amber, flashing: SELCAL) |
| `pedestal.acp1.vhf1.on` | bool | light | read | `0` | ACP 1 VHF1 key three green lines |
| `pedestal.acp1.vhf1.pressed` | bool | pushbutton | momentary | `0` | ACP 1 VHF1 transmission key (momentary) |
| `pedestal.acp1.vhf2.call` | bool | light | read | `0` | ACP 1 VHF2 key CALL legend (amber, flashing: SELCAL) |
| `pedestal.acp1.vhf2.on` | bool | light | read | `0` | ACP 1 VHF2 key three green lines |
| `pedestal.acp1.vhf2.pressed` | bool | pushbutton | momentary | `0` | ACP 1 VHF2 transmission key (momentary) |
| `pedestal.acp1.vhf3.call` | bool | light | read | `0` | ACP 1 VHF3 key CALL legend (amber, flashing: SELCAL) |
| `pedestal.acp1.vhf3.on` | bool | light | read | `0` | ACP 1 VHF3 key three green lines |
| `pedestal.acp1.vhf3.pressed` | bool | pushbutton | momentary | `0` | ACP 1 VHF3 transmission key (momentary) |
| `pedestal.acp1.voice.on` | bool | light | read | `0` | ACP 1 VOICE key green ON light |
| `pedestal.acp1.voice.pressed` | bool | pushbutton | write | `0` | ACP 1 VOICE key (alternate action: 1 = pressed in, navaid idents filtered) |
| `pedestal.acp2.att` | bool | light | read | `0` | ACP 2 CAB key ATT legend (amber, flashing) |
| `pedestal.acp2.cab.on` | bool | light | read | `0` | ACP 2 CAB key three green lines |
| `pedestal.acp2.cab.pressed` | bool | pushbutton | momentary | `0` | ACP 2 CAB transmission key (momentary) |
| `pedestal.acp2.hf1.call` | bool | light | read | `0` | ACP 2 HF1 key CALL legend (amber, flashing: SELCAL) |
| `pedestal.acp2.hf1.on` | bool | light | read | `0` | ACP 2 HF1 key three green lines |
| `pedestal.acp2.hf1.pressed` | bool | pushbutton | momentary | `0` | ACP 2 HF1 transmission key (momentary) |
| `pedestal.acp2.hf2.call` | bool | light | read | `0` | ACP 2 HF2 key CALL legend (amber, flashing: SELCAL) |
| `pedestal.acp2.hf2.on` | bool | light | read | `0` | ACP 2 HF2 key three green lines |
| `pedestal.acp2.hf2.pressed` | bool | pushbutton | momentary | `0` | ACP 2 HF2 transmission key (momentary) |
| `pedestal.acp2.int.on` | bool | light | read | `0` | ACP 2 INT key three green lines |
| `pedestal.acp2.int.pressed` | bool | pushbutton | momentary | `0` | ACP 2 INT transmission key (momentary) |
| `pedestal.acp2.intRad` | int | switch | write | `0` | ACP 2 INT/RAD switch (-1 INT, 0 neutral, 1 RAD: press and hold) |
| `pedestal.acp2.mech` | bool | light | read | `0` | ACP 2 INT key MECH legend (amber, flashing) |
| `pedestal.acp2.pa.on` | bool | light | read | `0` | ACP 2 PA key three green lines |
| `pedestal.acp2.pa.pressed` | bool | pushbutton | momentary | `0` | ACP 2 PA key (press and hold) |
| `pedestal.acp2.reset` | bool | pushbutton | momentary | `0` | ACP 2 SELCAL/CALL RESET key |
| `pedestal.acp2.rx.adf1.light` | bool | light | read | `0` | ACP 2 ADF 1 reception knob integral white light (knob out) |
| `pedestal.acp2.rx.adf1.on` | bool | switch | write | `0` | ACP 2 ADF 1 reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp2.rx.adf1.volume` | float | analog | write | `0` | ACP 2 ADF 1 reception knob volume (0..1) |
| `pedestal.acp2.rx.adf2.light` | bool | light | read | `0` | ACP 2 ADF 2 reception knob integral white light (knob out) |
| `pedestal.acp2.rx.adf2.on` | bool | switch | write | `0` | ACP 2 ADF 2 reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp2.rx.adf2.volume` | float | analog | write | `0` | ACP 2 ADF 2 reception knob volume (0..1) |
| `pedestal.acp2.rx.cab.light` | bool | light | read | `0` | ACP 2 CAB reception knob integral white light (knob out) |
| `pedestal.acp2.rx.cab.on` | bool | switch | write | `0` | ACP 2 CAB reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp2.rx.cab.volume` | float | analog | write | `0` | ACP 2 CAB reception knob volume (0..1) |
| `pedestal.acp2.rx.hf1.light` | bool | light | read | `0` | ACP 2 HF 1 reception knob integral white light (knob out) |
| `pedestal.acp2.rx.hf1.on` | bool | switch | write | `0` | ACP 2 HF 1 reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp2.rx.hf1.volume` | float | analog | write | `0` | ACP 2 HF 1 reception knob volume (0..1) |
| `pedestal.acp2.rx.hf2.light` | bool | light | read | `0` | ACP 2 HF 2 reception knob integral white light (knob out) |
| `pedestal.acp2.rx.hf2.on` | bool | switch | write | `0` | ACP 2 HF 2 reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp2.rx.hf2.volume` | float | analog | write | `0` | ACP 2 HF 2 reception knob volume (0..1) |
| `pedestal.acp2.rx.int.light` | bool | light | read | `0` | ACP 2 INT reception knob integral white light (knob out) |
| `pedestal.acp2.rx.int.on` | bool | switch | write | `0` | ACP 2 INT reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp2.rx.int.volume` | float | analog | write | `0` | ACP 2 INT reception knob volume (0..1) |
| `pedestal.acp2.rx.ls.light` | bool | light | read | `0` | ACP 2 LS reception knob integral white light (knob out) |
| `pedestal.acp2.rx.ls.on` | bool | switch | write | `0` | ACP 2 LS reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp2.rx.ls.volume` | float | analog | write | `0` | ACP 2 LS reception knob volume (0..1) |
| `pedestal.acp2.rx.mkr.light` | bool | light | read | `0` | ACP 2 MKR reception knob integral white light (knob out) |
| `pedestal.acp2.rx.mkr.on` | bool | switch | write | `0` | ACP 2 MKR reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp2.rx.mkr.volume` | float | analog | write | `0` | ACP 2 MKR reception knob volume (0..1) |
| `pedestal.acp2.rx.mls.light` | bool | light | read | `0` | ACP 2 MLS reception knob integral white light (knob out) |
| `pedestal.acp2.rx.mls.on` | bool | switch | write | `0` | ACP 2 MLS reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp2.rx.mls.volume` | float | analog | write | `0` | ACP 2 MLS reception knob volume (0..1) |
| `pedestal.acp2.rx.pa.light` | bool | light | read | `0` | ACP 2 PA reception knob integral white light (knob out) |
| `pedestal.acp2.rx.pa.on` | bool | switch | write | `0` | ACP 2 PA reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp2.rx.pa.volume` | float | analog | write | `0` | ACP 2 PA reception knob volume (0..1) |
| `pedestal.acp2.rx.vhf1.light` | bool | light | read | `0` | ACP 2 VHF 1 reception knob integral white light (knob out) |
| `pedestal.acp2.rx.vhf1.on` | bool | switch | write | `0` | ACP 2 VHF 1 reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp2.rx.vhf1.volume` | float | analog | write | `0` | ACP 2 VHF 1 reception knob volume (0..1) |
| `pedestal.acp2.rx.vhf2.light` | bool | light | read | `0` | ACP 2 VHF 2 reception knob integral white light (knob out) |
| `pedestal.acp2.rx.vhf2.on` | bool | switch | write | `0` | ACP 2 VHF 2 reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp2.rx.vhf2.volume` | float | analog | write | `0` | ACP 2 VHF 2 reception knob volume (0..1) |
| `pedestal.acp2.rx.vhf3.light` | bool | light | read | `0` | ACP 2 VHF 3 reception knob integral white light (knob out) |
| `pedestal.acp2.rx.vhf3.on` | bool | switch | write | `0` | ACP 2 VHF 3 reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp2.rx.vhf3.volume` | float | analog | write | `0` | ACP 2 VHF 3 reception knob volume (0..1) |
| `pedestal.acp2.rx.vor1.light` | bool | light | read | `0` | ACP 2 VOR 1 reception knob integral white light (knob out) |
| `pedestal.acp2.rx.vor1.on` | bool | switch | write | `0` | ACP 2 VOR 1 reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp2.rx.vor1.volume` | float | analog | write | `0` | ACP 2 VOR 1 reception knob volume (0..1) |
| `pedestal.acp2.rx.vor2.light` | bool | light | read | `0` | ACP 2 VOR 2 reception knob integral white light (knob out) |
| `pedestal.acp2.rx.vor2.on` | bool | switch | write | `0` | ACP 2 VOR 2 reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp2.rx.vor2.volume` | float | analog | write | `0` | ACP 2 VOR 2 reception knob volume (0..1) |
| `pedestal.acp2.tx` | int | rotary | write | `0` | ACP 2 transmission key selected (0 none, 1..3 VHF 1..3, 4..5 HF 1..2 (not fitted), 6 INT, 7 CAB) |
| `pedestal.acp2.vhf1.call` | bool | light | read | `0` | ACP 2 VHF1 key CALL legend (amber, flashing: SELCAL) |
| `pedestal.acp2.vhf1.on` | bool | light | read | `0` | ACP 2 VHF1 key three green lines |
| `pedestal.acp2.vhf1.pressed` | bool | pushbutton | momentary | `0` | ACP 2 VHF1 transmission key (momentary) |
| `pedestal.acp2.vhf2.call` | bool | light | read | `0` | ACP 2 VHF2 key CALL legend (amber, flashing: SELCAL) |
| `pedestal.acp2.vhf2.on` | bool | light | read | `0` | ACP 2 VHF2 key three green lines |
| `pedestal.acp2.vhf2.pressed` | bool | pushbutton | momentary | `0` | ACP 2 VHF2 transmission key (momentary) |
| `pedestal.acp2.vhf3.call` | bool | light | read | `0` | ACP 2 VHF3 key CALL legend (amber, flashing: SELCAL) |
| `pedestal.acp2.vhf3.on` | bool | light | read | `0` | ACP 2 VHF3 key three green lines |
| `pedestal.acp2.vhf3.pressed` | bool | pushbutton | momentary | `0` | ACP 2 VHF3 transmission key (momentary) |
| `pedestal.acp2.voice.on` | bool | light | read | `0` | ACP 2 VOICE key green ON light |
| `pedestal.acp2.voice.pressed` | bool | pushbutton | write | `0` | ACP 2 VOICE key (alternate action: 1 = pressed in, navaid idents filtered) |
| `pedestal.acp3.att` | bool | light | read | `0` | ACP 3 CAB key ATT legend (amber, flashing) |
| `pedestal.acp3.cab.on` | bool | light | read | `0` | ACP 3 CAB key three green lines |
| `pedestal.acp3.cab.pressed` | bool | pushbutton | momentary | `0` | ACP 3 CAB transmission key (momentary) |
| `pedestal.acp3.hf1.call` | bool | light | read | `0` | ACP 3 HF1 key CALL legend (amber, flashing: SELCAL) |
| `pedestal.acp3.hf1.on` | bool | light | read | `0` | ACP 3 HF1 key three green lines |
| `pedestal.acp3.hf1.pressed` | bool | pushbutton | momentary | `0` | ACP 3 HF1 transmission key (momentary) |
| `pedestal.acp3.hf2.call` | bool | light | read | `0` | ACP 3 HF2 key CALL legend (amber, flashing: SELCAL) |
| `pedestal.acp3.hf2.on` | bool | light | read | `0` | ACP 3 HF2 key three green lines |
| `pedestal.acp3.hf2.pressed` | bool | pushbutton | momentary | `0` | ACP 3 HF2 transmission key (momentary) |
| `pedestal.acp3.int.on` | bool | light | read | `0` | ACP 3 INT key three green lines |
| `pedestal.acp3.int.pressed` | bool | pushbutton | momentary | `0` | ACP 3 INT transmission key (momentary) |
| `pedestal.acp3.intRad` | int | switch | write | `0` | ACP 3 INT/RAD switch (-1 INT, 0 neutral, 1 RAD: press and hold) |
| `pedestal.acp3.mech` | bool | light | read | `0` | ACP 3 INT key MECH legend (amber, flashing) |
| `pedestal.acp3.pa.on` | bool | light | read | `0` | ACP 3 PA key three green lines |
| `pedestal.acp3.pa.pressed` | bool | pushbutton | momentary | `0` | ACP 3 PA key (press and hold) |
| `pedestal.acp3.reset` | bool | pushbutton | momentary | `0` | ACP 3 SELCAL/CALL RESET key |
| `pedestal.acp3.rx.adf1.light` | bool | light | read | `0` | ACP 3 ADF 1 reception knob integral white light (knob out) |
| `pedestal.acp3.rx.adf1.on` | bool | switch | write | `0` | ACP 3 ADF 1 reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp3.rx.adf1.volume` | float | analog | write | `0` | ACP 3 ADF 1 reception knob volume (0..1) |
| `pedestal.acp3.rx.adf2.light` | bool | light | read | `0` | ACP 3 ADF 2 reception knob integral white light (knob out) |
| `pedestal.acp3.rx.adf2.on` | bool | switch | write | `0` | ACP 3 ADF 2 reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp3.rx.adf2.volume` | float | analog | write | `0` | ACP 3 ADF 2 reception knob volume (0..1) |
| `pedestal.acp3.rx.cab.light` | bool | light | read | `0` | ACP 3 CAB reception knob integral white light (knob out) |
| `pedestal.acp3.rx.cab.on` | bool | switch | write | `0` | ACP 3 CAB reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp3.rx.cab.volume` | float | analog | write | `0` | ACP 3 CAB reception knob volume (0..1) |
| `pedestal.acp3.rx.hf1.light` | bool | light | read | `0` | ACP 3 HF 1 reception knob integral white light (knob out) |
| `pedestal.acp3.rx.hf1.on` | bool | switch | write | `0` | ACP 3 HF 1 reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp3.rx.hf1.volume` | float | analog | write | `0` | ACP 3 HF 1 reception knob volume (0..1) |
| `pedestal.acp3.rx.hf2.light` | bool | light | read | `0` | ACP 3 HF 2 reception knob integral white light (knob out) |
| `pedestal.acp3.rx.hf2.on` | bool | switch | write | `0` | ACP 3 HF 2 reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp3.rx.hf2.volume` | float | analog | write | `0` | ACP 3 HF 2 reception knob volume (0..1) |
| `pedestal.acp3.rx.int.light` | bool | light | read | `0` | ACP 3 INT reception knob integral white light (knob out) |
| `pedestal.acp3.rx.int.on` | bool | switch | write | `0` | ACP 3 INT reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp3.rx.int.volume` | float | analog | write | `0` | ACP 3 INT reception knob volume (0..1) |
| `pedestal.acp3.rx.ls.light` | bool | light | read | `0` | ACP 3 LS reception knob integral white light (knob out) |
| `pedestal.acp3.rx.ls.on` | bool | switch | write | `0` | ACP 3 LS reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp3.rx.ls.volume` | float | analog | write | `0` | ACP 3 LS reception knob volume (0..1) |
| `pedestal.acp3.rx.mkr.light` | bool | light | read | `0` | ACP 3 MKR reception knob integral white light (knob out) |
| `pedestal.acp3.rx.mkr.on` | bool | switch | write | `0` | ACP 3 MKR reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp3.rx.mkr.volume` | float | analog | write | `0` | ACP 3 MKR reception knob volume (0..1) |
| `pedestal.acp3.rx.mls.light` | bool | light | read | `0` | ACP 3 MLS reception knob integral white light (knob out) |
| `pedestal.acp3.rx.mls.on` | bool | switch | write | `0` | ACP 3 MLS reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp3.rx.mls.volume` | float | analog | write | `0` | ACP 3 MLS reception knob volume (0..1) |
| `pedestal.acp3.rx.pa.light` | bool | light | read | `0` | ACP 3 PA reception knob integral white light (knob out) |
| `pedestal.acp3.rx.pa.on` | bool | switch | write | `0` | ACP 3 PA reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp3.rx.pa.volume` | float | analog | write | `0` | ACP 3 PA reception knob volume (0..1) |
| `pedestal.acp3.rx.vhf1.light` | bool | light | read | `0` | ACP 3 VHF 1 reception knob integral white light (knob out) |
| `pedestal.acp3.rx.vhf1.on` | bool | switch | write | `0` | ACP 3 VHF 1 reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp3.rx.vhf1.volume` | float | analog | write | `0` | ACP 3 VHF 1 reception knob volume (0..1) |
| `pedestal.acp3.rx.vhf2.light` | bool | light | read | `0` | ACP 3 VHF 2 reception knob integral white light (knob out) |
| `pedestal.acp3.rx.vhf2.on` | bool | switch | write | `0` | ACP 3 VHF 2 reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp3.rx.vhf2.volume` | float | analog | write | `0` | ACP 3 VHF 2 reception knob volume (0..1) |
| `pedestal.acp3.rx.vhf3.light` | bool | light | read | `0` | ACP 3 VHF 3 reception knob integral white light (knob out) |
| `pedestal.acp3.rx.vhf3.on` | bool | switch | write | `0` | ACP 3 VHF 3 reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp3.rx.vhf3.volume` | float | analog | write | `0` | ACP 3 VHF 3 reception knob volume (0..1) |
| `pedestal.acp3.rx.vor1.light` | bool | light | read | `0` | ACP 3 VOR 1 reception knob integral white light (knob out) |
| `pedestal.acp3.rx.vor1.on` | bool | switch | write | `0` | ACP 3 VOR 1 reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp3.rx.vor1.volume` | float | analog | write | `0` | ACP 3 VOR 1 reception knob volume (0..1) |
| `pedestal.acp3.rx.vor2.light` | bool | light | read | `0` | ACP 3 VOR 2 reception knob integral white light (knob out) |
| `pedestal.acp3.rx.vor2.on` | bool | switch | write | `0` | ACP 3 VOR 2 reception knob (1 = out: channel selected, 0 = pushed in) |
| `pedestal.acp3.rx.vor2.volume` | float | analog | write | `0` | ACP 3 VOR 2 reception knob volume (0..1) |
| `pedestal.acp3.tx` | int | rotary | write | `0` | ACP 3 transmission key selected (0 none, 1..3 VHF 1..3, 4..5 HF 1..2 (not fitted), 6 INT, 7 CAB) |
| `pedestal.acp3.vhf1.call` | bool | light | read | `0` | ACP 3 VHF1 key CALL legend (amber, flashing: SELCAL) |
| `pedestal.acp3.vhf1.on` | bool | light | read | `0` | ACP 3 VHF1 key three green lines |
| `pedestal.acp3.vhf1.pressed` | bool | pushbutton | momentary | `0` | ACP 3 VHF1 transmission key (momentary) |
| `pedestal.acp3.vhf2.call` | bool | light | read | `0` | ACP 3 VHF2 key CALL legend (amber, flashing: SELCAL) |
| `pedestal.acp3.vhf2.on` | bool | light | read | `0` | ACP 3 VHF2 key three green lines |
| `pedestal.acp3.vhf2.pressed` | bool | pushbutton | momentary | `0` | ACP 3 VHF2 transmission key (momentary) |
| `pedestal.acp3.vhf3.call` | bool | light | read | `0` | ACP 3 VHF3 key CALL legend (amber, flashing: SELCAL) |
| `pedestal.acp3.vhf3.on` | bool | light | read | `0` | ACP 3 VHF3 key three green lines |
| `pedestal.acp3.vhf3.pressed` | bool | pushbutton | momentary | `0` | ACP 3 VHF3 transmission key (momentary) |
| `pedestal.acp3.voice.on` | bool | light | read | `0` | ACP 3 VOICE key green ON light |
| `pedestal.acp3.voice.pressed` | bool | pushbutton | write | `0` | ACP 3 VOICE key (alternate action: 1 = pressed in, navaid idents filtered) |

## Pedestal / ATC-TCAS

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `pedestal.atc.altRptg` | int | switch | write | `0` | ALT RPTG switch: 0 = OFF, 1 = ON |
| `pedestal.atc.clr` | bool | pushbutton | momentary | `0` | CLR key |
| `pedestal.atc.display` | string | light | read | `""` | Code window as shown (4 characters, a partial entry padded with spaces; blank without power) |
| `pedestal.atc.fail` | bool | light | read | `0` | ATC FAIL light (selected transponder failed) |
| `pedestal.atc.ident` | bool | pushbutton | momentary | `0` | IDENT pushbutton |
| `pedestal.atc.key0` | bool | pushbutton | momentary | `0` | Code key 0 |
| `pedestal.atc.key1` | bool | pushbutton | momentary | `0` | Code key 1 |
| `pedestal.atc.key2` | bool | pushbutton | momentary | `0` | Code key 2 |
| `pedestal.atc.key3` | bool | pushbutton | momentary | `0` | Code key 3 |
| `pedestal.atc.key4` | bool | pushbutton | momentary | `0` | Code key 4 |
| `pedestal.atc.key5` | bool | pushbutton | momentary | `0` | Code key 5 |
| `pedestal.atc.key6` | bool | pushbutton | momentary | `0` | Code key 6 |
| `pedestal.atc.key7` | bool | pushbutton | momentary | `0` | Code key 7 |
| `pedestal.atc.mode` | int | rotary | write | `0` | ATC mode selector: 0 = STBY, 1 = AUTO, 2 = ON |
| `pedestal.atc.xpdr` | int | rotary | write | `0` | XPDR selector: 1 = XPDR 1, 2 = XPDR 2 |
| `pedestal.tcas.mode` | int | rotary | write | `0` | TCAS mode selector: 0 = STBY, 1 = TA, 2 = TA/RA |
| `pedestal.tcas.test` | bool | pushbutton | momentary | `0` | TCAS TEST pushbutton (CMM 34-52-14 variant B; momentary) |
| `pedestal.tcas.traffic` | int | rotary | write | `0` | TCAS TRAFFIC selector: 0 = THRT, 1 = ALL, 2 = ABV, 3 = BLW |

## Pedestal / AUDIO SWITCHING

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `pedestal.audioSwitching` | int | rotary | write | `0` | AUDIO SWITCHING selector (0 NORM, 1 CAPT 3, 2 F/O 3) |

## Pedestal / COCKPIT DOOR

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `pedestal.cockpitDoor.fault` | bool | light | read | `0` | COCKPIT DOOR FAULT light (strike, pressure sensor or control unit failure) |
| `pedestal.cockpitDoor.open` | bool | light | read | `0` | COCKPIT DOOR OPEN light (steady: door not closed; flashing: emergency access request pending) |
| `pedestal.cockpitDoor.toggle` | int | switch | write | `0` | COCKPIT DOOR toggle switch (0 = UNLOCK: pulled and held, 1 = NORM, 2 = LOCK) |
| `pedestal.cockpitDoor.video.pressed` | bool | pushbutton | momentary | `0` | COCKPIT DOOR VIDEO pushbutton (momentary: 1 while held) |

## Pedestal / DRAIMS (dummy)

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `ped.draims1.brt` | float | analog | write | `0` | DRAIMS 1 screen BRT knob (0 = OFF .. 1; dummy: no function) |
| `ped.draims1.intRad` | int | switch | write | `0` | DRAIMS 1 INT/RAD switch (-1 INT, 0 neutral, 1 RAD: press and hold; dummy: no function) |
| `ped.draims1.key.0` | bool | pushbutton | momentary | `0` | DRAIMS 1 0 key (dummy: no function) |
| `ped.draims1.key.1` | bool | pushbutton | momentary | `0` | DRAIMS 1 1 key (dummy: no function) |
| `ped.draims1.key.2` | bool | pushbutton | momentary | `0` | DRAIMS 1 2 key (dummy: no function) |
| `ped.draims1.key.3` | bool | pushbutton | momentary | `0` | DRAIMS 1 3 key (dummy: no function) |
| `ped.draims1.key.4` | bool | pushbutton | momentary | `0` | DRAIMS 1 4 key (dummy: no function) |
| `ped.draims1.key.5` | bool | pushbutton | momentary | `0` | DRAIMS 1 5 key (dummy: no function) |
| `ped.draims1.key.6` | bool | pushbutton | momentary | `0` | DRAIMS 1 6 key (dummy: no function) |
| `ped.draims1.key.7` | bool | pushbutton | momentary | `0` | DRAIMS 1 7 key (dummy: no function) |
| `ped.draims1.key.8` | bool | pushbutton | momentary | `0` | DRAIMS 1 8 key (dummy: no function) |
| `ped.draims1.key.9` | bool | pushbutton | momentary | `0` | DRAIMS 1 9 key (dummy: no function) |
| `ped.draims1.key.arrow1` | bool | pushbutton | momentary | `0` | DRAIMS 1 ARROW1 key (dummy: no function) |
| `ped.draims1.key.arrow2` | bool | pushbutton | momentary | `0` | DRAIMS 1 ARROW2 key (dummy: no function) |
| `ped.draims1.key.atc` | bool | pushbutton | momentary | `0` | DRAIMS 1 ATC key (dummy: no function) |
| `ped.draims1.key.cab` | bool | pushbutton | momentary | `0` | DRAIMS 1 CAB key (dummy: no function) |
| `ped.draims1.key.clr` | bool | pushbutton | momentary | `0` | DRAIMS 1 CLR key (dummy: no function) |
| `ped.draims1.key.dot` | bool | pushbutton | momentary | `0` | DRAIMS 1 DOT key (dummy: no function) |
| `ped.draims1.key.down` | bool | pushbutton | momentary | `0` | DRAIMS 1 DOWN key (dummy: no function) |
| `ped.draims1.key.hf` | bool | pushbutton | momentary | `0` | DRAIMS 1 HF key (dummy: no function) |
| `ped.draims1.key.hf1` | bool | pushbutton | momentary | `0` | DRAIMS 1 HF1 key (dummy: no function) |
| `ped.draims1.key.hf2` | bool | pushbutton | momentary | `0` | DRAIMS 1 HF2 key (dummy: no function) |
| `ped.draims1.key.int` | bool | pushbutton | momentary | `0` | DRAIMS 1 INT key (dummy: no function) |
| `ped.draims1.key.l1` | bool | pushbutton | momentary | `0` | DRAIMS 1 L1 key (dummy: no function) |
| `ped.draims1.key.l2` | bool | pushbutton | momentary | `0` | DRAIMS 1 L2 key (dummy: no function) |
| `ped.draims1.key.l3` | bool | pushbutton | momentary | `0` | DRAIMS 1 L3 key (dummy: no function) |
| `ped.draims1.key.l4` | bool | pushbutton | momentary | `0` | DRAIMS 1 L4 key (dummy: no function) |
| `ped.draims1.key.menu` | bool | pushbutton | momentary | `0` | DRAIMS 1 MENU key (dummy: no function) |
| `ped.draims1.key.nav` | bool | pushbutton | momentary | `0` | DRAIMS 1 NAV key (dummy: no function) |
| `ped.draims1.key.pa` | bool | pushbutton | momentary | `0` | DRAIMS 1 PA key (dummy: no function) |
| `ped.draims1.key.r1` | bool | pushbutton | momentary | `0` | DRAIMS 1 R1 key (dummy: no function) |
| `ped.draims1.key.r2` | bool | pushbutton | momentary | `0` | DRAIMS 1 R2 key (dummy: no function) |
| `ped.draims1.key.r3` | bool | pushbutton | momentary | `0` | DRAIMS 1 R3 key (dummy: no function) |
| `ped.draims1.key.r4` | bool | pushbutton | momentary | `0` | DRAIMS 1 R4 key (dummy: no function) |
| `ped.draims1.key.spare` | bool | pushbutton | momentary | `0` | DRAIMS 1 SPARE key (dummy: no function) |
| `ped.draims1.key.tel` | bool | pushbutton | momentary | `0` | DRAIMS 1 TEL key (dummy: no function) |
| `ped.draims1.key.tel1` | bool | pushbutton | momentary | `0` | DRAIMS 1 TEL1 key (dummy: no function) |
| `ped.draims1.key.tel2` | bool | pushbutton | momentary | `0` | DRAIMS 1 TEL2 key (dummy: no function) |
| `ped.draims1.key.up` | bool | pushbutton | momentary | `0` | DRAIMS 1 UP key (dummy: no function) |
| `ped.draims1.key.vhf` | bool | pushbutton | momentary | `0` | DRAIMS 1 VHF key (dummy: no function) |
| `ped.draims1.key.vhf1` | bool | pushbutton | momentary | `0` | DRAIMS 1 VHF1 key (dummy: no function) |
| `ped.draims1.key.vhf2` | bool | pushbutton | momentary | `0` | DRAIMS 1 VHF2 key (dummy: no function) |
| `ped.draims1.key.vhf3` | bool | pushbutton | momentary | `0` | DRAIMS 1 VHF3 key (dummy: no function) |
| `ped.draims1.rx.cab.on` | bool | switch | write | `0` | DRAIMS 1 CAB reception knob out (dummy: no function) |
| `ped.draims1.rx.cab.volume` | float | analog | write | `0` | DRAIMS 1 CAB reception volume 0..1 (dummy: no function) |
| `ped.draims1.rx.hf1.on` | bool | switch | write | `0` | DRAIMS 1 HF1 reception knob out (dummy: no function) |
| `ped.draims1.rx.hf1.volume` | float | analog | write | `0` | DRAIMS 1 HF1 reception volume 0..1 (dummy: no function) |
| `ped.draims1.rx.hf2.on` | bool | switch | write | `0` | DRAIMS 1 HF2 reception knob out (dummy: no function) |
| `ped.draims1.rx.hf2.volume` | float | analog | write | `0` | DRAIMS 1 HF2 reception volume 0..1 (dummy: no function) |
| `ped.draims1.rx.int.on` | bool | switch | write | `0` | DRAIMS 1 INT reception knob out (dummy: no function) |
| `ped.draims1.rx.int.volume` | float | analog | write | `0` | DRAIMS 1 INT reception volume 0..1 (dummy: no function) |
| `ped.draims1.rx.nav.on` | bool | switch | write | `0` | DRAIMS 1 NAV reception knob out (dummy: no function) |
| `ped.draims1.rx.nav.volume` | float | analog | write | `0` | DRAIMS 1 NAV reception volume 0..1 (dummy: no function) |
| `ped.draims1.rx.pa.on` | bool | switch | write | `0` | DRAIMS 1 PA reception knob out (dummy: no function) |
| `ped.draims1.rx.pa.volume` | float | analog | write | `0` | DRAIMS 1 PA reception volume 0..1 (dummy: no function) |
| `ped.draims1.rx.tel1.on` | bool | switch | write | `0` | DRAIMS 1 TEL1 reception knob out (dummy: no function) |
| `ped.draims1.rx.tel1.volume` | float | analog | write | `0` | DRAIMS 1 TEL1 reception volume 0..1 (dummy: no function) |
| `ped.draims1.rx.tel2.on` | bool | switch | write | `0` | DRAIMS 1 TEL2 reception knob out (dummy: no function) |
| `ped.draims1.rx.tel2.volume` | float | analog | write | `0` | DRAIMS 1 TEL2 reception volume 0..1 (dummy: no function) |
| `ped.draims1.rx.vhf1.on` | bool | switch | write | `0` | DRAIMS 1 VHF1 reception knob out (dummy: no function) |
| `ped.draims1.rx.vhf1.volume` | float | analog | write | `0` | DRAIMS 1 VHF1 reception volume 0..1 (dummy: no function) |
| `ped.draims1.rx.vhf2.on` | bool | switch | write | `0` | DRAIMS 1 VHF2 reception knob out (dummy: no function) |
| `ped.draims1.rx.vhf2.volume` | float | analog | write | `0` | DRAIMS 1 VHF2 reception volume 0..1 (dummy: no function) |
| `ped.draims1.rx.vhf3.on` | bool | switch | write | `0` | DRAIMS 1 VHF3 reception knob out (dummy: no function) |
| `ped.draims1.rx.vhf3.volume` | float | analog | write | `0` | DRAIMS 1 VHF3 reception volume 0..1 (dummy: no function) |
| `ped.draims2.brt` | float | analog | write | `0` | DRAIMS 2 screen BRT knob (0 = OFF .. 1; dummy: no function) |
| `ped.draims2.intRad` | int | switch | write | `0` | DRAIMS 2 INT/RAD switch (-1 INT, 0 neutral, 1 RAD: press and hold; dummy: no function) |
| `ped.draims2.key.0` | bool | pushbutton | momentary | `0` | DRAIMS 2 0 key (dummy: no function) |
| `ped.draims2.key.1` | bool | pushbutton | momentary | `0` | DRAIMS 2 1 key (dummy: no function) |
| `ped.draims2.key.2` | bool | pushbutton | momentary | `0` | DRAIMS 2 2 key (dummy: no function) |
| `ped.draims2.key.3` | bool | pushbutton | momentary | `0` | DRAIMS 2 3 key (dummy: no function) |
| `ped.draims2.key.4` | bool | pushbutton | momentary | `0` | DRAIMS 2 4 key (dummy: no function) |
| `ped.draims2.key.5` | bool | pushbutton | momentary | `0` | DRAIMS 2 5 key (dummy: no function) |
| `ped.draims2.key.6` | bool | pushbutton | momentary | `0` | DRAIMS 2 6 key (dummy: no function) |
| `ped.draims2.key.7` | bool | pushbutton | momentary | `0` | DRAIMS 2 7 key (dummy: no function) |
| `ped.draims2.key.8` | bool | pushbutton | momentary | `0` | DRAIMS 2 8 key (dummy: no function) |
| `ped.draims2.key.9` | bool | pushbutton | momentary | `0` | DRAIMS 2 9 key (dummy: no function) |
| `ped.draims2.key.arrow1` | bool | pushbutton | momentary | `0` | DRAIMS 2 ARROW1 key (dummy: no function) |
| `ped.draims2.key.arrow2` | bool | pushbutton | momentary | `0` | DRAIMS 2 ARROW2 key (dummy: no function) |
| `ped.draims2.key.atc` | bool | pushbutton | momentary | `0` | DRAIMS 2 ATC key (dummy: no function) |
| `ped.draims2.key.cab` | bool | pushbutton | momentary | `0` | DRAIMS 2 CAB key (dummy: no function) |
| `ped.draims2.key.clr` | bool | pushbutton | momentary | `0` | DRAIMS 2 CLR key (dummy: no function) |
| `ped.draims2.key.dot` | bool | pushbutton | momentary | `0` | DRAIMS 2 DOT key (dummy: no function) |
| `ped.draims2.key.down` | bool | pushbutton | momentary | `0` | DRAIMS 2 DOWN key (dummy: no function) |
| `ped.draims2.key.hf` | bool | pushbutton | momentary | `0` | DRAIMS 2 HF key (dummy: no function) |
| `ped.draims2.key.hf1` | bool | pushbutton | momentary | `0` | DRAIMS 2 HF1 key (dummy: no function) |
| `ped.draims2.key.hf2` | bool | pushbutton | momentary | `0` | DRAIMS 2 HF2 key (dummy: no function) |
| `ped.draims2.key.int` | bool | pushbutton | momentary | `0` | DRAIMS 2 INT key (dummy: no function) |
| `ped.draims2.key.l1` | bool | pushbutton | momentary | `0` | DRAIMS 2 L1 key (dummy: no function) |
| `ped.draims2.key.l2` | bool | pushbutton | momentary | `0` | DRAIMS 2 L2 key (dummy: no function) |
| `ped.draims2.key.l3` | bool | pushbutton | momentary | `0` | DRAIMS 2 L3 key (dummy: no function) |
| `ped.draims2.key.l4` | bool | pushbutton | momentary | `0` | DRAIMS 2 L4 key (dummy: no function) |
| `ped.draims2.key.menu` | bool | pushbutton | momentary | `0` | DRAIMS 2 MENU key (dummy: no function) |
| `ped.draims2.key.nav` | bool | pushbutton | momentary | `0` | DRAIMS 2 NAV key (dummy: no function) |
| `ped.draims2.key.pa` | bool | pushbutton | momentary | `0` | DRAIMS 2 PA key (dummy: no function) |
| `ped.draims2.key.r1` | bool | pushbutton | momentary | `0` | DRAIMS 2 R1 key (dummy: no function) |
| `ped.draims2.key.r2` | bool | pushbutton | momentary | `0` | DRAIMS 2 R2 key (dummy: no function) |
| `ped.draims2.key.r3` | bool | pushbutton | momentary | `0` | DRAIMS 2 R3 key (dummy: no function) |
| `ped.draims2.key.r4` | bool | pushbutton | momentary | `0` | DRAIMS 2 R4 key (dummy: no function) |
| `ped.draims2.key.spare` | bool | pushbutton | momentary | `0` | DRAIMS 2 SPARE key (dummy: no function) |
| `ped.draims2.key.tel` | bool | pushbutton | momentary | `0` | DRAIMS 2 TEL key (dummy: no function) |
| `ped.draims2.key.tel1` | bool | pushbutton | momentary | `0` | DRAIMS 2 TEL1 key (dummy: no function) |
| `ped.draims2.key.tel2` | bool | pushbutton | momentary | `0` | DRAIMS 2 TEL2 key (dummy: no function) |
| `ped.draims2.key.up` | bool | pushbutton | momentary | `0` | DRAIMS 2 UP key (dummy: no function) |
| `ped.draims2.key.vhf` | bool | pushbutton | momentary | `0` | DRAIMS 2 VHF key (dummy: no function) |
| `ped.draims2.key.vhf1` | bool | pushbutton | momentary | `0` | DRAIMS 2 VHF1 key (dummy: no function) |
| `ped.draims2.key.vhf2` | bool | pushbutton | momentary | `0` | DRAIMS 2 VHF2 key (dummy: no function) |
| `ped.draims2.key.vhf3` | bool | pushbutton | momentary | `0` | DRAIMS 2 VHF3 key (dummy: no function) |
| `ped.draims2.rx.cab.on` | bool | switch | write | `0` | DRAIMS 2 CAB reception knob out (dummy: no function) |
| `ped.draims2.rx.cab.volume` | float | analog | write | `0` | DRAIMS 2 CAB reception volume 0..1 (dummy: no function) |
| `ped.draims2.rx.hf1.on` | bool | switch | write | `0` | DRAIMS 2 HF1 reception knob out (dummy: no function) |
| `ped.draims2.rx.hf1.volume` | float | analog | write | `0` | DRAIMS 2 HF1 reception volume 0..1 (dummy: no function) |
| `ped.draims2.rx.hf2.on` | bool | switch | write | `0` | DRAIMS 2 HF2 reception knob out (dummy: no function) |
| `ped.draims2.rx.hf2.volume` | float | analog | write | `0` | DRAIMS 2 HF2 reception volume 0..1 (dummy: no function) |
| `ped.draims2.rx.int.on` | bool | switch | write | `0` | DRAIMS 2 INT reception knob out (dummy: no function) |
| `ped.draims2.rx.int.volume` | float | analog | write | `0` | DRAIMS 2 INT reception volume 0..1 (dummy: no function) |
| `ped.draims2.rx.nav.on` | bool | switch | write | `0` | DRAIMS 2 NAV reception knob out (dummy: no function) |
| `ped.draims2.rx.nav.volume` | float | analog | write | `0` | DRAIMS 2 NAV reception volume 0..1 (dummy: no function) |
| `ped.draims2.rx.pa.on` | bool | switch | write | `0` | DRAIMS 2 PA reception knob out (dummy: no function) |
| `ped.draims2.rx.pa.volume` | float | analog | write | `0` | DRAIMS 2 PA reception volume 0..1 (dummy: no function) |
| `ped.draims2.rx.tel1.on` | bool | switch | write | `0` | DRAIMS 2 TEL1 reception knob out (dummy: no function) |
| `ped.draims2.rx.tel1.volume` | float | analog | write | `0` | DRAIMS 2 TEL1 reception volume 0..1 (dummy: no function) |
| `ped.draims2.rx.tel2.on` | bool | switch | write | `0` | DRAIMS 2 TEL2 reception knob out (dummy: no function) |
| `ped.draims2.rx.tel2.volume` | float | analog | write | `0` | DRAIMS 2 TEL2 reception volume 0..1 (dummy: no function) |
| `ped.draims2.rx.vhf1.on` | bool | switch | write | `0` | DRAIMS 2 VHF1 reception knob out (dummy: no function) |
| `ped.draims2.rx.vhf1.volume` | float | analog | write | `0` | DRAIMS 2 VHF1 reception volume 0..1 (dummy: no function) |
| `ped.draims2.rx.vhf2.on` | bool | switch | write | `0` | DRAIMS 2 VHF2 reception knob out (dummy: no function) |
| `ped.draims2.rx.vhf2.volume` | float | analog | write | `0` | DRAIMS 2 VHF2 reception volume 0..1 (dummy: no function) |
| `ped.draims2.rx.vhf3.on` | bool | switch | write | `0` | DRAIMS 2 VHF3 reception knob out (dummy: no function) |
| `ped.draims2.rx.vhf3.volume` | float | analog | write | `0` | DRAIMS 2 VHF3 reception volume 0..1 (dummy: no function) |

## Pedestal / ECAM CONTROL PANEL

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `pedestal.ecam.all.pressed` | bool | pushbutton | momentary | `0` | ALL pushbutton (momentary: 1 while held) |
| `pedestal.ecam.apu.lit` | bool | light | read | `0` | APU LIT light |
| `pedestal.ecam.apu.pressed` | bool | pushbutton | momentary | `0` | APU pushbutton (momentary: 1 while held) |
| `pedestal.ecam.bleed.lit` | bool | light | read | `0` | BLEED LIT light |
| `pedestal.ecam.bleed.pressed` | bool | pushbutton | momentary | `0` | BLEED pushbutton (momentary: 1 while held) |
| `pedestal.ecam.clr1.lit` | bool | light | read | `0` | CLR (left) LIT light |
| `pedestal.ecam.clr1.pressed` | bool | pushbutton | momentary | `0` | CLR (left) pushbutton (momentary: 1 while held) |
| `pedestal.ecam.clr2.lit` | bool | light | read | `0` | CLR (right) LIT light |
| `pedestal.ecam.clr2.pressed` | bool | pushbutton | momentary | `0` | CLR (right) pushbutton (momentary: 1 while held) |
| `pedestal.ecam.cond.lit` | bool | light | read | `0` | COND LIT light |
| `pedestal.ecam.cond.pressed` | bool | pushbutton | momentary | `0` | COND pushbutton (momentary: 1 while held) |
| `pedestal.ecam.door.lit` | bool | light | read | `0` | DOOR LIT light |
| `pedestal.ecam.door.pressed` | bool | pushbutton | momentary | `0` | DOOR pushbutton (momentary: 1 while held) |
| `pedestal.ecam.elec.lit` | bool | light | read | `0` | ELEC LIT light |
| `pedestal.ecam.elec.pressed` | bool | pushbutton | momentary | `0` | ELEC pushbutton (momentary: 1 while held) |
| `pedestal.ecam.emerCanc.pressed` | bool | pushbutton | momentary | `0` | EMER CANC pushbutton (momentary: 1 while held) |
| `pedestal.ecam.eng.lit` | bool | light | read | `0` | ENG LIT light |
| `pedestal.ecam.eng.pressed` | bool | pushbutton | momentary | `0` | ENG pushbutton (momentary: 1 while held) |
| `pedestal.ecam.fctl.lit` | bool | light | read | `0` | F/CTL LIT light |
| `pedestal.ecam.fctl.pressed` | bool | pushbutton | momentary | `0` | F/CTL pushbutton (momentary: 1 while held) |
| `pedestal.ecam.fuel.lit` | bool | light | read | `0` | FUEL LIT light |
| `pedestal.ecam.fuel.pressed` | bool | pushbutton | momentary | `0` | FUEL pushbutton (momentary: 1 while held) |
| `pedestal.ecam.hyd.lit` | bool | light | read | `0` | HYD LIT light |
| `pedestal.ecam.hyd.pressed` | bool | pushbutton | momentary | `0` | HYD pushbutton (momentary: 1 while held) |
| `pedestal.ecam.lowerDisplayBrt` | float | analog | write | `0` | ECAM LOWER DISPLAY OFF/BRT knob (0 = OFF, 1 = full bright) |
| `pedestal.ecam.press.lit` | bool | light | read | `0` | PRESS LIT light |
| `pedestal.ecam.press.pressed` | bool | pushbutton | momentary | `0` | PRESS pushbutton (momentary: 1 while held) |
| `pedestal.ecam.rcl.pressed` | bool | pushbutton | momentary | `0` | RCL pushbutton (momentary: 1 while held) |
| `pedestal.ecam.sts.lit` | bool | light | read | `0` | STS LIT light |
| `pedestal.ecam.sts.pressed` | bool | pushbutton | momentary | `0` | STS pushbutton (momentary: 1 while held) |
| `pedestal.ecam.toConfig.pressed` | bool | pushbutton | momentary | `0` | T.O CONFIG pushbutton (momentary: 1 while held) |
| `pedestal.ecam.upperDisplayBrt` | float | analog | write | `0` | ECAM UPPER DISPLAY OFF/BRT knob (0 = OFF, 1 = full bright) |
| `pedestal.ecam.wheel.lit` | bool | light | read | `0` | WHEEL LIT light |
| `pedestal.ecam.wheel.pressed` | bool | pushbutton | momentary | `0` | WHEEL pushbutton (momentary: 1 while held) |

## Pedestal / ENG 115VU

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `pedestal.engine.fault1` | bool | light | read | `0` | ENG 1 FAULT light (amber) |
| `pedestal.engine.fault2` | bool | light | read | `0` | ENG 2 FAULT light (amber) |
| `pedestal.engine.fire1` | bool | light | read | `0` | ENG 1 FIRE light (red) |
| `pedestal.engine.fire2` | bool | light | read | `0` | ENG 2 FIRE light (red) |
| `pedestal.engine.master1` | bool | switch | write | `0` | ENG MASTER 1 lever (1 = ON) |
| `pedestal.engine.master2` | bool | switch | write | `0` | ENG MASTER 2 lever (1 = ON) |
| `pedestal.engine.mode` | int | rotary | write | `0` | ENG MODE selector (0 = CRANK, 1 = NORM, 2 = IGN/START) |

## Pedestal / Flight controls

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `pedestal.flaps.lever` | int | rotary | write | `0` | FLAPS lever (0, 1, 2, 3, 4 = FULL) |
| `pedestal.pitchTrim.wheel` | float | analog | write | `0` | Pitch trim wheel = THS position (degrees, + nose up, -4 .. 13.5); writing another value moves the wheel (manual trim) |
| `pedestal.rudTrim.dashed` | bool | output | read | `0` | RUD TRIM position indicator dashed (powered, no rudder trim position from either FAC; ESTIMATED) |
| `pedestal.rudTrim.display` | string | light | read | `"L 2.3"` | RUD TRIM position indicator ("L 2.3", "R 12.0", "R 0.0", " --.-" dashed: no FAC data, " 88.8" ANN LT TEST, "" = dark: DC BUS 2 unpowered) |
| `pedestal.rudTrim.reset.pressed` | bool | pushbutton | momentary | `0` | RUD TRIM RESET pushbutton (momentary: 1 while held) |
| `pedestal.rudTrim.selector` | int | rotary | write | `0` | RUD TRIM rotary selector (-1 L, 0 neutral, 1 R; spring-loaded: the cockpit writes 0 on release) |
| `pedestal.speedBrake.armed` | bool | switch | write | `0` | SPEED BRAKE lever pulled up at RET: ground spoilers armed (1) |
| `pedestal.speedBrake.lever` | float | analog | write | `0` | SPEED BRAKE lever (0 RET .. 0.5 1/2 .. 1 FULL) |

## Pedestal / GRAVITY GEAR EXTN

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `pedestal.gravityGearExtn` | float | analog | write | `0` | Gravity gear extension hand crank: turns clockwise (0 = stowed / reset, 3 = mechanical stop: gear free fall) |

## Pedestal / MCDU 1

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `ped.mcdu1.brightness` | float | output | read | `0` | MCDU 1 screen brightness (0 = off) |
| `ped.mcdu1.key.0` | bool | pushbutton | momentary | `0` | MCDU 1 key 0 (momentary: 1 while held) |
| `ped.mcdu1.key.1` | bool | pushbutton | momentary | `0` | MCDU 1 key 1 (momentary: 1 while held) |
| `ped.mcdu1.key.2` | bool | pushbutton | momentary | `0` | MCDU 1 key 2 (momentary: 1 while held) |
| `ped.mcdu1.key.3` | bool | pushbutton | momentary | `0` | MCDU 1 key 3 (momentary: 1 while held) |
| `ped.mcdu1.key.4` | bool | pushbutton | momentary | `0` | MCDU 1 key 4 (momentary: 1 while held) |
| `ped.mcdu1.key.5` | bool | pushbutton | momentary | `0` | MCDU 1 key 5 (momentary: 1 while held) |
| `ped.mcdu1.key.6` | bool | pushbutton | momentary | `0` | MCDU 1 key 6 (momentary: 1 while held) |
| `ped.mcdu1.key.7` | bool | pushbutton | momentary | `0` | MCDU 1 key 7 (momentary: 1 while held) |
| `ped.mcdu1.key.8` | bool | pushbutton | momentary | `0` | MCDU 1 key 8 (momentary: 1 while held) |
| `ped.mcdu1.key.9` | bool | pushbutton | momentary | `0` | MCDU 1 key 9 (momentary: 1 while held) |
| `ped.mcdu1.key.a` | bool | pushbutton | momentary | `0` | MCDU 1 key A (momentary: 1 while held) |
| `ped.mcdu1.key.airport` | bool | pushbutton | momentary | `0` | MCDU 1 key AIRPORT (momentary: 1 while held) |
| `ped.mcdu1.key.atccomm` | bool | pushbutton | momentary | `0` | MCDU 1 key ATCCOMM (momentary: 1 while held) |
| `ped.mcdu1.key.b` | bool | pushbutton | momentary | `0` | MCDU 1 key B (momentary: 1 while held) |
| `ped.mcdu1.key.blank1` | bool | pushbutton | momentary | `0` | MCDU 1 blank key, upper function row right of DATA (momentary: 1 while held) |
| `ped.mcdu1.key.blank2` | bool | pushbutton | momentary | `0` | MCDU 1 blank key, right of AIRPORT (momentary: 1 while held) |
| `ped.mcdu1.key.brt` | bool | pushbutton | momentary | `0` | MCDU 1 key BRT (momentary: 1 while held) |
| `ped.mcdu1.key.c` | bool | pushbutton | momentary | `0` | MCDU 1 key C (momentary: 1 while held) |
| `ped.mcdu1.key.clr` | bool | pushbutton | momentary | `0` | MCDU 1 key CLR (momentary: 1 while held) |
| `ped.mcdu1.key.clrLong` | bool | pushbutton | momentary | `0` | MCDU 1 CLR long press (momentary: a rising edge = CLR held, clears the whole entry; for hardware that sends a long-press/repeat signal instead of the release) |
| `ped.mcdu1.key.d` | bool | pushbutton | momentary | `0` | MCDU 1 key D (momentary: 1 while held) |
| `ped.mcdu1.key.data` | bool | pushbutton | momentary | `0` | MCDU 1 key DATA (momentary: 1 while held) |
| `ped.mcdu1.key.dim` | bool | pushbutton | momentary | `0` | MCDU 1 key DIM (momentary: 1 while held) |
| `ped.mcdu1.key.dir` | bool | pushbutton | momentary | `0` | MCDU 1 key DIR (momentary: 1 while held) |
| `ped.mcdu1.key.dot` | bool | pushbutton | momentary | `0` | MCDU 1 key DOT (momentary: 1 while held) |
| `ped.mcdu1.key.down` | bool | pushbutton | momentary | `0` | MCDU 1 key DOWN (momentary: 1 while held) |
| `ped.mcdu1.key.e` | bool | pushbutton | momentary | `0` | MCDU 1 key E (momentary: 1 while held) |
| `ped.mcdu1.key.f` | bool | pushbutton | momentary | `0` | MCDU 1 key F (momentary: 1 while held) |
| `ped.mcdu1.key.fpln` | bool | pushbutton | momentary | `0` | MCDU 1 key FPLN (momentary: 1 while held) |
| `ped.mcdu1.key.fuelpred` | bool | pushbutton | momentary | `0` | MCDU 1 key FUELPRED (momentary: 1 while held) |
| `ped.mcdu1.key.g` | bool | pushbutton | momentary | `0` | MCDU 1 key G (momentary: 1 while held) |
| `ped.mcdu1.key.h` | bool | pushbutton | momentary | `0` | MCDU 1 key H (momentary: 1 while held) |
| `ped.mcdu1.key.i` | bool | pushbutton | momentary | `0` | MCDU 1 key I (momentary: 1 while held) |
| `ped.mcdu1.key.init` | bool | pushbutton | momentary | `0` | MCDU 1 key INIT (momentary: 1 while held) |
| `ped.mcdu1.key.j` | bool | pushbutton | momentary | `0` | MCDU 1 key J (momentary: 1 while held) |
| `ped.mcdu1.key.k` | bool | pushbutton | momentary | `0` | MCDU 1 key K (momentary: 1 while held) |
| `ped.mcdu1.key.l` | bool | pushbutton | momentary | `0` | MCDU 1 key L (momentary: 1 while held) |
| `ped.mcdu1.key.left` | bool | pushbutton | momentary | `0` | MCDU 1 key LEFT (momentary: 1 while held) |
| `ped.mcdu1.key.lsk1l` | bool | pushbutton | momentary | `0` | MCDU 1 key LSK1L (momentary: 1 while held) |
| `ped.mcdu1.key.lsk1r` | bool | pushbutton | momentary | `0` | MCDU 1 key LSK1R (momentary: 1 while held) |
| `ped.mcdu1.key.lsk2l` | bool | pushbutton | momentary | `0` | MCDU 1 key LSK2L (momentary: 1 while held) |
| `ped.mcdu1.key.lsk2r` | bool | pushbutton | momentary | `0` | MCDU 1 key LSK2R (momentary: 1 while held) |
| `ped.mcdu1.key.lsk3l` | bool | pushbutton | momentary | `0` | MCDU 1 key LSK3L (momentary: 1 while held) |
| `ped.mcdu1.key.lsk3r` | bool | pushbutton | momentary | `0` | MCDU 1 key LSK3R (momentary: 1 while held) |
| `ped.mcdu1.key.lsk4l` | bool | pushbutton | momentary | `0` | MCDU 1 key LSK4L (momentary: 1 while held) |
| `ped.mcdu1.key.lsk4r` | bool | pushbutton | momentary | `0` | MCDU 1 key LSK4R (momentary: 1 while held) |
| `ped.mcdu1.key.lsk5l` | bool | pushbutton | momentary | `0` | MCDU 1 key LSK5L (momentary: 1 while held) |
| `ped.mcdu1.key.lsk5r` | bool | pushbutton | momentary | `0` | MCDU 1 key LSK5R (momentary: 1 while held) |
| `ped.mcdu1.key.lsk6l` | bool | pushbutton | momentary | `0` | MCDU 1 key LSK6L (momentary: 1 while held) |
| `ped.mcdu1.key.lsk6r` | bool | pushbutton | momentary | `0` | MCDU 1 key LSK6R (momentary: 1 while held) |
| `ped.mcdu1.key.m` | bool | pushbutton | momentary | `0` | MCDU 1 key M (momentary: 1 while held) |
| `ped.mcdu1.key.menu` | bool | pushbutton | momentary | `0` | MCDU 1 key MENU (momentary: 1 while held) |
| `ped.mcdu1.key.n` | bool | pushbutton | momentary | `0` | MCDU 1 key N (momentary: 1 while held) |
| `ped.mcdu1.key.o` | bool | pushbutton | momentary | `0` | MCDU 1 key O (momentary: 1 while held) |
| `ped.mcdu1.key.ovfy` | bool | pushbutton | momentary | `0` | MCDU 1 key OVFY (momentary: 1 while held) |
| `ped.mcdu1.key.p` | bool | pushbutton | momentary | `0` | MCDU 1 key P (momentary: 1 while held) |
| `ped.mcdu1.key.perf` | bool | pushbutton | momentary | `0` | MCDU 1 key PERF (momentary: 1 while held) |
| `ped.mcdu1.key.plusminus` | bool | pushbutton | momentary | `0` | MCDU 1 key PLUSMINUS (momentary: 1 while held) |
| `ped.mcdu1.key.prog` | bool | pushbutton | momentary | `0` | MCDU 1 key PROG (momentary: 1 while held) |
| `ped.mcdu1.key.q` | bool | pushbutton | momentary | `0` | MCDU 1 key Q (momentary: 1 while held) |
| `ped.mcdu1.key.r` | bool | pushbutton | momentary | `0` | MCDU 1 key R (momentary: 1 while held) |
| `ped.mcdu1.key.radnav` | bool | pushbutton | momentary | `0` | MCDU 1 key RADNAV (momentary: 1 while held) |
| `ped.mcdu1.key.right` | bool | pushbutton | momentary | `0` | MCDU 1 key RIGHT (momentary: 1 while held) |
| `ped.mcdu1.key.s` | bool | pushbutton | momentary | `0` | MCDU 1 key S (momentary: 1 while held) |
| `ped.mcdu1.key.secfpln` | bool | pushbutton | momentary | `0` | MCDU 1 key SECFPLN (momentary: 1 while held) |
| `ped.mcdu1.key.slash` | bool | pushbutton | momentary | `0` | MCDU 1 key SLASH (momentary: 1 while held) |
| `ped.mcdu1.key.sp` | bool | pushbutton | momentary | `0` | MCDU 1 key SP (momentary: 1 while held) |
| `ped.mcdu1.key.t` | bool | pushbutton | momentary | `0` | MCDU 1 key T (momentary: 1 while held) |
| `ped.mcdu1.key.u` | bool | pushbutton | momentary | `0` | MCDU 1 key U (momentary: 1 while held) |
| `ped.mcdu1.key.up` | bool | pushbutton | momentary | `0` | MCDU 1 key UP (momentary: 1 while held) |
| `ped.mcdu1.key.v` | bool | pushbutton | momentary | `0` | MCDU 1 key V (momentary: 1 while held) |
| `ped.mcdu1.key.w` | bool | pushbutton | momentary | `0` | MCDU 1 key W (momentary: 1 while held) |
| `ped.mcdu1.key.x` | bool | pushbutton | momentary | `0` | MCDU 1 key X (momentary: 1 while held) |
| `ped.mcdu1.key.y` | bool | pushbutton | momentary | `0` | MCDU 1 key Y (momentary: 1 while held) |
| `ped.mcdu1.key.z` | bool | pushbutton | momentary | `0` | MCDU 1 key Z (momentary: 1 while held) |
| `ped.mcdu1.light.fail` | bool | light | read | `0` | MCDU 1 FAIL annunciator |
| `ped.mcdu1.light.fm` | bool | light | read | `0` | MCDU 1 FM annunciator |
| `ped.mcdu1.light.fm1` | bool | light | read | `0` | MCDU 1 FM1 annunciator |
| `ped.mcdu1.light.fm2` | bool | light | read | `0` | MCDU 1 FM2 annunciator |
| `ped.mcdu1.light.ind` | bool | light | read | `0` | MCDU 1 IND annunciator |
| `ped.mcdu1.light.menu` | bool | light | read | `0` | MCDU 1 MENU annunciator |
| `ped.mcdu1.light.rdy` | bool | light | read | `0` | MCDU 1 RDY annunciator |
| `ped.mcdu1.line01.color` | string | output | read | `""` | MCDU 1 screen line 1: one letter per character of .text, the color (W white, C cyan, G green, A amber, M magenta, Y yellow, R red), upper case = large font, lower case = small font |
| `ped.mcdu1.line01.text` | string | output | read | `""` | MCDU 1 screen line 1: its 24 monospace characters (blank while the screen is dark; symbols □ ← → ↑ ↓ ° Δ), for hardware that shows text |
| `ped.mcdu1.line02.color` | string | output | read | `""` | MCDU 1 screen line 2: one letter per character of .text, the color (W white, C cyan, G green, A amber, M magenta, Y yellow, R red), upper case = large font, lower case = small font |
| `ped.mcdu1.line02.text` | string | output | read | `""` | MCDU 1 screen line 2: its 24 monospace characters (blank while the screen is dark; symbols □ ← → ↑ ↓ ° Δ), for hardware that shows text |
| `ped.mcdu1.line03.color` | string | output | read | `""` | MCDU 1 screen line 3: one letter per character of .text, the color (W white, C cyan, G green, A amber, M magenta, Y yellow, R red), upper case = large font, lower case = small font |
| `ped.mcdu1.line03.text` | string | output | read | `""` | MCDU 1 screen line 3: its 24 monospace characters (blank while the screen is dark; symbols □ ← → ↑ ↓ ° Δ), for hardware that shows text |
| `ped.mcdu1.line04.color` | string | output | read | `""` | MCDU 1 screen line 4: one letter per character of .text, the color (W white, C cyan, G green, A amber, M magenta, Y yellow, R red), upper case = large font, lower case = small font |
| `ped.mcdu1.line04.text` | string | output | read | `""` | MCDU 1 screen line 4: its 24 monospace characters (blank while the screen is dark; symbols □ ← → ↑ ↓ ° Δ), for hardware that shows text |
| `ped.mcdu1.line05.color` | string | output | read | `""` | MCDU 1 screen line 5: one letter per character of .text, the color (W white, C cyan, G green, A amber, M magenta, Y yellow, R red), upper case = large font, lower case = small font |
| `ped.mcdu1.line05.text` | string | output | read | `""` | MCDU 1 screen line 5: its 24 monospace characters (blank while the screen is dark; symbols □ ← → ↑ ↓ ° Δ), for hardware that shows text |
| `ped.mcdu1.line06.color` | string | output | read | `""` | MCDU 1 screen line 6: one letter per character of .text, the color (W white, C cyan, G green, A amber, M magenta, Y yellow, R red), upper case = large font, lower case = small font |
| `ped.mcdu1.line06.text` | string | output | read | `""` | MCDU 1 screen line 6: its 24 monospace characters (blank while the screen is dark; symbols □ ← → ↑ ↓ ° Δ), for hardware that shows text |
| `ped.mcdu1.line07.color` | string | output | read | `""` | MCDU 1 screen line 7: one letter per character of .text, the color (W white, C cyan, G green, A amber, M magenta, Y yellow, R red), upper case = large font, lower case = small font |
| `ped.mcdu1.line07.text` | string | output | read | `""` | MCDU 1 screen line 7: its 24 monospace characters (blank while the screen is dark; symbols □ ← → ↑ ↓ ° Δ), for hardware that shows text |
| `ped.mcdu1.line08.color` | string | output | read | `""` | MCDU 1 screen line 8: one letter per character of .text, the color (W white, C cyan, G green, A amber, M magenta, Y yellow, R red), upper case = large font, lower case = small font |
| `ped.mcdu1.line08.text` | string | output | read | `""` | MCDU 1 screen line 8: its 24 monospace characters (blank while the screen is dark; symbols □ ← → ↑ ↓ ° Δ), for hardware that shows text |
| `ped.mcdu1.line09.color` | string | output | read | `""` | MCDU 1 screen line 9: one letter per character of .text, the color (W white, C cyan, G green, A amber, M magenta, Y yellow, R red), upper case = large font, lower case = small font |
| `ped.mcdu1.line09.text` | string | output | read | `""` | MCDU 1 screen line 9: its 24 monospace characters (blank while the screen is dark; symbols □ ← → ↑ ↓ ° Δ), for hardware that shows text |
| `ped.mcdu1.line10.color` | string | output | read | `""` | MCDU 1 screen line 10: one letter per character of .text, the color (W white, C cyan, G green, A amber, M magenta, Y yellow, R red), upper case = large font, lower case = small font |
| `ped.mcdu1.line10.text` | string | output | read | `""` | MCDU 1 screen line 10: its 24 monospace characters (blank while the screen is dark; symbols □ ← → ↑ ↓ ° Δ), for hardware that shows text |
| `ped.mcdu1.line11.color` | string | output | read | `""` | MCDU 1 screen line 11: one letter per character of .text, the color (W white, C cyan, G green, A amber, M magenta, Y yellow, R red), upper case = large font, lower case = small font |
| `ped.mcdu1.line11.text` | string | output | read | `""` | MCDU 1 screen line 11: its 24 monospace characters (blank while the screen is dark; symbols □ ← → ↑ ↓ ° Δ), for hardware that shows text |
| `ped.mcdu1.line12.color` | string | output | read | `""` | MCDU 1 screen line 12: one letter per character of .text, the color (W white, C cyan, G green, A amber, M magenta, Y yellow, R red), upper case = large font, lower case = small font |
| `ped.mcdu1.line12.text` | string | output | read | `""` | MCDU 1 screen line 12: its 24 monospace characters (blank while the screen is dark; symbols □ ← → ↑ ↓ ° Δ), for hardware that shows text |
| `ped.mcdu1.line13.color` | string | output | read | `""` | MCDU 1 screen line 13: one letter per character of .text, the color (W white, C cyan, G green, A amber, M magenta, Y yellow, R red), upper case = large font, lower case = small font |
| `ped.mcdu1.line13.text` | string | output | read | `""` | MCDU 1 screen line 13: its 24 monospace characters (blank while the screen is dark; symbols □ ← → ↑ ↓ ° Δ), for hardware that shows text |
| `ped.mcdu1.line14.color` | string | output | read | `""` | MCDU 1 screen line 14: one letter per character of .text, the color (W white, C cyan, G green, A amber, M magenta, Y yellow, R red), upper case = large font, lower case = small font |
| `ped.mcdu1.line14.text` | string | output | read | `""` | MCDU 1 screen line 14: its 24 monospace characters (blank while the screen is dark; symbols □ ← → ↑ ↓ ° Δ), for hardware that shows text |
| `ped.mcdu1.subsystem.aids` | bool | pushbutton | momentary | `0` | MCDU 1 select AIDS (momentary: a rising edge = MCDU MENU then its line select key; for MCDU hardware without an MCDU MENU key) |
| `ped.mcdu1.subsystem.atsu` | bool | pushbutton | momentary | `0` | MCDU 1 select ATSU (momentary: a rising edge = MCDU MENU then its line select key; for MCDU hardware without an MCDU MENU key) |
| `ped.mcdu1.subsystem.cfds` | bool | pushbutton | momentary | `0` | MCDU 1 select CFDS (momentary: a rising edge = MCDU MENU then its line select key; for MCDU hardware without an MCDU MENU key) |
| `ped.mcdu1.subsystem.fmgc` | bool | pushbutton | momentary | `0` | MCDU 1 select FMGC (momentary: a rising edge = MCDU MENU then its line select key; for MCDU hardware without an MCDU MENU key) |

## Pedestal / MCDU 2

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `ped.mcdu2.brightness` | float | output | read | `0` | MCDU 2 screen brightness (0 = off) |
| `ped.mcdu2.key.0` | bool | pushbutton | momentary | `0` | MCDU 2 key 0 (momentary: 1 while held) |
| `ped.mcdu2.key.1` | bool | pushbutton | momentary | `0` | MCDU 2 key 1 (momentary: 1 while held) |
| `ped.mcdu2.key.2` | bool | pushbutton | momentary | `0` | MCDU 2 key 2 (momentary: 1 while held) |
| `ped.mcdu2.key.3` | bool | pushbutton | momentary | `0` | MCDU 2 key 3 (momentary: 1 while held) |
| `ped.mcdu2.key.4` | bool | pushbutton | momentary | `0` | MCDU 2 key 4 (momentary: 1 while held) |
| `ped.mcdu2.key.5` | bool | pushbutton | momentary | `0` | MCDU 2 key 5 (momentary: 1 while held) |
| `ped.mcdu2.key.6` | bool | pushbutton | momentary | `0` | MCDU 2 key 6 (momentary: 1 while held) |
| `ped.mcdu2.key.7` | bool | pushbutton | momentary | `0` | MCDU 2 key 7 (momentary: 1 while held) |
| `ped.mcdu2.key.8` | bool | pushbutton | momentary | `0` | MCDU 2 key 8 (momentary: 1 while held) |
| `ped.mcdu2.key.9` | bool | pushbutton | momentary | `0` | MCDU 2 key 9 (momentary: 1 while held) |
| `ped.mcdu2.key.a` | bool | pushbutton | momentary | `0` | MCDU 2 key A (momentary: 1 while held) |
| `ped.mcdu2.key.airport` | bool | pushbutton | momentary | `0` | MCDU 2 key AIRPORT (momentary: 1 while held) |
| `ped.mcdu2.key.atccomm` | bool | pushbutton | momentary | `0` | MCDU 2 key ATCCOMM (momentary: 1 while held) |
| `ped.mcdu2.key.b` | bool | pushbutton | momentary | `0` | MCDU 2 key B (momentary: 1 while held) |
| `ped.mcdu2.key.blank1` | bool | pushbutton | momentary | `0` | MCDU 2 blank key, upper function row right of DATA (momentary: 1 while held) |
| `ped.mcdu2.key.blank2` | bool | pushbutton | momentary | `0` | MCDU 2 blank key, right of AIRPORT (momentary: 1 while held) |
| `ped.mcdu2.key.brt` | bool | pushbutton | momentary | `0` | MCDU 2 key BRT (momentary: 1 while held) |
| `ped.mcdu2.key.c` | bool | pushbutton | momentary | `0` | MCDU 2 key C (momentary: 1 while held) |
| `ped.mcdu2.key.clr` | bool | pushbutton | momentary | `0` | MCDU 2 key CLR (momentary: 1 while held) |
| `ped.mcdu2.key.clrLong` | bool | pushbutton | momentary | `0` | MCDU 2 CLR long press (momentary: a rising edge = CLR held, clears the whole entry; for hardware that sends a long-press/repeat signal instead of the release) |
| `ped.mcdu2.key.d` | bool | pushbutton | momentary | `0` | MCDU 2 key D (momentary: 1 while held) |
| `ped.mcdu2.key.data` | bool | pushbutton | momentary | `0` | MCDU 2 key DATA (momentary: 1 while held) |
| `ped.mcdu2.key.dim` | bool | pushbutton | momentary | `0` | MCDU 2 key DIM (momentary: 1 while held) |
| `ped.mcdu2.key.dir` | bool | pushbutton | momentary | `0` | MCDU 2 key DIR (momentary: 1 while held) |
| `ped.mcdu2.key.dot` | bool | pushbutton | momentary | `0` | MCDU 2 key DOT (momentary: 1 while held) |
| `ped.mcdu2.key.down` | bool | pushbutton | momentary | `0` | MCDU 2 key DOWN (momentary: 1 while held) |
| `ped.mcdu2.key.e` | bool | pushbutton | momentary | `0` | MCDU 2 key E (momentary: 1 while held) |
| `ped.mcdu2.key.f` | bool | pushbutton | momentary | `0` | MCDU 2 key F (momentary: 1 while held) |
| `ped.mcdu2.key.fpln` | bool | pushbutton | momentary | `0` | MCDU 2 key FPLN (momentary: 1 while held) |
| `ped.mcdu2.key.fuelpred` | bool | pushbutton | momentary | `0` | MCDU 2 key FUELPRED (momentary: 1 while held) |
| `ped.mcdu2.key.g` | bool | pushbutton | momentary | `0` | MCDU 2 key G (momentary: 1 while held) |
| `ped.mcdu2.key.h` | bool | pushbutton | momentary | `0` | MCDU 2 key H (momentary: 1 while held) |
| `ped.mcdu2.key.i` | bool | pushbutton | momentary | `0` | MCDU 2 key I (momentary: 1 while held) |
| `ped.mcdu2.key.init` | bool | pushbutton | momentary | `0` | MCDU 2 key INIT (momentary: 1 while held) |
| `ped.mcdu2.key.j` | bool | pushbutton | momentary | `0` | MCDU 2 key J (momentary: 1 while held) |
| `ped.mcdu2.key.k` | bool | pushbutton | momentary | `0` | MCDU 2 key K (momentary: 1 while held) |
| `ped.mcdu2.key.l` | bool | pushbutton | momentary | `0` | MCDU 2 key L (momentary: 1 while held) |
| `ped.mcdu2.key.left` | bool | pushbutton | momentary | `0` | MCDU 2 key LEFT (momentary: 1 while held) |
| `ped.mcdu2.key.lsk1l` | bool | pushbutton | momentary | `0` | MCDU 2 key LSK1L (momentary: 1 while held) |
| `ped.mcdu2.key.lsk1r` | bool | pushbutton | momentary | `0` | MCDU 2 key LSK1R (momentary: 1 while held) |
| `ped.mcdu2.key.lsk2l` | bool | pushbutton | momentary | `0` | MCDU 2 key LSK2L (momentary: 1 while held) |
| `ped.mcdu2.key.lsk2r` | bool | pushbutton | momentary | `0` | MCDU 2 key LSK2R (momentary: 1 while held) |
| `ped.mcdu2.key.lsk3l` | bool | pushbutton | momentary | `0` | MCDU 2 key LSK3L (momentary: 1 while held) |
| `ped.mcdu2.key.lsk3r` | bool | pushbutton | momentary | `0` | MCDU 2 key LSK3R (momentary: 1 while held) |
| `ped.mcdu2.key.lsk4l` | bool | pushbutton | momentary | `0` | MCDU 2 key LSK4L (momentary: 1 while held) |
| `ped.mcdu2.key.lsk4r` | bool | pushbutton | momentary | `0` | MCDU 2 key LSK4R (momentary: 1 while held) |
| `ped.mcdu2.key.lsk5l` | bool | pushbutton | momentary | `0` | MCDU 2 key LSK5L (momentary: 1 while held) |
| `ped.mcdu2.key.lsk5r` | bool | pushbutton | momentary | `0` | MCDU 2 key LSK5R (momentary: 1 while held) |
| `ped.mcdu2.key.lsk6l` | bool | pushbutton | momentary | `0` | MCDU 2 key LSK6L (momentary: 1 while held) |
| `ped.mcdu2.key.lsk6r` | bool | pushbutton | momentary | `0` | MCDU 2 key LSK6R (momentary: 1 while held) |
| `ped.mcdu2.key.m` | bool | pushbutton | momentary | `0` | MCDU 2 key M (momentary: 1 while held) |
| `ped.mcdu2.key.menu` | bool | pushbutton | momentary | `0` | MCDU 2 key MENU (momentary: 1 while held) |
| `ped.mcdu2.key.n` | bool | pushbutton | momentary | `0` | MCDU 2 key N (momentary: 1 while held) |
| `ped.mcdu2.key.o` | bool | pushbutton | momentary | `0` | MCDU 2 key O (momentary: 1 while held) |
| `ped.mcdu2.key.ovfy` | bool | pushbutton | momentary | `0` | MCDU 2 key OVFY (momentary: 1 while held) |
| `ped.mcdu2.key.p` | bool | pushbutton | momentary | `0` | MCDU 2 key P (momentary: 1 while held) |
| `ped.mcdu2.key.perf` | bool | pushbutton | momentary | `0` | MCDU 2 key PERF (momentary: 1 while held) |
| `ped.mcdu2.key.plusminus` | bool | pushbutton | momentary | `0` | MCDU 2 key PLUSMINUS (momentary: 1 while held) |
| `ped.mcdu2.key.prog` | bool | pushbutton | momentary | `0` | MCDU 2 key PROG (momentary: 1 while held) |
| `ped.mcdu2.key.q` | bool | pushbutton | momentary | `0` | MCDU 2 key Q (momentary: 1 while held) |
| `ped.mcdu2.key.r` | bool | pushbutton | momentary | `0` | MCDU 2 key R (momentary: 1 while held) |
| `ped.mcdu2.key.radnav` | bool | pushbutton | momentary | `0` | MCDU 2 key RADNAV (momentary: 1 while held) |
| `ped.mcdu2.key.right` | bool | pushbutton | momentary | `0` | MCDU 2 key RIGHT (momentary: 1 while held) |
| `ped.mcdu2.key.s` | bool | pushbutton | momentary | `0` | MCDU 2 key S (momentary: 1 while held) |
| `ped.mcdu2.key.secfpln` | bool | pushbutton | momentary | `0` | MCDU 2 key SECFPLN (momentary: 1 while held) |
| `ped.mcdu2.key.slash` | bool | pushbutton | momentary | `0` | MCDU 2 key SLASH (momentary: 1 while held) |
| `ped.mcdu2.key.sp` | bool | pushbutton | momentary | `0` | MCDU 2 key SP (momentary: 1 while held) |
| `ped.mcdu2.key.t` | bool | pushbutton | momentary | `0` | MCDU 2 key T (momentary: 1 while held) |
| `ped.mcdu2.key.u` | bool | pushbutton | momentary | `0` | MCDU 2 key U (momentary: 1 while held) |
| `ped.mcdu2.key.up` | bool | pushbutton | momentary | `0` | MCDU 2 key UP (momentary: 1 while held) |
| `ped.mcdu2.key.v` | bool | pushbutton | momentary | `0` | MCDU 2 key V (momentary: 1 while held) |
| `ped.mcdu2.key.w` | bool | pushbutton | momentary | `0` | MCDU 2 key W (momentary: 1 while held) |
| `ped.mcdu2.key.x` | bool | pushbutton | momentary | `0` | MCDU 2 key X (momentary: 1 while held) |
| `ped.mcdu2.key.y` | bool | pushbutton | momentary | `0` | MCDU 2 key Y (momentary: 1 while held) |
| `ped.mcdu2.key.z` | bool | pushbutton | momentary | `0` | MCDU 2 key Z (momentary: 1 while held) |
| `ped.mcdu2.light.fail` | bool | light | read | `0` | MCDU 2 FAIL annunciator |
| `ped.mcdu2.light.fm` | bool | light | read | `0` | MCDU 2 FM annunciator |
| `ped.mcdu2.light.fm1` | bool | light | read | `0` | MCDU 2 FM1 annunciator |
| `ped.mcdu2.light.fm2` | bool | light | read | `0` | MCDU 2 FM2 annunciator |
| `ped.mcdu2.light.ind` | bool | light | read | `0` | MCDU 2 IND annunciator |
| `ped.mcdu2.light.menu` | bool | light | read | `0` | MCDU 2 MENU annunciator |
| `ped.mcdu2.light.rdy` | bool | light | read | `0` | MCDU 2 RDY annunciator |
| `ped.mcdu2.line01.color` | string | output | read | `""` | MCDU 2 screen line 1: one letter per character of .text, the color (W white, C cyan, G green, A amber, M magenta, Y yellow, R red), upper case = large font, lower case = small font |
| `ped.mcdu2.line01.text` | string | output | read | `""` | MCDU 2 screen line 1: its 24 monospace characters (blank while the screen is dark; symbols □ ← → ↑ ↓ ° Δ), for hardware that shows text |
| `ped.mcdu2.line02.color` | string | output | read | `""` | MCDU 2 screen line 2: one letter per character of .text, the color (W white, C cyan, G green, A amber, M magenta, Y yellow, R red), upper case = large font, lower case = small font |
| `ped.mcdu2.line02.text` | string | output | read | `""` | MCDU 2 screen line 2: its 24 monospace characters (blank while the screen is dark; symbols □ ← → ↑ ↓ ° Δ), for hardware that shows text |
| `ped.mcdu2.line03.color` | string | output | read | `""` | MCDU 2 screen line 3: one letter per character of .text, the color (W white, C cyan, G green, A amber, M magenta, Y yellow, R red), upper case = large font, lower case = small font |
| `ped.mcdu2.line03.text` | string | output | read | `""` | MCDU 2 screen line 3: its 24 monospace characters (blank while the screen is dark; symbols □ ← → ↑ ↓ ° Δ), for hardware that shows text |
| `ped.mcdu2.line04.color` | string | output | read | `""` | MCDU 2 screen line 4: one letter per character of .text, the color (W white, C cyan, G green, A amber, M magenta, Y yellow, R red), upper case = large font, lower case = small font |
| `ped.mcdu2.line04.text` | string | output | read | `""` | MCDU 2 screen line 4: its 24 monospace characters (blank while the screen is dark; symbols □ ← → ↑ ↓ ° Δ), for hardware that shows text |
| `ped.mcdu2.line05.color` | string | output | read | `""` | MCDU 2 screen line 5: one letter per character of .text, the color (W white, C cyan, G green, A amber, M magenta, Y yellow, R red), upper case = large font, lower case = small font |
| `ped.mcdu2.line05.text` | string | output | read | `""` | MCDU 2 screen line 5: its 24 monospace characters (blank while the screen is dark; symbols □ ← → ↑ ↓ ° Δ), for hardware that shows text |
| `ped.mcdu2.line06.color` | string | output | read | `""` | MCDU 2 screen line 6: one letter per character of .text, the color (W white, C cyan, G green, A amber, M magenta, Y yellow, R red), upper case = large font, lower case = small font |
| `ped.mcdu2.line06.text` | string | output | read | `""` | MCDU 2 screen line 6: its 24 monospace characters (blank while the screen is dark; symbols □ ← → ↑ ↓ ° Δ), for hardware that shows text |
| `ped.mcdu2.line07.color` | string | output | read | `""` | MCDU 2 screen line 7: one letter per character of .text, the color (W white, C cyan, G green, A amber, M magenta, Y yellow, R red), upper case = large font, lower case = small font |
| `ped.mcdu2.line07.text` | string | output | read | `""` | MCDU 2 screen line 7: its 24 monospace characters (blank while the screen is dark; symbols □ ← → ↑ ↓ ° Δ), for hardware that shows text |
| `ped.mcdu2.line08.color` | string | output | read | `""` | MCDU 2 screen line 8: one letter per character of .text, the color (W white, C cyan, G green, A amber, M magenta, Y yellow, R red), upper case = large font, lower case = small font |
| `ped.mcdu2.line08.text` | string | output | read | `""` | MCDU 2 screen line 8: its 24 monospace characters (blank while the screen is dark; symbols □ ← → ↑ ↓ ° Δ), for hardware that shows text |
| `ped.mcdu2.line09.color` | string | output | read | `""` | MCDU 2 screen line 9: one letter per character of .text, the color (W white, C cyan, G green, A amber, M magenta, Y yellow, R red), upper case = large font, lower case = small font |
| `ped.mcdu2.line09.text` | string | output | read | `""` | MCDU 2 screen line 9: its 24 monospace characters (blank while the screen is dark; symbols □ ← → ↑ ↓ ° Δ), for hardware that shows text |
| `ped.mcdu2.line10.color` | string | output | read | `""` | MCDU 2 screen line 10: one letter per character of .text, the color (W white, C cyan, G green, A amber, M magenta, Y yellow, R red), upper case = large font, lower case = small font |
| `ped.mcdu2.line10.text` | string | output | read | `""` | MCDU 2 screen line 10: its 24 monospace characters (blank while the screen is dark; symbols □ ← → ↑ ↓ ° Δ), for hardware that shows text |
| `ped.mcdu2.line11.color` | string | output | read | `""` | MCDU 2 screen line 11: one letter per character of .text, the color (W white, C cyan, G green, A amber, M magenta, Y yellow, R red), upper case = large font, lower case = small font |
| `ped.mcdu2.line11.text` | string | output | read | `""` | MCDU 2 screen line 11: its 24 monospace characters (blank while the screen is dark; symbols □ ← → ↑ ↓ ° Δ), for hardware that shows text |
| `ped.mcdu2.line12.color` | string | output | read | `""` | MCDU 2 screen line 12: one letter per character of .text, the color (W white, C cyan, G green, A amber, M magenta, Y yellow, R red), upper case = large font, lower case = small font |
| `ped.mcdu2.line12.text` | string | output | read | `""` | MCDU 2 screen line 12: its 24 monospace characters (blank while the screen is dark; symbols □ ← → ↑ ↓ ° Δ), for hardware that shows text |
| `ped.mcdu2.line13.color` | string | output | read | `""` | MCDU 2 screen line 13: one letter per character of .text, the color (W white, C cyan, G green, A amber, M magenta, Y yellow, R red), upper case = large font, lower case = small font |
| `ped.mcdu2.line13.text` | string | output | read | `""` | MCDU 2 screen line 13: its 24 monospace characters (blank while the screen is dark; symbols □ ← → ↑ ↓ ° Δ), for hardware that shows text |
| `ped.mcdu2.line14.color` | string | output | read | `""` | MCDU 2 screen line 14: one letter per character of .text, the color (W white, C cyan, G green, A amber, M magenta, Y yellow, R red), upper case = large font, lower case = small font |
| `ped.mcdu2.line14.text` | string | output | read | `""` | MCDU 2 screen line 14: its 24 monospace characters (blank while the screen is dark; symbols □ ← → ↑ ↓ ° Δ), for hardware that shows text |
| `ped.mcdu2.subsystem.aids` | bool | pushbutton | momentary | `0` | MCDU 2 select AIDS (momentary: a rising edge = MCDU MENU then its line select key; for MCDU hardware without an MCDU MENU key) |
| `ped.mcdu2.subsystem.atsu` | bool | pushbutton | momentary | `0` | MCDU 2 select ATSU (momentary: a rising edge = MCDU MENU then its line select key; for MCDU hardware without an MCDU MENU key) |
| `ped.mcdu2.subsystem.cfds` | bool | pushbutton | momentary | `0` | MCDU 2 select CFDS (momentary: a rising edge = MCDU MENU then its line select key; for MCDU hardware without an MCDU MENU key) |
| `ped.mcdu2.subsystem.fmgc` | bool | pushbutton | momentary | `0` | MCDU 2 select FMGC (momentary: a rising edge = MCDU MENU then its line select key; for MCDU hardware without an MCDU MENU key) |

## Pedestal / PARKING BRK

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `pedestal.parkingBrake.set` | bool | switch | write | `0` | PARK BRK handle (1 = ON) |

## Pedestal / PRINTER

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `pedestal.printer.slew.pressed` | bool | pushbutton | momentary | `0` | Printer SLEW switch (momentary: feeds paper while held) |
| `printer.jobCount` | int | output | read | `0` | Printouts since Systems started (+1 at every print; the Hardware Printer devices fetch them) |
| `printer.powered` | bool | output | read | `0` | Cockpit printer powered (C/B 6TW PTR SPLY, AC BUS 1) |

## Pedestal / RMP 1

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `pedestal.rmp1.active` | string | light | read | `"122.800"` | RMP 1 ACTIVE window ("122.800", "110.30", "415", "" dark) |
| `pedestal.rmp1.adf.on` | bool | light | read | `0` | RMP 1 ADF green light |
| `pedestal.rmp1.adf.pressed` | bool | pushbutton | momentary | `0` | RMP 1 ADF key (momentary) |
| `pedestal.rmp1.am.on` | bool | light | read | `0` | RMP 1 AM green light |
| `pedestal.rmp1.am.pressed` | bool | pushbutton | momentary | `0` | RMP 1 AM key (momentary) |
| `pedestal.rmp1.bfo.on` | bool | light | read | `0` | RMP 1 BFO green light |
| `pedestal.rmp1.bfo.pressed` | bool | pushbutton | momentary | `0` | RMP 1 BFO key (momentary) |
| `pedestal.rmp1.hf1.on` | bool | light | read | `0` | RMP 1 HF 1 green light |
| `pedestal.rmp1.hf1.pressed` | bool | pushbutton | momentary | `0` | RMP 1 HF 1 key (momentary) |
| `pedestal.rmp1.hf2.on` | bool | light | read | `0` | RMP 1 HF 2 green light |
| `pedestal.rmp1.hf2.pressed` | bool | pushbutton | momentary | `0` | RMP 1 HF 2 key (momentary) |
| `pedestal.rmp1.ils.on` | bool | light | read | `0` | RMP 1 ILS green light |
| `pedestal.rmp1.ils.pressed` | bool | pushbutton | momentary | `0` | RMP 1 ILS key (momentary) |
| `pedestal.rmp1.innerKnob` | int | encoder | write | `0` | RMP 1 inner tuning knob counter (+1 per clockwise detent) |
| `pedestal.rmp1.mls.on` | bool | light | read | `0` | RMP 1 MLS green light |
| `pedestal.rmp1.mls.pressed` | bool | pushbutton | momentary | `0` | RMP 1 MLS key (momentary) |
| `pedestal.rmp1.nav.on` | bool | light | read | `0` | RMP 1 NAV (guarded) green light |
| `pedestal.rmp1.nav.pressed` | bool | pushbutton | momentary | `0` | RMP 1 NAV (guarded) key (momentary) |
| `pedestal.rmp1.outerKnob` | int | encoder | write | `0` | RMP 1 outer tuning knob counter (+1 per clockwise detent) |
| `pedestal.rmp1.power` | bool | switch | write | `0` | RMP 1 ON/OFF switch (1 = ON) |
| `pedestal.rmp1.sel` | bool | light | read | `0` | RMP 1 SEL amber light |
| `pedestal.rmp1.standby` | string | light | read | `"121.500"` | RMP 1 STBY/CRS window ("121.500", "C-123", "" dark) |
| `pedestal.rmp1.transfer.on` | bool | light | read | `0` | RMP 1 transfer green light |
| `pedestal.rmp1.transfer.pressed` | bool | pushbutton | momentary | `0` | RMP 1 transfer key (momentary) |
| `pedestal.rmp1.vhf1.on` | bool | light | read | `0` | RMP 1 VHF 1 green light |
| `pedestal.rmp1.vhf1.pressed` | bool | pushbutton | momentary | `0` | RMP 1 VHF 1 key (momentary) |
| `pedestal.rmp1.vhf2.on` | bool | light | read | `0` | RMP 1 VHF 2 green light |
| `pedestal.rmp1.vhf2.pressed` | bool | pushbutton | momentary | `0` | RMP 1 VHF 2 key (momentary) |
| `pedestal.rmp1.vhf3.on` | bool | light | read | `0` | RMP 1 VHF 3 green light |
| `pedestal.rmp1.vhf3.pressed` | bool | pushbutton | momentary | `0` | RMP 1 VHF 3 key (momentary) |
| `pedestal.rmp1.vor.on` | bool | light | read | `0` | RMP 1 VOR green light |
| `pedestal.rmp1.vor.pressed` | bool | pushbutton | momentary | `0` | RMP 1 VOR key (momentary) |

## Pedestal / RMP 2

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `pedestal.rmp2.active` | string | light | read | `"122.800"` | RMP 2 ACTIVE window ("122.800", "110.30", "415", "" dark) |
| `pedestal.rmp2.adf.on` | bool | light | read | `0` | RMP 2 ADF green light |
| `pedestal.rmp2.adf.pressed` | bool | pushbutton | momentary | `0` | RMP 2 ADF key (momentary) |
| `pedestal.rmp2.am.on` | bool | light | read | `0` | RMP 2 AM green light |
| `pedestal.rmp2.am.pressed` | bool | pushbutton | momentary | `0` | RMP 2 AM key (momentary) |
| `pedestal.rmp2.bfo.on` | bool | light | read | `0` | RMP 2 BFO green light |
| `pedestal.rmp2.bfo.pressed` | bool | pushbutton | momentary | `0` | RMP 2 BFO key (momentary) |
| `pedestal.rmp2.hf1.on` | bool | light | read | `0` | RMP 2 HF 1 green light |
| `pedestal.rmp2.hf1.pressed` | bool | pushbutton | momentary | `0` | RMP 2 HF 1 key (momentary) |
| `pedestal.rmp2.hf2.on` | bool | light | read | `0` | RMP 2 HF 2 green light |
| `pedestal.rmp2.hf2.pressed` | bool | pushbutton | momentary | `0` | RMP 2 HF 2 key (momentary) |
| `pedestal.rmp2.ils.on` | bool | light | read | `0` | RMP 2 ILS green light |
| `pedestal.rmp2.ils.pressed` | bool | pushbutton | momentary | `0` | RMP 2 ILS key (momentary) |
| `pedestal.rmp2.innerKnob` | int | encoder | write | `0` | RMP 2 inner tuning knob counter (+1 per clockwise detent) |
| `pedestal.rmp2.mls.on` | bool | light | read | `0` | RMP 2 MLS green light |
| `pedestal.rmp2.mls.pressed` | bool | pushbutton | momentary | `0` | RMP 2 MLS key (momentary) |
| `pedestal.rmp2.nav.on` | bool | light | read | `0` | RMP 2 NAV (guarded) green light |
| `pedestal.rmp2.nav.pressed` | bool | pushbutton | momentary | `0` | RMP 2 NAV (guarded) key (momentary) |
| `pedestal.rmp2.outerKnob` | int | encoder | write | `0` | RMP 2 outer tuning knob counter (+1 per clockwise detent) |
| `pedestal.rmp2.power` | bool | switch | write | `0` | RMP 2 ON/OFF switch (1 = ON) |
| `pedestal.rmp2.sel` | bool | light | read | `0` | RMP 2 SEL amber light |
| `pedestal.rmp2.standby` | string | light | read | `"121.500"` | RMP 2 STBY/CRS window ("121.500", "C-123", "" dark) |
| `pedestal.rmp2.transfer.on` | bool | light | read | `0` | RMP 2 transfer green light |
| `pedestal.rmp2.transfer.pressed` | bool | pushbutton | momentary | `0` | RMP 2 transfer key (momentary) |
| `pedestal.rmp2.vhf1.on` | bool | light | read | `0` | RMP 2 VHF 1 green light |
| `pedestal.rmp2.vhf1.pressed` | bool | pushbutton | momentary | `0` | RMP 2 VHF 1 key (momentary) |
| `pedestal.rmp2.vhf2.on` | bool | light | read | `0` | RMP 2 VHF 2 green light |
| `pedestal.rmp2.vhf2.pressed` | bool | pushbutton | momentary | `0` | RMP 2 VHF 2 key (momentary) |
| `pedestal.rmp2.vhf3.on` | bool | light | read | `0` | RMP 2 VHF 3 green light |
| `pedestal.rmp2.vhf3.pressed` | bool | pushbutton | momentary | `0` | RMP 2 VHF 3 key (momentary) |
| `pedestal.rmp2.vor.on` | bool | light | read | `0` | RMP 2 VOR green light |
| `pedestal.rmp2.vor.pressed` | bool | pushbutton | momentary | `0` | RMP 2 VOR key (momentary) |

## Pedestal / SWITCHING

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `pedestal.switching.airData` | int | rotary | write | `0` | AIR DATA selector (0 = CAPT 3, 1 = NORM, 2 = F/O 3) |
| `pedestal.switching.attHdg` | int | rotary | write | `0` | ATT HDG selector (0 = CAPT 3, 1 = NORM, 2 = F/O 3) |
| `pedestal.switching.ecamNdXfr` | int | rotary | write | `0` | ECAM/ND XFR selector (0 = CAPT, 1 = NORM, 2 = F/O) |
| `pedestal.switching.eisDmc` | int | rotary | write | `0` | EIS DMC selector (0 = CAPT 3, 1 = NORM, 2 = F/O 3) |

## Pedestal / THRUST LEVERS

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `pedestal.thrust.athrDisc1.pressed` | bool | pushbutton | momentary | `0` | A/THR instinctive disconnect pushbutton on thrust lever 1 (momentary: 1 while held) |
| `pedestal.thrust.athrDisc2.pressed` | bool | pushbutton | momentary | `0` | A/THR instinctive disconnect pushbutton on thrust lever 2 (momentary: 1 while held) |
| `pedestal.thrust.lever1` | float | analog | write | `0` | Thrust lever 1 angle (TLA, degrees): -20 MAX REV, 0 IDLE, 25 CL, 35 FLX/MCT, 45 TO/GA |
| `pedestal.thrust.lever2` | float | analog | write | `0` | Thrust lever 2 angle (TLA, degrees): -20 MAX REV, 0 IDLE, 25 CL, 35 FLX/MCT, 45 TO/GA |

## Pedestal / WEATHER RADAR

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `pedestal.wxr.gain` | int | rotary | write | `0` | GAIN knob: 0 = MIN, 1 = -12, 2 = -9, 3 = -6, 4 = -3, 5 = CAL, 6 = +4, 7 = +8, 8 = +12, 9 = MAX |
| `pedestal.wxr.gcs` | int | switch | write | `0` | GCS switch (spring-loaded to AUTO): 0 = OFF (held), 1 = AUTO |
| `pedestal.wxr.mode` | int | rotary | write | `0` | MODE selector: 0 = WX, 1 = WX+T, 2 = TURB, 3 = MAP |
| `pedestal.wxr.multiscan` | int | switch | write | `0` | MULTISCAN switch: 0 = MAN, 1 = AUTO |
| `pedestal.wxr.pws` | int | switch | write | `0` | PWS switch: 0 = OFF, 1 = AUTO |
| `pedestal.wxr.sys` | int | switch | write | `0` | Radar SYS switch: 1 = SYS 1 on, 0 = OFF, 2 = SYS 2 on |
| `pedestal.wxr.tilt` | float | analog | write | `0` | TILT knob (degrees, -15 DN .. +15 UP, quarter degree steps; MULTISCAN MAN) |

## Performance

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `perf.load.blockKg` | float | output | read | `0` | Block fuel of the applied load (kg) |
| `perf.load.zfwCgMac` | float | output | read | `0` | ZFW CG of the applied load (% MAC) |
| `perf.load.zfwKg` | float | output | read | `0` | ZFW of the applied load (kg) |
| `perf.loadMatches` | bool | output | read | `0` | The aircraft is loaded as applied (ZFW, ZFW CG and fuel) |
| `perf.mcdu.block` | string | output | read | `"9.0"` | INIT B BLOCK entry of the applied load ("9.0") |
| `perf.mcdu.flapsThs` | string | output | read | `"1/UP0.8"` | PERF TAKE OFF FLAPS/THS entry ("1/UP0.8") |
| `perf.mcdu.flex` | string | output | read | `"66"` | PERF TAKE OFF FLEX TO TEMP entry ("66"; "" with TOGA) |
| `perf.mcdu.toShift` | string | output | read | `""` | PERF TAKE OFF TO SHIFT entry (m; "" without a shift) |
| `perf.mcdu.zfwZfwCg` | string | output | read | `"62.4/27.5"` | INIT B ZFW/ZFWCG entry of the applied load ("62.4/27.5") |
| `perf.to.airport` | string | output | read | `""` | Airport of the applied takeoff performance |
| `perf.to.condition` | string | output | read | `"dry"` | Runway condition of the takeoff performance kept ("dry", "wet", "standingWater", "slush", "wetSnow", "drySnow", "compactedSnow"; "" none) |
| `perf.to.conf` | int | output | read | `0` | Takeoff CONF (1 = 1+F, 2, 3) |
| `perf.to.depthMm` | float | output | read | `0` | Contaminant depth of the takeoff performance kept (mm, 0 = none) |
| `perf.to.flexTempC` | int | output | read | `0` | Calculated FLEX temperature (°C, -99 = TOGA) |
| `perf.to.limiting` | string | output | read | `"runwayLength"` | What limits the takeoff weight of the performance kept ("runwayLength", "brakeEnergy", "vmu", "contaminated", "tireSpeed", ...; "" none) |
| `perf.to.runway` | string | output | read | `""` | Runway of the applied takeoff performance |
| `perf.to.rwycc` | int | output | read | `-1` | ICAO runway condition code of the takeoff performance kept (6 dry … 1; -1 none) |
| `perf.to.shiftM` | float | output | read | `0` | Takeoff shift of the calculation (m, 0 = none) |
| `perf.to.status` | string | output | read | `" none asked, "` | Why a takeoff performance is (not) kept: "" none asked, "kept", "noRunway" (load applied without a runway), "errors" |
| `perf.to.thsDeg` | float | output | read | `0` | Takeoff trim (THS °, + UP) |
| `perf.to.towKg` | float | output | read | `0` | Takeoff weight of the calculation (kg) |
| `perf.to.v1` | int | output | read | `0` | Calculated V1 (kt) |
| `perf.to.v2` | int | output | read | `0` | Calculated V2 (kt) |
| `perf.to.valid` | bool | output | read | `0` | A takeoff performance was applied with the load |
| `perf.to.vr` | int | output | read | `0` | Calculated VR (kt) |
| `perf.wx.oatC` | float | output | read | `0` | Outside air temperature at the aircraft (°C) |
| `perf.wx.qnhHpa` | float | output | read | `0` | QNH at the aircraft (hPa, from the static pressure and the altitude) |
| `perf.wx.valid` | bool | output | read | `0` | Simulator weather available |
| `perf.wx.windDirDeg` | float | output | read | `0` | Wind direction at the aircraft (° magnetic, from) |
| `perf.wx.windKt` | float | output | read | `0` | Wind speed at the aircraft (kt) |

## Radio (receivers)

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `radio.adf1.frequencyKhz` | int | output | read | `0` | ADF 1 tuned frequency (kHz) |
| `radio.adf1.ident` | string | output | read | `""` | ADF 1 received station ident ("" = no station received): the Morse ident Audio plays |
| `radio.adf1.relativeBearingDeg` | float | output | read | `0` | ADF 1 relative bearing (-1 without signal) |
| `radio.adf2.frequencyKhz` | int | output | read | `0` | ADF 2 tuned frequency (kHz) |
| `radio.adf2.ident` | string | output | read | `""` | ADF 2 received station ident ("" = no station received): the Morse ident Audio plays |
| `radio.adf2.relativeBearingDeg` | float | output | read | `0` | ADF 2 relative bearing (-1 without signal) |
| `radio.dme1.distanceNm` | float | output | read | `0` | DME 1 distance (NM, -1 without signal) |
| `radio.dme1.ident` | string | output | read | `""` | DME 1 received station ident ("" = no station received): the Morse ident Audio plays |
| `radio.dme2.distanceNm` | float | output | read | `0` | DME 2 distance (NM, -1 without signal) |
| `radio.dme2.ident` | string | output | read | `""` | DME 2 received station ident ("" = no station received): the Morse ident Audio plays |
| `radio.marker` | int | output | read | `0` | Marker beacon received (0 none, 1 outer, 2 middle, 3 inner) |
| `radio.mmr1.frequencyKhz` | int | output | read | `0` | MMR 1 ILS tuned frequency (kHz), or the GLS channel (20001..39999, GLS option; radio.mmr1.gls) |
| `radio.mmr1.gls` | bool | output | read | `0` | MMR 1 in GLS mode (GLS option, a GLS channel tuned): the LOC / G/S deviations are the GLS lateral / vertical ones |
| `radio.mmr1.gsDeviationDots` | float | output | read | `0` | MMR 1 G/S deviation (dots, + = fly up; 0 without signal) |
| `radio.mmr1.gsValid` | bool | output | read | `0` | MMR 1 G/S received (deviation valid) |
| `radio.mmr1.ident` | string | output | read | `""` | MMR 1 received station ident ("" = no station received): the Morse ident Audio plays |
| `radio.mmr1.locDeviationDots` | float | output | read | `0` | MMR 1 LOC deviation (dots, + = fly right; NaN-free, 0 without signal) |
| `radio.mmr1.locValid` | bool | output | read | `0` | MMR 1 LOC received (deviation valid; radio.mmr1.ident is the station's while true) |
| `radio.mmr2.frequencyKhz` | int | output | read | `0` | MMR 2 ILS tuned frequency (kHz), or the GLS channel (20001..39999, GLS option; radio.mmr2.gls) |
| `radio.mmr2.gls` | bool | output | read | `0` | MMR 2 in GLS mode (GLS option, a GLS channel tuned): the LOC / G/S deviations are the GLS lateral / vertical ones |
| `radio.mmr2.gsDeviationDots` | float | output | read | `0` | MMR 2 G/S deviation (dots, + = fly up; 0 without signal) |
| `radio.mmr2.gsValid` | bool | output | read | `0` | MMR 2 G/S received (deviation valid) |
| `radio.mmr2.ident` | string | output | read | `""` | MMR 2 received station ident ("" = no station received): the Morse ident Audio plays |
| `radio.mmr2.locDeviationDots` | float | output | read | `0` | MMR 2 LOC deviation (dots, + = fly right; NaN-free, 0 without signal) |
| `radio.mmr2.locValid` | bool | output | read | `0` | MMR 2 LOC received (deviation valid; radio.mmr2.ident is the station's while true) |
| `radio.ra1.heightFt` | float | output | read | `0` | Radio altimeter 1 height (ft, -1 invalid or above its 5000 ft range) |
| `radio.ra2.heightFt` | float | output | read | `0` | Radio altimeter 2 height (ft, -1 invalid or above its 5000 ft range) |
| `radio.vhf1.active` | string | output | read | `"122.800"` | VHF 1 active frequency ("122.800") |
| `radio.vhf1.standby` | string | output | read | `""` | VHF 1 standby frequency |
| `radio.vhf1.tuneActiveKhz` | float | analog | write | `0` | VHF 1 tuned by an external RMP (its ARINC 429 output): a new value (kHz, 118000..136990; MHz accepted) becomes the active frequency; 0 = none |
| `radio.vhf1.tuneStandbyKhz` | float | analog | write | `0` | VHF 1 standby frequency from an external RMP: a new value (kHz; MHz accepted) becomes the standby frequency; 0 = none |
| `radio.vhf2.active` | string | output | read | `"122.800"` | VHF 2 active frequency ("122.800") |
| `radio.vhf2.standby` | string | output | read | `""` | VHF 2 standby frequency |
| `radio.vhf2.tuneActiveKhz` | float | analog | write | `0` | VHF 2 tuned by an external RMP (its ARINC 429 output): a new value (kHz, 118000..136990; MHz accepted) becomes the active frequency; 0 = none |
| `radio.vhf2.tuneStandbyKhz` | float | analog | write | `0` | VHF 2 standby frequency from an external RMP: a new value (kHz; MHz accepted) becomes the standby frequency; 0 = none |
| `radio.vhf3.active` | string | output | read | `"122.800"` | VHF 3 active frequency ("122.800") |
| `radio.vhf3.dataMode` | bool | switch | write | `0` | VHF 3 data / voice for external panels: write 1 = DATA (DATA active, the voice frequency to STBY), 0 = voice (the STBY frequency, else the last voice one, else 118.000, active; DATA to STBY); reads the current mode |
| `radio.vhf3.standby` | string | output | read | `""` | VHF 3 standby frequency |
| `radio.vhf3.tuneActiveKhz` | float | analog | write | `0` | VHF 3 tuned by an external RMP (its ARINC 429 output): a new value (kHz, 118000..136990; MHz accepted) becomes the active frequency; 0 = none |
| `radio.vhf3.tuneStandbyKhz` | float | analog | write | `0` | VHF 3 standby frequency from an external RMP: a new value (kHz; MHz accepted) becomes the standby frequency; 0 = none |
| `radio.vor1.bearingDeg` | float | output | read | `0` | VOR 1 bearing to the station (magnetic, -1 without signal) |
| `radio.vor1.frequencyKhz` | int | output | read | `0` | VOR 1 tuned frequency (kHz, 0 = none) |
| `radio.vor1.ident` | string | output | read | `""` | VOR 1 received station ident ("" = no station received): the Morse ident Audio plays |
| `radio.vor2.bearingDeg` | float | output | read | `0` | VOR 2 bearing to the station (magnetic, -1 without signal) |
| `radio.vor2.frequencyKhz` | int | output | read | `0` | VOR 2 tuned frequency (kHz, 0 = none) |
| `radio.vor2.ident` | string | output | read | `""` | VOR 2 received station ident ("" = no station received): the Morse ident Audio plays |

## Radio (simulator)

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `radio.sim.com1Vhf` | int | output | read | `0` | VHF carried by the simulator's COM 1 (1..3; network clients such as xPilot see it) |
| `radio.sim.com2Vhf` | int | output | read | `0` | VHF carried by the simulator's COM 2 (1..3; VHF 3 when the captain's ACP needs it more than VHF 2 / VHF 1) |
| `radio.sim.transmitCom` | int | output | read | `0` | Simulator COM selected to transmit (0 none / unchanged, 1 COM 1, 2 COM 2): the captain's ACP transmission key |
| `radio.sim.voiceThroughAmu` | bool | service | write | `0` | The radio client's voice (xPilot, SayIntentions...) is captured by the Audio program into the AMU VHF channels: the simulator's COM 1 / 2 always receive at full volume and the AMU applies each crew station's ACP knobs (Audio writes it) |

## Radio (transmission)

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `calls.cabinCall` | int | output | read | `0` | Cabin calls to the cockpit received from the CIDS (counter, +1 per call, wraps at 65536; the sound is the cockpit buzzer) |
| `calls.cockpitBuzzer` | bool | output | read | `0` | Cockpit call buzzer sounding (ground mechanic call held, or the CIDS cabin call buzzer) |
| `calls.selcal` | bool | output | read | `0` | SELCAL buzzer sounding (continuous from a decoded call until ACP RESET or MASTER CAUT; silent in FWC phases 3-5 and 7-8) |
| `radio.selcal.tones` | int | output | read | `0` | SELCAL tones received (counter, +1 per call heard on a working receiver, wraps at 65536): Audio plays them on that channel |
| `radio.selcal.tonesChannel` | int | output | read | `0` | AMU channel of the last SELCAL tones (1..3 VHF n, 4..5 HF n) |
| `radio.selcal.tonesCode` | string | output | read | `"AB-CD"` | Code of the last SELCAL tones ("AB-CD") |
| `radio.serviceInterphone.active` | bool | output | read | `0` | Service interphone jacks connected (SVCE INT OVRD ON, or AUTO with the gear compressed for 10 s; a CIDS director working) |
| `radio.vhf1.transmitting` | bool | output | read | `0` | VHF 1 transceiver keyed (transmitting) |
| `radio.vhf2.transmitting` | bool | output | read | `0` | VHF 2 transceiver keyed (transmitting) |
| `radio.vhf3.transmitting` | bool | output | read | `0` | VHF 3 transceiver keyed (transmitting) |

## Rain removal

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `rainRepellent.capt.coating` | float | output | read | `0` | Captain side rain repellent film on the windshield (0 none .. 1 covered) |
| `rainRepellent.capt.spraying` | bool | output | read | `0` | Captain rain repellent solenoid valve open (spraying) |
| `rainRepellent.fo.coating` | float | output | read | `0` | First officer side rain repellent film on the windshield (0 none .. 1 covered) |
| `rainRepellent.fo.spraying` | bool | output | read | `0` | First officer rain repellent solenoid valve open (spraying) |
| `wipers.capt.position` | float | output | read | `0` | Captain wiper blade position (0 parked out of view .. 1 far end of the sweep) |
| `wipers.capt.running` | bool | output | read | `0` | Captain wiper motor running |
| `wipers.capt.speed` | int | output | read | `0` | Captain wiper motor speed (0 stopped, 1 slow, 2 fast) |
| `wipers.fo.position` | float | output | read | `0` | First officer wiper blade position (0 parked out of view .. 1 far end of the sweep) |
| `wipers.fo.running` | bool | output | read | `0` | First officer wiper motor running |
| `wipers.fo.speed` | int | output | read | `0` | First officer wiper motor speed (0 stopped, 1 slow, 2 fast) |
| `wshld.birdSplatL` | int | output | read | `0` | Captain windshield bird remains decal (0 clean, 1..4 the variant shown; the failure WSHLD.BIRD_SPLAT_L) |
| `wshld.birdSplatR` | int | output | read | `0` | First officer windshield bird remains decal (0 clean, 1..4 the variant shown; the failure WSHLD.BIRD_SPLAT_R) |

## Recorders

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `rcdr.cvr.eraseCount` | int | output | read | `0` | CVR erasures done (counter, +1 per CVR ERASE held 2 s with the conditions met; nothing is really recorded) |
| `rcdr.cvr.recording` | bool | output | read | `0` | CVR energized (recording) |
| `rcdr.cvr.testTone` | bool | output | read | `0` | CVR test tone through the cockpit loudspeakers (CVR TEST held, test conditions met; Audio plays it) |
| `rcdr.dfdr.eventCount` | int | output | read | `0` | DFDR event marks set (counter, +1 per DFDR EVENT press while the DFDR records) |
| `rcdr.dfdr.recording` | bool | output | read | `0` | Flight data recording system energized (FDIU and DFDR recording) |

## Relays (read-only discretes)

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `aircond.cockpitAirFlow` | bool | output | read | `0` | Air flowing into the cockpit (a pack, ram air or the cabin recirculation fans through the mixer unit) |
| `elec.bus.acBus1.powered` | bool | output | read | `0` | AC BUS 1 powered |
| `elec.bus.acBus1.volts` | float | output | read | `0` | AC BUS 1 voltage (V; 0 unpowered): its source's (AC 116 V from a generator, the GPU's, 115 V on the static inverter; DC 28.8 V from a TR, the battery voltage on the batteries) |
| `elec.bus.acBus2.powered` | bool | output | read | `0` | AC BUS 2 powered |
| `elec.bus.acBus2.volts` | float | output | read | `0` | AC BUS 2 voltage (V; 0 unpowered): its source's (AC 116 V from a generator, the GPU's, 115 V on the static inverter; DC 28.8 V from a TR, the battery voltage on the batteries) |
| `elec.bus.acEss.powered` | bool | output | read | `0` | AC ESS BUS powered |
| `elec.bus.acEss.volts` | float | output | read | `0` | AC ESS BUS voltage (V; 0 unpowered): its source's (AC 116 V from a generator, the GPU's, 115 V on the static inverter; DC 28.8 V from a TR, the battery voltage on the batteries) |
| `elec.bus.acEssShed.powered` | bool | output | read | `0` | AC ESS SHED BUS powered |
| `elec.bus.acEssShed.volts` | float | output | read | `0` | AC ESS SHED BUS voltage (V; 0 unpowered): its source's (AC 116 V from a generator, the GPU's, 115 V on the static inverter; DC 28.8 V from a TR, the battery voltage on the batteries) |
| `elec.bus.acGndFlt.powered` | bool | output | read | `0` | AC GND/FLT BUS powered |
| `elec.bus.acGndFlt.volts` | float | output | read | `0` | AC GND/FLT BUS voltage (V; 0 unpowered): its source's (AC 116 V from a generator, the GPU's, 115 V on the static inverter; DC 28.8 V from a TR, the battery voltage on the batteries) |
| `elec.bus.acStatInv.powered` | bool | output | read | `0` | AC STAT INV BUS powered |
| `elec.bus.acStatInv.volts` | float | output | read | `0` | AC STAT INV BUS voltage (V; 0 unpowered): its source's (AC 116 V from a generator, the GPU's, 115 V on the static inverter; DC 28.8 V from a TR, the battery voltage on the batteries) |
| `elec.bus.dcBat.powered` | bool | output | read | `0` | DC BAT BUS powered |
| `elec.bus.dcBat.volts` | float | output | read | `0` | DC BAT BUS voltage (V; 0 unpowered): its source's (AC 116 V from a generator, the GPU's, 115 V on the static inverter; DC 28.8 V from a TR, the battery voltage on the batteries) |
| `elec.bus.dcBus1.powered` | bool | output | read | `0` | DC BUS 1 powered |
| `elec.bus.dcBus1.volts` | float | output | read | `0` | DC BUS 1 voltage (V; 0 unpowered): its source's (AC 116 V from a generator, the GPU's, 115 V on the static inverter; DC 28.8 V from a TR, the battery voltage on the batteries) |
| `elec.bus.dcBus2.powered` | bool | output | read | `0` | DC BUS 2 powered |
| `elec.bus.dcBus2.volts` | float | output | read | `0` | DC BUS 2 voltage (V; 0 unpowered): its source's (AC 116 V from a generator, the GPU's, 115 V on the static inverter; DC 28.8 V from a TR, the battery voltage on the batteries) |
| `elec.bus.dcEss.powered` | bool | output | read | `0` | DC ESS BUS powered |
| `elec.bus.dcEss.volts` | float | output | read | `0` | DC ESS BUS voltage (V; 0 unpowered): its source's (AC 116 V from a generator, the GPU's, 115 V on the static inverter; DC 28.8 V from a TR, the battery voltage on the batteries) |
| `elec.bus.dcEssShed.powered` | bool | output | read | `0` | DC ESS SHED BUS powered |
| `elec.bus.dcEssShed.volts` | float | output | read | `0` | DC ESS SHED BUS voltage (V; 0 unpowered): its source's (AC 116 V from a generator, the GPU's, 115 V on the static inverter; DC 28.8 V from a TR, the battery voltage on the batteries) |
| `elec.bus.dcGndFlt.powered` | bool | output | read | `0` | DC GND/FLT BUS powered |
| `elec.bus.dcGndFlt.volts` | float | output | read | `0` | DC GND/FLT BUS voltage (V; 0 unpowered): its source's (AC 116 V from a generator, the GPU's, 115 V on the static inverter; DC 28.8 V from a TR, the battery voltage on the batteries) |
| `elec.bus.hotBus1.powered` | bool | output | read | `0` | HOT BUS 1 powered |
| `elec.bus.hotBus1.volts` | float | output | read | `26.3` | HOT BUS 1 voltage (V; 0 unpowered): its source's (AC 116 V from a generator, the GPU's, 115 V on the static inverter; DC 28.8 V from a TR, the battery voltage on the batteries) |
| `elec.bus.hotBus2.powered` | bool | output | read | `0` | HOT BUS 2 powered |
| `elec.bus.hotBus2.volts` | float | output | read | `26.3` | HOT BUS 2 voltage (V; 0 unpowered): its source's (AC 116 V from a generator, the GPU's, 115 V on the static inverter; DC 28.8 V from a TR, the battery voltage on the batteries) |
| `fg.ap.anyEngaged` | bool | output | read | `0` | An autopilot (AP 1 or AP 2) engaged |
| `fg.ap.noneEngaged` | bool | output | read | `0` | No autopilot engaged (inverse of fg.ap.anyEngaged) |
| `mip.clock.powered` | bool | output | read | `0` | Cockpit clock powered (its displays lit) |
| `mip.isis.powered` | bool | output | read | `0` | ISIS powered (its screen on) |

## Sidesticks

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `ctl.sidestickSolenoid.capt` | bool | output | read | `0` | Captain sidestick lock solenoid engaged: stick locked in neutral while an autopilot is engaged (released at AP disengagement) |
| `ctl.sidestickSolenoid.fo` | bool | output | read | `0` | F/O sidestick lock solenoid engaged: stick locked in neutral while an autopilot is engaged (released at AP disengagement) |
| `sidestick.capt.takeover.pressed` | bool | pushbutton | momentary | `0` | Captain sidestick takeover (AP disconnect) pushbutton (momentary: 1 while held) |
| `sidestick.fo.takeover.pressed` | bool | pushbutton | momentary | `0` | F/O sidestick takeover (AP disconnect) pushbutton (momentary: 1 while held) |

## Simulator

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `license.demoRemainingS` | int | output | read | `0` | Demo: seconds left in this run (0 when licensed or ended) |
| `license.restart` | bool | pushbutton | momentary | `0` | Restart Systems (cold and dark) once the demo period has ended; ignored otherwise |
| `license.state` | int | output | read | `0` | Product mode decided by Systems: 0 = licensed, 1 = demo (20 minutes per run, DEMO on the screens), 2 = demo period ended (simulation stopped) |

## Surveillance

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `atc.code` | int | output | read | `0` | Transponder code (octal digits as a number, e.g. 7700) |
| `atc.replying` | bool | output | read | `0` | The selected transponder replies (not STBY, working) |
| `tcas.mode` | int | output | read | `0` | TCAS operating mode: 0 = off / failed, 1 = STBY, 2 = TA ONLY, 3 = TA/RA |
| `tcas.ra` | bool | output | read | `0` | A resolution advisory is active |
| `tcas.ta` | bool | output | read | `0` | A traffic advisory is present |
| `tcas.test` | bool | output | read | `0` | TCAS test in progress |

## Water / waste

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `waste.levelL` | float | output | read | `0` | Toilet waste in the waste tank (l, 0..170 usable) |
| `waste.vacuumAvailable` | bool | output | read | `0` | Toilets can flush (VSC working, vacuum generator or differential pressure) |
| `water.pressurized` | bool | output | read | `0` | Potable water system pressurized (ground air or bleed air) |
| `water.quantityL` | float | output | read | `0` | Potable water in the tank (l, 0..200) |

## Weather radar

| Dataref | Type | Kind | Access | Sample value | Description |
| --- | --- | --- | --- | --- | --- |
| `wxr.debug.pattern` | int | service | write | `0` | Debug: 1 = synthetic echo picture in place of the simulator's (development only) |
| `wxr.pwsActive` | bool | output | read | `0` | Predictive windshear detection active |
| `wxr.pwsAlert` | int | output | read | `0` | Predictive windshear area: 0 = none, 1 = advisory (ND only), 2 = caution, 3 = warning |
| `wxr.pwsOff` | bool | output | read | `0` | PWS switch OFF (PRED W/S OFF memo, for the FWC) |
| `wxr.status` | string | output | read | `""` | Picture source: SIMULATOR, TEST PATTERN, or INOP (no picture from the simulator) |
| `wxr.tiltDeg` | float | output | read | `0` | Antenna tilt (degrees, positive up) |
| `wxr.transmitting` | bool | output | read | `0` | The selected radar is on and transmitting |
