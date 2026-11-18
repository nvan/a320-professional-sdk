/*
 * NVAN A320 Professional: a minimal Hardware plugin in plain C (see include/nvan_hardware_plugin.h).
 *
 * One device type, "C example panel", with one button and one light:
 *   - the button presses MASTER WARN (glare.masterWarn.capt.pressed);
 *   - the light follows the MASTER WARN light (glare.masterWarn.capt.lit).
 * There is no real device: the button is "pressed" every 5 seconds and the light is written to the plugin's log
 * (Hardware's Plugins tab). Replace those two places with your device's I/O.
 */
#include <stdio.h>
#include "nvan_hardware_plugin.h"

static const nvan_hw_host_api *host;   /* Hardware's functions */
static uint32_t panel;                 /* the device handle (0 = no panel open) */
static uint32_t light_id;              /* the id subscribe() gave the light's dataref */
static int ticks;                      /* update() calls since the panel opened */

static int32_t open_device(uint32_t device, const char *type_id, const char *settings_json)
{
    panel = device;
    ticks = 0;
    light_id = host->subscribe(host->context, "glare.masterWarn.capt.lit");   /* its value comes to on_dataref */
    host->set_status(host->context, device, 1, "Connected (simulated)");
    return NVAN_HW_OK;
}

static void close_device(uint32_t device)
{
    host->unsubscribe(host->context, light_id);
    panel = 0;
}

/* Every 10 ms (the manifest's updateIntervalMs): read the device here, without blocking. */
static void update(void)
{
    if (panel == 0) return;
    ticks++;
    if (ticks % 500 == 0) {   /* 500 x 10 ms = every 5 seconds: the button went down */
        host->log(host->context, NVAN_HW_LOG_INFO, "Button pressed");
        host->press(host->context, "glare.masterWarn.capt.pressed");
    }
}

/* A followed dataref changed. valid = 0 while Systems is not connected: show the light dark. */
static void on_dataref(uint32_t id, int32_t valid, double number, const char *text)
{
    if (id != light_id) return;
    char line[64];
    snprintf(line, sizeof line, "Light %s", valid && number != 0 ? "ON" : "off");
    host->log(host->context, NVAN_HW_LOG_INFO, line);
}

static void plugin_shutdown(void)
{
}

static const nvan_hw_plugin_api plugin = {
    .struct_size = sizeof(nvan_hw_plugin_api),
    .abi_version = NVAN_HW_ABI_VERSION,
    .manifest_json =
        "{\"id\": \"com.example.c-panel\", \"name\": \"C example panel\", \"version\": \"1.0.0\","
        " \"vendor\": \"Example\", \"description\": \"One button and one light, in C\","
        " \"deviceTypes\": [{\"id\": \"c-panel\", \"name\": \"C example panel\", \"settings\": []}]}",
    .open_device = open_device,
    .close_device = close_device,
    .update = update,
    .shutdown = plugin_shutdown,
    .on_dataref = on_dataref,
};

/* The only export: Hardware calls it once when it loads the library. */
NVAN_HW_EXPORT const nvan_hw_plugin_api *nvan_hw_plugin_entry(const nvan_hw_host_api *host_api)
{
    host = host_api;
    return &plugin;
}
