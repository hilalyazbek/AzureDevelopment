using AzureDevelopment.Model;
using AzureDevelopment.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AzureStorage.Pages;

public class KeyVaultModel : PageModel
{
    private readonly KeyVaultService _keyVaultService;
    public string? SecretValue { get; private set; }

    public string? KeyValue { get; private set; }

    public KeyVaultModel(KeyVaultService keyVaultService)
    {
        _keyVaultService = keyVaultService;

        SecretValue = _keyVaultService.GetSecretValue("APIKEY");
        KeyValue = _keyVaultService.GetKeyValue("GeneratedKey");
    }
    public void OnGet()
    {
    }
}
