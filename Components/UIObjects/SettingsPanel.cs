using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Markup.Xaml.MarkupExtensions;
using Avalonia.Media.Imaging;
using System;

namespace Houston.Components.UIObjects;

public class SettingsPanel : UserControl
{
    public SettingsPanel()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        var backgroundPanel = new Panel
        {
            Background = new Avalonia.Media.ImageBrush
            {
                Source = new Bitmap("Assets/nccips-servers.png"),
                Stretch = Avalonia.Media.Stretch.UniformToFill,
                Opacity = 0.3,
            },
            VerticalAlignment = VerticalAlignment.Stretch,
            HorizontalAlignment = HorizontalAlignment.Stretch,
        };
        var contentPanel = new StackPanel
        {
            Orientation = Orientation.Horizontal,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            Spacing = 20,
        };
        

        var overlayPanel = new Panel();

        overlayPanel.Children.Add(contentPanel);
        backgroundPanel.Children.Add(overlayPanel);

        Content = backgroundPanel;
    }
}