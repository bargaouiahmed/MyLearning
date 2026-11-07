using System;
using MyLearning.Domain.CopyBook.Page.PageItem;

namespace MyLearning.Domain.CopyBook;

public sealed class CopyBook
{
    public CopyBookId Id { get; private set; }
    public CopyBookName Name { get; private set; }

    public AssetId? CoverId { get; private set; }
    public Asset? Cover { get; private set; }
    private CopyBook(CopyBookId id, CopyBookName name, AssetId? coverId)
    {
        Id = id;
        Name = name;
        CoverId = coverId;
    }



    public static CopyBook Create(CopyBookName name, AssetId? coverId)
    {
        return new CopyBook(CopyBookId.New(), name, coverId);
    }

    public void UpdateName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
        {
            throw new ArgumentException("New name cannot be null or whitespace.", nameof(newName));
        }
        Name = CopyBookName.From(newName);

    }
    public void UpdateCover(AssetId? newCoverId)
    {

        CoverId = newCoverId;
    }
}
