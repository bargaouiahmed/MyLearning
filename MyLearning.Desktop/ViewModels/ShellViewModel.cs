using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using MyLearning.Desktop.Services;
using MyLearning.Desktop.ViewModels.Dashboard;

namespace MyLearning.Desktop.ViewModels
{
    public partial class ShellViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        [ObservableProperty]
        private ViewModelBase? currentViewModel;
        public ShellViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public async Task ShowDashboardAsync(CancellationToken cancellationToken = default)
        {
            CurrentViewModel = await _navigationService.NavigateAsync<DashboardViewModel>(CurrentViewModel, cancellationToken);
        }

    }
}