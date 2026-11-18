// NVAN A320 Professional: follow, read, write and press datarefs from Node.js 22 or newer (nothing to install).
// Run:  node datarefs.mjs [address]     (default localhost; the address and API port are shown in the Systems window)
// Stop with Ctrl+C.

const host = process.argv[2] ?? "localhost";
const socket = new WebSocket(`ws://${host}:8080/api/ws`);

socket.onopen = () => {
  console.log("Connected");

  // 1. Follow a dataref: Systems sends its current value now, then every change.
  socket.send(JSON.stringify({ op: "subscribe", paths: ["overhead.elec.bat1.pressed"] }));

  // 2. Read a dataref once.
  socket.send(JSON.stringify({ op: "get", paths: ["glare.fcu.altWindow"] }));

  // 3. Write a dataref: a switch or latching pushbutton gets its position (here BAT 1 on).
  socket.send(JSON.stringify({ op: "set", path: "overhead.elec.bat1.pressed", value: 1 }));

  // 4. Press a momentary pushbutton: Systems holds it 100 ms and releases it.
  socket.send(JSON.stringify({ op: "press", path: "glare.masterWarn.capt.pressed" }));
};

// Print what Systems answers, then every change of the followed dataref.
socket.onmessage = (event) => {
  const message = JSON.parse(event.data);
  if (message.op === "values") {
    for (const [path, value] of Object.entries(message.values)) console.log(`${path} = ${value}`);
  } else if (message.op === "get") {
    console.log("Read once:", message.values);
  } else if (message.op === "ack") {
    console.log("Done");
  } else if (message.op === "error") {
    console.log("Error:", message.message);
  }
};

socket.onclose = () => console.log("Connection closed");
