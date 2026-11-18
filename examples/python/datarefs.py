# NVAN A320 Professional: follow, read, write and press datarefs from Python.
# Python 3 only, nothing to install. Run:  python3 datarefs.py [address]     (default localhost)
# The address and API port (8080) are shown in the Systems window. Stop with Ctrl+C.
#
# Systems speaks WebSocket at ws://<address>:8080/api/ws with JSON text messages. Python has no WebSocket in its
# standard library, so the few lines below open one by hand. With the "websockets" package
# (pip install websockets) the same is: websocket = websockets.sync.client.connect(url); websocket.send(text);
# websocket.recv().

import base64
import json
import os
import socket
import struct
import sys

host = sys.argv[1] if len(sys.argv) > 1 else "localhost"
port = 8080

# Open the WebSocket: a TCP connection plus an HTTP "Upgrade" request; Systems answers "101 Switching Protocols".
connection = socket.create_connection((host, port))
key = base64.b64encode(os.urandom(16)).decode()
connection.sendall((f"GET /api/ws HTTP/1.1\r\nHost: {host}:{port}\r\nUpgrade: websocket\r\nConnection: Upgrade\r\n"
                    f"Sec-WebSocket-Key: {key}\r\nSec-WebSocket-Version: 13\r\n\r\n").encode())
stream = connection.makefile("rb")
print(stream.readline().decode().strip())          # HTTP/1.1 101 Switching Protocols
while stream.readline() != b"\r\n":                # skip the other header lines
    pass


def send(message):
    # One WebSocket text frame. A client must mask what it sends with 4 random bytes.
    data = json.dumps(message).encode()
    mask = os.urandom(4)
    if len(data) < 126:
        header = struct.pack("!BB", 0x81, 0x80 | len(data))
    else:
        header = struct.pack("!BBH", 0x81, 0x80 | 126, len(data))
    connection.sendall(header + mask + bytes(b ^ mask[i % 4] for i, b in enumerate(data)))


def receive():
    # One WebSocket frame from Systems (not masked). Returns the JSON message, or None for a frame without text.
    first, second = stream.read(2)
    length = second & 0x7F
    if length == 126:
        length = struct.unpack("!H", stream.read(2))[0]
    elif length == 127:
        length = struct.unpack("!Q", stream.read(8))[0]
    data = stream.read(length)
    if first & 0x0F == 8:                          # Systems closed the connection
        sys.exit("Connection closed")
    if first & 0x0F != 1:                          # not a text message (a keep-alive): ignore it
        return None
    return json.loads(data)


# 1. Follow a dataref: Systems sends its current value now, then every change.
send({"op": "subscribe", "paths": ["overhead.elec.bat1.pressed"]})

# 2. Read a dataref once.
send({"op": "get", "paths": ["glare.fcu.altWindow"]})

# 3. Write a dataref: a switch or latching pushbutton gets its position (here BAT 1 on).
send({"op": "set", "path": "overhead.elec.bat1.pressed", "value": 1})

# 4. Press a momentary pushbutton: Systems holds it 100 ms and releases it.
send({"op": "press", "path": "glare.masterWarn.capt.pressed"})

# Print what Systems answers, then every change of the followed dataref.
while True:
    message = receive()
    if message is None:
        continue
    if message["op"] == "values":
        for path, value in message["values"].items():
            print(f"{path} = {value}")
    elif message["op"] == "get":
        print(f"Read once: {message['values']}")
    elif message["op"] == "ack":
        print("Done")
    elif message["op"] == "error":
        print(f"Error: {message['message']}")
