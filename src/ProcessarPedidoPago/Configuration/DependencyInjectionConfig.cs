using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Amazon.S3;
using Microsoft.Extensions.DependencyInjection;
using ProcessarPedidoPago.Interfaces;
using ProcessarPedidoPago.Interfaces.Services;
using ProcessarPedidoPago.Services;
using ProcessarPedidoPago.Interfaces.Repositories;
using ProcessarPedidoPago.Repositories;

namespace ProcessarPedidoPago.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceProvider ConfigureServices()
    {
        var _serviceCollection = new ServiceCollection();

        _serviceCollection.AddScoped<IAmazonS3, AmazonS3Client>();
        _serviceCollection.AddScoped<IProcessPaidOrder, ProcessPaidOrder>();
        _serviceCollection.AddScoped<IStorageService, StorageService>();
        _serviceCollection.AddScoped<IDynamoDBContext, DynamoDBContext>();
        _serviceCollection.AddScoped<IAmazonDynamoDB, AmazonDynamoDBClient>();
        _serviceCollection.AddScoped<IInvoiceRepository, InvoiceRepository>();

        return _serviceCollection.BuildServiceProvider();
    }
}