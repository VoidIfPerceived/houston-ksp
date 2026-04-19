using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Markup.Xaml.MarkupExtensions;
using Avalonia.Media.Imaging;
using System;

namespace Houston.Components.UIObjects;

public class SelectionPanel : UserControl
{
    private Button HostButton { get; set; }
    private Button JoinButton { get; set; }

    private Button SettingsButton { get; set; }

    public Action OnSettingsClicked { get; set; }

    public Action OnJoinClicked { get; set; }

    public Action OnHostClicked { get; set; }

    public SelectionPanel()
    {
        this.HostButton = new Button();
        this.OnHostClicked = () => {};
        this.JoinButton = new Button();
        this.OnJoinClicked = () => {};
        this.SettingsButton = new Button();
        this.OnSettingsClicked = () => {};
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        // Create the main background panel
        var backgroundPanel = new Panel
        {
            Background = new Avalonia.Media.ImageBrush
            {
                Source = new Bitmap("Assets/mission-control.png"),
                Stretch = Avalonia.Media.Stretch.UniformToFill,
                Opacity = 0.3
            },
            VerticalAlignment = VerticalAlignment.Stretch,
            HorizontalAlignment = HorizontalAlignment.Stretch
        };

        // Create the center content panel with buttons
        var contentPanel = new StackPanel
        {
            Orientation = Orientation.Horizontal,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            Spacing = 20
        };

        // Create Pilot button
        this.HostButton = new Button
        {
            Content = "Host Server",
            Width = 200,
            Height = 60,
            FontSize = 18,
            HorizontalContentAlignment = HorizontalAlignment.Center,
            VerticalContentAlignment = VerticalAlignment.Center,
        };
        this.HostButton.Click += (sender, e) => OnHostButtonClicked();

        // Create Mission Control button
        this.JoinButton = new Button
        {
            Content = "Join Server",
            Width = 200,
            Height = 60,
            FontSize = 18,
            HorizontalContentAlignment = HorizontalAlignment.Center,
            VerticalContentAlignment = VerticalAlignment.Center,
        };
        this.JoinButton.Click += (sender, e) => OnJoinButtonClicked();

        this.SettingsButton = new Button
        {
            Content = "Settings",
            Width = 200,
            Height = 60,
            FontSize = 18,
            HorizontalContentAlignment = HorizontalAlignment.Center,
            VerticalContentAlignment = VerticalAlignment.Center,
        };
        this.SettingsButton.Click += (sender, e) => OnSettingsButtonClicked();

        // Add buttons to content panel
        contentPanel.Children.Add(this.HostButton);
        contentPanel.Children.Add(this.JoinButton);
        contentPanel.Children.Add(this.SettingsButton);

        // Create overlay panel for the buttons
        var overlayPanel = new Panel();
        overlayPanel.Children.Add(contentPanel);

        // Set background and add overlay
        backgroundPanel.Children.Add(overlayPanel);

        // Set the content
        Content = backgroundPanel;
    }

    private void OnSettingsButtonClicked()
    {
        System.Diagnostics.Debug.WriteLine("Settings Button Pressed");
        this.OnSettingsClicked?.Invoke();
    }

    private void OnJoinButtonClicked()
    {
        // TODO: Handle join selection
        System.Diagnostics.Debug.WriteLine("Pilot selected");
        this.OnJoinClicked?.Invoke();
    }

    private void OnHostButtonClicked()
    {
        // TODO: Handle host selection
        System.Diagnostics.Debug.WriteLine("Mission Control selected");
        this.OnHostClicked?.Invoke();
    }
}
