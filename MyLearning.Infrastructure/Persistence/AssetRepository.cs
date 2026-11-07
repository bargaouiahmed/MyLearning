using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyLearning.Application.Persistence;
using MyLearning.Domain.CopyBook.Page.PageItem;
using MyLearning.Infrastructure.Database;
namespace MyLearning.Infrastructure.Persistence
{
    public class AssetRepository : IAssetRepository
    {
        private readonly SqliteDbContext _dbContext;
        public AssetRepository(SqliteDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Asset asset)
        {
            _dbContext.Assets.Add(asset);
        }

        public async Task DeleteAsync(AssetId assetId, CancellationToken cancellationToken = default)
        {
            var asset = await GetByIdAsync(assetId, cancellationToken);
            if (asset is null) return;

            _dbContext.Assets.Remove(asset);

        }

        public async Task<Asset?> GetByIdAsync(AssetId assetId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Assets.FirstOrDefaultAsync(x => x.Id == assetId, cancellationToken);
        }
    }
}