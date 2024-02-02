using Amazon.S3;
using Amazon.S3.Model;
using ECommerceLambda.Interfaces.Services;
using System.Net;

namespace ECommerceLambda.Services;

public class StorageService : IStorageService
{
    private readonly IAmazonS3 _clientS3;

    public StorageService(IAmazonS3 clientS3)
    {
        _clientS3 = clientS3;
    }
    public async Task<byte[]> Download(string bucketName, string fileKey)
    {
        MemoryStream? stream = null;

        var getObjectRequest = new GetObjectRequest
        {
            BucketName = bucketName,
            Key = fileKey
        };

        var response = await _clientS3.GetObjectAsync(getObjectRequest);

        if (response.HttpStatusCode is HttpStatusCode.OK)
        {
            stream = new MemoryStream();
            await response.ResponseStream.CopyToAsync(stream);
        }

        if (stream is null)
        {
            throw new FileNotFoundException($"O arquivo {fileKey} não foi localizado");
        }

        return stream.ToArray();
    }
}
