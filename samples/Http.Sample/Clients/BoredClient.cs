using Finickyzone.Extensions.Http;

namespace Finickyzone.Extensions.Samples.Clients;

/// <summary>
/// Named client
/// </summary>
[HttpClient(Name = ClientName, ConfigSection = nameof(BoredClient))]
public sealed class BoredClient(IHttpClientFactory factory)
{
    private const string ClientName = nameof(BoredClient);

    public async Task<string?> GetActivity(CancellationToken cancellationToken = default)
    {
        HttpClient client = factory.CreateClient(ClientName);
        var response = await client.GetFromJsonAsync<Response>("api/activity", cancellationToken);
        return response?.Activity;
    }

    private record Response(string Activity);
}