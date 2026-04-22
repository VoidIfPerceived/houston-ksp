using Avalonia;
using Avalonia.Input.TextInput;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Markup.Xaml.MarkupExtensions;
using Avalonia.Media.Imaging;
using Houston.Components.Screens;
using Houston.Components.Connections;
using System;
using Avalonia.Media;
using Tmds.DBus.Protocol;

namespace Houston.Components.UIElements.Startup;

public class HostPanel : UserControl
{
    private Button ReturnButton { get; set; }

    private Button SubmitButton { get; set; }

    private String HostName { get; set; }

    private String IPAddress { get; set; }

    private String RPCPort { get; set; }

    private String StreamPort { get; set; }

    private TextBox HostnameInput { get; set; }

    private TextBox IPAddressInput { get; set; }

    private TextBox RPCPortInput { get; set; }

    private TextBox StreamPortInput { get; set; }

    public Action OnReturnClicked { get; set; }

    public Action OnSubmitClicked { get; set; }

    public HostPanel()
    {
        this.HostName = "";
        this.IPAddress = "";
        this.RPCPort = "";
        this.StreamPort = "";
        this.SubmitButton = new Button();
        this.ReturnButton = new Button();
        this.OnReturnClicked = () => {};
        this.OnSubmitClicked = () => {};
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

        var hostnameLabel = new TextBlock
        {
            Text = "Host Name:",
            FontSize = 24,
        };

        this.HostnameInput = new TextBox
        {
            Text = this.HostName,
            FontSize = 24,
            BorderBrush = Brushes.Azure,
            Width = 600,
        };

        var ipaddressLabel = new TextBlock
        {
            Text = "IP Address",
            FontSize = 24,
        };

        this.IPAddressInput = new TextBox
        {
            Text = this.IPAddress,
            FontSize = 24,
            BorderBrush = Brushes.Azure,
            Width = 600,
        };

        var rpcportLabel = new TextBlock
        {
            Text = "RPC Port",
            FontSize = 24,
        };

        this.RPCPortInput = new TextBox
        {
            Text = this.RPCPort,
            FontSize = 24,
            BorderBrush = Brushes.Azure,
            Width = 600,
        };

        var streamportLabel = new TextBlock
        {
            Text = "Stream Port",
            FontSize = 24,
        };

        this.StreamPortInput = new TextBox
        {
            Text = this.StreamPort,
            FontSize = 24,
            BorderBrush = Brushes.Azure,
            Width = 600,
        };

        // Footer section with Return button
        var footerPanel = new StackPanel
        {
            Orientation = Orientation.Horizontal,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            Spacing = 20,
        };
        Grid.SetRow(footerPanel, 2);

        this.SubmitButton = new Button
        {
            Content = "Create",
            Width = 120,
            Height = 60,
            FontSize = 18,
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalContentAlignment = HorizontalAlignment.Center,
            VerticalContentAlignment = VerticalAlignment.Center,
        };
        this.SubmitButton.Click += (sender, e) => OnSubmitButtonClicked();

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

        // Add all sections to the grid
        mainGrid.Children.Add(headerPanel);
        mainGrid.Children.Add(contentPanel);
        mainGrid.Children.Add(footerPanel);

        // Add Content to Grid Sections
        contentPanel.Children.Add(hostnameLabel);
        contentPanel.Children.Add(this.HostnameInput);
        contentPanel.Children.Add(ipaddressLabel);
        contentPanel.Children.Add(this.IPAddressInput);
        contentPanel.Children.Add(rpcportLabel);
        contentPanel.Children.Add(this.RPCPortInput);
        contentPanel.Children.Add(streamportLabel);
        contentPanel.Children.Add(this.StreamPortInput);
        contentPanel.Children.Add(this.SubmitButton);
        footerPanel.Children.Add(this.ReturnButton);

        // Add grid to background panel
        backgroundPanel.Children.Add(mainGrid);

        Content = backgroundPanel;
    }

    private void OnSubmitButtonClicked()
    {
        System.Diagnostics.Debug.WriteLine("SubmitButtonClicked");
        // Capture TextBox values into properties
        this.HostName = this.HostnameInput?.Text ?? "";
        this.IPAddress = this.IPAddressInput?.Text ?? "";
        this.RPCPort = this.RPCPortInput?.Text ?? "";
        this.StreamPort = this.StreamPortInput?.Text ?? "";
        this.OnSubmitClicked?.Invoke();
    }
    private void OnReturnButtonClicked()
    {
        // Handle Return Button Click
        System.Diagnostics.Debug.WriteLine("ReturnButtonClicked");
        this.OnReturnClicked?.Invoke();
    }

    public Array GetHostData()
    {
        var hostname = this.HostName;
        var ipaddress = this.IPAddress;
        var rpcport = this.RPCPort;
        var streamport = this.StreamPort;

        string[] hostData = [hostname, ipaddress, rpcport, streamport];

        return hostData;
    }
}