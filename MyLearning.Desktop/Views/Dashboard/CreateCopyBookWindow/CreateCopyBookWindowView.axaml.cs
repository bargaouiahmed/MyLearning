using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;
using MyLearning.Desktop.ViewModels.Dashboard.CreateCopyBookWindow;

namespace MyLearning.Desktop.Views.Dashboard.CreateCopyBookWindow;

public partial class CreateCopyBookWindowView : Window
{
    public CreateCopyBookWindowView()
    {
        InitializeComponent();
        DataContextChanged += OnDataContextChanged;
    }
    private void OnDataContextChanged(object? sender, EventArgs e)
    {
        if (DataContext is CreateCopyBookWindowViewModel viewModel)
        {
            viewModel.CloseRequested += OnCloseRequested;
        }
    }
    private void OnCloseRequested(object? sender, bool e)
    {
        Close(e);
    }


    private async void SelectCoverImage_Click(object? sender, RoutedEventArgs e)
    {
        var files = await StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            AllowMultiple = false,
            Title = "Select Cover Image",
            FileTypeFilter = new List<FilePickerFileType>
            {
                new FilePickerFileType("Image Files")
                {
                    Patterns = new[] { "*.jpg", "*.jpeg", "*.png", "*.bmp", "*.gif" }
                }
            }
        });

        if (files.Count == 0)
        {
            return;
        }
        if (DataContext is CreateCopyBookWindowViewModel viewModel)
        {
            viewModel.SetCoverImage(files[0].Path.LocalPath) ;
        }
    }
}