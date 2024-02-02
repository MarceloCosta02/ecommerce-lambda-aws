using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using ECommerceLambda.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using ProcessarPedidoPago.Configuration;
using ProcessarPedidoPago.Interfaces.Services;
using System.Text.Json;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace ProcessarPedidoPago;
public class Function
{
    private readonly IProcessPaidOrder _processPaidOrderService;

    public Function()
    {
        _processPaidOrderService = DependencyInjectionConfig
            .ConfigureServices()
            .GetRequiredService<IProcessPaidOrder>();
    }

    public async Task FunctionHandler(SQSEvent evnt, ILambdaContext context)
    {
        foreach (var message in evnt.Records)
        {
            await ProcessMessageAsync(message, context);
        }
    }

    private async Task ProcessMessageAsync(SQSEvent.SQSMessage message, ILambdaContext context)
    {
        context.Logger.LogInformation($"Processed message {message.Body}");

        var order = JsonSerializer.Deserialize<Order>(message.Body);

        await _processPaidOrderService.Process(order);
    }
}