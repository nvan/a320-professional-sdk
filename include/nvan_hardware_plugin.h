/*
 * NVAN A320 Professional - Hardware plugin ABI, version 2.
 *
 * Copyright (c) 2026 NVAN. Licensed under the MIT License. See LICENSE in the SDK root.
 *
 * A Hardware plugin is a native shared library (.so on Linux, .dll on Windows, x86-64) that exports ONE function,
 * nvan_hw_plugin_entry. The Hardware program runs every plugin in its own helper process (HardwarePluginHost), so a
 * plugin that crashes or hangs never takes Hardware down: the process is restarted on its own.
 *
 * Install: copy the library into the "plugins" folder next to the Hardware executable (plugins/<name>.so|.dll or
 * plugins/<name>/<name>.so|.dll). Hardware picks it up within 2 seconds; its log is in Hardware's Plugins tab.
 *
 * Datarefs: every cockpit control, light, display and aircraft state is a dataref, named by a path
 * ("glare.fcu.ap1.pressed", "overhead.elec.bat1.pressed", "glare.fcu.altWindow"...). The plugin itself reads, writes and
 * follows the datarefs it needs through the host functions below; nothing is bound in Hardware. Which datarefs a
 * button, light or display uses is the plugin's choice: its own settings or configuration window (open_config) can
 * offer them from the catalog (host->catalog).
 *
 * Rules (summary):
 *  - Strings are UTF-8 and NUL-terminated. Strings the host passes in are valid only during that call: copy them.
 *    The manifest string the plugin returns must stay valid until shutdown() returns.
 *  - Every function of nvan_hw_plugin_api except open_config is called from ONE host thread (the plugin thread),
 *    never concurrently, so a plugin needs no locking for state touched only from those functions. open_config is
 *    the exception: it runs on its own thread, concurrently with the others (see open_config below).
 *  - Thread safety of the host: every function of nvan_hw_host_api is thread-safe and never blocks (it queues the
 *    request or reads a cache): it may be called from any thread (the plugin thread, open_config, the plugin's own
 *    reader threads) from the moment nvan_hw_plugin_entry is called until shutdown() returns. Writes, presses and
 *    subscriptions made from one thread reach Hardware in the order they were made.
 *  - Values are absolute (a switch's position, a knob's value), never deltas.
 *  - Do not block: update() runs every update interval (manifest "updateIntervalMs"); a call that does not return
 *    for 3 seconds makes Hardware kill and restart the plugin process.
 *  - Reconnection: Systems may restart or the network may drop at any time. Subscriptions survive it on their own
 *    (values become "not valid", then every value is delivered again). Writes made while Systems is not connected
 *    are dropped after 3 s: write the state of your switches again in on_systems_changed(1).
 *  - A plugin process that ends (crash, hang, restart, disabled) has every press it was holding released by Hardware.
 *  - Compatibility: structures only grow at the end. struct_size tells the reader which fields exist.
 *    abi_version is the major version: a plugin built for another major version is refused.
 *    Version 2 renamed two members to American spelling on 2026-11-14 (catalogue -> catalog,
 *    on_catalogue_changed -> on_catalog_changed) without bumping the version: names are not part of the binary
 *    interface and the layout is unchanged, so a library built from the older header still loads.
 *    The host table grew on 2026-11-16 (remote_axis, at its end): check NVAN_HW_HOST_HAS_REMOTE_AXIS(host) before
 *    calling it (an older Hardware has a 96-byte table without it).
 *  - Remote axes: a lever, stick, pedal or tiller the plugin reads may be reported with remote_axis() (raw value and its
 *    range) instead of writing its ctl.axis.* dataref; see remote_axis below.
 */
#ifndef NVAN_HARDWARE_PLUGIN_H
#define NVAN_HARDWARE_PLUGIN_H

#include <stddef.h>
#include <stdint.h>

