using Finickyzone.Extensions.Http;

namespace Finickyzone.Extensions.Samples.Clients;

/// <summary>
/// Typed client
/// </summary>
[HttpClient(ConfigSection = nameof(CatFactClient))]
public sealed class CatFactClient(HttpClient client)
{
    public async Task<string?> GetCatFact(CancellationToken cancellationToken = default)
    {
        var response = await client.GetFromJsonAsync<Response>("fact", cancellationToken);
        return response?.Fact;
    }

    private record Response(string Fact);
}