using Finickyzone.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Samples.MessageHandlers;

[Transient]
public sealed class CustomHttpMessageHandler(ILogger<CustomHttpMessageHandler> logger) : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Hello from {Handler}", nameof(CustomHttpMessageHandler));
        return base.SendAsync(request, cancellationToken);
    }
}