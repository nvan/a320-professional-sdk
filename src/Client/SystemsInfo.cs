namespace NVAN.A320.Sdk.Client;

/// <summary>Who a Systems is: the reply to the <c>info</c> op and to <c>GET /api/info</c>.</summary>
/// <param name="Product">Product name, "NVAN A320 Professional".</param>
/// <param name="Version">Version of Systems.</param>
/// <param name="Api">
/// Protocol version. It is raised only for a change that breaks existing clients; new ops and new fields keep it.
/// This library speaks version 1.
/// </param>
/// <param name="SimId">SIM ID: 4 characters that identify the simulator on the network (e.g. "K7QX").</param>
/// <param name="Name">User-editable simulator name.</param>
/// <param name="InstanceId">Random per Systems process: a different value means Systems was restarted.</param>
public sealed record SystemsInfo(string Product, string Version, int Api, string SimId, string Name, uint InstanceId);
