namespace Finickyzone.Extensions.Http.Clients;

[HttpClient(Name)]
public sealed class Client_Named_WithFactory(IHttpClientFactory factory)
{
    private const string Name = nameof(Client_Named_WithFactory);

    public HttpClient Client { get; } = factory.CreateClient(Name);
}