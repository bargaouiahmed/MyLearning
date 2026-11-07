using System;

namespace MyLearning.Domain.CopyBook;

public record struct CopyBookId
{
    public Guid Value { get; private set; }


    private CopyBookId(Guid value) { Value = value; }
    public static CopyBookId From(Guid guid)
    {
        return new CopyBookId(guid);
    }
    public static CopyBookId New()
    {
        return new CopyBookId(Guid.CreateVersion7());
    }




    public int CompareTo(CopyBookId other)
    {
        return Value.CompareTo(other.Value);
    }
    public static bool operator >(CopyBookId left, CopyBookId right)
    {
        return left.CompareTo(right) > 0;
    }
    public static bool operator <(CopyBookId left, CopyBookId right)
    {
        return left.CompareTo(right) < 0;
    }

}
