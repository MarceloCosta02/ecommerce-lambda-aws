namespace ECommerceLambda.Interfaces.Services;

public interface IStorageService
{
    Task<byte[]> Download(string bucketName, string fileKey);
}
