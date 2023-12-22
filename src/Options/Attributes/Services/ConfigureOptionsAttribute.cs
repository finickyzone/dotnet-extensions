using Microsoft.Extensions.Options;

namespace Finickyzone.Extensions.Options;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class ConfigureOptionsAttribute : OptionsServiceAttribute
{
    public ConfigureOptionsAttribute(Type? optionsType = null)
        : base(typeof(IConfigureOptions<>), optionsType)
    {
    }
}