using ECommerceLambda.Interfaces.Services;
using ECommerceLambda.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceLambda.Controllers;

[Route("[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private readonly IOrderService _service;

    public OrderController(ILogger<OrderController> logger, IOrderService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Add(Order order)
    {
        _logger.LogInformation("Enviando o pedido para a fila");

        await _service.SendOrder(order);

        return Ok();
    }
}
