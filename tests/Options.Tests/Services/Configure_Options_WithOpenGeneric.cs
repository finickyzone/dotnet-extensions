using Microsoft.Extensions.Options;

namespace Finickyzone.Extensions.Options;

[ConfigureOptions]
public class Configure_Options_WithOpenGeneric<TOptions> : IConfigureNamedOptions<TOptions> where TOptions : class
{
    public void Configure(TOptions options)
    {
    }

    public void Configure(string name, TOptions options)
    {
    }
}