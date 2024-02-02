using AprovarPedidoLambda.Interfaces.Repositories;
using AprovarPedidoLambda.Interfaces.Services;
using ECommerceLambda.Domain.Enums;
using ECommerceLambda.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AprovarPedidoLambda.Services;

public class ApprovalService : IApprovalService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMessageService _messageService;

    public ApprovalService(IOrderRepository orderRepository, IMessageService messageService)
    {
        _orderRepository = orderRepository;
        _messageService = messageService;
    }

    public async Task Approve(Order order)
    {
        if(order == null)
        {
            throw new Exception("The order is required");
        }

        if (order.Client == null)
        {
            throw new Exception("The client information is required");
        }

        if (order.Client.Address == null)
        {
            throw new Exception("The address of the client is required");
        }

        //Tentativa de pagamento no gateway

        order.OrderStatus = OrderStatus.AGUARDANDO_ENVIO;

        await _orderRepository.Save(order);
        await _messageService.SendMessage(order);
    }
}
