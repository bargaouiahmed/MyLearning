using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyLearning.Application.Persistence;
using MyLearning.Infrastructure.Database;

namespace MyLearning.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SqliteDbContext _dbContext;
        public UnitOfWork(SqliteDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task CommitAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}