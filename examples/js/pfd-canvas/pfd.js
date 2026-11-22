// NVAN A320 Professional: a basic A320 captain PFD drawn on a 2D canvas from the Systems display stream.
//
// A DIDACTIC EXAMPLE, NOT A CERTIFIED DISPLAY. It shows how to:
//   1. connect to the Systems WebSocket API (ws://<host>:8080/api/ws), reconnecting and subscribing again by itself;
//   2. subscribe to a display stream ("pfd.capt") and keep the PFD state with the merge rule (full / delta messages);
//   3. draw that state: every value, color, flag, "shown" decision and flashing phase comes from Systems (its DMC).
//      This file decides nothing about what the PFD shows; it only draws what it receives.
// The protocol and every field: ../../../DISPLAY-STREAMS.md. Field names below are exactly the documented ones.
//
// Drawing: the PFD is drawn in a 1000 x 1000 "design unit" square (the same units as the PFD of NVAN Displays), scaled
// to the canvas. Geometry, colors and font sizes follow our Displays PFD; several items are simplified (marked
// "SIMPLIFIED" below). No interpolation between frames: each frame is drawn as received (see the note at drawFrame).
//
// Font: NVANEIS-Regular.ttf (loaded by pfd.html with @font-face, monospace as the fallback) is Copyright 2026 NVAN,
// all rights reserved, under a proprietary license, NOT the SDK's MIT license: it is provided only to draw displays
// connected to NVAN A320 Professional. See FONT-LICENSE.txt.

// ==== 1. Connection and stream state ==================================================================================

const params = new URLSearchParams(location.search);
const STREAM = params.get("stream") ?? "pfd.capt";             // "pfd.capt" (captain) or "pfd.fo" (first officer)
const RATE = Number(params.get("rate") ?? 50);                  // messages per second, 10..50
if (params.has("bare")) document.body.classList.add("bare");    // ?bare: the canvas alone (a display unit)

const hostInput = document.getElementById("host");
const statusText = document.getElementById("status");
hostInput.value = params.get("host") ?? "localhost";            // as datarefs.html: Systems on this PC by default

// "192.168.1.20" → ws://192.168.1.20:8080/api/ws (the API port shown in the Systems window); "host:port" is kept.
function socketUrl(host) {
  const h = host.trim() || "localhost";
  return `ws://${/:\d+$/.test(h) ? h : `${h}:8080`}/api/ws`;
}

let socket = null;        // the current WebSocket
let retryTimer = 0;
let pfd = null;           // the merged PFD state (the "data" object); null until the first full message
let lastSeq = 0;          // "seq" of the last display message (from 1, no gap)
let lastMessageAt = 0;    // performance.now() of the last display message
let dirty = true;         // something to redraw

function setStatus(text) {
  statusText.textContent = text;
}

function connect() {
  clearTimeout(retryTimer);
  if (socket) {
    socket.onclose = null;
    socket.close();
  }
  pfd = null;
  dirty = true;
  const url = socketUrl(hostInput.value);
  setStatus(`connecting to ${url}...`);
  let ws;
  try {
    ws = new WebSocket(url);
  } catch (e) {
    setStatus(`bad address: ${e.message}`);
    return;
  }
  socket = ws;

  // Subscribe on every (re)connection: Systems answers "display-subscribed", then a full message, then deltas.
  ws.onopen = () => {
    ws.send(JSON.stringify({ op: "subscribe-display", streams: [STREAM], rate: RATE }));
  };

  ws.onmessage = (event) => {
    let message;
    try {
      message = JSON.parse(event.data);
    } catch {
      return;
    }
    onMessage(message);
  };

  // Systems closed or restarted, network lost...: forget the state (never draw stale data) and try again in 2 s.
  // The new subscription starts with a full message, so nothing older is ever needed.
  ws.onclose = () => {
    if (socket !== ws) return;
    socket = null;
    pfd = null;
    dirty = true;
    setStatus("no connection: retrying in 2 s");
    retryTimer = setTimeout(connect, 2000);
  };
  ws.onerror = () => {};   // onclose follows
}

function onMessage(m) {
  switch (m.op) {
    case "display-subscribed":
      setStatus(`subscribed to ${STREAM} (format ${m.format}, ${m.rate} Hz)`);
      return;
    case "error":
      setStatus(`Systems: ${m.message}`);
      return;
    case "display":
      break;
    default:
      return;              // datarefs ops ("values", "ack"...) are not used here
  }
  if (m.stream !== STREAM) return;
  if (m.format !== 1) {
    // A breaking change of the schema: this example only knows format 1 (new fields alone keep format 1).
    pfd = null;
    dirty = true;
    setStatus(`display stream format ${m.format} not supported by this example`);
    return;
  }
  lastMessageAt = performance.now();
  if (m.full) {
    // Full message (the first one after subscribing, then one every 2 s): it replaces the whole state.
    pfd = m.data;
  } else if (pfd && m.seq === lastSeq + 1) {
    // Delta: only what changed since the previous message, merged object by object, key by key.
    merge(pfd, m.data);
  } else {
    // A delta without a base (or after a gap, which TCP never gives): wait for the next full message (2 s at most).
    pfd = null;
  }
  lastSeq = m.seq;
  dirty = true;
}

// The merge rule of DISPLAY-STREAMS.md: where both sides hold an object, merge recursively; any other value (number,
// boolean, string, null, array) replaces the old one. No key is ever removed. Unknown keys are merged and ignored.
function merge(copy, delta) {
  for (const [k, v] of Object.entries(delta)) {
    if (v !== null && typeof v === "object" && !Array.isArray(v) && copy[k] !== null && typeof copy[k] === "object")
      merge(copy[k], v);
    else copy[k] = v;
  }
}

document.getElementById("connect").onclick = () => {
  const url = new URL(location.href);
  url.searchParams.set("host", hostInput.value.trim());
  history.replaceState(null, "", url);
  connect();
};
hostInput.onkeydown = (e) => {
  if (e.key === "Enter") document.getElementById("connect").click();
};

// ==== 2. Small drawing helpers =========================================================================================

const canvas = document.getElementById("pfd");
const ctx = canvas.getContext("2d");

// ECAM colors by the names the stream uses (EcamColor), and the PFD's own colors.
const COLORS = {
  white: "#F4F4F4", green: "#2EE846", amber: "#FF9C12", cyan: "#2CD6F2",
  magenta: "#F45CEC", red: "#FF2E2E", yellow: "#FFE41C",
};
const SKY = "#0698FF", GROUND = "#9C480C", GRAY = "#787878", BLACK = "#000";
const DIM_YELLOW = "#5A500A", DIM_AMBER = "#5A3706";   // a pulsing item in its dim phase

// A named color, or null for an unknown name (a newer Systems: draw nothing for it).
const color = (name) => COLORS[name] ?? null;
// Defensive readers: a number (finite) or a default; a strict boolean.
const num = (v, d = 0) => (typeof v === "number" && Number.isFinite(v) ? v : d);
const on = (v) => v === true;
const clamp = (v, lo, hi) => Math.min(hi, Math.max(lo, v));
const rad = (deg) => (deg * Math.PI) / 180;
const wrap180 = (d) => ((((d + 180) % 360) + 360) % 360) - 180;
const wrap360 = (d) => ((d % 360) + 360) % 360;

// Text in the NVAN EIS font. `size` is the em size of the text on the real display in design units (as our
// Displays: 37.8 for the FMA and scales, 44.1 for the flags...). The face is drawn 0.76/0.75 larger (same cap height
// as the real screens) and condensed to the real character pitch (0.79 of the cap height).
const FONT_FAMILY = '"NVANEIS", monospace';
const CAP_SCALE = 0.76 / 0.75;
const CONDENSE = (0.79 * 0.76) / 0.65 / CAP_SCALE;
const capHeight = (size) => size * 0.76;

function textWidth(str, size) {
  ctx.font = `${size * CAP_SCALE}px ${FONT_FAMILY}`;
  return ctx.measureText(str).width * CONDENSE;
}

// Draws `str` with its baseline at y; anchor "left" | "center" | "right". Returns the right edge.
function text(str, x, y, size, fill, anchor = "left") {
  if (!str || !fill) return x;
  const w = textWidth(str, size);
  const left = anchor === "left" ? x : anchor === "right" ? x - w : x - w / 2;
  ctx.save();
  ctx.fillStyle = fill;
  ctx.translate(left, y);
  ctx.scale(CONDENSE, 1);
  ctx.fillText(str, 0, 0);
  ctx.restore();
  return left + w;
}

function line(x1, y1, x2, y2, stroke, width, cap = "butt") {
  ctx.beginPath();
  ctx.moveTo(x1, y1);
  ctx.lineTo(x2, y2);
  ctx.strokeStyle = stroke;
  ctx.lineWidth = width;
  ctx.lineCap = cap;
  ctx.stroke();
}

// A polyline / polygon from [x, y, x, y, ...].
function poly(points, stroke, width, close = false, fill = null, join = "miter") {
  ctx.beginPath();
  ctx.moveTo(points[0], points[1]);
  for (let i = 2; i < points.length; i += 2) ctx.lineTo(points[i], points[i + 1]);
  if (close) ctx.closePath();
  if (fill) {
    ctx.fillStyle = fill;
    ctx.fill();
  }
  if (stroke) {
    ctx.strokeStyle = stroke;
    ctx.lineWidth = width;
    ctx.lineJoin = join;
    ctx.lineCap = "butt";
    ctx.stroke();
  }
}

