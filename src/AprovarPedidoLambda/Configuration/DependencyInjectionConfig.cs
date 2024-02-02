using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using AprovarPedidoLambda.Interfaces.Repositories;
using AprovarPedidoLambda.Interfaces.Services;
using AprovarPedidoLambda.Repositories;
using AprovarPedidoLambda.Services;
using Microsoft.Extensions.DependencyInjection;
using Amazon.SQS;

namespace AprovarPedidoLambda.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceProvider ConfigureServices()
    {
        var _serviceCollection = new ServiceCollection();

        _serviceCollection.AddScoped<IApprovalService, ApprovalService>();
        _serviceCollection.AddScoped<IOrderRepository, OrderRepository>();
        _serviceCollection.AddScoped<IDynamoDBContext, DynamoDBContext>();
        _serviceCollection.AddScoped<IAmazonDynamoDB, AmazonDynamoDBClient>();
        _serviceCollection.AddScoped<IMessageService, MessageService>();
        _serviceCollection.AddScoped<IAmazonSQS, AmazonSQSClient>();

        return _serviceCollection.BuildServiceProvider();
    }
}