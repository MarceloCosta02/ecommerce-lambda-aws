using Amazon.SQS;
using Amazon.SQS.Model;
using ECommerceLambda.Interfaces.Services;
using ECommerceLambda.Domain.Models;
using System.Text.Json;

namespace ECommerceLambda.Services;

public class OrderService : IOrderService
{
    private readonly IAmazonSQS _sqsClient;

    public OrderService(IAmazonSQS sqsClient)
    {
        _sqsClient = sqsClient;
    }


    public async Task SendOrder(Order order)
    {
        var request = new SendMessageRequest
        {
            MessageBody = JsonSerializer.Serialize(order),
            QueueUrl = Environment.GetEnvironmentVariable("PEDIDO_CRIADO_QUEUE")
        };

        await _sqsClient.SendMessageAsync(request);
    }
}
