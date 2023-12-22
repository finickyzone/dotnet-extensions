using Microsoft.Extensions.Options;

namespace Finickyzone.Extensions.Options;

/// <summary>
/// Registers the Attribute's target as an <see cref="IPostConfigureOptions{TOptions}"/> used to configure a particular type of options.
/// Note: These are run after all <seealso cref="IConfigureOptions{TOptions}"/>.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class PostConfigureOptionsAttribute : OptionsServiceAttribute
{
    public PostConfigureOptionsAttribute(Type? optionsType = null)
        : base(typeof(IPostConfigureOptions<>), optionsType)
    {
    }
}