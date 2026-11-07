using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyLearning.Domain.CopyBook.Page.PageItem;

namespace MyLearning.Application.Persistence
{
    public interface IAssetRepository
    {
        public void Add(Asset asset);
        public Task<Asset?> GetByIdAsync(AssetId assetId, CancellationToken cancellationToken = default);
        public Task DeleteAsync(AssetId assetId, CancellationToken cancellationToken = default);

    }
}