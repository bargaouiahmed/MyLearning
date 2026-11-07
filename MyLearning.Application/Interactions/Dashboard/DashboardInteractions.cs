using MyLearning.Application.Objects.DashboardObjects;
using MyLearning.Application.Persistence;
using MyLearning.Domain.CopyBook;

namespace MyLearning.Application.Interactions.Dashboard;

public sealed class DashboardInteractions : IDashboardInteractions
{
    private readonly ICopyBookRepository _copyBookRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAssetStorage _assetStorage;

    public DashboardInteractions(ICopyBookRepository copyBookRepository, IUnitOfWork unitOfWork, IAssetStorage assetStorage)
    {
        _copyBookRepository = copyBookRepository;
        _unitOfWork = unitOfWork;
        _assetStorage = assetStorage;
    }

    public async Task AddCopyBookAsync(CopyBook copybook, string? assetPath, CancellationToken cancellationToken = default)
    {
        // asset path is the path of an asset on a storage system, basically given to us by the
        // file picker, we need to import the asset into our system and get an asset id for it
        if (!string.IsNullOrEmpty(assetPath))
        {
            using var fileStream = File.OpenRead(assetPath);
            var assetId = await _assetStorage.ImportAsync(fileStream, Path.GetFileName(assetPath), null, Path.GetExtension(assetPath), cancellationToken);
            copybook.UpdateCover(assetId);
        }
        _copyBookRepository.Add(copybook);
        await _unitOfWork.CommitAsync(cancellationToken);
    }

    public async Task DeleteCopyBookAsync(CopyBookId copybookId, CancellationToken cancellationToken = default)
    {
        await _copyBookRepository.DeleteAsync(copybookId);
        await _unitOfWork.CommitAsync(cancellationToken);
    }

    public Task<PaginatedCopyBooks> GetCopyBooksPaginatedAsync(int pageSize, CopyBookId? lastCopyBookId = null, CancellationToken cancellationToken = default)
    {
        return _copyBookRepository.GetCopyBooksPaginatedAsync(pageSize, lastCopyBookId, cancellationToken);
    }

    public async Task UpdateCopyBookNameAsync(CopyBookId copybookId, string newName, CancellationToken cancellationToken = default)
    {
        await _copyBookRepository.UpdateNameAsync(copybookId, newName);
        await _unitOfWork.CommitAsync(cancellationToken);
    }
}
