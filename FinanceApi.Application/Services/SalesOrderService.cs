using AutoMapper;
using FinanceApi.Application.Dtos;
using FinanceApi.Application.Interfaces;
using FinanceApi.Domain.Repositories;

namespace FinanceApi.Application.Services;

public class SalesOrderService : ISalesOrderService
{
    private readonly IMapper _mapper;
    private readonly ISalesOrderRepository _salesOrderRepository;

    public SalesOrderService(IMapper mapper, ISalesOrderRepository salesOrderRepository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _salesOrderRepository = salesOrderRepository ?? throw new ArgumentNullException(nameof(salesOrderRepository));
    }

    public async Task<SalesOrderDto?> GetByIdAsync(int id, bool shouldIncludeSalesOrderDetails = false, CancellationToken cancellationToken = default)
    {
        var saleOrder = await _salesOrderRepository.GetByIdAsync(id, shouldIncludeSalesOrderDetails, cancellationToken);

        return saleOrder == null 
            ? null 
            : _mapper.Map<SalesOrderDto>(saleOrder);
    }
}