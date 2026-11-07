using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLearning.Application.Persistence
{
    public interface IUnitOfWork
    {
        public Task CommitAsync(CancellationToken cancellationToken = default);
    }
}