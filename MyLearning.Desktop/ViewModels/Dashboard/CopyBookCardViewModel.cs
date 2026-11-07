using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MyLearning.Desktop.ViewModels.Dashboard
{
    public partial class CopyBookCardViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string name;
        [ObservableProperty]
        private Bitmap? coverImage;

        public CopyBookCardViewModel(string name, Bitmap? coverImage)
        {
            Name = name;
            CoverImage = coverImage;
        }
        
    }
}