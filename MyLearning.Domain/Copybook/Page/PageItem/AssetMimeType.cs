namespace MyLearning.Domain.CopyBook.Page.PageItem;

public record struct AssetMimeType
{
    private readonly static string[] AllowedMimeTypes =
    [
        "image/jpeg",
        "image/png",
        "image/gif",
        "image/bmp",
        "image/webp",
        "image/svg+xml",
        "video/mp4",
        "video/webm",
        "video/ogg",
        "audio/mpeg",
        "audio/wav",
        "audio/ogg",

    ];
    public string Value { get; private set; }
    private AssetMimeType(string value)
    {
        Value = value;
    }
    public static AssetMimeType From(string value)
    {
        if (!AllowedMimeTypes.Contains(value))
        {
            throw new ArgumentException($"Invalid mime type: {value}");
        }
        return new AssetMimeType(value);
    }
}
