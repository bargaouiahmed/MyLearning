using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyLearning.Application.Interactions.Dashboard;
using MyLearning.Application.Persistence;
using MyLearning.Infrastructure.Database;
using MyLearning.Infrastructure.Persistence;

namespace MyLearning.Infrastructure.DependencyInjection
{
    public static class InfrastructureServiceCollectionExtensions
    {



        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string databasePath)
        {
            services.AddDbContext<SqliteDbContext>(opts => opts.UseSqlite($"Data Source={databasePath}"));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICopyBookRepository, CopyBookRepository>();
            services.AddScoped<IDashboardInteractions, DashboardInteractions>();
            services.AddScoped<IAssetRepository, AssetRepository>();
            services.AddScoped<IAssetStorage, AssetStorage>();





            return services;
        }

    }
}