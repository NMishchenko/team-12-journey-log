using Azure.Storage.Blobs;
using JourneyLog.BLL.Exceptions.BadRequestException;
using JourneyLog.BLL.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace JourneyLog.BLL.Services;

public class BlobStorageService : IBlobStorageService
{
    private const string BlobStorageConnectionStringName = "BlobStorage";
    private const string BlobStorageContainerName = "JourneyLogStorage";
    private readonly BlobContainerClient _blobContainerClient;

    public BlobStorageService(IConfiguration configuration)
    {
        _blobContainerClient = new BlobContainerClient(configuration.GetConnectionString(BlobStorageConnectionStringName),
            BlobStorageContainerName);
    }
    
    public async Task<string> CreateImageAsyncAndGetFileName(string imageBase64)
    {
        var dividedBase64 = imageBase64.Split(',');
        var imageType = GetImageTypeFromBase64(dividedBase64[0]);
        var generatedImageName = $"{Guid.NewGuid()}.{imageType}";
        
        var blobClient = _blobContainerClient.GetBlobClient(generatedImageName);
        
        if (await blobClient.ExistsAsync())
        {
            throw new BadRequestException($"Image with name {generatedImageName} already exists");
        }
        
        var clearBase64 = dividedBase64[1];
        var imageBytes = Convert.FromBase64String(clearBase64);

        using (var stream = new MemoryStream(imageBytes))
        {
            await blobClient.UploadAsync(stream);
        }

        return generatedImageName;
    }

    public async Task DeleteImageAsync(string fileName)
    {
        var blobClient = _blobContainerClient.GetBlobClient(fileName);
        
        if (await blobClient.ExistsAsync())
        {
            await blobClient.DeleteAsync();
        }
    }
    
    private string GetImageTypeFromBase64(string base64)
    {
        const string base64StartLine = "data:image/";
        var indexFrom = base64.IndexOf(base64StartLine) + base64StartLine.Length;
        var indexTo = base64.IndexOf(";");

        return base64.Substring(indexFrom, indexTo - indexFrom);
    }

}