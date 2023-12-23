using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.DependencyInjection;

/// <summary>
/// Adds a scoped service of the type specified in serviceType with Attribute's target type as the implementation to the DI container.
/// </summary>
/// <param name="serviceKey">
/// The <see cref="ServiceDescriptor.ServiceKey"/> of the service.
/// </param>
/// <param name="serviceType">
/// The type of the service to be registered under.
/// If null, the service will be registered as the Attribute's target type.
/// </param>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class KeyedScopedAttribute(object serviceKey, Type? serviceType = null) : ServiceAttribute
{
    protected internal override void Register(IServiceCollection services, Type targetType)
    {
        services.AddKeyedScoped(serviceType ?? targetType, serviceKey, targetType);
    }
}