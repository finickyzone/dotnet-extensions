using Finickyzone.Extensions.Http.MessageHandlers;

namespace Finickyzone.Extensions.Http.Clients;

[AdditionalHttpMessageHandler<FakeDelegatingHandler>]
public sealed class Client_Typed_WithHttpMessageHandler(HttpClient client)
{
    public HttpClient Client { get; } = client;
}