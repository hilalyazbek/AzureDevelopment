using Azure.Storage.Blobs.Models;

namespace AzureDevelopment.Model;

public record AzureBlobItem
{
    public string? Name { get; set; }
    public string? Href { get; set; }
}
