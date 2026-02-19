using FinanceApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceApi.Infrastructure.Configurations;

public class SalesOrderDetailConfiguration : IEntityTypeConfiguration<SalesOrderDetail>
{
    public void Configure(EntityTypeBuilder<SalesOrderDetail> builder)
    {
        builder.ToTable("SalesOrderDetail");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("SalesOrderDetailID");

        builder.Property(e => e.OrderQty)
            .IsRequired();

        builder.Property(e => e.ProductId)
            .IsRequired();

        builder.Property(e => e.UnitPrice)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(e => e.UnitPriceDiscount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(e => e.LineTotal)
            .HasColumnType("decimal(18,2)");

        builder.Property(e => e.RowGuid)
            .HasColumnName("rowguid")
            .IsRequired();

        builder.Property(e => e.ModifiedDate)
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(e => e.SalesOrderId)
            .HasColumnName("SalesOrderID")
            .IsRequired();
    }
}