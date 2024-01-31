using AprovarPedidoLambda.Interfaces.Repositories;
using AprovarPedidoLambda.Interfaces.Services;
using ECommerceLambda.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AprovarPedidoLambda.Services;

public class ApprovalService : IApprovalService
{
    private readonly IOrderRepository _orderRepository;

    public ApprovalService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task Approve(Order order)
    {
        await _orderRepository.Save(order);
    }
}