function rect(x, y, w, h, fill) {
  ctx.fillStyle = fill;
  ctx.fillRect(x, y, w, h);
}

function strokeRect(x, y, w, h, stroke, width) {
  ctx.strokeStyle = stroke;
  ctx.lineWidth = width;
  ctx.lineJoin = "miter";
  ctx.strokeRect(x, y, w, h);
}

// A flag / message is drawn when it is set and not in the off phase of its flashing (flagsFlashOff).
const flagShown = (d, name) => on(d.flags?.[name]) && !on(d.flagsFlashOff?.[name]);

// ==== 3. Geometry (design units, 1000 x 1000) ==========================================================================

// Line weights.
const SMALL = 2.4, NORMAL = 3.8, THICK = 5.2, HUGE = 7.6;
const OUTLINE = 5.0, THICK_OUTLINE = 6.9, HUGE_OUTLINE = 9.3;
// Text sizes.
const F_SMALLEST = 28.3, F_SMALL = 31.5, F_SCALE = 37.8, F_LARGE = 40.9, F_FLAG = 44.1, F_RA_LOW = 48.3;

// Attitude sphere: a circle cut by two vertical sides; its center is the aircraft symbol.
const CX = 434.1, CY = 509.1, SPHERE_R = 265.1, SPHERE_HALF_W = 231.6;
const BAND_HALF_H = 198.8, SKY_BOX_HALF_W = 176.1, GROUND_BOX_HALF_W = 283.7, GROUND_BOX_H = 285.7, GROUND_RISE_MAX = 397.4;
// Pitch scale: degrees → distance above the horizon (linear near the horizon, compressed beyond).
const PITCH_DEG = [-80, -50, -30, -20, -15, -10, -7.5, -5, -2.5, 0, 2.5, 5, 7.5, 10, 12.5, 15, 17.5, 20, 22.5, 25, 27.5, 30, 50, 80];
const PITCH_UP = [-554.3, -365.4, -239.4, -176.4, -144.9, -107.1, -83.5, -56.7, -28.3, 0, 28.3, 56.7, 85.0, 113.4, 141.7, 170.1, 198.4, 226.8, 253.5, 277.2, 297.6, 315.0, 441.0, 629.9];
// Roll scale.
const ROLL_R = 265.4, ROLL_ARC_HALF = 31.4;
// Speed scale.
const TAPE_TOP = 239.9, TAPE_BOTTOM = 778.3, TAPE_HALF_H = CY - TAPE_TOP;
const SPD_LEFT = 12.0, SPD_RIGHT = 119.9, KT_PX = 6.3;
const STRIP_LEFT = SPD_RIGHT, STRIP_RIGHT = SPD_RIGHT + 19.0;
// Altitude scale and window.
const ALT_LEFT = 741.8, ALT_RIGHT = 824.3, FT_PX = 0.4724;
const WINDOW_HALF_H = 28.3, DRUM_RIGHT = 880.1, DRUM_HALF_H = 45.1;
// Vertical speed scale.
const VS_LEFT = 921.6, VS_INNER = 956.5, VS_OUTER = 982.5, VS_HALF_H = 320.6, VS_SLANT_H = 98.4;
const VS_MARKS = [0, 500, 1000, 1500, 2000, 4000, 6000];
const VS_MARK_AT = [0, 0.2873, 0.5747, 0.6814, 0.788, 0.8946, 1.0];
const VS_FULL = 298.4;
// Heading scale.
const HDG_LEFT = CX - SPHERE_HALF_W, HDG_RIGHT = CX + SPHERE_HALF_W, HDG_TOP = 915.5, HDG_BOTTOM = 980.9, DEG_PX = 9.518;
// FMA: the four gray column lines; rows.
const FMA_LINES = [208.6, 417.3, 645.8, 842.3];
const FMA_BOX_TOP = 11.4, FMA_ROW = 45.7, FMA_BOX_H = 38.1;
const FMA_COLUMNS = ["thrust", "vertical", "lateral", "approachCapability", "engagement"];
const FMA_LINE_NAMES = ["line1", "line2", "line3"];
// Landing system (SIMPLIFIED): LOC scale under the sphere, G/S scale right of it, 95 units per dot.
const LOC_Y = 822.1, GS_X = 691.1, LS_DOT = 95.2;

function pitchOffset(deg) {
  if (deg <= PITCH_DEG[0]) return PITCH_UP[0] + (deg - PITCH_DEG[0]) * 6.3;
  if (deg >= PITCH_DEG.at(-1)) return PITCH_UP.at(-1) + (deg - PITCH_DEG.at(-1)) * 6.3;
  let k = 1;
  while (deg > PITCH_DEG[k]) k++;
  const a = (deg - PITCH_DEG[k - 1]) / (PITCH_DEG[k] - PITCH_DEG[k - 1]);
  return PITCH_UP[k - 1] + a * (PITCH_UP[k] - PITCH_UP[k - 1]);
}

function vsOffset(fpm) {
  fpm = Math.min(Math.abs(fpm), 6000);
  for (let k = 1; k < VS_MARKS.length; k++) {
    if (fpm > VS_MARKS[k]) continue;
    const a = (fpm - VS_MARKS[k - 1]) / (VS_MARKS[k] - VS_MARKS[k - 1]);
    return (VS_MARK_AT[k - 1] + a * (VS_MARK_AT[k] - VS_MARK_AT[k - 1])) * VS_FULL;
  }
  return VS_FULL;
}

function sphereClip() {
  ctx.beginPath();
  ctx.arc(CX, CY, SPHERE_R, 0, 2 * Math.PI);
  ctx.clip();
  ctx.beginPath();
  ctx.rect(CX - SPHERE_HALF_W, 0, 2 * SPHERE_HALF_W, 1000);
  ctx.clip();
}

// ==== 4. The frame ======================================================================================================

// One frame. Note: Systems sends up to 50 frames per second; continuous values (attitude, speed, heading...) could be
// interpolated between the last two frames when drawing faster (our Displays does). This example draws the latest.
function drawFrame() {
  const scale = canvas.width / 1000;
  ctx.setTransform(1, 0, 0, 1, 0, 0);
  rect(0, 0, canvas.width, canvas.height, BLACK);
  ctx.setTransform(scale, 0, 0, scale, 0, 0);
  ctx.textBaseline = "alphabetic";

  const d = pfd;
  if (!d) {
    text("WAITING FOR STREAM", 500, 500, F_SMALL, "#666", "center");
    return;
  }

  // The display unit that shows this PFD: normally the one at the PFD position; with PFD/ND XFR the ND position.
  const units = d.displayUnits ?? {};
  const du = units.pfd?.format === "pfd" ? units.pfd : units.nd?.format === "pfd" ? units.nd : units.pfd ?? {};
  if (du.state !== "on") {
    // Below "selfTest" the DU is black. SIMPLIFIED: the failed "F" and the self-test screen as plain texts.
    if (du.state === "failed") text("F", 500, 520, F_FLAG, COLORS.amber, "center");
    else if (du.state === "selfTest") text("SELF TEST IN PROGRESS", 500, 520, F_SCALE, COLORS.white, "center");
    return;
  }
  if (du.dmcStatus === "failureWarning") {
    text("INVALID DATA", 500, 520, F_SCALE, COLORS.amber, "center");
    return;
  }
  if (du.dmcStatus === "noComputedData") {
    text("WAITING FOR DATA", 500, 520, F_SCALE, COLORS.green, "center");
    return;
  }
  if (du.format !== "pfd") {
    // This DU shows something else (ND, ECAM...): not drawn by this example.
    text(`(${String(du.format).toUpperCase()})`, 500, 520, F_SMALL, "#666", "center");
    return;
  }
  // Not "normal": nothing of this frame may be drawn.
  if (d.status !== "normal") return;

  drawFma(d);
  drawFctlMessage(d);
  drawAttitude(d);
  drawSpeed(d);
  drawAltitude(d);
  drawVerticalSpeed(d);
  drawHeading(d);
  drawLandingSystem(d);
  drawDuMessages(du);

  // Brightness of the DU (knob, automatic adjustment) as a final dimming.
  const brightness = clamp(num(du.brightness, 1), 0, 1);
  if (brightness < 1) {
    ctx.globalAlpha = 1 - brightness;
    rect(0, 0, 1000, 1000, BLACK);
    ctx.globalAlpha = 1;
  }
}

// ==== 5. FMA: 5 columns x 3 lines =======================================================================================

const fmaCell = (d, column, lineIndex) => d.fma?.[FMA_COLUMNS[column]]?.[FMA_LINE_NAMES[lineIndex]] ?? {};
const columnLeft = (c) => (c === 0 ? 0 : c > FMA_LINES.length ? 1000 : FMA_LINES[c - 1]);

