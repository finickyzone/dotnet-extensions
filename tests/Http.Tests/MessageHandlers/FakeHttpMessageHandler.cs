using Finickyzone.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Http.MessageHandlers;

[Transient]
public sealed class FakeHttpMessageHandler : HttpMessageHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}