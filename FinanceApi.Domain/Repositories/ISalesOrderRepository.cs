using FinanceApi.Domain.Entities;

namespace FinanceApi.Domain.Repositories;

public interface ISalesOrderRepository
{
    Task<SalesOrder?> GetByIdAsync(int id,
        bool shouldIncludeSalesOrderDetails = false,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<SalesOrder>> GetAllAsync(bool shouldIncludeSalesOrderDetails, 
        CancellationToken cancellationToken);
}