using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using MyLearning.Desktop.Services.BookPreviewService;

namespace MyLearning.Desktop.ViewModels.Dashboard
{
    public partial class CopyBookCardViewModel : ViewModelBase
    {
        private readonly IBookPreviewService _bookPreviewService;

        [ObservableProperty]
        private string name = string.Empty;
        [ObservableProperty]
        private Bitmap? coverImage;

        [ObservableProperty]
        private string? coverPath;
        [ObservableProperty]
        private Bitmap? previewImage;

        public CopyBookCardViewModel(string name, Bitmap? coverImage, string? coverPath, IBookPreviewService bookPreviewService)
        {
            Name = name;
            CoverImage = coverImage;
            CoverPath = coverPath;
            _bookPreviewService = bookPreviewService;
            if (coverPath != null)
            {
                var preview = _bookPreviewService.CreatePreview(coverPath ?? string.Empty);
                PreviewImage = preview;
            }
            else
            {
                var preview = _bookPreviewService.CreatePreview(string.Empty);
                PreviewImage = preview;
            }
        }

    }
}