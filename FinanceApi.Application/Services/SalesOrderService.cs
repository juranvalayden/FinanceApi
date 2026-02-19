using FinanceApi.Application.Interfaces;
using FinanceApi.Domain.Entities;
using FinanceApi.Domain.Repositories;

namespace FinanceApi.Application.Services;

public class SalesOrderService : ISalesOrderService
{
    private readonly ISalesOrderRepository _salesOrderRepository;

    public SalesOrderService(ISalesOrderRepository salesOrderRepository)
    {
        _salesOrderRepository = salesOrderRepository ?? throw new ArgumentNullException(nameof(salesOrderRepository));
    }

    public async Task<SalesOrder?> GetByIdAsync(int id)
    {
        return await _salesOrderRepository.GetByIdAsync(id);
    }
}