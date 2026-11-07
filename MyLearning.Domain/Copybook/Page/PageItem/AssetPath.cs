namespace MyLearning.Domain.CopyBook.Page.PageItem;

public record struct AssetPath
{
    public string Value { get; private set; }
    private AssetPath(string value)
    {
        Value = value;
    }
    public static AssetPath From(string path)
    {

        if (string.IsNullOrWhiteSpace(path))
        {
            throw new ArgumentException("Asset path cannot be null or empty.", nameof(path));
        }

        return new AssetPath(path);
    }

}