function drawFma(d) {
  const fctl = d.fctlMessage?.message;
  const fctlShown = fctl === "useManPitchTrim" || fctl === "manPitchTrimOnly";

  // Gray column lines. A first-line text spanning two columns (LAND, FLARE...) removes the line between them; a
  // third-line text spanning two columns (or the flight control message) cuts it from the third line down.
  for (let k = 0; k < FMA_LINES.length; k++) {
    const top = fmaCell(d, k, 0);
    if (on(top.spanNext) && top.text) continue;
    const bottom = fmaCell(d, k, 2);
    const cut = (on(bottom.spanNext) && bottom.text) || (k === 1 && fctlShown);
    line(FMA_LINES[k], 2.1, FMA_LINES[k], cut ? 101.4 : 133.6, GRAY, NORMAL);
  }

  for (let column = 0; column < 5; column++) {
    for (let row = 0; row < 3; row++) {
      const cell = fmaCell(d, column, row);
      const str = typeof cell.text === "string" ? cell.text : "";
      if (!str) continue;
      // The flight control message has the priority on the third line of columns 2 and 3.
      if (fctlShown && row === 2 && (column === 1 || column === 2)) continue;
      const left = columnLeft(column);
      const span = on(cell.spanNext) && column < 4;
      const right = columnLeft(span ? column + 2 : column + 1);
      const center = (left + right) / 2;
      const boxTop = FMA_BOX_TOP + row * FMA_ROW;
      const baseline = boxTop + FMA_BOX_H / 2 + capHeight(F_SCALE) / 2;
      // Two colors: `color` up to character color2From, `color2` from there ("V/S" green + "+2500" cyan).
      const split = clamp(num(cell.color2From, str.length), 0, str.length);
      const first = str.slice(0, split), second = str.slice(split);

      // Column 4, line 3 "BARO" / "RADIO" + the minimum: the label left, the value right, in the small size.
      if (column === 3 && row === 2 && first && second) {
        if (!on(cell.textFlashOff)) {
          text(first.trimEnd(), 651.8, baseline, F_SMALLEST, color(cell.color));
          text(second, 840.5, baseline, F_SMALLEST, color(cell.color2), "right");
        }
        continue;
      }

      // A text wider than its column is narrowed to fit (a safeguard: the real texts fit).
      const width = textWidth(first, F_SCALE) + textWidth(second, F_SCALE);
      const room = right - left - 12;
      const squeeze = width > room ? room / width : 1;
      if (!on(cell.textFlashOff)) {
        ctx.save();
        ctx.translate(center, 0);
        ctx.scale(squeeze, 1);
        const x = text(first, -width / 2, baseline, F_SCALE, color(cell.color));
        text(second, first ? x : -width / 2, baseline, F_SCALE, color(cell.color2));
        ctx.restore();
      }

      // White or amber box (flashing: boxFlashOff = off phase). boxTwoLines: around this cell and the one below.
      if (!(on(cell.boxWhite) || on(cell.boxAmber)) || on(cell.boxFlashOff)) continue;
      let halfW = (width * squeeze) / 2;
      let bottom = boxTop + FMA_BOX_H;
      if (on(cell.boxTwoLines) && row < 2) {
        const below = fmaCell(d, column, row + 1);
        if (below.text) halfW = Math.max(halfW, Math.min(textWidth(below.text, F_SCALE), room) / 2);
        bottom += FMA_ROW;
      }
      strokeRect(center - halfW - 6, boxTop, 2 * halfW + 12, bottom - boxTop, on(cell.boxAmber) ? COLORS.amber : COLORS.white, NORMAL);
    }
  }
}

// Flight control message on the third FMA line across columns 2-3: red MAN PITCH TRIM ONLY flashes (hidden in the
// off phase), amber USE MAN PITCH TRIM pulses (dim in the off phase).
function drawFctlMessage(d) {
  const message = d.fctlMessage?.message;
  if (message !== "useManPitchTrim" && message !== "manPitchTrimOnly") return;
  const only = message === "manPitchTrimOnly";
  const off = on(d.fctlMessage.flashOff);
  if (only && off) return;
  const str = only ? "MAN PITCH TRIM ONLY" : "USE MAN PITCH TRIM";
  const baseline = FMA_BOX_TOP + 2 * FMA_ROW + FMA_BOX_H / 2 + capHeight(F_SCALE) / 2;
  const room = FMA_LINES[2] - FMA_LINES[0] - 12;
  const width = textWidth(str, F_SCALE);
  ctx.save();
  ctx.translate((FMA_LINES[0] + FMA_LINES[2]) / 2, 0);
  if (width > room) ctx.scale(room / width, 1);
  text(str, 0, baseline, F_SCALE, only ? COLORS.red : off ? DIM_AMBER : COLORS.amber, "center");
  ctx.restore();
}

// ==== 6. Attitude, guidance and flags of the sphere =====================================================================

function drawAttitude(d) {
  const a = d.attitude ?? {};
  if (on(d.flags?.att)) {
    // Attitude lost: the sphere is cleared (nothing of it is drawn), the red ATT flag instead.
    if (flagShown(d, "att")) text("ATT", 478.1, 523.7, F_FLAG, COLORS.red, "right");
  } else {
    const pitch = num(a.pitchDeg), roll = num(a.rollDeg);
    const horizon = pitchOffset(pitch);
    const headingValid = !on(d.flags?.hdg);
    const heading = num(d.heading?.deg);
    const ra = d.altitude?.radioHeight ?? {};

    ctx.save();
    sphereClip();
    ctx.translate(CX, CY);
    ctx.rotate(rad(-roll));                       // + roll = right wing down: the horizon turns the other way

    // Earth-referenced part: sky, ground, horizon line and pitch scale, moved by the pitch.
    ctx.save();
    ctx.translate(0, horizon);
    rect(-700, -2400, 1400, 2400, SKY);
    rect(-700, 0, 1400, 2400, GROUND);
    line(-700, 0, 700, 0, COLORS.white, NORMAL);
    drawPitchScale(pitch);
    if (a.protections === "normal" || a.protections === "lost") {
      // Pitch limits: 30° nose up, 15° nose down (green "=" in normal law, amber X otherwise).
      for (const side of [-1, 1]) {
        protectionMark(side * 97.0, -pitchOffset(30), a.protections, 0, 12.6, 4.4, 4.5);
        protectionMark(side * 43.8, -pitchOffset(-15), a.protections, 0, 12.6, 4.4, 4.5);
      }
    }
    if (on(a.pitchArrowsDown)) pitchArrows(ARROWS_DOWN);
    if (on(a.pitchArrowsUp)) pitchArrows(ARROWS_UP);
    ctx.restore();

    // Plain sky box above the pitch band, and the ground box below it, raised towards the horizon near the ground
    // (radio height / 10 as degrees below the horizon).
    rect(-SKY_BOX_HALF_W, -BAND_HALF_H - 300, 2 * SKY_BOX_HALF_W, 300, SKY);
    strokeRect(-SKY_BOX_HALF_W, -BAND_HALF_H - 300, 2 * SKY_BOX_HALF_W, 300, COLORS.white, NORMAL);
    let groundTop = BAND_HALF_H;
    if (on(ra.shown)) groundTop = clamp(pitchOffset(pitch + 0.1 * Math.max(num(ra.ft), 0)), BAND_HALF_H - GROUND_RISE_MAX, BAND_HALF_H);
    rect(-GROUND_BOX_HALF_W, groundTop, 2 * GROUND_BOX_HALF_W, GROUND_BOX_H, GROUND);
    strokeRect(-GROUND_BOX_HALF_W, groundTop, 2 * GROUND_BOX_HALF_W, GROUND_BOX_H, COLORS.white, NORMAL);

    // Heading marks on the horizon every 10°, kept inside the pitch band.
    if (headingValid) {
      const y = clamp(horizon, -BAND_HALF_H, BAND_HALF_H);
      for (let deg = Math.ceil((heading - 35) / 10) * 10; deg <= heading + 35; deg += 10) {
        const x = (deg - heading) * 9.45;
        line(x, y, x, y + 11.3, COLORS.white, NORMAL);
      }
    }
    ctx.restore();

    // Radio height digits in the lower part of the sphere (larger at 400 ft and below).
    if (on(ra.shown)) {
      const size = num(ra.ft) <= 400 ? F_RA_LOW : F_LARGE;
      text(String(num(ra.digitsFt)), 435.9, 754.4, size, color(ra.color), "center");
    }

    drawRollScale();
    if (a.protections === "normal" || a.protections === "lost") {
      // Bank angle protection at ±67°, across the roll scale line.
      for (const side of [-1, 1]) {
        const ang = rad(side * 67 - 90);
        protectionMark(CX + Math.cos(ang) * ROLL_R, CY + Math.sin(ang) * ROLL_R, a.protections, side * 67 + 90, 5.6, 2.5, 5.6);
      }
    }
    // Roll index and sideslip index turn with the bank angle; the sideslip index is removed with the SI flag.
    ctx.save();
    ctx.translate(CX, CY);
    ctx.rotate(rad(-roll));
    poly([0, -258.7, -18.0, -232.1, 18.0, -232.1], COLORS.yellow, NORMAL, true, null, "round");
    if (!on(d.flags?.si)) {
      const dx = clamp(num(a.sideslipG), -0.3, 0.3) * 315;
      poly([dx - 22.3, -225.7, dx + 22.3, -225.7, dx + 31.7, -211.7, dx - 31.7, -211.7], color(a.sideslipColor), NORMAL, true);
    }
    ctx.restore();

    // Inside the sphere: sidestick order, FD bars, yaw bar, aircraft symbol, flight path vector.
    ctx.save();
    sphereClip();
    drawSidestick(a.sidestick ?? {});
    drawFdBars(d.guidance ?? {});
    drawYawBar(d.guidance ?? {});
    drawAircraftSymbol();
    drawFlightPath(d, pitch, roll);
    ctx.restore();

    if (flagShown(d, "fd")) text("FD", 332.0, 353.2, F_FLAG, COLORS.red, "right");
    if (flagShown(d, "fpv")) text("FPV", 396.8, 563.3, F_FLAG, COLORS.red, "right");
  }

  if (flagShown(d, "si")) text("SI", 455.5, 303.1, F_SMALL, COLORS.red, "right");
  if (flagShown(d, "checkAtt")) text("CHECK ATT", CX, 440.0, F_SCALE, COLORS.amber, "center");
  if (flagShown(d, "wsAheadWarning")) text("W/S AHEAD", CX, 392.0, F_LARGE, COLORS.red, "center");
  else if (flagShown(d, "wsAheadCaution")) text("W/S AHEAD", CX, 392.0, F_LARGE, COLORS.amber, "center");
  if (on(d.flags?.windshear)) text("WINDSHEAR", CX, 476.0, F_LARGE, COLORS.red, "center");
  if (flagShown(d, "ra")) text("RA", 435.9, 754.4, F_LARGE, COLORS.red, "center");
}

