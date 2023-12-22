namespace Finickyzone.Extensions.Http.Clients;

[HttpClient(ConfigSection = "")]
public sealed class Client_Typed_WithRootConfigSection(HttpClient client)
{
    public HttpClient Client { get; } = client;
}