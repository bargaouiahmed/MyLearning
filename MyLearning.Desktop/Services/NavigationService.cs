using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MyLearning.Desktop.Abstractions;
using MyLearning.Desktop.ViewModels;

namespace MyLearning.Desktop.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IServiceProvider _serviceProvider;

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TViewModel> NavigateAsync<TViewModel>(ViewModelBase? current, CancellationToken cancellationToken = default) where TViewModel : ViewModelBase
        {
            if (current is IActivatable activatableCurrent)
            {
                await activatableCurrent.DeactivateAsync(cancellationToken);
            }

            var viewModel = _serviceProvider.GetRequiredService<TViewModel>();
            if (viewModel is IActivatable activatableNew)
            {
                await activatableNew.ActivateAsync(cancellationToken);
            }

            return viewModel;
        }
    }
}