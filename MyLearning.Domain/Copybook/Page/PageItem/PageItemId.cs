using System;

namespace MyLearning.Domain.CopyBook.Page.PageItem;

public class PageItemId
{
    public Guid Value { get; private set; }
    private PageItemId(Guid value) { Value = value; }
    public static PageItemId From(Guid guid)
    {
        return new PageItemId(guid);
    }
    public static PageItemId New()
    {
        return new PageItemId(Guid.CreateVersion7());
    }

}
