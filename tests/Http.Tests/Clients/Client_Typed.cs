namespace Finickyzone.Extensions.Http.Clients;

[HttpClient]
public sealed class Client_Typed(HttpClient client)
{
    public HttpClient Client { get; } = client;
}