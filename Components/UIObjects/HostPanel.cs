using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Markup.Xaml.MarkupExtensions;
using Avalonia.Media.Imaging;
using Houston.Components.Screens;
using System;

namespace Houston.Components.UIObjects;

public class HostPanel : UserControl
{
    private Button ReturnButton { get; set; }

    public Action OnReturnClicked { get; set; }

    public HostPanel()
    {
        this.ReturnButton = new Button();
        this.OnReturnClicked = () => {};
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

        // Create the main grid with 3 rows
        var mainGrid = new Grid
        {
            RowDefinitions = new RowDefinitions("Auto,*,Auto"),
            VerticalAlignment = VerticalAlignment.Stretch,
            HorizontalAlignment = HorizontalAlignment.Stretch,
        };

        // Header section
        var headerPanel = new StackPanel
        {
            Orientation = Orientation.Horizontal,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            Spacing = 20,
        };
        var headerLabel = new TextBlock
        {
            Text = "Host",
            FontSize = 24,
            FontWeight = Avalonia.Media.FontWeight.Bold,
        };
        headerPanel.Children.Add(headerLabel);
        Grid.SetRow(headerPanel, 0);

        // Content section
        var contentPanel = new StackPanel
        {
            Orientation = Orientation.Vertical,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            Spacing = 20,
        };
        Grid.SetRow(contentPanel, 1);

        // Footer section with Return button
        var footerPanel = new StackPanel
        {
            Orientation = Orientation.Horizontal,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            Spacing = 20,
        };

        this.ReturnButton = new Button
        {
            Content = "Return",
            Width = 120,
            Height = 60,
            FontSize = 18,
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalContentAlignment = HorizontalAlignment.Center,
            VerticalContentAlignment = VerticalAlignment.Center,
        };
        this.ReturnButton.Click += (sender, e) => OnReturnButtonClicked();
        footerPanel.Children.Add(this.ReturnButton);
        Grid.SetRow(footerPanel, 2);

        // Add all sections to the grid
        mainGrid.Children.Add(headerPanel);
        mainGrid.Children.Add(contentPanel);
        mainGrid.Children.Add(footerPanel);

        // Add grid to background panel
        backgroundPanel.Children.Add(mainGrid);

        Content = backgroundPanel;
    }

    private void OnReturnButtonClicked()
    {
        // Handle Return Button Click
        System.Diagnostics.Debug.WriteLine("ReturnButtonClicked");
        this.OnReturnClicked?.Invoke();
    }
}