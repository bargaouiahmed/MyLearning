using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyLearning.Domain.CopyBook.Page.PageItem;

namespace MyLearning.Infrastructure.Database.Converters.Asset
{
    public sealed class AssetPathConverter : ValueConverter<AssetPath, string>
    {
        public AssetPathConverter() : base(
            assetPath => assetPath.Value,
            str => AssetPath.From(str))
        { }

    }

}


