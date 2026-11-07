using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyLearning.Domain.CopyBook;
using MyLearning.Infrastructure.Database.Converters.Asset;
using MyLearning.Infrastructure.Database.Converters.CopyBook;

namespace MyLearning.Infrastructure.Database.Configurations
{
    public sealed class CopyBookConfiguration : IEntityTypeConfiguration<CopyBook>
    {

        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CopyBook> builder)
        {
            builder.HasKey(cb => cb.Id);
            builder.Property(cb => cb.Id).HasConversion(new CopyBookIdConverter());
            builder.Property(cb => cb.CoverId).HasConversion(new AssetIdConverter());
            builder.Property(cb => cb.Name).HasConversion(new CopyBookNameConverter());

            builder.HasOne(cb => cb.Cover)
                .WithMany()
                .HasForeignKey(cb => cb.CoverId)
                .OnDelete(DeleteBehavior.SetNull);


            builder.Property(cb => cb.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.HasIndex(cb => cb.Name).IsUnique();


        }
    }
}