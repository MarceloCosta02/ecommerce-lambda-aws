using ECommerceLambda.Domain.Models;

namespace ProcessarPedidoPago.Interfaces.Repositories;

public interface IInvoiceRepository
{
    Task SaveInvoice(Invoice invoice);
}