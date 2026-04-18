
using System;
using System.Net;
using KRPC.Client;
using KRPC.Client.Services.KRPC;

namespace Houston.Components.Connections;

class GameConnection
{
    public static void KRPCConnection(string ipaddress, string rpcport, string streamport)
    {
        using (var connection = new Connection(
            name: "Houston Host",
            address: IPAddress.Parse(ipaddress),
            rpcPort: int.Parse(rpcport),
            streamPort: int.Parse(streamport)))
        {
            var krpc = connection.KRPC();
            Console.WriteLine("KRPC Connection Status Verification: " + krpc.GetStatus().Version);
        }
    }
}