using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkiaSharp;

namespace MyLearning.Rendering.DashboardRenderers
{
    public record struct BookCoverRendererOptions
    {
        public float Width { get; init; }
        public float Height { get; init; }

        public float ZRotationDegrees { get; init; }
        public SKPoint TopLeft { get; init; }

        public SKPoint TopRight { get; init; }
        public SKPoint BottomLeft { get; init; }
        public SKPoint BottomRight { get; init; }



    }
}