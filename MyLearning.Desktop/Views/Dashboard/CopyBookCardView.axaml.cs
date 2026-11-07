using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using System;
using System.Diagnostics;

namespace MyLearning.Desktop.Views.Dashboard;

public partial class CopyBookCardView : UserControl
{
    public CopyBookCardView()
    {
        InitializeComponent();
    }

    private void CardSurface_PointerPressed(object? sender, PointerPressedEventArgs e)
    {
        var position = e.GetPosition(CardSurface);
        var message = $"CopyBookCard click: X={position.X:0.##}, Y={position.Y:0.##}";

        Debug.WriteLine(message);
        Console.WriteLine(message);
    }
}