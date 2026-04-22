
using System;
using System.Net;
using KRPC.Client;
using KRPC.Client.Services.KRPC;
using Houston.Services;

namespace Houston.Components.Connections;

class GameConnection
{
    public static object KRPCConnection(String ipaddress, String rpcport, String streamport)
    {
        Logger.LogDebug($"KRPCConnection called with: IP={ipaddress}, RPC Port={rpcport}, Stream Port={streamport}");
        
        try
        {
            var address = IPAddress.Parse(ipaddress);
            var rpcPortNum = int.Parse(rpcport);
            var streamPortNum = int.Parse(streamport);
            
            Logger.LogInfo($"Creating KRPC connection to {address}:{rpcPortNum} (stream: {streamPortNum})");
            
            using (var connection = new Connection(
                name: "Houston Host",
                address: address,
                rpcPort: rpcPortNum,
                streamPort: streamPortNum))
            {
                Logger.LogInfo("KRPC connection established successfully");
                var krpc = connection.KRPC();
                Logger.LogInfo("Retrieved KRPC service");
                return krpc;
            }
        }
        catch (Exception ex)
        {
            Logger.LogError($"Error in KRPCConnection: {ex.Message}", ex);
            throw;
        }
    }
}