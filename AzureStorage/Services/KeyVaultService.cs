using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace AzureDevelopment.Services;

public class KeyVaultService
{
    private readonly IConfiguration _configuration;
    private readonly SecretClient _secretClient;

    public KeyVaultService(IConfiguration configuration)
    {
        _configuration = configuration;

        var vaultUrl = _configuration.GetConnectionString("KeyVaultUrl");

        _secretClient = new SecretClient(vaultUri: new Uri(vaultUrl), credential: new DefaultAzureCredential());
    }

    //internal string GetKeyValue(string name)
    //{

    //}

    internal string GetSecretValue(string name)
    {
        var kvSecret = _secretClient.GetSecret("SQLConnection");

        return kvSecret.Value.Value;
    }
}

