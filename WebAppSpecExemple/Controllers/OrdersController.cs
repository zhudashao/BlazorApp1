using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using WebAppSpecExemple.Services;

namespace WebAppSpecExemple.Controllers;

public class OrdersController : ApiControllerBase
{
    private readonly OrderService _orderService;

    public OrdersController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders([FromQuery] string status, [FromQuery] decimal? minPrice, [FromQuery] int? customerId)
    {
        var orders = await _orderService.GetOrdersByStatusWithDetailsAndCustomer(status, minPrice, customerId);
        return Ok(orders);
    }
}
