namespace Finickyzone.Extensions.Http.Clients;

[HttpClient(ConfigSection = ConfigSection)]
public sealed class Client_Typed_WithConfigSection
{
    public const string ConfigSection = "Client";
    
    public Client_Typed_WithConfigSection(HttpClient client)
    {
        Client = client;
    }

    public HttpClient Client { get; }
}