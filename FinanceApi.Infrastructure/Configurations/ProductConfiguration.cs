using FinanceApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceApi.Infrastructure.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Product");

        builder.HasKey(p => p.Id);

        builder
            .Property(p => p.Id)
            .IsRequired();

        builder.Property(p => p.Id)
            .HasColumnName("ProductID")
            .IsRequired();

        builder.Property(p => p.ProductNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Color)
            .HasMaxLength(30);

        builder.Property(p => p.StandardCost)
            .IsRequired()
            .HasColumnType("money");

        builder.Property(p => p.ListPrice)
            .IsRequired()
            .HasColumnType("money");

        builder.Property(p => p.Size)
            .HasMaxLength(10);

        builder.Property(p => p.Weight)
            .HasColumnType("decimal(8,2)");

        builder
            .Property(p => p.ProductCategoryId)
            .HasColumnName("ProductCategoryID");

        builder
            .Property(p => p.ProductModelId)
            .HasColumnName("ProductModelID");

        builder.Property(p => p.SellStartDate)
            .IsRequired()
            .HasColumnType("datetime");

        builder.Property(p => p.SellEndDate)
            .HasColumnType("datetime");

        builder.Property(p => p.DiscontinuedDate)
            .HasColumnType("datetime");

        builder.Property(p => p.ThumbNailPhoto)
            .HasColumnType("varbinary(max)");

        builder.Property(p => p.ThumbnailPhotoFileName)
            .HasMaxLength(100);

        builder.Property(p => p.RowGuid)
            .IsRequired();

        builder.Property(p => p.ModifiedDate)
            .IsRequired()
            .HasColumnType("datetime");
    }
}