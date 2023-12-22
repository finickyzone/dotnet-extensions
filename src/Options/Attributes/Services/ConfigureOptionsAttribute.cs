using Microsoft.Extensions.Options;

namespace Finickyzone.Extensions.Options;

/// <summary>
/// Registers the Attribute's target as an <see cref="IConfigureOptions{TOptions}"/> used to configure a particular type of options.
/// Note: These are run before all <seealso cref="IPostConfigureOptions{TOptions}"/>.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class ConfigureOptionsAttribute : OptionsServiceAttribute
{
    public ConfigureOptionsAttribute(Type? optionsType = null)
        : base(typeof(IConfigureOptions<>), optionsType)
    {
    }
}