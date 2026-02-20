using FinanceApi.Application.Dtos;
using FinanceApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApi.Presentation.Controllers;

[ApiController]
[Route("api/sales-orders")]
public class SalesOrderController : ControllerBase
{
    private readonly ILogger<SalesOrderController> _logger;
    private readonly ISalesOrderService _salesOrderService;

    public SalesOrderController(ILogger<SalesOrderController> logger, ISalesOrderService salesOrderService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _salesOrderService = salesOrderService ?? throw new ArgumentNullException(nameof(salesOrderService));
    }

    [ProducesResponseType(typeof(SalesOrderDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetSalesOrderAsync(int id, CancellationToken cancellationToken, bool shouldIncludeSalesOrderDetails = false)
    {
        try
        {
            var salesOrder = await _salesOrderService.GetByIdAsync(id, shouldIncludeSalesOrderDetails, cancellationToken);

            if (salesOrder == null) return NotFound();

            return Ok(salesOrder);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "An error occurred for SalesOrder with {Id}", id);
            return BadRequest($"An error occurred while retrieving SalesOrder with Id: {id}.");
        }
    }

    [ProducesResponseType(typeof(SalesOrderDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet]
    public async Task<IActionResult> GetSalesOrdersAsync(CancellationToken cancellationToken, bool shouldIncludeSalesOrderDetails = false)
    {
        try
        {
            var salesOrders = await _salesOrderService.GetAllAsync(shouldIncludeSalesOrderDetails, cancellationToken);

            if (salesOrders == null) return NotFound();

            return Ok(salesOrders);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "An error occurred for SalesOrders");
            return BadRequest($"An error occurred while retrieving SalesOrders.");
        }
    }
}