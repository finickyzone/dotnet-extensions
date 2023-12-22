using Microsoft.Extensions.Options;

namespace Finickyzone.Extensions.Options;

[PostConfigureOptions(typeof(Options_WithPostConfigureOptions))]
public class PostConfigure_Options_WithOptionsType<TOptions> : IPostConfigureOptions<TOptions> where TOptions : class
{
    public void PostConfigure(string name, TOptions options)
    {
    }
}