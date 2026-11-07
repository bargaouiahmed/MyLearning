using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyLearning.Application.Interactions.Dashboard;
using MyLearning.Desktop.Abstractions;
using MyLearning.Desktop.Services.BookPreviewService;
using MyLearning.Domain.CopyBook;

namespace MyLearning.Desktop.ViewModels.Dashboard
{
    public partial class DashboardViewModel : ViewModelBase, IActivatable
    {
        private readonly IDashboardInteractions _dashboardInteractions;
        private readonly ICreateCopyBookDialog _createCopyBookDialog;
        private readonly IBookPreviewService _bookPreviewService;
        public DashboardViewModel(IDashboardInteractions dashboardInteractions, ICreateCopyBookDialog createCopyBookDialog, IBookPreviewService bookPreviewService)
        {
            _dashboardInteractions = dashboardInteractions;
            _createCopyBookDialog = createCopyBookDialog;


            CopyBooks = [];
            _bookPreviewService = bookPreviewService;
        }


        [ObservableProperty]
        private IReadOnlyCollection<CopyBookCardViewModel> copyBooks;

        [ObservableProperty]
        private bool isLoading;

        [ObservableProperty]
        private string errorMessage = string.Empty;

        private async Task LoadCopyBooksAsync(int pageSize = 10, CopyBookId? lastCopyBookId = null, CancellationToken cancellationToken = default)
        {
            IsLoading = true;
            ErrorMessage = string.Empty;
            try
            {
                var paginatedCopyBooks = await _dashboardInteractions.GetCopyBooksPaginatedAsync(pageSize, lastCopyBookId, cancellationToken);
                CopyBooks = [.. paginatedCopyBooks.CopyBooks.Select(cb => new CopyBookCardViewModel(cb.Name.Value, cb.Cover?.Path != null ? new Bitmap(cb.Cover.Path.Value) : null, cb.Cover?.Path.Value, _bookPreviewService))];
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error loading copybooks: {ex.Message}";
            }
            finally
            {
                IsLoading = false;
            }
        }


        [RelayCommand]
        private async Task CreateCopyBookAsync(CancellationToken cancellationToken = default)
        {
            var created = await _createCopyBookDialog.ShowAsync(cancellationToken);
            if (created)
            {
                await LoadCopyBooksAsync(cancellationToken: cancellationToken);
            }

        }
        public Task RefreshCopyBooksAsync(int pageSize = 10, CopyBookId? lastCopyBookId = null, CancellationToken cancellationToken = default)
        {
            return LoadCopyBooksAsync(pageSize, lastCopyBookId, cancellationToken);
        }
        public Task ActivateAsync(CancellationToken cancellationToken = default)
        {
            return LoadCopyBooksAsync(cancellationToken: cancellationToken);
        }

        public Task DeactivateAsync(CancellationToken cancellationToken = default)
        {
            // Perform any necessary cleanup or state saving here
            return Task.CompletedTask;
        }
    }
}