using Microsoft.Extensions.Options;

namespace Finickyzone.Extensions.Options;

[ConfigureOptions<Options_WithConfigureOptions>]
public class Configure_Options_WithOptionsType<TOptions> : IConfigureNamedOptions<TOptions> where TOptions : class
{
    public void Configure(TOptions options)
    {
    }

    public void Configure(string? name, TOptions options)
    {
    }
}