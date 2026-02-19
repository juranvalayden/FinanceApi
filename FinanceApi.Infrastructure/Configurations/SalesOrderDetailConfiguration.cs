using FinanceApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceApi.Infrastructure.Configurations;

public class SalesOrderDetailConfiguration : IEntityTypeConfiguration<SalesOrderDetail>
{
    public void Configure(EntityTypeBuilder<SalesOrderDetail> builder)
    {
        builder.ToTable("SalesOrderDetail");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id)
            .HasColumnName("SalesOrderDetailID")
            .IsRequired();

        builder.Property(d => d.SalesOrderId)
            .HasColumnName("SalesOrderID")
            .IsRequired();

        builder.Property(d => d.OrderQty)
            .IsRequired();

        builder.Property(d => d.ProductId)
            .HasColumnName("ProductID")
            .IsRequired();

        builder.Property(d => d.UnitPrice)
            .IsRequired()
            .HasColumnType("money");

        builder.Property(d => d.UnitPriceDiscount)
            .IsRequired()
            .HasColumnType("money");

        builder
            .Property(d => d.LineTotal)
            .HasColumnType("numeric(38,6)");

        builder.Property(d => d.RowGuid)
            .IsRequired();

        builder.Property(d => d.ModifiedDate)
            .IsRequired()
            .HasColumnType("datetime");

        builder.HasOne(d => d.SalesOrder)
            .WithMany()
            .HasForeignKey(d => d.SalesOrderId);
    }
}