
using System.Security.Cryptography.X509Certificates;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Houston.Components.UIObjects;
using Tmds.DBus.Protocol;

namespace Houston.Components.Screens;

public class Startup : Window
{
    private SelectionPanel selectionPanel;
    private SettingsPanel settingsPanel;

    public Startup()
    {
        Title = "Houston";
        Width = 1024;
        Height = 768;
        WindowStartupLocation = WindowStartupLocation.CenterScreen;
        settingsPanel = new SettingsPanel();
        selectionPanel = new SelectionPanel();
        
        // Set up the callback for the settings button
        selectionPanel.OnSettingsClicked += () =>
        {
            Content = settingsPanel;
        };
        
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        // Basic window setup
        CanResize = true;
        ShowInTaskbar = true;
        // Add the selection panel as window content
        Content = selectionPanel;
    }

    public static void Render(IClassicDesktopStyleApplicationLifetime desktop)
    {
        var startupWindow = new Startup();
        desktop.MainWindow = startupWindow;
    }
}