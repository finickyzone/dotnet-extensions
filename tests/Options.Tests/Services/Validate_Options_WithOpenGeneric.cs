using Microsoft.Extensions.Options;

namespace Finickyzone.Extensions.Options;

[ValidateOptions]
public class Validate_Options_WithOpenGeneric<TOptions> : IValidateOptions<TOptions> where TOptions : class
{
    public ValidateOptionsResult Validate(string? name, TOptions options)
    {
        return ValidateOptionsResult.Skip;
    }
}