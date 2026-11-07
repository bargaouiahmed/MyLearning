using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyLearning.Domain.CopyBook.Page.PageItem;

namespace MyLearning.Infrastructure.Database.Converters.Asset
{
    public sealed class AssetMimeTypeConverter : ValueConverter<AssetMimeType, string>
    {
        public AssetMimeTypeConverter() : base(
            assetType => assetType.Value,
            str => AssetMimeType.From(str))
        { }

    }

}


