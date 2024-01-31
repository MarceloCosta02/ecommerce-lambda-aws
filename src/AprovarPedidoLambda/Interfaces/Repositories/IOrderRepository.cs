using ECommerceLambda.Domain.Models;

namespace AprovarPedidoLambda.Interfaces.Repositories;

public interface IOrderRepository
{
    Task Save(Order order);
}
