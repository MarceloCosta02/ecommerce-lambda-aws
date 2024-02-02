using ECommerceLambda.Domain.Models;
using ProcessarPedidoPago.Interfaces.Repositories;
using ProcessarPedidoPago.Interfaces.Services;

namespace ProcessarPedidoPago.Services;

public class ProcessPaidOrder : IProcessPaidOrder
{
    private readonly IStorageService _storageService;
    private readonly IInvoiceRepository _invoiceRepository;

    public ProcessPaidOrder(IStorageService storageService, IInvoiceRepository invoiceRepository)
    {
        _storageService = storageService;
        _invoiceRepository = invoiceRepository;
    }

    public async Task Process(Order order)
    {
        var invoice = new Invoice
        {
            ClientDocument = order.ClientDocument,
            InvoiceId = Guid.NewGuid().ToString(),
            CalculationBasis = order.TotalValue,
            TaxRate = 20,
            Description = $"Invoice of the order {order.OrderId}"
        };

        await _storageService.SaveInvoice(invoice);
        await _invoiceRepository.SaveInvoice(invoice);
    }
}