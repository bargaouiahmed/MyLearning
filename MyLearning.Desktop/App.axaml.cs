using Avalonia.Controls.ApplicationLifetimes;
using System;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using MyLearning.Desktop.ViewModels;
using MyLearning.Desktop.Views;
using MyLearning.Desktop.ViewModels.Dashboard;

namespace MyLearning.Desktop;

public partial class App : Avalonia.Application
{
    private static IServiceProvider? _services;

    public static void ConfigureServices(IServiceProvider services)
    {
        _services = services;
    }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var services = _services
                ?? throw new InvalidOperationException("Application services were not configured.");

            desktop.MainWindow = services.GetRequiredService<MainWindow>();
            var shell = services.GetRequiredService<ShellViewModel>();
            desktop.MainWindow.DataContext = shell;


            _ = shell.ShowDashboardAsync();

        }

        base.OnFrameworkInitializationCompleted();
    }
}