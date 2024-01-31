using AprovarPedidoLambda.Interfaces.Repositories;
using ECommerceLambda.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AprovarPedidoLambda.Interfaces.Services;

public interface IApprovalService
{
    Task Approve(Order order);
}
