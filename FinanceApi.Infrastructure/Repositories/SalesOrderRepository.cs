using FinanceApi.Domain.Entities;
using FinanceApi.Domain.Repositories;
using FinanceApi.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace FinanceApi.Infrastructure.Repositories;

public class SalesOrderRepository : ISalesOrderRepository
{
    private readonly AdventureWorksDbContext _dbContext;

    public SalesOrderRepository(AdventureWorksDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<SalesOrder?> GetByIdAsync(int id, bool shouldIncludeSalesOrderDetails = false, CancellationToken cancellationToken = default)
    {
        if (!shouldIncludeSalesOrderDetails) return await _dbContext.SalesOrders.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

        var salesOrder = await _dbContext
            .SalesOrders
            .Include(s => s.SalesOrderDetails)
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

        return salesOrder;
    }
}
