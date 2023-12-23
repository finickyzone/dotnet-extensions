using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.DependencyInjection;

/// <summary>
/// Adds a transient service of the type specified in <paramref name="serviceType"/> with the Attribute's target type as the implementation to the DI container.
/// </summary>
/// <param name="serviceType">
/// The type of the service to be registered under.
/// If null, the service will be registered as the Attribute's target type.
/// </param>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class TransientAttribute(Type? serviceType = null) : ServiceAttribute
{
    protected internal override void Register(IServiceCollection services, Type targetType)
    {
        services.AddTransient(serviceType ?? targetType, targetType);
    }
}