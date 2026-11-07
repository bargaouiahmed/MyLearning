using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using MyLearning.Rendering.DashboardRenderers;
using SkiaSharp;

namespace MyLearning.Desktop.Services.BookPreviewService
{
    public class BookPreviewService(IBookCoverRenderer bookCoverRenderer) : IBookPreviewService
    {
        private readonly IBookCoverRenderer _bookCoverRenderer = bookCoverRenderer;

        public Bitmap CreatePreview(string coverPath)
        {
            if (string.IsNullOrEmpty(coverPath))
            {

                byte[] templateBytesForReturn = LoadTemplateBytes();
                using var returnStream = new MemoryStream(templateBytesForReturn);
                return new Bitmap(returnStream);
            }
            byte[] templateBytes = LoadTemplateBytes();
            var options = new BookCoverRendererOptions
            {
                Width = 200,
                Height = 300,
                ZRotationDegrees = 0,
                TopLeft = new SKPoint(30, 36),
TopRight = new SKPoint(128, 18),
BottomRight = new SKPoint(184, 211),
BottomLeft = new SKPoint(80, 239)
            };


            byte[] previewPng = _bookCoverRenderer.RenderCover(coverPath, templateBytes, options);

            using var stream = new MemoryStream(previewPng);
            return new Bitmap(stream);
        }

        public static byte[] LoadTemplateBytes()
        {
            var templateUri = new Uri("avares://MyLearning.Desktop/Assets/img.png");
            using Stream templateStream = AssetLoader.Open(templateUri);
            using var templateMemoryStream = new MemoryStream();

            templateStream.CopyTo(templateMemoryStream);

            return templateMemoryStream.ToArray();
        }
    }
}