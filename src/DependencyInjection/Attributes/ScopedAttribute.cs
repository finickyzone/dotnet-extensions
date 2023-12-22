using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.DependencyInjection;

/// <summary>
/// Adds a scoped service of the type specified in serviceType with Attribute's target type as the implementation to the DI container.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class ScopedAttribute(Type? serviceType = null) : ServiceAttribute
{
    /// <summary>
    /// The type of the service to be registered under. If null, the service will be registered as the type this attribute is
    /// above.
    /// </summary>
    public Type? ServiceType { get; } = serviceType;

    protected internal override void Register(IServiceCollection services, Type targetType)
    {
        services.AddScoped(ServiceType ?? targetType, targetType);
    }
}