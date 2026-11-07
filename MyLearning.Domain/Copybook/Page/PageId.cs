using System;

namespace MyLearning.Domain.CopyBook.Page;

public record struct PageId
{
    public Guid Value { get; private set; }
    private PageId(Guid value) { Value = value; }
    public static PageId From(Guid guid)
    {
        return new PageId(guid);
    }
    public static PageId New()
    {
        return new PageId(Guid.CreateVersion7());
    }

}
