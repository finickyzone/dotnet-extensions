namespace Finickyzone.Extensions.Http.Clients;

[HttpClient(Name)]
public sealed class Client_Named_WithFactory
{
    private const string Name = nameof(Client_Named_WithFactory);
    
    public Client_Named_WithFactory(IHttpClientFactory factory)
    {
        Client = factory.CreateClient(Name);
    }

    public HttpClient Client { get; }
}