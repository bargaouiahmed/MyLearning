using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkiaSharp;

namespace MyLearning.Rendering.DashboardRenderers
{
    public class SkiaSharpBookCoverRenderer : IBookCoverRenderer
    {


        public byte[] RenderCover(string coverPath, byte[] templateBytes, BookCoverRendererOptions options)
        {
            //For learning purposes: apparently SKBitmap.Decode can read file path directly, as well as byte arrays
            using var coverBitmap = SKBitmap.Decode(coverPath);

            // create the template bitmap from the byte array
            using var templateBitmap = SKBitmap.Decode(templateBytes);


            var imageInfo = new SKImageInfo((int)options.Width, (int)options.Height);
            using var surface = SKSurface.Create(imageInfo);
            //apparently skia sharp has the bitmap for image pixels
            //and the surface for drawing on the bitmap
            //and the canvas is the drawing context for the surface

            var canvas = surface.Canvas;
            canvas.Clear(SKColors.Transparent);
            var positions = new[]
            {
                options.TopLeft,
                options.TopRight,
                options.BottomRight,

                options.TopLeft,
                options.BottomLeft,
                options.BottomRight
            };

            var textureCoordinates = new[]
            {
                new SKPoint(0, 0),
                new SKPoint(coverBitmap.Width, 0),
                new SKPoint(coverBitmap.Width,coverBitmap.Height),

                new SKPoint(0, 0),
                new SKPoint(coverBitmap.Width,coverBitmap.Height),

    new SKPoint(0, coverBitmap.Height)
            };
            //draw the normal cover without any transforms to test the logic first
            var templateScale = 0.9f;
            float templateWidth = options.Width * templateScale;
            float templateHeight = options.Height * templateScale;

            float templateLeft = (options.Width - templateWidth) / 2;
            float templateTop = (options.Height - templateHeight) / 2;
            var templateRect = new SKRect(templateLeft, templateTop, templateLeft + templateWidth, templateTop + templateHeight);
            canvas.DrawBitmap(templateBitmap, templateRect);

            canvas.Save();
            using var coverShader = SKShader.CreateBitmap(coverBitmap, SKShaderTileMode.Clamp, SKShaderTileMode.Clamp);
            using var paint = new SKPaint { Shader = coverShader, IsAntialias = true };
            canvas.DrawVertices(SKVertexMode.Triangles, positions, textureCoordinates, null, paint);
            canvas.Restore();

            using var snapshot = surface.Snapshot();
            using var encodedImage = snapshot.Encode(SKEncodedImageFormat.Png, 100);
            return encodedImage.ToArray();

        }
    }
}