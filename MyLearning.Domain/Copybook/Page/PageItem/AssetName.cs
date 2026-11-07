namespace MyLearning.Domain.CopyBook.Page.PageItem;

public record struct AssetName
{
    public string Value { get; private set; }
    private AssetName(string value)
    {
        Value = value;
    }
    public static AssetName From(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Asset name cannot be null or empty");
        }
        return new AssetName(value);
    }

}
