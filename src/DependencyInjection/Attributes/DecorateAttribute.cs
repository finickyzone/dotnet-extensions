using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.DependencyInjection;

/// <summary>
/// Decorates all registered services of the specified serviceType using the Attribute's target type.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class DecorateAttribute : ServiceAttribute
{
    private readonly Type _serviceType;

    /// <summary>
    /// Decorates all registered services of the specified <paramref name="serviceType"/> using the Attribute's target type.
    /// </summary>
    /// <param name="serviceType">The type of services to decorate.</param>
    public DecorateAttribute(Type serviceType)
    {
        _serviceType = serviceType;
        Rank = short.MaxValue;
    }

    protected internal override void Register(IServiceCollection services, Type targetType)
    {
        services.Decorate(_serviceType, targetType);
    }
}