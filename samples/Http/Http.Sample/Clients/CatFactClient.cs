using Finickyzone.Extensions.Http;

namespace Finickyzone.Extensions.Samples.Clients;

/// <summary>
/// Typed client
/// </summary>
[HttpClient(ConfigSection = nameof(CatFactClient))]
public sealed class CatFactClient
{
    private readonly HttpClient _client;

    public CatFactClient(HttpClient client)
    {
        _client = client;
    }

    public async Task<string?> GetCatFact(CancellationToken cancellationToken = default)
    {
        var response = await _client.GetFromJsonAsync<Response>("fact", cancellationToken);
        return response?.Fact;
    }

    private record Response(string Fact);
}