
using System.Security.Cryptography.X509Certificates;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Houston.Components.UIObjects;
using Tmds.DBus.Protocol;

namespace Houston.Components.Screens;

public class Startup : Window
{
    private readonly SelectionPanel selectionPanel;
    private readonly SettingsPanel settingsPanel;

    private readonly JoinPanel joinPanel;

    private readonly HostPanel hostPanel;

    public Startup()
    {
        Title = "Houston";
        Width = 1024;
        Height = 768;
        WindowStartupLocation = WindowStartupLocation.CenterScreen;
        this.settingsPanel = new SettingsPanel();
        this.selectionPanel = new SelectionPanel();
        this.joinPanel = new JoinPanel();
        this.hostPanel = new HostPanel();
        
        // Set up the callback for the settings button
        this.selectionPanel.OnSettingsClicked += () =>
        {
            Content = this.settingsPanel;
        };

        this.selectionPanel.OnJoinClicked += () =>
        {
            Content = this.joinPanel;
        };

        this.selectionPanel.OnHostClicked += () =>
        {
            Content = this.hostPanel;
        };

        this.settingsPanel.OnReturnClicked += () =>
        {
            Content = this.selectionPanel;
        };

        this.joinPanel.OnReturnClicked += () =>
        {
            Content = this.selectionPanel;
        };

        this.hostPanel.OnReturnClicked += () =>
        {
            Content = this.selectionPanel;
        };
        
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        // Basic window setup
        CanResize = true;
        ShowInTaskbar = true;
        // Add the selection panel as window content
        Content = this.selectionPanel;
    }

    public static void Render(IClassicDesktopStyleApplicationLifetime desktop)
    {
        var startupWindow = new Startup();
        desktop.MainWindow = startupWindow;
    }
}