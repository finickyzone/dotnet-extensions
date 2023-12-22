namespace Finickyzone.Extensions.Http.Clients;

[HttpClient(ConfigSection = "")]
public sealed class Client_Typed_WithRootConfigSection
{
    public Client_Typed_WithRootConfigSection(HttpClient client)
    {
        Client = client;
    }

    public HttpClient Client { get; }
}