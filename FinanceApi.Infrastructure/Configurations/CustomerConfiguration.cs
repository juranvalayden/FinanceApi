using FinanceApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceApi.Infrastructure.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customer");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("CustomerID")
            .IsRequired();

        builder.Property(c => c.NameStyle)
            .IsRequired();

        builder.Property(c => c.Title)
            .HasMaxLength(16);

        builder.Property(c => c.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.MiddleName)
            .HasMaxLength(100);

        builder.Property(c => c.LastName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Suffix)
            .HasMaxLength(20);

        builder.Property(c => c.CompanyName)
            .HasMaxLength(256);

        builder.Property(c => c.SalesPerson)
            .HasMaxLength(512);

        builder.Property(c => c.EmailAddress)
            .HasMaxLength(100);

        builder.Property(c => c.Phone)
            .HasMaxLength(50);

        builder.Property(c => c.PasswordHash)
            .IsRequired()
            .HasMaxLength(128)
            .IsUnicode(false);

        builder.Property(c => c.PasswordSalt)
            .IsRequired()
            .HasMaxLength(10)
            .IsUnicode(false);

        builder.Property(c => c.RowGuid)
            .IsRequired();

        builder.Property(c => c.ModifiedDate)
            .IsRequired()
            .HasColumnType("datetime");
    }
}