using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyLearning.Domain.CopyBook.Page.PageItem;
using MyLearning.Infrastructure.Database.Converters.Asset;

namespace MyLearning.Infrastructure.Database.Configurations
{
    public class AssetConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasConversion(new AssetIdConverter());
            builder.Property(a => a.Name).HasConversion(new AssetNameConverter());
            builder.Property(a => a.Path).HasConversion(new AssetPathConverter());
            builder.Property(a => a.MimeType).HasConversion(new AssetMimeTypeConverter());
            builder.Property(a => a.SizeInBytes).HasConversion(new AssetSizeInBytesConverter());
            builder.Property(a => a.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.HasIndex(a => a.Name);

        }
    }
}