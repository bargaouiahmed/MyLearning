using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyLearning.Domain.CopyBook;

namespace MyLearning.Infrastructure.Database.Converters.CopyBook
{
    public sealed class CopyBookNameConverter : ValueConverter<CopyBookName, string>
    {
        public CopyBookNameConverter() : base(
            copyBookName => copyBookName.Value,
            str => CopyBookName.From(str))
        { }

    }
}


