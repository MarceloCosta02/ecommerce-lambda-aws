using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.SystemTextJson;
using Amazon.Lambda.SQSEvents;
using AprovarPedidoLambda.Configuration;
using AprovarPedidoLambda.Interfaces.Services;
using ECommerceLambda.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

[assembly: LambdaSerializer(typeof(DefaultLambdaJsonSerializer))]

namespace AprovarPedidoLambda;

public class Function
{
    private readonly IApprovalService _approvalService;

    public Function()
    {
        _approvalService = DependencyInjectionConfig
            .ConfigureServices()
            .GetRequiredService<IApprovalService>();
    }

    public async Task FunctionHandler(SQSEvent input, ILambdaContext context)
    {
        foreach (var message in input.Records)
        {
            await ProcessMessage(message, context);
        }
    }

    private async Task ProcessMessage(SQSEvent.SQSMessage message, ILambdaContext context)
    {
        context.Logger.Log("Mensagem processada");
        context.Logger.Log(message.Body);

        var pedido = JsonSerializer.Deserialize<Order>(message.Body);

        await _approvalService.Approve(pedido);

        await Task.CompletedTask;
    }
}
