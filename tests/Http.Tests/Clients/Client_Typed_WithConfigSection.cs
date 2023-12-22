namespace Finickyzone.Extensions.Http.Clients;

[HttpClient(ConfigSection = ConfigSection)]
public sealed class Client_Typed_WithConfigSection(HttpClient client)
{
    public const string ConfigSection = "Client";

    public HttpClient Client { get; } = client;
}