using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyLearning.Domain.CopyBook.Page.PageItem;

namespace MyLearning.Infrastructure.Database.Converters.Asset
{
    public sealed class AssetNameConverter : ValueConverter<AssetName, string>
    {
        public AssetNameConverter() : base(
            assetName => assetName.Value,
            str => AssetName.From(str))
        { }

    }

}


