using FinanceApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceApi.Infrastructure.Configurations;

public class SalesOrderConfiguration : IEntityTypeConfiguration<SalesOrder>
{
    public void Configure(EntityTypeBuilder<SalesOrder> builder)
    {
        builder.ToTable("SalesOrderHeader");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("SalesOrderID");

        builder.Property(e => e.RevisionNumber)
            .IsRequired();

        builder.Property(e => e.OrderDate)
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(e => e.DueDate)
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(e => e.ShipDate)
            .HasColumnType("datetime");

        builder.Property(e => e.Status)
            .IsRequired();

        builder.Property(e => e.OnlineOrderFlag)
            .IsRequired();

        builder.Property(e => e.SalesOrderNumber)
            .HasMaxLength(25);

        builder.Property(e => e.PurchaseOrderNumber)
            .HasMaxLength(25);

        builder.Property(e => e.AccountNumber)
            .HasMaxLength(15);

        builder.Property(e => e.CustomerId)
            .IsRequired();

        builder.Property(e => e.ShipToAddressId);

        builder.Property(e => e.BillToAddressId);

        builder.Property(e => e.ShipMethod)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.CreditCardApprovalCode)
            .HasMaxLength(15);

        builder.Property(e => e.SubTotal)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(e => e.TaxAmt)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(e => e.Freight)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(e => e.TotalDue)
            .HasColumnType("decimal(18,2)");

        builder.Property(e => e.Comment)
            .HasMaxLength(128);

        builder.Property(e => e.RowGuid)
            .HasColumnName("rowguid")
            .IsRequired();

        builder.Property(e => e.ModifiedDate)
            .HasColumnType("datetime")
            .IsRequired();

        builder.HasMany(e => e.SalesOrderDetails)
            .WithOne(d => d.SalesOrder)
            .HasForeignKey(d => d.SalesOrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}