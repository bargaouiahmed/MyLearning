using MyLearning.Application.Objects.DashboardObjects;
using MyLearning.Application.Persistence;
using MyLearning.Domain.CopyBook;
using MyLearning.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
namespace MyLearning.Infrastructure.Persistence
{
    public class CopyBookRepository : ICopyBookRepository
    {
        private readonly SqliteDbContext _dbContext;
        public CopyBookRepository(SqliteDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(CopyBook copyBook)
        {
            _dbContext.CopyBooks.Add(copyBook);
        }

        public async Task DeleteAsync(CopyBookId copyBookId)
        {
            var copyBook = await _dbContext.CopyBooks.FirstOrDefaultAsync(cb => cb.Id == copyBookId) ?? throw new InvalidOperationException($"CopyBook with Id {copyBookId} not found.");
            _dbContext.CopyBooks.Remove(copyBook);
        }

        public async Task<PaginatedCopyBooks> GetCopyBooksPaginatedAsync(int pageSize, CopyBookId? lastCopyBookId = null, CancellationToken cancellationToken = default)
        {
            var result = await _dbContext.CopyBooks
                .Include(cb => cb.Cover)
                .OrderBy(cb => cb.Id)
                .Where(cb => lastCopyBookId == null || cb.Id > lastCopyBookId.Value)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
            var hasMore = await _dbContext.CopyBooks.AsNoTracking().AnyAsync(cb => result.LastOrDefault() != null && cb.Id > result.Last().Id, cancellationToken);
            return new PaginatedCopyBooks
            {
                CopyBooks = result,
                LastCopyBookId = result.LastOrDefault()?.Id,
                HasMore = hasMore
            };

        }

        public async Task UpdateNameAsync(CopyBookId copyBookId, string newName)
        {
            var copyBook = await _dbContext.CopyBooks.FirstOrDefaultAsync(cb => cb.Id == copyBookId) ?? throw new InvalidOperationException($"CopyBook with Id {copyBookId} not found.");
            copyBook.UpdateName(newName);


        }

    }
}