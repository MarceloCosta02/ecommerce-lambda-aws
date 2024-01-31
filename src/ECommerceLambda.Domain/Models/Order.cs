using ECommerceLambda.Domain.Enums;

namespace ECommerceLambda.Domain.Models;

public class Order
{
    public OrderStatus OrderStatus { get; set; }
    public string ClientDocument => Client.Document;
    public Guid OrderId { get; set; }
    public Client Client { get; set; }
    public decimal TotalValue => OrderItems.Sum(x => x.UnitValue * x.Quantity);
    public List<OrderItem> OrderItems { get; set; }
}
