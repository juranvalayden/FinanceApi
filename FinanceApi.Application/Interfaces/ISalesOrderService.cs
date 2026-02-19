using FinanceApi.Application.Dtos;

namespace FinanceApi.Application.Interfaces;

public interface ISalesOrderService
{
    Task<SalesOrderDto?> GetByIdAsync(int id, 
        bool shouldIncludeSalesOrderDetails = false,
        CancellationToken cancellationToken = default);
}