using Microsoft.Extensions.Options;

namespace Finickyzone.Extensions.Options;

[ValidateOptions(typeof(Options_WithValidateOptions))]
public class Validate_Options_WithOptionsType<TOptions> : IValidateOptions<TOptions> where TOptions : class
{
    public ValidateOptionsResult Validate(string name, TOptions options)
    {
        return ValidateOptionsResult.Skip;
    }
}