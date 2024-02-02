
using Amazon.S3;
using Amazon.S3.Model;
using ECommerceLambda.Domain.Models;
using ProcessarPedidoPago.Interfaces.Services;
using System.Text;
using System.Text.Json;

namespace ProcessarPedidoPago.Interfaces;

public class StorageService : IStorageService
{
    private readonly IAmazonS3 _client;

    public StorageService(IAmazonS3 client)
    {
        _client = client;
    }

    public async Task SaveInvoice(Invoice invoice)
    {
        var prefix = $"{invoice.ClientDocument}/{DateTime.Now.Year}/{DateTime.Now.Month}/{DateTime.Now.Day}";
        var key = $"{prefix}/{Guid.NewGuid()}.json";

        var putObjectRequest = new PutObjectRequest
        {
            BucketName = Environment.GetEnvironmentVariable("INVOICES_BUCKET_NAME"),
            Key = key,
            ContentType = "application/json",
            InputStream = new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(invoice)))
        };

        await _client.PutObjectAsync(putObjectRequest);
    }
}