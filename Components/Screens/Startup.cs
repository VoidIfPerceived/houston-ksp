
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Houston.Components.UIObjects;

namespace Houston.Components.Screens;

public class Startup : Window
{
    public Startup()
    {
        InitializeComponent();
        Title = "Houston";
        Width = 1024;
        Height = 768;
        WindowStartupLocation = WindowStartupLocation.CenterScreen;
    }

    private void InitializeComponent()
    {
        // Basic window setup
        CanResize = true;
        ShowInTaskbar = true;
        // Add the selection panel as window content
        Content = new SelectionPanel();
    }

    public static void Render(IClassicDesktopStyleApplicationLifetime desktop)
    {
        var startupWindow = new Startup();
        desktop.MainWindow = startupWindow;
    }
}