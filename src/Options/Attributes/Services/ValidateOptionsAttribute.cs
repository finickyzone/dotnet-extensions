using Microsoft.Extensions.Options;

namespace Finickyzone.Extensions.Options;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class ValidateOptionsAttribute : OptionsServiceAttribute
{
    public ValidateOptionsAttribute(Type? optionsType = null)
        : base(typeof(IValidateOptions<>), optionsType)
    {
    }
}