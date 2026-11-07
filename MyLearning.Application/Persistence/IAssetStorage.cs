

using MyLearning.Domain.CopyBook.Page.PageItem;

namespace MyLearning.Application.Persistence
{
    public interface IAssetStorage
    {
        public Task<AssetId> ImportAsync(Stream content, string originalFileName, string? mimeType, string extension, CancellationToken cancellationToken = default);
        public Task<Stream> GetContentAsync(AssetId assetId, CancellationToken cancellationToken = default);
        public Task DeleteAsync(AssetId assetId, CancellationToken cancellationToken = default);

    }
}