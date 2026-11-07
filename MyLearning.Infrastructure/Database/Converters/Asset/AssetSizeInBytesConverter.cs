using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyLearning.Domain.CopyBook.Page.PageItem;

namespace MyLearning.Infrastructure.Database.Converters.Asset
{
    public sealed class AssetSizeInBytesConverter : ValueConverter<AssetSizeInBytes, long>
    {
        public AssetSizeInBytesConverter() : base(
            assetSize => assetSize.Value,
            size => AssetSizeInBytes.From(size))
        { }

    }

}


