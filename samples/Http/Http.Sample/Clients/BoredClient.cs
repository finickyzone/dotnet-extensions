using Finickyzone.Extensions.Http;

namespace Finickyzone.Extensions.Samples.Clients;

/// <summary>
/// Named client
/// </summary>
[HttpClient(Name = ClientName, ConfigSection = nameof(BoredClient))]
public sealed class BoredClient
{
    private const string ClientName = nameof(BoredClient);
    
    private readonly IHttpClientFactory _factory;
    
    public BoredClient(IHttpClientFactory factory)
    {
        _factory = factory;
    }

    public async Task<string?> GetActivity(CancellationToken cancellationToken = default)
    {
        HttpClient client = _factory.CreateClient(ClientName);
        var response = await client.GetFromJsonAsync<Response>("api/activity", cancellationToken);
        return response?.Activity;
    }

    private record Response(string Activity);
}