// Pitch marks every 2.5° (to 30° up / 10° down), then 15, 20, 30, 50, 80°; labels at 10, 20, 30, 50, 80°.
// Horizon frame: origin on the horizon, y down.
function drawPitchScale(pitch) {
  for (let i = 0; i < PITCH_DEG.length; i++) {
    const deg = PITCH_DEG[i];
    if (deg === 0 || Math.abs(deg - pitch) > 45) continue;
    const a = Math.abs(deg);
    const half = a === 80 ? 132.3 : a === 50 ? 100.8 : a === 30 ? 81.9 : a === 10 || a === 20 ? 59.8 : a === 5 || a === 15 || a === 25 ? 28.3 : 15.7;
    const y = -PITCH_UP[i];
    line(-half, y, half, y, COLORS.white, NORMAL);
    if (![10, 20, 30, 50, 80].includes(a)) continue;
    const baseline = y + capHeight(F_SMALL) / 2;
    text(String(a), -half - 29.6, baseline, F_SMALL, COLORS.white, "right");
    text(String(a), half + 29.6, baseline, F_SMALL, COLORS.white, "left");
  }
}

// Red chevrons beyond the pitch limits, pointing the way back to the horizon (horizon frame).
const ARROWS_DOWN = [
  [-50.9, -422.0, -32.7, -422.0, 0, -365.4, 32.7, -422.0, 50.9, -422.0, 0, -333.9],
  [-47.3, -592.1, -72.7, -592.1, 0, -466.1, 72.7, -592.1, 47.3, -592.1, 0, -510.2],
  [0, -674.0, -59.8, -733.8, -18.9, -733.8, -18.9, -755.9, -113.4, -755.9, 0, -642.5, 113.4, -755.9, 18.9, -755.9, 18.9, -733.8, 59.8, -733.8],
];
const ARROWS_UP = [
  [0, 258.3, -50.9, 346.5, -32.7, 346.5, 0, 289.8, 32.7, 346.5, 50.9, 346.5],
  [-72.7, 522.8, 0, 396.9, 72.7, 522.8, 47.3, 522.8, 0, 441.0, -47.3, 522.8],
  [18.9, 658.3, 18.9, 680.4, 113.4, 680.4, 0, 567.0, -113.4, 680.4, -18.9, 680.4, -18.9, 658.3, -59.8, 658.3, 0, 598.5, 59.8, 658.3],
];

function pitchArrows(shapes) {
  for (const shape of shapes) poly(shape, COLORS.red, NORMAL, true);
}

// Green "=" (protections of normal law) or amber X (lost), at (x, y), turned by rotationDeg.
function protectionMark(x, y, protections, rotationDeg, halfLen, gap, lostHalf) {
  ctx.save();
  ctx.translate(x, y);
  ctx.rotate(rad(rotationDeg));
  if (protections === "lost") {
    line(-lostHalf, -lostHalf, lostHalf, lostHalf, COLORS.amber, NORMAL);
    line(-lostHalf, lostHalf, lostHalf, -lostHalf, COLORS.amber, NORMAL);
  } else {
    const w = rotationDeg === 0 ? NORMAL : SMALL;
    line(-halfLen, -gap, halfLen, -gap, COLORS.green, w);
    line(-halfLen, gap, halfLen, gap, COLORS.green, w);
  }
  ctx.restore();
}

// White roll scale: an arc between ±30°, open bars at 10, 20, 30°, a line at 45°; the fixed yellow zero index.
function drawRollScale() {
  ctx.beginPath();
  ctx.arc(CX, CY, ROLL_R, rad(-90 - ROLL_ARC_HALF), rad(-90 + ROLL_ARC_HALF));
  ctx.strokeStyle = COLORS.white;
  ctx.lineWidth = SMALL;
  ctx.lineCap = "round";
  ctx.stroke();
  for (const m of [10, 20, 30, 45]) {
    for (const side of [-1, 1]) {
      ctx.save();
      ctx.translate(CX, CY);
      ctx.rotate(rad(side * m));
      if (m === 45) line(0, -ROLL_R, 0, -ROLL_R - 25.4, COLORS.white, SMALL, "round");
      else {
        const len = m === 30 ? 23.1 : 16.7;
        poly([-6.35, -ROLL_R, -6.35, -ROLL_R - len, 6.35, -ROLL_R - len, 6.35, -ROLL_R], COLORS.white, SMALL);
      }
      ctx.restore();
    }
  }
  poly([CX, CY - ROLL_R, CX - 15.9, CY - ROLL_R - 23.3, CX + 15.9, CY - ROLL_R - 23.3], COLORS.yellow, NORMAL, true, null, "round");
}

// Fixed aircraft symbol: two black wings outlined yellow (each with a short leg down) and the center square.
function drawAircraftSymbol() {
  for (const side of [-1, 1]) {
    const outer = CX + side * 218.9, inner = CX + side * 123.7, leg = CX + side * (123.7 + 15.9);
    const pts = [outer, CY - 7.9, inner, CY - 7.9, inner, CY + 33.3, leg, CY + 33.3, leg, CY + 7.9, outer, CY + 7.9];
    poly(pts, BLACK, OUTLINE, true);
    poly(pts, COLORS.yellow, NORMAL, true, BLACK);
  }
  strokeRect(CX - 7.9, CY - 7.9, 15.8, 15.8, BLACK, OUTLINE);
  rect(CX - 7.9, CY - 7.9, 15.8, 15.8, BLACK);
  strokeRect(CX - 7.9, CY - 7.9, 15.8, 15.8, COLORS.yellow, NORMAL);
}

// Sidestick order on the ground: four white corners (the full deflection box) and the order cross.
function drawSidestick(s) {
  if (!on(s.shown)) return;
  const halfW = 185.6, halfH = 144.4, corner = 38.1, arm = 32.0, armHalf = 4.8;
  for (const sx of [-1, 1])
    for (const sy of [-1, 1]) {
      const x = CX + sx * halfW, y = CY + sy * halfH;
      poly([x - sx * corner, y, x, y, x, y - sy * corner], COLORS.white, NORMAL);
    }
  const cx = CX + clamp(num(s.rollRatio), -1, 1) * halfW;
  const cy = CY - clamp(num(s.pitchRatio), -1, 1) * halfH;
  for (const sx of [-1, 1])
    for (const sy of [-1, 1])
      poly([cx + sx * arm, cy + sy * armHalf, cx + sx * armHalf, cy + sy * armHalf, cx + sx * armHalf, cy + sy * arm], COLORS.white, NORMAL);
}

// FD crossed bars (not with the flight path director): pitch bar up for a nose-up order, roll bar right for a right
// bank order; a flashing bar is hidden in its off phase.
function drawFdBars(g) {
  if (on(g.flightPathDirector)) return;
  const pitchBar = g.pitchBar ?? {}, rollBar = g.rollBar ?? {};
  const pitchOn = on(pitchBar.shown) && !on(pitchBar.flashOff);
  const rollOn = on(rollBar.shown) && !on(rollBar.flashOff);
  const x = CX + clamp(num(rollBar.deg), -45, 45) * 2.77;
  const y = CY - clamp(num(pitchBar.deg) * 11.33, -126.2, 126.2);
  for (const [stroke, width] of [[BLACK, THICK_OUTLINE], [COLORS.green, THICK]]) {
    if (rollOn) line(x, CY - 120.6, x, CY + 120.6, stroke, width, "round");
    if (pitchOn) line(CX - 123.7, y, CX + 123.7, y, stroke, width, "round");
  }
}

function drawYawBar(g) {
  const yaw = g.yawBar ?? {};
  if (!on(yaw.shown)) return;
  const x = CX + clamp(num(yaw.deg), -20, 20) * 6;
  line(x, CY + 10, x, CY + 50, BLACK, THICK_OUTLINE, "round");
  line(x, CY + 10, x, CY + 50, COLORS.green, THICK, "round");
}

