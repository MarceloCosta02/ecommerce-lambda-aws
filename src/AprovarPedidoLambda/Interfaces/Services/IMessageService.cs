using ECommerceLambda.Domain.Models;

namespace AprovarPedidoLambda.Interfaces.Services;

public interface IMessageService
{
    Task SendMessage(Order order);
}