#ifdef __cplusplus
extern "C" {
#endif

#define NVAN_HW_ABI_VERSION 2u

#if defined(_WIN32)
#define NVAN_HW_EXPORT __declspec(dllexport)
#else
#define NVAN_HW_EXPORT __attribute__((visibility("default")))
#endif

/* Log levels for nvan_hw_host_api.log. */
#define NVAN_HW_LOG_DEBUG 0
#define NVAN_HW_LOG_INFO 1
#define NVAN_HW_LOG_WARNING 2
#define NVAN_HW_LOG_ERROR 3

/* Results of open_device. */
#define NVAN_HW_OK 0
#define NVAN_HW_ERROR_UNKNOWN_TYPE (-1)
#define NVAN_HW_ERROR_BAD_SETTINGS (-2)
#define NVAN_HW_ERROR_FAILED (-3)

/* Dataref value types (nvan_hw_dataref_info.type). */
#define NVAN_HW_TYPE_BOOL 0     /* 0 / 1 */
#define NVAN_HW_TYPE_INT 1
#define NVAN_HW_TYPE_FLOAT 2
#define NVAN_HW_TYPE_STRING 3   /* text with a fixed format: "0456", "121.800", "24000" */

/* Dataref kinds (nvan_hw_dataref_info.kind): what the dataref is in the cockpit. */
#define NVAN_HW_KIND_PUSHBUTTON 0
#define NVAN_HW_KIND_SWITCH 1
#define NVAN_HW_KIND_ROTARY 2
#define NVAN_HW_KIND_ENCODER 3
#define NVAN_HW_KIND_ANALOG 4
#define NVAN_HW_KIND_LIGHT 5
#define NVAN_HW_KIND_SERVICE 6
#define NVAN_HW_KIND_FAILURE 7
#define NVAN_HW_KIND_OUTPUT 8
#define NVAN_HW_KIND_GATE 9

/* One dataref of the catalog. */
typedef struct nvan_hw_dataref_info {
    const char *path;          /* "glare.fcu.ap1.pressed" */
    const char *panel;         /* where it is: "Glareshield / FCU" */
    const char *description;   /* one line for the user */
    int32_t type;              /* NVAN_HW_TYPE_* */
    int32_t kind;              /* NVAN_HW_KIND_* */
    int32_t writable;          /* 1: write_number / write_text / press accept it */
    int32_t momentary;         /* 1: a pushbutton that is 1 only while held: press() it, or write 1 then 0 */
} nvan_hw_dataref_info;

/* Provided by the host. Every function is thread-safe and non-blocking (see the rules above). */
typedef struct nvan_hw_host_api {
    uint32_t struct_size;   /* sizeof(nvan_hw_host_api) of the host */
    uint32_t abi_version;   /* NVAN_HW_ABI_VERSION of the host */
    void *context;          /* pass back as the first argument of every function below */

    /* Writes a line to the plugin's log (Hardware's Plugins tab and plugin-logs/<file>.log). */
    void (*log)(void *context, int32_t level, const char *message);

    /* Connection state of a device and a short text for the device list ("Connected: PoKeys 12345",
     * "Waiting for COM3"...). A device starts as not connected. */
    void (*set_status)(void *context, uint32_t device, int32_t connected, const char *text);

    /* Follows a dataref: returns its id (1, 2, ...; 0 for an empty or over-long path). The same path always gets the
     * same id in this process, so subscribing twice is harmless (one subscription). Its value then comes to
     * on_dataref: the current value as soon as Hardware has it, then every change, "not valid" while Systems is not
     * connected or does not know the path (logged once), and every value again after Systems reconnects or restarts. */
    uint32_t (*subscribe)(void *context, const char *path);

    /* Stops following a dataref (its id stays reserved for the path: subscribe returns it again). */
    void (*unsubscribe)(void *context, uint32_t id);

    /* Writes a dataref: bool (0 / non-zero), int (rounded) or float; a string dataref gets the number as text. The
     * write waits (up to 3 s) until Systems is connected and knows the path; unknown or read-only paths are dropped and
     * logged. A non-zero write of a momentary dataref is held at least 100 ms, then until the plugin writes 0. */
    void (*write_number)(void *context, const char *path, double value);

    /* Writes a string dataref; a numeric dataref gets the text parsed as a number ("1", "0.5", "true"). */
    void (*write_text)(void *context, const char *path, const char *text);

    /* A momentary press: writes 1, then 0 at least 100 ms later (Hardware releases it even if the plugin dies). */
    void (*press)(void *context, const char *path);

    /* The last value delivered for a subscribed path, without waiting: returns 1 and fills *number (NaN for a string
     * dataref) and text (the value as text, cut to text_size bytes, NUL-terminated; either may be NULL), or 0 when
     * there is no value (not subscribed, not received yet, Systems not connected, unknown path). */
    int32_t (*read)(void *context, const char *path, double *number, char *text, uint32_t text_size);

    /* The dataref catalog: an array of *count entries in Systems' order (count 0 until Hardware has received it
     * from Systems). The array and its strings stay valid until the process ends, also after on_catalog_changed
     * brings a newer one: keep the pointer, read it from any thread. */
    const nvan_hw_dataref_info *(*catalog)(void *context, uint32_t *count);

    /* 1 while Hardware is connected to Systems (values and writes flow), else 0. on_systems_changed reports changes. */
    int32_t (*systems_connected)(void *context);

    /* (Since 2026-11-16; check NVAN_HW_HOST_HAS_REMOTE_AXIS(host) first.) Reports a remote axis of a device: a lever,
     * stick, pedal or tiller the plugin reads. `name` identifies the axis on the device ("THROTTLE LEFT"; shown to the
     * user), `function` is the axis function it drives by default ("ctl.axis.thrustLever1", "ctl.axis.speedBrakeLever"...
     * from the catalog, panel "Controls / Axes (hardware)"), `value` its raw reading between `min` and `max` (the axis'
     * own units, e.g. 0..1023; min > max for a reversed axis). By default Hardware sends it flat: the raw range linearly
     * onto the function's range (a lever: 0 = IDLE / RET .. 1 = TO/GA / FULL, no detents, no reverse; a stick -1..1).
     * The user may enable it, per axis, in the device's editor: it is then handled like a joystick axis (any function,
     * end stops, response curve, a lever's detents and reverse zone). Sent to Systems while the device is open; a closed
     * device, or value NaN, releases it (sticks and pedals return to neutral, levers hold). Call it whenever the value
     * changes (more often is harmless: only changes travel). Do not also write the ctl.axis.* dataref. */
    void (*remote_axis)(void *context, uint32_t device, const char *name, const char *function, double value, double min,
                        double max);
} nvan_hw_host_api;

/* Whether the host table has remote_axis (Hardware from 2026-11-16 on). */
#define NVAN_HW_HOST_HAS_REMOTE_AXIS(host) \
    ((host)->struct_size >= (uint32_t)(offsetof(nvan_hw_host_api, remote_axis) + sizeof(void *)) && (host)->remote_axis != 0)

/* Provided by the plugin (returned by nvan_hw_plugin_entry). */
typedef struct nvan_hw_plugin_api {
    uint32_t struct_size;   /* sizeof(nvan_hw_plugin_api) */
    uint32_t abi_version;   /* NVAN_HW_ABI_VERSION */

    /* Manifest (JSON), valid until shutdown() returns. Unknown members are ignored. Ids: 1..64 of A-Z a-z 0-9 . _ -
     *   {"id": "com.example.panels",          unique, never change it (users' devices refer to it)
     *    "name": "Example panels", "version": "1.0.0", "vendor": "...", "description": "...",
     *    "updateIntervalMs": 10,              1..1000, default 10
     *    "minPluginApi": "1.0.0",             the oldest Plugin API ("x.y.z") the plugin needs; default "1.0.0"
     *    "maxPluginApi": "2.0.0",             optional, excluded; only after a drastic (MAJOR) change
     *    "deviceTypes": [{                    1..64 types
     *      "id": "fcu", "name": "Example FCU", "description": "...",
     *      "hasConfig": false,                true: a "Config..." button calls open_config
     *      "settings": [{"key": "port", "label": "Port", "type": "string", "default": "", "help": "..."}]}]}
     *                                         type: string | number (min, max) | bool | choice ("choices": [...])
     * Settings are edited by the user in Hardware's device list and passed to open_device.
     * Plugin API (separate from NVAN_HW_ABI_VERSION, the struct layout): MAJOR.MINOR.PATCH from 1.0.0; PATCH = datarefs
     * added, MINOR = host functions or services added, MAJOR = a change that breaks older plugins (not planned). A
     * plugin works with every product providing minPluginApi or later within the same MAJOR (or below maxPluginApi
     * when given). Hardware does not start a plugin whose range the running product does not provide ("Not compatible
     * with this version"); a malformed range refuses the manifest. Declare the API your plugin was built and tested
     * against: a newer dataref you use means a newer minimum. */
    const char *manifest_json;

    /* Creates device `device` (a handle chosen by the host, unique while the process lives) of type `type_id`
     * with the user's settings (a JSON object with one member per setting key). Since Plugin API 1.1.0 the object also
     * has the reserved member "deviceId": the device's stable id in Hardware (a short string that never changes while
     * the user keeps the device, unlike the handle), to keep the plugin's own per-device data under it. Do not declare a
     * setting with that key: Hardware replaces its value. Returns NVAN_HW_OK, or a negative
     * NVAN_HW_ERROR_* (log why). Opening must not wait for the hardware: a device whose hardware is missing opens
     * fine, reports not connected, and keeps trying from update(). */
    int32_t (*open_device)(uint32_t device, const char *type_id, const char *settings_json);

    /* Releases a device (removed, disabled or its settings changed: it is opened again with the new settings). */
    void (*close_device)(uint32_t device);

    /* Called every update interval: poll the hardware, retry lost connections, write datarefs, report status. */
    void (*update)(void);

    /* Last call: close the hardware and free everything. No host function may be called after it returns. */
    void (*shutdown)(void);

    /* Optional (NULL when no device type declares "hasConfig": true in the manifest; required when one does).
     * The user pressed the device's "Config..." button in Hardware: show the plugin's own configuration window for
     * device `device` (any toolkit, or none: open a file, start a program...), for example to choose the datarefs of
     * each button and light from host->catalog. Fire and forget: the host ignores what happens and expects no result.
     * Threading: called on a dedicated config thread, NOT the plugin thread, so it runs CONCURRENTLY with update(),
     * on_dataref() and the other functions: protect what it shares with them. It is not watched by the 3 s watchdog:
     * it may block for as long as the window is open (a modal dialog with its own message loop is fine). It must never
     * block the plugin thread waiting for the window. Requests for a device whose open_config has not returned yet
     * are not delivered. On Windows the thread is a single-threaded apartment (STA).
     * The device may be closed (and shutdown() called, then the process ends) while the window is open: check that
     * the handle is still open before using it. The plugin stores its configuration where it wants (next to the
     * library, the user's configuration folder...) and applies it itself; every host function may be called from
     * this thread. */
    void (*open_config)(uint32_t device);

    /* Optional. A subscribed dataref's value (plugin thread): `id` from subscribe; valid 0 = no data (Systems not
     * connected, unknown path): show it dark / blank. number: bool 0/1, int or float (NaN for a string dataref);
     * text: the value as text (a string dataref as is, a number formatted invariantly), never NULL, valid only during
     * the call. Called with the current value after subscribing, then on every change. */
    void (*on_dataref)(uint32_t id, int32_t valid, double number, const char *text);

    /* Optional. A new dataref catalog arrived (plugin thread): read it with host->catalog. */
    void (*on_catalog_changed)(void);

    /* Optional. Hardware's connection to Systems changed (plugin thread): 1 connected, 0 lost. When it becomes 1,
     * write the current state of switches and selectors again (a restarted Systems starts from its defaults). */
    void (*on_systems_changed)(int32_t connected);
} nvan_hw_plugin_api;

/* The only export. Called once on the plugin thread. Keep `host` (it stays valid until shutdown returns) and return
 * the plugin's function table (static storage), or NULL when the plugin cannot start (log why first). */
NVAN_HW_EXPORT const nvan_hw_plugin_api *nvan_hw_plugin_entry(const nvan_hw_host_api *host);

typedef const nvan_hw_plugin_api *(*nvan_hw_plugin_entry_fn)(const nvan_hw_host_api *host);

#ifdef __cplusplus
}
#endif

#endif /* NVAN_HARDWARE_PLUGIN_H */
