using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyLearning.Domain.CopyBook;

namespace MyLearning.Infrastructure.Database.Converters.CopyBook
{
    public sealed class CopyBookIdConverter : ValueConverter<CopyBookId, Guid>
    {
        public CopyBookIdConverter() : base(
            copyBookId => copyBookId.Value,
            guid => CopyBookId.From(guid))
        { }

    }
}


