using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyLearning.Desktop.Abstractions
{
    public interface IActivatable
    {
        public Task ActivateAsync(CancellationToken cancellationToken = default);
        public Task DeactivateAsync(CancellationToken cancellationToken = default);

    }
}