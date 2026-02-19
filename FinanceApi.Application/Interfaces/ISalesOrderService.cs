using FinanceApi.Domain.Entities;

namespace FinanceApi.Application.Interfaces;

public interface ISalesOrderService
{
    Task<SalesOrder?> GetByIdAsync(int id);
}