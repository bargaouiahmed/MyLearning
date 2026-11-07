using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MyLearning.Rendering.DashboardRenderers;

namespace MyLearning.Rendering.DependencyInjection
{
    public static class RenderingServiceCollectionExtensions
    {

        public static IServiceCollection AddRenderingServices(this IServiceCollection services)
        {
            services.AddSingleton<IBookCoverRenderer, SkiaSharpBookCoverRenderer>();

            return services;
        }

    }
}