using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyLearning.Application.Objects.DashboardObjects;
using MyLearning.Domain.CopyBook;

namespace MyLearning.Application.Interactions.Dashboard
{
    public interface IDashboardInteractions
    {
        public Task<PaginatedCopyBooks> GetCopyBooksPaginatedAsync(int pageSize, CopyBookId? lastCopyBookId = null, CancellationToken cancellationToken = default);
        public Task AddCopyBookAsync(CopyBook copybook, string? assetPath, CancellationToken cancellationToken = default);
        public Task DeleteCopyBookAsync(CopyBookId copybookId, CancellationToken cancellationToken = default);
        public Task UpdateCopyBookNameAsync(CopyBookId copybookId, string newName, CancellationToken cancellationToken = default);
    }
}