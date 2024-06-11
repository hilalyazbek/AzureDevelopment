using AzureDevelopment.Model;
using AzureDevelopment.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AzureDevelopment.Pages;
public class IndexModel : PageModel
{

    private readonly StorageService _storageService;

    public string? AccountName { get; private set; }
    public List<AzureBlobItem>? Blobs{ get; private set; }

    public IndexModel(StorageService storageService)
    {
        _storageService = storageService;
    }

    public void OnGet()
    {
        GetAccountName();
        GetBlobs();
    }

    private void GetBlobs()
    {
        Blobs = _storageService.GetBlobsInContainer("publicfiles");
    }

    public void GetAccountName()
    {
        AccountName = _storageService.GetAccountName();
    }
}
