using Finickyzone.Extensions.Http.MessageHandlers;

namespace Finickyzone.Extensions.Http.Clients;

[PrimaryHttpMessageHandler<FakeHttpMessageHandler>]
public sealed class Client_Typed_WithPrimaryHttpMessageHandler(HttpClient client)
{
    public HttpClient Client { get; } = client;
}