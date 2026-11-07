using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyLearning.Desktop.Abstractions
{
    public interface ICreateCopyBookDialog
    {
        Task<bool> ShowAsync(CancellationToken cancellationToken = default);
    }
}