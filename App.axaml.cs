using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Houston.Components.Screens;

namespace Houston;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var mainWindow = new Window
            {
                Title = "Houston",
                Width = 1024,
                Height = 768,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                CanResize = true,
                ShowInTaskbar = true
            };

            // Initialize startup with the persistent window
            Startup.InitializeContent(mainWindow);
            
            desktop.MainWindow = mainWindow;
        }

        base.OnFrameworkInitializationCompleted();
    }
}