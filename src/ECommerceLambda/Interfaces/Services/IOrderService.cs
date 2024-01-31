using ECommerceLambda.Models;

namespace ECommerceLambda.Interfaces.Services;

public interface IOrderService
{
    Task SendOrder(Order order);
}
