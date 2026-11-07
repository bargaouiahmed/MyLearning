using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyLearning.Domain.CopyBook.Page.PageItem;

namespace MyLearning.Infrastructure.Database.Converters.Asset
{
    public sealed class AssetIdConverter : ValueConverter<AssetId, Guid>
    {
        public AssetIdConverter() : base(
            assetId => assetId.Value,
            guid => AssetId.From(guid))
        { }

    }

}


