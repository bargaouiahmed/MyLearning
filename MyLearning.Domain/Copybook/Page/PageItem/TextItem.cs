namespace MyLearning.Domain.CopyBook.Page.PageItem;

public sealed class TextItem : PageItem
{
    private TextItem(PageItemId id, PageId pageId, Transform transform, int zIndex, string text) : base(id, pageId, transform, zIndex)
    {
        Text = text;
    }
    public string Text { get; set; }

    public static TextItem Create(PageItemId id, PageId pageId, Transform transform, int zIndex, string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            throw new ArgumentException("Text cannot be null or empty", nameof(text));
        }
        return new TextItem(id, pageId, transform, zIndex, text);
    }
}

