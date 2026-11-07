using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MyLearning.Desktop.ViewModels;

namespace MyLearning.Desktop.Services
{
    public interface INavigationService
    {
        Task<TViewModel> NavigateAsync<TViewModel>(ViewModelBase? current, CancellationToken cancellationToken = default) where TViewModel : ViewModelBase;
    }
}