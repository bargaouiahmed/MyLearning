using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyLearning.Domain.CopyBook;

namespace MyLearning.Application.Objects.DashboardObjects
{
    public sealed class PaginatedCopyBooks
    {
        public IReadOnlyCollection<CopyBook> CopyBooks { get; init; } = [];
        public CopyBookId? LastCopyBookId { get; init; }
        public bool HasMore { get; init; }
    }
}