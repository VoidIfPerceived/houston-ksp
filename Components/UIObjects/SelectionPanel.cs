using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media.Imaging;
using System;

namespace Houston.Components.UIObjects;

public class SelectionPanel : UserControl
{
    private Button PilotButton { get; set; }
    private Button MissionControlButton { get; set; }

    public SelectionPanel()
    {
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
        PilotButton = new Button
        {
            Content = "Pilot",
            Width = 200,
            Height = 60,
            FontSize = 18,
            HorizontalContentAlignment = HorizontalAlignment.Center,
            VerticalContentAlignment = VerticalAlignment.Center,
        };
        PilotButton.Click += (sender, e) => OnPilotButtonClicked();

        // Create Mission Control button
        MissionControlButton = new Button
        {
            Content = "Mission Control",
            Width = 200,
            Height = 60,
            FontSize = 18,
            HorizontalContentAlignment = HorizontalAlignment.Center,
            VerticalContentAlignment = VerticalAlignment.Center,
        };
        MissionControlButton.Click += (sender, e) => OnMissionControlButtonClicked();

        // Add buttons to content panel
        contentPanel.Children.Add(PilotButton);
        contentPanel.Children.Add(MissionControlButton);

        // Create overlay panel for the buttons
        var overlayPanel = new Panel();
        overlayPanel.Children.Add(contentPanel);

        // Set background and add overlay
        backgroundPanel.Children.Add(overlayPanel);

        // Set the content
        Content = backgroundPanel;
    }

    private void OnPilotButtonClicked()
    {
        // TODO: Handle Pilot mode selection
        System.Diagnostics.Debug.WriteLine("Pilot selected");
    }

    private void OnMissionControlButtonClicked()
    {
        // TODO: Handle Mission Control mode selection
        System.Diagnostics.Debug.WriteLine("Mission Control selected");
    }
}
