using ECommerceLambda.Domain.Models;

namespace ProcessarPedidoPago.Interfaces.Services;

public interface IStorageService
{
    Task SaveInvoice(Invoice invoice);
}