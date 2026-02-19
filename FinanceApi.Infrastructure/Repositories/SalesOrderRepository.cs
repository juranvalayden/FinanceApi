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

    public async Task<SalesOrder?> GetByIdAsync(int id)
    {
        return await _dbContext.SalesOrders.FirstOrDefaultAsync(s => s.Id == id);
    }
}
