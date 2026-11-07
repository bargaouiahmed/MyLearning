using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;

namespace MyLearning.Desktop.Services.BookPreviewService
{
    public interface IBookPreviewService
    {
        public Bitmap CreatePreview(string coverPath);

    }
}