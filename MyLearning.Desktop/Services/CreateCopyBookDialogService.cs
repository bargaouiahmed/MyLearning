using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Controls.ApplicationLifetimes;
using Microsoft.Extensions.DependencyInjection;
using MyLearning.Desktop.Abstractions;
using MyLearning.Desktop.ViewModels.Dashboard.CreateCopyBookWindow;
using MyLearning.Desktop.Views.Dashboard.CreateCopyBookWindow;

namespace MyLearning.Desktop.Services
{
    public class CreateCopyBookDialogService : ICreateCopyBookDialog
    {
        private readonly IServiceProvider _serviceProvider;

        public CreateCopyBookDialogService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<bool> ShowAsync(CancellationToken cancellationToken = default)
        {
            var owner = (Avalonia.Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow ?? throw new InvalidOperationException("Main window is not available.");

            var dialog = _serviceProvider.GetRequiredService<CreateCopyBookWindowView>();
            var viewModel = _serviceProvider.GetRequiredService<CreateCopyBookWindowViewModel>();
            dialog.DataContext = viewModel;
            return await dialog.ShowDialog<bool>(owner);
        }

    }


}