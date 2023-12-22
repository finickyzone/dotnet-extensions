using Microsoft.Extensions.Options;

namespace Finickyzone.Extensions.Options;

[PostConfigureOptions]
public class PostConfigure_Options_WithOpenGeneric<TOptions> : IPostConfigureOptions<TOptions> where TOptions : class
{
    public void PostConfigure(string? name, TOptions options)
    {
    }
}