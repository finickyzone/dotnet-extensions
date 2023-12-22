using Microsoft.Extensions.Options;

namespace Finickyzone.Extensions.Options;

[ValidateOptions]
public class Validate_Options : IValidateOptions<Options_WithValidateOptions>
{
    public ValidateOptionsResult Validate(string? name, Options_WithValidateOptions options)
    {
        return ValidateOptionsResult.Skip;
    }
}