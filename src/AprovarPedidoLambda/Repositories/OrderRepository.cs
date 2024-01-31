using Amazon.DynamoDBv2.DataModel;
using AprovarPedidoLambda.Interfaces.Repositories;
using ECommerceLambda.Domain.Models;

namespace AprovarPedidoLambda.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly IDynamoDBContext _context;

    public OrderRepository(IDynamoDBContext context)
    {
        _context = context;
    }

    public async Task Save(Order order)
    {
        await _context.SaveAsync(order);
    }
}
