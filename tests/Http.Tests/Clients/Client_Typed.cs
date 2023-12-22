namespace Finickyzone.Extensions.Http.Clients;

[HttpClient]
public sealed class Client_Typed
{
    public Client_Typed(HttpClient client)
    {
        Client = client;
    }

    public HttpClient Client { get; }
}