using System;
using Avalonia.Controls;
using Houston.Components.UIElements.Startup;
using Houston.Components.Connections;
using Houston.Services;
using System.Net;
using System.Net.Sockets;

namespace Houston.Components.Screens;

public class Startup : Window
{
    private static SelectionPanel selectionPanel;
    private static SettingsPanel settingsPanel;
    private static JoinPanel joinPanel;
    private static HostPanel hostPanel;

    public static void InitializeContent(Window window)
    {
        // Create all panels
        selectionPanel = new SelectionPanel();
        settingsPanel = new SettingsPanel();
        joinPanel = new JoinPanel();
        hostPanel = new HostPanel();

        // Set up callbacks for screen navigation
        selectionPanel.OnSettingsClicked += () =>
        {
            window.Content = settingsPanel;
        };

        selectionPanel.OnJoinClicked += () =>
        {
            window.Content = joinPanel;
        };

        selectionPanel.OnHostClicked += () =>
        {
            window.Content = hostPanel;
        };

        settingsPanel.OnReturnClicked += () =>
        {
            window.Content = selectionPanel;
        };

        joinPanel.OnReturnClicked += () =>
        {
            window.Content = selectionPanel;
        };

        hostPanel.OnSubmitClicked += () =>
        {
            try
            {
                Logger.LogInfo("=== Host Connection Attempt Started ===");
                
                object[] hostdata = (object[])hostPanel.GetHostData();
                var hostname = (String)hostdata[0];
                var ipAddressString = (String)hostdata[1];
                var rpcport = int.Parse((String)hostdata[2]);
                var streamport = int.Parse((String)hostdata[3]);
                
                Logger.LogInfo($"Host Data - Hostname: {hostname}, IP: {ipAddressString}, RPC Port: {rpcport}, Stream Port: {streamport}");
                
                // Resolve hostname or IP address
                Logger.LogDebug($"Resolving hostname/IP: {ipAddressString}");
                var addresses = Dns.GetHostAddresses(ipAddressString);
                var ipaddress = addresses.Length > 0 ? addresses[0] : IPAddress.Parse(ipAddressString);
                Logger.LogInfo($"Resolved IP Address: {ipaddress}");
                
                Logger.LogInfo($"Attempting to connect to {ipaddress}:{rpcport} (Stream: {streamport})");
                var krpc = GameConnection.KRPCConnection(ipaddress: ipaddress.ToString(), rpcport: rpcport.ToString(), streamport: streamport.ToString());
                Logger.LogInfo("Connection successful!");
            }
            catch (SocketException ex)
            {
                Logger.LogError($"Socket connection failed: {ex.Message}", ex);
                Logger.LogWarning("Returning to host selection screen due to connection failure");
                window.Content = hostPanel;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Unexpected error during connection: {ex.Message}", ex);
                Logger.LogWarning("Returning to host selection screen due to error");
                window.Content = hostPanel;
            }
        };

        hostPanel.OnReturnClicked += () =>
        {
            window.Content = selectionPanel;
        };

        // Set initial content
        window.Content = selectionPanel;
    }
}