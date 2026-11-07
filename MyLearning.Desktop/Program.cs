using Avalonia;
using Microsoft.Extensions.DependencyInjection;
using MyLearning.Infrastructure.DependencyInjection;
using MyLearning.Desktop.ViewModels;
using MyLearning.Desktop.Views;
using System;
using MyLearning.Desktop.ViewModels.Dashboard;
using MyLearning.Desktop.Services;
using MyLearning.Desktop.Abstractions;
using MyLearning.Desktop.Views.Dashboard.CreateCopyBookWindow;
using MyLearning.Desktop.ViewModels.Dashboard.CreateCopyBookWindow;
using MyLearning.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MyLearning.Desktop.Services.BookPreviewService;
using MyLearning.Rendering.DependencyInjection;

namespace MyLearning.Desktop;

sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        var services = ConfigureServices();

        using var provider = services.BuildServiceProvider();
        App.ConfigureServices(provider);

        using (var scope = provider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<SqliteDbContext>();
            dbContext.Database.Migrate();
        }

        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
    }


    public static IServiceCollection ConfigureServices()
    {
        // Register your services here
        var services = new ServiceCollection();
        services.AddInfrastructureServices("MyLearning.db");
        services.AddRenderingServices();
        services.AddTransient<MainWindowViewModel>();
        services.AddTransient<MainWindow>();
        services.AddTransient<ShellViewModel>();
        services.AddSingleton<DashboardViewModel>();
        services.AddSingleton<INavigationService, NavigationService>();
        services.AddSingleton<ICreateCopyBookDialog, CreateCopyBookDialogService>();
        services.AddTransient<CreateCopyBookWindowView>();
        services.AddTransient<CreateCopyBookWindowViewModel>();
        services.AddSingleton<IBookPreviewService, BookPreviewService>();


        return services;
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()

            .UsePlatformDetect()
#if DEBUG
            .WithDeveloperTools()
#endif
            .WithInterFont()
            .LogToTrace();
}
