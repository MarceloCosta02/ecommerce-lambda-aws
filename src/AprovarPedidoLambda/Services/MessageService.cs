using Amazon.SQS;
using Amazon.SQS.Model;
using AprovarPedidoLambda.Interfaces.Services;
using ECommerceLambda.Domain.Models;
using System.Text.Json;

namespace AprovarPedidoLambda.Services;

public class MessageService : IMessageService
{
    private readonly IAmazonSQS _sqsClient;

    public MessageService(IAmazonSQS sqsClient)
    {
        _sqsClient = sqsClient;
    }

    public async Task SendMessage(Order order)
    {
        var request = new SendMessageRequest
        {
            MessageBody = JsonSerializer.Serialize(order),
            QueueUrl = Environment.GetEnvironmentVariable("PEDIDO_PAGO_SQS_URL")
        };

        await _sqsClient.SendMessageAsync(request);
    }
}