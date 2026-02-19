using FinanceApi.Domain.Entities;
using FinanceApi.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace FinanceApi.Infrastructure.DbContexts;

public class AdventureWorksDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<SalesOrder> SalesOrders { get; set; } = null!;
    public DbSet<SalesOrderDetail> SalesOrderDetails { get; set; } = null!;

    public AdventureWorksDbContext(DbContextOptions<AdventureWorksDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("SalesLT");

        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new SalesOrderConfiguration());
        modelBuilder.ApplyConfiguration(new SalesOrderDetailConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
