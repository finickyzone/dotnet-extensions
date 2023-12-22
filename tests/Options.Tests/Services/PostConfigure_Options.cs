using Microsoft.Extensions.Options;

namespace Finickyzone.Extensions.Options;

[PostConfigureOptions]
public class PostConfigure_Options : IPostConfigureOptions<Options_WithPostConfigureOptions>
{
    public void PostConfigure(string name, Options_WithPostConfigureOptions options)
    {
    }
}