using Finickyzone.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Finickyzone.Extensions.Options;

/// <summary>
/// Registers the Attribute's target as an <see cref="IValidateOptions{TOptions}"/> used to validate a particular type of options.
/// Note: These are run after all <seealso cref="IPostConfigureOptions{TOptions}"/>.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class ValidateOptionsAttribute : ServiceAttribute
{
    public ValidateOptionsAttribute(Type? optionsType = null)
    {
        OptionsType = optionsType;
    }

    /// <summary>
    /// The type of the options. If null and the inherited interface is open generic, the service type will stay open generic.
    /// Otherwise, the service type will take the same generic type than its inherited interface. 
    /// </summary>
    public Type? OptionsType { get; }

    protected internal override void Register(IServiceCollection services, Type targetType)
    {
        services.AddOptionsService(typeof(IValidateOptions<>), targetType, OptionsType);
    }
}