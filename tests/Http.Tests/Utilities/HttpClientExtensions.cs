using System.Runtime.CompilerServices;

namespace Finickyzone.Extensions.Http;

public static class HttpClientExtensions
{
    public static IEnumerable<HttpMessageHandler> GetHttpMessageHandlers(this HttpClient client)
    {
        HttpMessageHandler handler = GetHandler(client);
        do
        {
            yield return handler;
        }
        while (TryGetInnerHandler(ref handler));
    }
    
    [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "_handler")]
    private static extern ref HttpMessageHandler GetHandler(HttpMessageInvoker client);
    
    private static bool TryGetInnerHandler(ref HttpMessageHandler handler)
    {
        if (handler is DelegatingHandler { InnerHandler: HttpMessageHandler innerHandler })
        {
            handler = innerHandler;
            return true;
        }
        return false;
    }
}