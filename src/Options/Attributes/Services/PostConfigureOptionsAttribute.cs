using Finickyzone.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Finickyzone.Extensions.Options;

/// <summary>
/// Registers the Attribute's target as an <see cref="IPostConfigureOptions{TOptions}"/> used to configure a particular type of options.
/// Note: These are run after all <seealso cref="IConfigureOptions{TOptions}"/>.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class PostConfigureOptionsAttribute(Type? optionsType = null) : ServiceAttribute
{
    /// <summary>
    /// The type of the options. If null and the inherited interface is open generic, the service type will stay open generic.
    /// Otherwise, the service type will take the same generic type than its inherited interface. 
    /// </summary>
    public Type? OptionsType { get; } = optionsType;

    protected internal override void Register(IServiceCollection services, Type targetType)
    {
        services.AddOptionsService(typeof(IPostConfigureOptions<>), targetType, OptionsType);
    }
}