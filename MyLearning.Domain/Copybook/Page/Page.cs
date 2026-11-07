using System;

namespace MyLearning.Domain.CopyBook.Page;

public sealed class Page
{
    public PageId Id { get; private set; }
    public PageDate CreatedAt { get; private set; }
    public CopyBookId CopyBookId { get; private set; }

    private Page(PageId id, PageDate createdAt, CopyBookId copybookId)
    {
        Id = id;
        CreatedAt = createdAt;
        CopyBookId = copybookId;
    }


    public static Page Create(CopyBookId copybookId)
    {
        return new Page(PageId.New(), PageDate.Now(), copybookId);
    }



}
