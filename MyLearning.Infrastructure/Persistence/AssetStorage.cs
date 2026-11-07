using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyLearning.Application.Persistence;
using MyLearning.Domain.CopyBook.Page.PageItem;

namespace MyLearning.Infrastructure.Persistence
{
    public class AssetStorage : IAssetStorage
    {
        private readonly IAssetRepository _assetRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AssetStorage(IAssetRepository assetRepository, IUnitOfWork unitOfWork)
        {
            _assetRepository = assetRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task DeleteAsync(AssetId assetId, CancellationToken cancellationToken = default)
        {
            var asset = await _assetRepository.GetByIdAsync(assetId, cancellationToken);
            if (asset is null) return;
            File.Delete(asset.Path.Value);
            await _assetRepository.DeleteAsync(assetId, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);


        }

        public async Task<Stream> GetContentAsync(AssetId assetId, CancellationToken cancellationToken = default)
        {
            var asset = await _assetRepository.GetByIdAsync(assetId, cancellationToken);
            if (asset is null) throw new InvalidOperationException($"Asset with Id {assetId} not found.");
            var assetPath = asset.Path.Value;
            if (!File.Exists(assetPath)) throw new FileNotFoundException($"Asset file not found at path {assetPath}.");
            return new FileStream(assetPath, FileMode.Open, FileAccess.Read);
        }

        public async Task<AssetId> ImportAsync(Stream content, string originalFileName, string? mimeType, string extension, CancellationToken cancellationToken = default)
        {
            // Persist the file content to the application storage directory (AppData for example)
            if (!extension.StartsWith('.'))
            {
                extension = "." + extension;
            }
            var assetsDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyLearning", "Assets");
            if (!Directory.Exists(assetsDirectory))
            {
                Directory.CreateDirectory(assetsDirectory);
            }
            var assetId = AssetId.New();
            var asset = Asset.From(assetId, AssetName.From(originalFileName), AssetPath.From(Path.Combine(assetsDirectory, $"{assetId}{extension}")), mimeType is null ? null : AssetMimeType.From(mimeType), AssetSizeInBytes.From(content.Length));
            var assetPath = asset.Path.Value;
            using (var fileStream = new FileStream(assetPath, FileMode.Create, FileAccess.Write))
            {
                await content.CopyToAsync(fileStream, cancellationToken);
            }

            _assetRepository.Add(asset);
            await _unitOfWork.CommitAsync(cancellationToken);
            return assetId;
        }
    }
}