// Flight path vector ("bird", TRK FPA) and, SIMPLIFIED, the flight path director (a green bar with wedges above it).
function drawFlightPath(d, pitch, roll) {
  const g = d.guidance ?? {};
  const fpv = g.flightPathVector ?? {};
  if (!on(fpv.shown) || on(d.flags?.fpv)) return;
  const hx = clamp(num(fpv.driftDeg), -21, 21) * 9.45;
  const hy = pitchOffset(pitch) - pitchOffset(num(fpv.fpaDeg));
  const cos = Math.cos(rad(-roll)), sin = Math.sin(rad(-roll));
  const bx = CX + hx * cos - hy * sin, by = CY + hx * sin + hy * cos;
  for (const [stroke, thin, thick] of [[BLACK, OUTLINE, THICK_OUTLINE], [COLORS.green, NORMAL, THICK]]) {
    ctx.beginPath();
    ctx.arc(bx, by, 14.3, 0, 2 * Math.PI);
    ctx.strokeStyle = stroke;
    ctx.lineWidth = thin;
    ctx.stroke();
    line(bx - 46, by, bx - 14.3, by, stroke, thick, "round");
    line(bx + 14.3, by, bx + 46, by, stroke, thick, "round");
    line(bx, by - 14.3, bx, by - 30.2, stroke, thick, "round");
  }
  if (!on(g.flightPathDirector)) return;
  const pitchOn = on(g.pitchBar?.shown) && !on(g.pitchBar?.flashOff);
  const rollOn = on(g.rollBar?.shown) && !on(g.rollBar?.flashOff);
  if (!pitchOn && !rollOn) return;
  const up = pitchOn ? clamp(num(g.pitchBar.deg), -22.5, 22.5) * 11.97 : 0;
  ctx.save();
  ctx.translate(bx + up * sin, by - up * cos);
  if (rollOn) ctx.rotate(rad(clamp(num(g.rollBar.deg), -45, 45) * 0.77));
  for (const [stroke, width] of [[BLACK, OUTLINE], [COLORS.green, NORMAL]]) {
    ctx.beginPath();
    ctx.arc(0, 0, 6.3, 0, 2 * Math.PI);
    for (const side of [-1, 1]) {
      ctx.moveTo(side * 6.3, 0);
      ctx.lineTo(side * 53.9, 0);
      ctx.lineTo(side * 95.2, -9.5);
      ctx.lineTo(side * 95.2, 9.5);
      ctx.closePath();
    }
    ctx.strokeStyle = stroke;
    ctx.lineWidth = width;
    ctx.lineJoin = "round";
    ctx.stroke();
  }
  ctx.restore();
}

// ==== 7. Speed scale ====================================================================================================

function drawSpeed(d) {
  const s = d.speed ?? {};
  if (on(d.flags?.spd)) {
    // SPD flag: the gray band stays, red outline, every speed symbol removed.
    rect(SPD_LEFT, TAPE_TOP, SPD_RIGHT - SPD_LEFT, TAPE_BOTTOM - TAPE_TOP, GRAY);
    failedScaleOutline(SPD_LEFT, SPD_RIGHT, 29.8);
    if (flagShown(d, "spd")) text("SPD", 111.9, CY + capHeight(F_FLAG) / 2, F_FLAG, COLORS.red, "right");
  } else {
    const speed = Math.max(num(s.casKt, 30), 30);
    const yOf = (kt) => CY - (kt - speed) * KT_PX;
    rect(SPD_LEFT, TAPE_TOP, SPD_RIGHT - SPD_LEFT, TAPE_BOTTOM - TAPE_TOP, GRAY);
    ctx.save();
    ctx.beginPath();
    ctx.rect(SPD_LEFT, TAPE_TOP, SPD_RIGHT - SPD_LEFT, TAPE_BOTTOM - TAPE_TOP);
    ctx.clip();
    // Graduations every 10 kt, labels every 20 kt (three digits below 100: "040").
    for (let kt = Math.max(Math.floor((speed - 50) / 10) * 10, 30); kt <= speed + 50; kt += 10) {
      const y = yOf(kt);
      line(SPD_RIGHT - 17.8, y, SPD_RIGHT, y, COLORS.white, NORMAL);
      if (kt % 20 === 0) text(String(kt).padStart(3, "0"), 50.6, y + capHeight(F_SCALE) / 2, F_SCALE, COLORS.white, "center");
    }
    ctx.restore();
    line(SPD_RIGHT, TAPE_TOP, SPD_RIGHT, Math.min(TAPE_BOTTOM, CY + (speed - 30) * KT_PX), COLORS.white, NORMAL);
    line(SPD_LEFT, TAPE_TOP, SPD_RIGHT + 29.8, TAPE_TOP, COLORS.white, NORMAL);
    line(SPD_LEFT, TAPE_BOTTOM, SPD_RIGHT + 29.8, TAPE_BOTTOM, COLORS.white, NORMAL);

    // VMAX: red and black strip from VMAX up.
    if (on(s.vmax?.shown)) {
      const bottom = Math.min(yOf(num(s.vmax.kt)), TAPE_BOTTOM);
      if (bottom > TAPE_TOP) strip(TAPE_TOP, bottom, COLORS.red, 15.2, 31.7, true);
    }
    drawSpeedLimits(s, yOf);

    // Speed trend: yellow arrow from the reference line to the speed in 10 s.
    if (on(s.trend?.shown)) {
      const x = SPD_RIGHT - 22.5;
      const tip = CY - clamp(num(s.trend.kt) * KT_PX, -TAPE_HALF_H, TAPE_HALF_H);
      const dir = tip < CY ? 1 : -1;
      line(x, CY, x, tip, COLORS.yellow, NORMAL, "round");
      line(x, tip, x - 7.9, tip + dir * 15.5, COLORS.yellow, NORMAL, "round");
      line(x, tip, x + 7.9, tip + dir * 15.5, COLORS.yellow, NORMAL, "round");
    }

    if (on(s.decel)) text("DECEL", 129.4, 813.1, F_SCALE, COLORS.green, "right");

    // Speed target: magenta (managed) or cyan open triangle right of the scale; its digits above / below when off it.
    if (on(s.target?.shown)) {
      const fill = on(s.target.managed) ? COLORS.magenta : COLORS.cyan;
      const kt = num(s.target.kt);
      const y = yOf(kt);
      if (y < TAPE_TOP || y > TAPE_BOTTOM) {
        if (y < TAPE_TOP || !on(s.decel)) text(String(Math.round(kt)), 151.7, y < TAPE_TOP ? 231.0 : 808.1, F_SMALLEST, fill, "right");
      } else {
        const x0 = SPD_RIGHT + 1.5, x1 = x0 + 33.8;
        poly([x0, y + 6.8, x1, y + 19.0, x1, y - 19.0, x0, y - 6.8], fill, NORMAL, false, null, "round");
      }
    }

    // ECON speed range: two magenta marks.
    if (on(s.econMargins?.shown))
      for (const kt of [num(s.econMargins.lowKt), num(s.econMargins.highKt)]) {
        const y = yOf(kt);
        if (y >= TAPE_TOP && y <= TAPE_BOTTOM) rect(124.1, y - 2.2, 33.7, 4.4, COLORS.magenta);
      }

    // V1 (cyan "1", its digits at the top when above the scale) and VR (cyan circle).
    if (on(s.vr?.shown)) {
      const y = yOf(num(s.vr.kt));
      if (y >= TAPE_TOP && y <= TAPE_BOTTOM) {
        ctx.beginPath();
        ctx.arc(127.9, y, 7.9, 0, 2 * Math.PI);
        ctx.strokeStyle = COLORS.cyan;
        ctx.lineWidth = NORMAL;
        ctx.stroke();
      }
    }
    if (on(s.v1?.shown)) {
      const y = yOf(num(s.v1.kt));
      if (y < TAPE_TOP) text(String(Math.round(num(s.v1.kt))), 134.0, 272.3, F_SMALLEST, COLORS.cyan);
      else if (y <= TAPE_BOTTOM) {
        line(104.7, y, 139.3, y, COLORS.cyan, NORMAL);
        text("1", 165.1, y + 13.5, F_LARGE, COLORS.cyan, "center");
      }
    }

    // Speed reference: a yellow stub left of the scale and a bar with a triangle right of it.
    rect(0.6, CY - 2.3, 12.7, 4.6, COLORS.yellow);
    poly([88.2, CY - 2.3, 129.4, CY - 2.3, 149.1, CY - 9.5, 149.1, CY + 9.5, 129.4, CY + 2.3, 88.2, CY + 2.3], null, 0, true, COLORS.yellow);
  }

  // Mach below the scale (green ".76"), or the red MACH flag.
  if (on(s.mach?.shown)) text("." + String(num(s.mach.hundredths) % 100).padStart(2, "0"), 35.1, 863.2, F_FLAG, COLORS.green);
  else if (flagShown(d, "mach")) text("MACH", 35.1, 863.2, F_FLAG, COLORS.red);
}

