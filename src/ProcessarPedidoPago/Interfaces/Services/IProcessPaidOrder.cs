using ECommerceLambda.Domain.Models;

namespace ProcessarPedidoPago.Interfaces.Services;

public interface IProcessPaidOrder
{
    Task Process(Order order);
}