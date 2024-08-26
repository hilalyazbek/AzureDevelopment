using Azure.Identity;
using Azure.Security.KeyVault.Keys;
using Azure.Security.KeyVault.Secrets;

namespace AzureDevelopment.Services;

public class KeyVaultService
{
    private readonly IConfiguration _configuration;
    private readonly SecretClient _secretClient;
    private readonly KeyClient _keyClient;

    public KeyVaultService(IConfiguration configuration)
    {
        _configuration = configuration;

        var keyVaultEndpoint = new Uri(_configuration.GetValue<string>("KeyVault:VaultUri"));

        var clientId = _configuration.GetValue<string>("KeyVault:ClientId");

        var tenantId = _configuration.GetValue<string>("KeyVault:TenantId");

        var clientSecret = _configuration.GetValue<string>("KeyVault:ClientSecret");

        _secretClient = new SecretClient(keyVaultEndpoint,
            new ClientSecretCredential(tenantId, clientId, clientSecret));

        _keyClient = new KeyClient(keyVaultEndpoint,
            new ClientSecretCredential(tenantId, clientId, clientSecret));
    }

    internal string GetKeyValue(string name)
    {
        var kvKey = _keyClient.GetKey(name);

        return kvKey.Value.Properties.Version;
    }

    internal string GetSecretValue(string name)
    {
        var kvSecret = _secretClient.GetSecret(name);

        return kvSecret.Value.Value;
    }
}