// Low speed strips (VLS amber hook, alpha prot black/amber, alpha max red, VSW red/black), VFE NEXT and high speed
// protection "=", green dot, F and S.
function drawSpeedLimits(s, yOf) {
  ctx.save();
  ctx.beginPath();
  ctx.rect(SPD_LEFT - 30, TAPE_TOP, 270, TAPE_BOTTOM - TAPE_TOP);
  ctx.clip();
  let lowTop = TAPE_BOTTOM;
  if (on(s.alphaMax?.shown)) {
    const y = Math.max(yOf(num(s.alphaMax.kt)), TAPE_TOP);
    if (y < TAPE_BOTTOM) rect(STRIP_LEFT, y, 21.6, TAPE_BOTTOM - y, COLORS.red);
    lowTop = Math.min(lowTop, y);
  }
  if (on(s.alphaProt?.shown)) {
    const top = Math.max(yOf(num(s.alphaProt.kt)), TAPE_TOP);
    strip(top, lowTop, COLORS.amber, 8.9, 18.4, false);
    lowTop = Math.min(lowTop, top);
  }
  if (on(s.vsw?.shown)) {
    const top = Math.max(yOf(num(s.vsw.kt)), TAPE_TOP);
    strip(top, TAPE_BOTTOM, COLORS.red, 15.2, 31.7, false);
    lowTop = Math.min(lowTop, top);
  }
  if (on(s.vls?.shown)) {
    const y = yOf(num(s.vls.kt));
    if (y < lowTop) {
      if (y >= TAPE_TOP) line(SPD_RIGHT, y, SPD_RIGHT + 12.4, y, COLORS.amber, NORMAL);
      line(SPD_RIGHT + 12.4, Math.max(y, TAPE_TOP), SPD_RIGHT + 12.4, lowTop, COLORS.amber, NORMAL);
    }
  }
  if (on(s.highSpeedProtection?.shown)) equalMark(yOf(num(s.highSpeedProtection.kt)), SPD_RIGHT - 31.7, SPD_RIGHT - 12.7, COLORS.green, true);
  if (on(s.vfeNext?.shown)) equalMark(yOf(num(s.vfeNext.kt)), SPD_RIGHT - 18.1, SPD_RIGHT, COLORS.amber, false);
  if (on(s.greenDot?.shown)) {
    const y = yOf(num(s.greenDot.kt));
    for (const [stroke, width] of [[BLACK, THICK_OUTLINE], [COLORS.green, THICK]]) {
      ctx.beginPath();
      ctx.arc(SPD_RIGHT, y, 7.9, 0, 2 * Math.PI);
      ctx.strokeStyle = stroke;
      ctx.lineWidth = width;
      ctx.stroke();
    }
  }
  for (const [item, letter] of [[s.fSpeed, "F"], [s.sSpeed, "S"]]) {
    if (!on(item?.shown)) continue;
    const y = yOf(num(item.kt));
    line(SPD_RIGHT, y, SPD_RIGHT + 24.1, y, COLORS.green, NORMAL);
    text(letter, SPD_RIGHT + 53.6, y + capHeight(F_LARGE) / 2, F_LARGE, COLORS.green, "center");
  }
  ctx.restore();
}

// A strip right of the speed scale: blocks of `fill` every `period` (from the top down, or from the bottom up),
// black between them, a thin line of the color on its outer side.
function strip(top, bottom, fill, block, period, fromBottom) {
  if (bottom <= top) return;
  rect(STRIP_LEFT, top, STRIP_RIGHT - STRIP_LEFT, bottom - top, BLACK);
  if (fromBottom) {
    for (let y = bottom; y > top; y -= period) {
      const y0 = Math.max(y - block, top);
      rect(STRIP_LEFT, y0, STRIP_RIGHT - STRIP_LEFT, y - y0, fill);
    }
  } else {
    for (let y = top; y < bottom; y += period) rect(STRIP_LEFT, y, STRIP_RIGHT - STRIP_LEFT, Math.min(block, bottom - y), fill);
  }
  line(STRIP_RIGHT - 0.5, top, STRIP_RIGHT - 0.5, bottom, fill, 1);
}

function equalMark(y, left, right, stroke, outline) {
  if (outline) {
    line(left, y - 3.2, right, y - 3.2, BLACK, OUTLINE);
    line(left, y + 3.2, right, y + 3.2, BLACK, OUTLINE);
  }
  line(left, y - 3.2, right, y - 3.2, stroke, NORMAL, "round");
  line(left, y + 3.2, right, y + 3.2, stroke, NORMAL, "round");
}

// A failed speed or altitude scale: the gray band stays, its top, right edge and bottom are drawn red.
function failedScaleOutline(left, right, over) {
  line(left, TAPE_TOP, right + over, TAPE_TOP, COLORS.red, NORMAL);
  line(right, TAPE_TOP, right, TAPE_BOTTOM, COLORS.red, NORMAL);
  line(left, TAPE_BOTTOM, right + over, TAPE_BOTTOM, COLORS.red, NORMAL);
}

// ==== 8. Altitude scale, window, target, baro reference =================================================================

function drawAltitude(d) {
  const a = d.altitude ?? {};
  if (on(d.flags?.alt)) {
    rect(ALT_LEFT, TAPE_TOP, ALT_RIGHT - ALT_LEFT, TAPE_BOTTOM - TAPE_TOP, GRAY);
    failedScaleOutline(ALT_LEFT, ALT_RIGHT, 0);
    rect(ALT_LEFT - 1, CY - 25, ALT_RIGHT - ALT_LEFT + 5, 50, BLACK);
    if (flagShown(d, "alt")) text("ALT", 826.3, CY + capHeight(F_FLAG) / 2, F_FLAG, COLORS.red, "right");
  } else {
    const alt = num(a.ft);
    const yOf = (ft) => CY - (ft - alt) * FT_PX;
    // Yellow reference line from the sphere to the altitude window.
    rect(CX + SPHERE_HALF_W + 3, CY - 4.76, ALT_LEFT - (CX + SPHERE_HALF_W + 3), 9.52, COLORS.yellow);
    rect(ALT_LEFT, TAPE_TOP, ALT_RIGHT - ALT_LEFT, TAPE_BOTTOM - TAPE_TOP, GRAY);
    ctx.save();
    ctx.beginPath();
    ctx.rect(725, TAPE_TOP, ALT_RIGHT - 725, TAPE_BOTTOM - TAPE_TOP);
    ctx.clip();
    // Graduations every 100 ft, labels (hundreds of feet) and chevrons every 500 ft.
    for (let ft = Math.floor((alt - 700) / 100) * 100; ft <= alt + 700; ft += 100) {
      const y = yOf(ft);
      line(ALT_RIGHT - 12.7, y, ALT_RIGHT, y, COLORS.white, NORMAL);
      if (ft % 500 !== 0) continue;
      text(String(ft / 100), 776.6, y + capHeight(F_SCALE) / 2, F_SCALE, COLORS.white, "center");
      poly([729.4, y + 6.8, 737.8, y, 729.4, y - 6.8], COLORS.white, NORMAL);
    }
    ctx.restore();
    line(ALT_RIGHT, TAPE_TOP, ALT_RIGHT, TAPE_BOTTOM, COLORS.white, NORMAL);
    line(ALT_LEFT, TAPE_TOP, ALT_RIGHT + 29.8, TAPE_TOP, COLORS.white, NORMAL);
    line(ALT_LEFT, TAPE_BOTTOM, ALT_RIGHT + 29.8, TAPE_BOTTOM, COLORS.white, NORMAL);

    // Red ground reference ribbon from the radio height down.
    const ra = a.radioHeight ?? {};
    if (on(ra.groundRibbon)) {
      const y = Math.max(CY + num(ra.ft) * FT_PX, TAPE_TOP);
      if (y < TAPE_BOTTOM) rect(826.2, y, 18, TAPE_BOTTOM - y, COLORS.red);
    }
    if (on(a.target?.shown)) drawAltitudeTarget(a, alt);
    drawAltitudeWindow(a, alt);

    // SIMPLIFIED linear deviation: the green dot left of the scale (no half dot / readout beyond ±500 ft).
    const vdev = a.verticalDeviation ?? {};
    if (on(vdev.dotShown)) {
      ctx.beginPath();
      ctx.arc(741.8, CY + clamp(num(vdev.ft), -500, 500) * 0.081 * 6.299, 9.5, 0, 2 * Math.PI);
      ctx.fillStyle = COLORS.green;
      ctx.fill();
    }
  }

  if (flagShown(d, "checkAlt")) {
    // "CHECK" down the right of the scale, "ALT" in a second column.
    const letters = "CHECKALT";
    for (let i = 0; i < letters.length; i++)
      text(letters[i], i < 5 ? 842.2 : 868.0, 274.6 + i * 26.8 + (i < 5 ? 0 : 3.7), F_SMALL, COLORS.amber, "center");
  }

  // Baro reference: STD in a yellow box, or QNH + setting; hidden in the off phase of its flashing.
  const baro = a.baro ?? {};
  if (!on(baro.flashOff)) {
    if (baro.mode === "std") {
      strokeRect(786.1, 829.9, 82.5, 44.4, COLORS.yellow, NORMAL);
      text("STD", 792.2, 865.3, F_SCALE, COLORS.cyan);
    } else if (baro.mode === "qnhHpa" || baro.mode === "qnhInHg") {
      const value = num(baro.value);
      text("QNH", 744.8, 870.0, F_SCALE, COLORS.white);
      text(baro.mode === "qnhHpa" ? String(value) : (value / 100).toFixed(2), 889.8, 870.0, F_SCALE, COLORS.cyan, "center");
    }
  }
}

