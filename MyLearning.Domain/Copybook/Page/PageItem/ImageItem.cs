namespace MyLearning.Domain.CopyBook.Page.PageItem;

public sealed class ImageItem : PageItem
{
    public AssetId AssetId { get; private set; }
    public ImageFit Fit { get; private set; }

    private ImageItem(PageItemId id, PageId pageId, Transform transform, int zIndex, AssetId assetId, ImageFit fit) : base(id, pageId, transform, zIndex)
    {
        AssetId = assetId;
        Fit = fit;
    }

    public static ImageItem From(PageItemId id, PageId pageId, Transform transform, int zIndex, AssetId assetId, ImageFit fit)
    {
        return new ImageItem(id, pageId, transform, zIndex, assetId, fit);
    }


}
