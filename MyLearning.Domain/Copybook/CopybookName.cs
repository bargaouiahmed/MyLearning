using System;

namespace MyLearning.Domain.CopyBook;

public record struct CopyBookName
{
    public string Value { get; private set; }

    private CopyBookName(string value) { Value = value; }

    public static CopyBookName From(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("CopyBook name cannot be null or empty.", nameof(name));
        }
        return new CopyBookName(name);
    }

}