// Altitude target: cyan (magenta for a constraint) digits on a black box between two brackets; off the scale, its
// value above / below the scale ("FL" with STD).
function drawAltitudeTarget(a, alt) {
  const fill = on(a.target.constraint) ? COLORS.magenta : COLORS.cyan;
  const target = num(a.target.ft);
  const std = a.baro?.mode === "std";
  const str = std ? String(clamp(Math.round(target / 100), 0, 999)).padStart(3, "0") : String(Math.round(target));
  const y = CY - (target - alt) * FT_PX;
  if (y < TAPE_TOP || y > TAPE_BOTTOM) {
    const baseline = y < TAPE_TOP ? 234.6 : 810.7;
    text(str, 858.1, baseline, F_SCALE, fill, "right");
    if (std) text("FL", 761.3, baseline, F_SMALL, fill, "center");
    return;
  }
  ctx.save();
  ctx.beginPath();
  ctx.rect(ALT_LEFT - 23, TAPE_TOP, 200, TAPE_BOTTOM - TAPE_TOP);
  ctx.clip();
  rect(ALT_LEFT, y - 19.0, std ? 78.7 : 120.6, 38.0, BLACK);
  for (const side of [-1, 1])
    poly([ALT_LEFT + 31.2, y + side * 19.0, ALT_LEFT + 31.2, y + side * 60.2, ALT_LEFT - 12.7, y + side * 60.2, ALT_LEFT - 12.7, y + side * 6.3, ALT_LEFT, y], fill, NORMAL);
  text(str, 744.8, y + capHeight(F_SCALE) / 2, F_SCALE, fill);
  ctx.restore();
}

// Altitude window: hundreds (rolling when the tens pass 80) and the tens drum in 20 ft steps; NEG; the outline
// (yellow, pulsing dim, or amber flashing).
function drawAltitudeWindow(a, alt) {
  const outline = [ALT_LEFT, CY - WINDOW_HALF_H, ALT_RIGHT, CY - WINDOW_HALF_H, ALT_RIGHT, CY - DRUM_HALF_H, DRUM_RIGHT, CY - DRUM_HALF_H,
    DRUM_RIGHT, CY + DRUM_HALF_H, ALT_RIGHT, CY + DRUM_HALF_H, ALT_RIGHT, CY + WINDOW_HALF_H, ALT_LEFT, CY + WINDOW_HALF_H];
  poly(outline, null, 0, true, BLACK);
  const digits = color(a.digitsColor) ?? COLORS.green;
  const value = Math.abs(alt);
  const hundreds = Math.floor(value / 100);
  const tens = value - hundreds * 100;
  const roll = tens > 80 ? (tens - 80) / 20 : 0;

  ctx.save();
  ctx.beginPath();
  ctx.rect(ALT_LEFT, CY - WINDOW_HALF_H, ALT_RIGHT - ALT_LEFT, 2 * WINDOW_HALF_H);
  ctx.clip();
  const baseline = CY + capHeight(F_FLAG) / 2;
  const xs = [815.0, 787.0, 757.5];          // hundreds, thousands, ten thousands
  let lowerNines = true;
  for (let k = 0, power = 1; k < 3; k++, power *= 10) {
    const current = Math.floor(hundreds / power) % 10;
    const next = Math.floor((hundreds + 1) / power) % 10;
    const showCurrent = k === 0 || hundreds >= power;
    const showNext = k === 0 || hundreds + 1 >= power;
    if (roll > 0 && lowerNines) {
      if (showCurrent) text(String(current), xs[k], baseline + roll * 44.1, F_FLAG, digits, "center");
      if (showNext) text(String(next), xs[k], baseline - (1 - roll) * 44.1, F_FLAG, digits, "center");
    } else if (showCurrent) text(String(current), xs[k], baseline, F_FLAG, digits, "center");
    lowerNines &&= current === 9;
  }
  ctx.restore();

  ctx.save();
  ctx.beginPath();
  ctx.rect(ALT_RIGHT, CY - DRUM_HALF_H, DRUM_RIGHT - ALT_RIGHT, 2 * DRUM_HALF_H);
  ctx.clip();
  const drum = ["00", "20", "40", "60", "80"];
  for (let n = -2; n <= 7; n++)
    text(drum[((n % 5) + 5) % 5], 853.2, CY + ((tens - n * 20) / 20) * 29.6 + capHeight(F_SMALLEST) / 2, F_SMALLEST, digits, "center");
  ctx.restore();

  if (on(a.negative)) [-18.0, 15.3, 48.3].forEach((dy, i) => text("NEG"[i], 766.0, CY + dy, F_LARGE, COLORS.white, "right"));

  const w = a.window ?? {};
  if (on(w.flashOff)) return;
  const stroke = on(w.pulseDim) ? DIM_YELLOW : color(w.color) ?? COLORS.yellow;
  poly(outline, stroke, NORMAL, false);
}

// ==== 9. Vertical speed =================================================================================================

function drawVerticalSpeed(d) {
  const v = d.verticalSpeed ?? {};
  const t = d.tcas ?? {};
  const shape = [VS_LEFT, CY - VS_HALF_H, VS_INNER, CY - VS_HALF_H, VS_OUTER, CY - VS_HALF_H + VS_SLANT_H,
    VS_OUTER, CY + VS_HALF_H - VS_SLANT_H, VS_INNER, CY + VS_HALF_H, VS_LEFT, CY + VS_HALF_H];
  poly(shape, null, 0, true, GRAY);
  if (on(d.flags?.vs)) {
    if (flagShown(d, "vs")) [-20.9, 15.1, 50.7].forEach((dy, i) => text("V/S"[i], 964.0, CY + dy, F_FLAG, COLORS.red, "right"));
    return;
  }

  // TCAS RA (SIMPLIFIED): the scale made rectangular and the red / green zones in its right part.
  if (on(t.raShown)) {
    rect(VS_INNER, CY - VS_HALF_H, VS_OUTER - VS_INNER, 2 * VS_HALF_H, GRAY);
    for (const [zone, fill] of [[t.redLow, COLORS.red], [t.redHigh, COLORS.red], [t.green, COLORS.green]]) {
      if (!on(zone?.shown)) continue;
      const y1 = CY - Math.sign(num(zone.fromFpm)) * vsOffset(num(zone.fromFpm));
      const y2 = CY - Math.sign(num(zone.toFpm)) * vsOffset(num(zone.toFpm));
      rect(VS_INNER, Math.min(y1, y2), VS_OUTER - VS_INNER, Math.abs(y2 - y1), fill);
    }
  }

  // Graduations: bars labeled 1, 2, 6 at 1000, 2000, 6000 ft/min; thin lines at 500, 1500, 4000.
  for (let k = 1; k < VS_MARKS.length; k++) {
    const dy = VS_MARK_AT[k] * VS_FULL;
    const m = VS_MARKS[k];
    for (const side of [-1, 1]) {
      const y = CY + side * dy;
      if (m === 1000 || m === 2000 || m === 6000) {
        const half = m === 6000 ? 4.6 * 0.83 : 4.6;
        rect(944.4, y - half, VS_INNER - 944.4, 2 * half, COLORS.white);
        text(String(m / 1000), 935.0, y + capHeight(F_SMALLEST) / 2, F_SMALLEST, COLORS.white, "center");
      } else line(944.4, y, VS_INNER, y, COLORS.white, SMALL);
    }
  }
  rect(918.4, CY - 4.76, VS_INNER - 918.4, 9.52, COLORS.yellow);

  // Needle: from the graduation towards a pivot right of the scale, over a black outline.
  const fpm = num(v.fpm);
  const needleColor = color(v.color) ?? COLORS.green;
  const y0 = CY - Math.sign(fpm) * vsOffset(fpm);
  const yEnd = y0 + (CY - y0) * ((993.6 - 949.5) / (1025.1 - 949.5));
  line(949.5, y0, 993.6, yEnd, BLACK, HUGE_OUTLINE);
  line(949.5, y0, 993.6, yEnd, needleColor, HUGE, "round");

  // Digits (hundreds of ft/min) in a black box, above the needle when climbing, below when descending.
  if (on(v.digitsShown)) {
    const hundreds = num(v.hundreds);
    const center = y0 - (hundreds > 0 ? 15.1 : -15.1);
    rect(953.4, center - 13.85, 44.4, 27.7, BLACK);
    if (on(v.baroOnly)) strokeRect(953.4, center - 13.85, 44.4, 27.7, COLORS.amber, SMALL);
    const digitsColor = on(t.raShown) ? color(t.digitsColor) : needleColor;
    text(String(Math.abs(hundreds)), 977.3, center + capHeight(F_SMALLEST) / 2, F_SMALLEST, digitsColor, "center");
  }

  // Amber vertical "TCAS": no RA data.
  if (on(t.message)) [629.9, 661.4, 692.9, 724.4].forEach((y, i) => text("TCAS"[i], 891.4, y, F_SMALL, COLORS.amber, "right"));
}

// ==== 10. Heading scale =================================================================================================

