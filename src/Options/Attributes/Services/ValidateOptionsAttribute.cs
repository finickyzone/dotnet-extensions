using Microsoft.Extensions.Options;

namespace Finickyzone.Extensions.Options;

/// <summary>
/// Registers the Attribute's target as an <see cref="IValidateOptions{TOptions}"/> used to validate a particular type of options.
/// Note: These are run after all <seealso cref="IPostConfigureOptions{TOptions}"/>.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class ValidateOptionsAttribute : OptionsServiceAttribute
{
    public ValidateOptionsAttribute(Type? optionsType = null)
        : base(typeof(IValidateOptions<>), optionsType)
    {
    }
}