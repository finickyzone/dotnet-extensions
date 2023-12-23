using Finickyzone.Extensions.Http;
using Finickyzone.Extensions.Samples.MessageHandlers;

namespace Finickyzone.Extensions.Samples.Clients;

/// <summary>
/// Typed client
/// </summary>
[HttpClient(ConfigSection = nameof(CatFactClient))]
[AdditionalHttpMessageHandler<CustomHttpMessageHandler>]
public sealed class CatFactClient(HttpClient client)
{
    public async Task<string?> GetCatFact(CancellationToken cancellationToken = default)
    {
        var response = await client.GetFromJsonAsync<Response>("fact", cancellationToken);
        return response?.Fact;
    }

    private record Response(string Fact);
}