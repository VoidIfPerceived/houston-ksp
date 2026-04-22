using Avalonia;
using Avalonia.Markup.Xaml.MarkupExtensions;
using Avalonia.Layout;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using System;


namespace Houston.Components.UIElements.Main;

public class ServerInfo : UserControl
{
    private object KRPCInstance { get; set; }

    public ServerInfo(object krpcInstance)
    {
        this.KRPCInstance = krpcInstance;
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        var backgroundPanel = new Panel
        {
            Background = new Avalonia.Media.ImageBrush
            {
                Source = new Bitmap("Assets/cupola.png"),
                Stretch = Avalonia.Media.Stretch.UniformToFill,
                Opacity = 0.3
            },
            VerticalAlignment = VerticalAlignment.Stretch,
            HorizontalAlignment = HorizontalAlignment.Stretch,
        };

        var mainGrid = new Grid
        {
            RowDefinitions = new RowDefinitions("Auto,*,Auto"),
            VerticalAlignment = VerticalAlignment.Stretch,
            HorizontalAlignment = HorizontalAlignment.Stretch,
        };

        var connectionVerification = new TextBlock
        {
            Text = this.KRPCInstance.ToString(),
        };

        backgroundPanel.Children.Add(mainGrid);

        Content = backgroundPanel;
    }

}