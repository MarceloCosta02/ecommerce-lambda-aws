using Amazon.DynamoDBv2.DataModel;
using ECommerceLambda.Domain.Conversors;
using ECommerceLambda.Domain.Enums;

namespace ECommerceLambda.Domain.Models;

[DynamoDBTable("order")]
public class Order
{
    [DynamoDBHashKey(typeof(DynamoDbEnumStringConverter<OrderStatus>))]
    public OrderStatus OrderStatus { get; set; }

    public Guid OrderId { get; set; }

    public Client Client { get; set; }

    public List<OrderItem> OrderItems { get; set; }

    [DynamoDBRangeKey]
    public string ClientDocument
    {
        get
        {
            return Client.Document;
        }
        private set => ClientDocument = value;
    }

    public decimal TotalValue
    {
        get
        {
            return OrderItems.Sum(x => x.UnitValue * x.Quantity);
        }
        private set => TotalValue = value;
    }
}
