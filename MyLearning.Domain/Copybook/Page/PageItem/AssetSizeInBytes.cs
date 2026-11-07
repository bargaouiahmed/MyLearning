namespace MyLearning.Domain.CopyBook.Page.PageItem;

public record struct AssetSizeInBytes
{
    public long Value { get; private set; }
    private AssetSizeInBytes(long value)
    {
        Value = value;
    }
    public static AssetSizeInBytes From(long value)
    {
        return new AssetSizeInBytes(value);
    }
}