function drawHeading(d) {
  const h = d.heading ?? {};
  const frame = (stroke) => poly([HDG_LEFT, 984.1, HDG_LEFT, HDG_TOP, HDG_RIGHT, HDG_TOP, HDG_RIGHT, 984.1], stroke, NORMAL);
  rect(HDG_LEFT, HDG_TOP, HDG_RIGHT - HDG_LEFT, HDG_BOTTOM - HDG_TOP, GRAY);
  if (on(d.flags?.hdg)) {
    frame(COLORS.red);
    if (flagShown(d, "hdg")) text("HDG", 478.3, (HDG_TOP + HDG_BOTTOM) / 2 + capHeight(F_FLAG) / 2, F_FLAG, COLORS.red, "right");
  } else {
    const heading = wrap360(num(h.deg));
    ctx.save();
    ctx.beginPath();
    ctx.rect(HDG_LEFT, HDG_TOP, HDG_RIGHT - HDG_LEFT, HDG_BOTTOM - HDG_TOP);
    ctx.clip();
    // Marks every 5°, labels every 10° (tens of degrees; larger every 30°).
    for (let deg = Math.floor((heading - 30) / 5) * 5; deg <= heading + 30; deg += 5) {
      const x = CX + (deg - heading) * DEG_PX;
      const ten = deg % 10 === 0;
      line(x, HDG_TOP, x, HDG_TOP + (ten ? 25.2 : 10.6), COLORS.white, NORMAL);
      if (!ten) continue;
      const n = Math.round(wrap360(deg) / 10) % 36;
      text(String(n), x, 974.1, n % 3 === 0 ? F_SCALE : F_SMALLEST, COLORS.white, "center");
    }
    // Green track diamond.
    if (on(h.track?.shown)) {
      const x = CX + wrap180(num(h.track.deg) - heading) * DEG_PX;
      poly([x, HDG_TOP + 2.6, x + 7.9, HDG_TOP + 13.7, x, HDG_TOP + 24.8, x - 7.9, HDG_TOP + 13.7], COLORS.green, THICK, true, null, "round");
    }
    ctx.restore();
    frame(COLORS.white);

    // Selected heading / track: cyan trapezoid on the scale, or its digits at the side when off it.
    if (on(h.target?.shown)) {
      const target = num(h.target.deg);
      const offset = wrap180(target - heading) * DEG_PX;
      if (Math.abs(offset) > SPHERE_HALF_W) {
        const n = Math.round(wrap360(target)) % 360 || 360;
        text(String(n).padStart(3, "0"), offset < 0 ? 229.4 : 640.6, 909.3, F_SMALLEST, COLORS.cyan, "center");
      } else {
        const x = CX + offset;
        poly([x - 6.8, 914.0, x - 19.0, 880.2, x + 19.0, 880.2, x + 6.8, 914.0], COLORS.cyan, NORMAL, false, null, "round");
      }
    }
    // SIMPLIFIED ILS course: a magenta line on the scale (no off-scale digits).
    const course = d.landingSystem?.course ?? {};
    if (on(course.shown)) {
      const offset = wrap180(num(course.deg) - heading) * DEG_PX;
      if (Math.abs(offset) <= SPHERE_HALF_W) line(CX + offset, HDG_TOP - 20, CX + offset, HDG_TOP + 30, COLORS.magenta, THICK);
    }
    // Yellow reference line.
    rect(428.9, 877.2, 9.6, 50.8, COLORS.yellow);
    if (on(h.trueReference)) {
      strokeRect(393.3, 847.0, 81.5, 28.8, COLORS.cyan, NORMAL);
      text("TRUE", 434.05, 861.4 + capHeight(F_SMALLEST) / 2, F_SMALLEST, COLORS.cyan, "center");
    }
  }
  if (flagShown(d, "checkHdg")) text("CHECK HDG", 365.0, 908.0, F_SCALE, COLORS.amber, "right");
}

// ==== 11. Landing system (SIMPLIFIED) ===================================================================================
// LOC / G/S scales with white dots and magenta diamonds, the red LOC / G/S flags, the ILS frequency / ident / DME
// bottom left, and the marker. Our Displays draws more (half diamonds beyond 2 dots, exact text places...).

function drawLandingSystem(d) {
  const ls = d.landingSystem;
  if (!ls) return;
  const lsFlag = (name) => on(ls.flags?.[name]) && !on(ls.flagsFlashOff?.[name]);
  const dot = (x, y) => {
    ctx.beginPath();
    ctx.arc(x, y, 6.3, 0, 2 * Math.PI);
    ctx.strokeStyle = COLORS.white;
    ctx.lineWidth = NORMAL;
    ctx.stroke();
  };
  const diamond = (x, y, hw, hh) => poly([x - hw, y, x, y - hh, x + hw, y, x, y + hh], COLORS.magenta, NORMAL, true);

  if (on(ls.locScale?.shown) && !on(ls.locScale.flashOff)) {
    for (const k of [-2, -1, 1, 2]) dot(CX + k * LS_DOT, LOC_Y);
    rect(CX - 4.8, LOC_Y - 20, 9.6, 40, COLORS.yellow);
    if (lsFlag("loc")) text("LOC", CX, LOC_Y + capHeight(F_FLAG) / 2, F_FLAG, COLORS.red, "center");
    else if (on(ls.loc?.shown) && !on(ls.loc.flashOff)) diamond(CX + clamp(num(ls.loc.dots), -2, 2) * LS_DOT, LOC_Y, 23.8, 15.9);
  }
  if (on(ls.gsScale?.shown) && !on(ls.gsScale.flashOff)) {
    for (const k of [-2, -1, 1, 2]) dot(GS_X, CY + k * LS_DOT);
    rect(GS_X - 26.6, CY - 4.8, 53.2, 9.6, COLORS.yellow);
    if (lsFlag("gs")) ["G", "/", "S"].forEach((c, i) => text(c, GS_X, CY - 40 + i * 40, F_FLAG, COLORS.red, "center"));
    else if (on(ls.gs?.shown) && !on(ls.gs.flashOff)) diamond(GS_X, CY - clamp(num(ls.gs.dots), -2, 2) * LS_DOT, 15.9, 23.8);
  }

  const info = ls.ilsInfo ?? {};
  const receiver = num(ls.receiver, 1) === 2 ? "2" : "1";
  if (lsFlag("ils")) text("ILS" + receiver, 7, 952, F_LARGE, COLORS.red);
  else if (on(info.shown)) {
    text((num(info.frequencyKhz) / 1000).toFixed(2), 7, 952, F_LARGE, COLORS.magenta);
    if (on(info.identShown) && typeof info.ident === "string") text(info.ident, 7, 914, F_LARGE, COLORS.magenta);
  }
  if (lsFlag("dme")) text("DME" + receiver, 7, 990, F_LARGE, COLORS.red);
  else if (on(info.shown) && on(info.dmeShown)) text(num(info.dmeNm).toFixed(1) + "NM", 7, 990, F_LARGE, COLORS.magenta);

  if (on(ls.lsMessage?.shown) && !on(ls.lsMessage.flashOff)) text("LS", 650, 340, F_SCALE, COLORS.amber, "center");
  const marker = ls.marker ?? {};
  if (on(marker.shown) && !on(marker.flashOff)) {
    const m = { outer: ["OM", COLORS.cyan], middle: ["MM", COLORS.amber], inner: ["IM", COLORS.white] }[marker.type];
    if (m) text(m[0], 650, 300, F_SCALE, m[1], "center");
  }
}

// ==== 12. Display unit messages =========================================================================================

function drawDuMessages(du) {
  const feedback = { checkCaptPfd: "CHECK CAPT PFD", checkFoPfd: "CHECK F/O PFD", checkCaptNd: "CHECK CAPT ND",
    checkFoNd: "CHECK F/O ND", checkEwd: "CHECK EWD", checkSd: "CHECK SD" }[du.feedback];
  // SIMPLIFIED place: under the FMA.
  if (feedback) text(feedback, CX, 175, F_SMALL, COLORS.amber, "center");
  if (on(du.notMonitored)) text("DU NOT MONITORED", CX, 205, F_SMALL, COLORS.amber, "center");
}

// ==== 13. Start =========================================================================================================

// The canvas buffer follows its size on the screen (x devicePixelRatio) so lines and texts stay sharp; the drawing
// itself is in design units and does not change.
function fitCanvas() {
  const size = Math.round(canvas.clientWidth * (window.devicePixelRatio || 1));
  if (size > 0 && canvas.width !== size) {
    canvas.width = canvas.height = size;
    dirty = true;
  }
}

let silentSeconds = 0;

function frame() {
  fitCanvas();
  // No message for a while (Systems paused or busy, network trouble): say so, keep the last picture. A closed
  // connection is handled by onclose (reconnection).
  const silent = pfd && socket ? Math.floor((performance.now() - lastMessageAt) / 1000) : 0;
  if (silent !== silentSeconds) {
    silentSeconds = silent;
    if (silent >= 3) setStatus(`no message from Systems for ${silent} s`);
    else if (socket) setStatus(`receiving ${STREAM}`);
  }
  if (dirty) {
    dirty = false;
    drawFrame();
  }
  requestAnimationFrame(frame);
}

// Load the font before the first drawing (canvas text does not wait for a CSS font); monospace if it fails.
async function start() {
  try {
    await document.fonts.load(`40px "NVANEIS"`);
  } catch {
    // keep the fallback
  }
  window.pfdState = () => pfd;   // the merged state, for a look from the browser console
  connect();
  requestAnimationFrame(frame);
}

start();
