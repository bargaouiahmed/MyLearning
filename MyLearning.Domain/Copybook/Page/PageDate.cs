using System;

namespace MyLearning.Domain.CopyBook.Page;

public record struct PageDate
{
    public DateTimeOffset Value { get; private set; }

    private PageDate(DateTime value) { Value = value; }
    private PageDate(DateTimeOffset value) { Value = value; }

    public static PageDate From(DateTime date)
    {
        return new PageDate(date);
    }
    public static PageDate From(DateTimeOffset date)
    {
        return new PageDate(date);
    }
    public static PageDate Now()
    {
        return new PageDate(DateTimeOffset.UtcNow);
    }


}
