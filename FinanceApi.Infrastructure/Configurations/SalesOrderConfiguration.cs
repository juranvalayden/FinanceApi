using FinanceApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceApi.Infrastructure.Configurations;

public class SalesOrderConfiguration : IEntityTypeConfiguration<SalesOrder>
{
    public void Configure(EntityTypeBuilder<SalesOrder> builder)
    {
        builder.ToTable("SalesOrder");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
            .HasColumnName("SalesOrderID")
            .IsRequired();

        builder.Property(s => s.RevisionNumber)
            .IsRequired();

        builder.Property(s => s.OrderDate)
            .IsRequired()
            .HasColumnType("datetime");

        builder.Property(s => s.DueDate)
            .IsRequired()
            .HasColumnType("datetime");

        builder.Property(s => s.ShipDate)
            .HasColumnType("datetime");

        builder.Property(s => s.Status)
            .IsRequired();

        builder.Property(s => s.OnlineOrderFlag)
            .IsRequired();

        builder.Property(s => s.SalesOrderNumber)
            .HasMaxLength(50);

        builder.Property(s => s.PurchaseOrderNumber)
            .HasMaxLength(50);

        builder.Property(s => s.AccountNumber)
            .HasMaxLength(30);

        builder
            .Property(s => s.CustomerId)
            .HasColumnName("CustomerID")
            .IsRequired();

        builder
            .Property(s => s.ShipToAddressId)
            .HasColumnName("ShipToAddressID");

        builder
            .Property(s => s.BillToAddressId)
            .HasColumnName("BillToAddressID");

        builder.Property(s => s.ShipMethod)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(s => s.CreditCardApprovalCode)
            .HasMaxLength(15)
            .IsUnicode(false);

        builder.Property(s => s.SubTotal)
            .IsRequired()
            .HasColumnType("money");

        builder.Property(s => s.TaxAmt)
            .IsRequired()
            .HasColumnType("money");

        builder.Property(s => s.Freight)
            .IsRequired()
            .HasColumnType("money");

        builder.Property(s => s.TotalDue)
            .HasColumnType("money");

        builder.Property(s => s.Comment)
            .HasColumnType("nvarchar(max)");

        builder.Property(s => s.RowGuid)
            .IsRequired();

        builder.Property(s => s.ModifiedDate)
            .IsRequired()
            .HasColumnType("datetime");
    }
}