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
        using (var response = await _clientS3.GetObjectAsync(bucketName, fileKey))
        {
            if (response.HttpStatusCode != HttpStatusCode.OK)
            {
                throw new FileNotFoundException($"O arquivo {fileKey} não foi localizado");
            }

            using (var memoryStream = new MemoryStream())
            {
                await response.ResponseStream.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }

}
