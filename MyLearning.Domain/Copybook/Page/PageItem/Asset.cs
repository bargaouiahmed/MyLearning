namespace MyLearning.Domain.CopyBook.Page.PageItem;

public sealed class Asset
{
    public AssetId Id { get; private set; }
    public AssetName Name { get; private set; }
    public AssetPath Path { get; private set; }
    public AssetMimeType? MimeType { get; private set; }
    public AssetSizeInBytes SizeInBytes { get; private set; }


    private Asset(AssetId id, AssetName name, AssetPath path, AssetMimeType? mimeType, AssetSizeInBytes sizeInBytes)
    {
        Id = id;
        Name = name;
        Path = path;
        MimeType = mimeType;
        SizeInBytes = sizeInBytes;
    }
    public static Asset From(AssetName name, AssetPath path, AssetMimeType? mimeType, AssetSizeInBytes sizeInBytes)
    {
        return new Asset(AssetId.New(), name, path, mimeType, sizeInBytes);
    }
    public static Asset From(AssetId id, AssetName name, AssetPath path, AssetMimeType? mimeType, AssetSizeInBytes sizeInBytes)
    {
        return new Asset(id, name, path, mimeType, sizeInBytes);
    }

}
