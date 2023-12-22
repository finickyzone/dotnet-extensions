using Microsoft.Extensions.Options;

namespace Finickyzone.Extensions.Options;

[ConfigureOptions]
public class Configure_Options : IConfigureNamedOptions<Options_WithConfigureOptions>
{
    public void Configure(Options_WithConfigureOptions options)
    {
    }

    public void Configure(string? name, Options_WithConfigureOptions options)
    {
    }
}