using AzureDevelopment.Model;
using AzureDevelopment.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AzureDevelopment.Pages;
public class IndexModel : PageModel
{
    [BindProperty]
    public List<IFormFile>? FileUpload { get; set; }

    private readonly StorageService _storageService;
    public List<AzureBlobItem>? Blobs{ get; private set; }

    public IndexModel(StorageService storageService)
    {
        _storageService = storageService;
    }

    public void OnGet()
    {
        GetBlobs();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (FileUpload != null && FileUpload.Count > 0)
        {
            foreach(var file in FileUpload)
            {
                var client = _storageService.GetBlobClient("publicfiles", file.FileName);
                await client.UploadAsync(file.OpenReadStream(), true);
            }
        }

        return RedirectToPage();
    }
    

    private void GetBlobs()
    {
        Blobs = _storageService.GetBlobsInContainer("publicfiles");
    }

}
