using Azure.Storage.Blobs;

namespace AzureDevelopment.Services;

public class StorageService
{
    private readonly IConfiguration _configuration;
    private readonly BlobServiceClient _blobServiceClient;
    public StorageService(IConfiguration configuration)
    {
        _configuration = configuration;
        _blobServiceClient = new BlobServiceClient(_configuration.GetConnectionString("StorageAccount"));
    }

    public string GetAccountName()
    {
        return _blobServiceClient.AccountName;
    }

    internal List<string> GetBlobsInContainer(string containerName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        var blobs = containerClient.GetBlobs();

        List<string> result = [];

        foreach(var blob in blobs)
        {
            result.Add(blob.Name);
        }

        return result;
    }
}
