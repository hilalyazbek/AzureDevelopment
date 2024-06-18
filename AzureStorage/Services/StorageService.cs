using Azure.Storage.Blobs;
using AzureDevelopment.Model;

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

    internal List<AzureBlobItem> GetBlobsInContainer(string containerName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        var blobs = containerClient.GetBlobs();

        List<AzureBlobItem> result = [];

        foreach(var blob in blobs)
        {
            var blobClient = containerClient.GetBlobClient(blob.Name);
            result.Add(new AzureBlobItem()
            {
                Name = blobClient.Name,
                Href = blobClient.Uri.ToString()

            });
        }

        return result;
    }

    internal BlobClient GetBlobClient(string containerName, string fileName)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        return containerClient.GetBlobClient(fileName);
    }
}
