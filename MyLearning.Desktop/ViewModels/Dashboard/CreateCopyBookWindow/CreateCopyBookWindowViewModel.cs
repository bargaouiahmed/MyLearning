using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyLearning.Application.Interactions.Dashboard;
using MyLearning.Domain.CopyBook;

namespace MyLearning.Desktop.ViewModels.Dashboard.CreateCopyBookWindow
{
    public partial class CreateCopyBookWindowViewModel(IDashboardInteractions dashboardInteractions) : ViewModelBase
    {
        [ObservableProperty]
        private Bitmap? coverImage;
 
        public void SetCoverImage(string path)
        {
            CoverPath = path;
            CoverImage = new Bitmap(path);
        }
        public event EventHandler<bool>? CloseRequested;

        private readonly IDashboardInteractions _dashboardInteractions = dashboardInteractions;
        [ObservableProperty]
        private string name = string.Empty;

        [ObservableProperty]
        private string? coverPath = null;

        [ObservableProperty]
        private bool isCreating;
        [ObservableProperty]
        private string errorMessage = string.Empty;

        [RelayCommand]
        public async Task CreateCopyBookAsync(CancellationToken cancellationToken = default)
        {
            IsCreating = true;
            ErrorMessage = string.Empty;

            try
            {
                var copyBookName = CopyBookName.From(Name);
                var copyBook = CopyBook.Create(copyBookName, null);
                await _dashboardInteractions.AddCopyBookAsync(copyBook, CoverPath, cancellationToken);
                CloseRequested?.Invoke(this, true);
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error creating copybook: {ex.Message}";
            }
            finally
            {
                IsCreating = false;
            }
        }

    }
}