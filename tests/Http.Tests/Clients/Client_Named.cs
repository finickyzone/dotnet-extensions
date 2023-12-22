namespace Finickyzone.Extensions.Http.Clients;

[HttpClient(Name)]
public sealed class Client_Named(HttpClient client)
{
    private const string Name = nameof(Client_Named);

    public HttpClient Client { get; } = client;
}