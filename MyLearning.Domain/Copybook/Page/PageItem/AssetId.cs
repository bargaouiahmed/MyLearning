namespace MyLearning.Domain.CopyBook.Page.PageItem;

public record struct AssetId
{
    public Guid Value { get; init; }
    private AssetId(Guid value) { Value = value; }
    public static AssetId From(Guid guid)
    {
        return new AssetId(guid);
    }
    public static AssetId New()
    {
        return new AssetId(Guid.CreateVersion7());
    }
}
