namespace Finickyzone.Extensions.Http.Clients;

[HttpClient(Name)]
public sealed class Client_Named
{
    private const string Name = nameof(Client_Named_WithFactory);
    
    public Client_Named(HttpClient client)
    {
        Client = client;
    }

    public HttpClient Client { get; }
}