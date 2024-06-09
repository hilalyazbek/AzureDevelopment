using AzureDevelopment.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AzureDevelopment.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IConfiguration _configuration;
    private readonly StorageService _storageService;
    public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration, StorageService storageService)
    {
        _logger = logger;
        _configuration = configuration;
        _storageService = storageService;
    }

    public void GetAccountName()
    {
        var accountName = _storageService.GetAccountName();
        //var blobs = _storageService.GetBlobsInContainerAsync("publicfiles");
    }
}
