using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyLearning.Application.Objects.DashboardObjects;
using MyLearning.Domain.CopyBook;

namespace MyLearning.Application.Persistence
{
    public interface ICopyBookRepository
    {
        public Task<PaginatedCopyBooks> GetCopyBooksPaginatedAsync(int pageSize, CopyBookId? lastCopyBookId = null, CancellationToken cancellationToken = default);
        public void Add(CopyBook copyBook);
        public Task DeleteAsync(CopyBookId copyBookId);
        public Task UpdateNameAsync(CopyBookId copyBookId, string newName);

    }
}