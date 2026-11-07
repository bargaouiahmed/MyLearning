using System;

namespace MyLearning.Domain.CopyBook.Page.PageItem;

public abstract class PageItem
{
    public PageItemId Id { get; private set; }
    public PageId PageId { get; private set; }
    public Transform Transform { get; private set; }
    public int ZIndex { get; private set; }


    protected PageItem(PageItemId id, PageId pageId, Transform transform, int zIndex)
    {
        Id = id;
        PageId = pageId;
        Transform = transform;
        ZIndex = zIndex;
    }

}
