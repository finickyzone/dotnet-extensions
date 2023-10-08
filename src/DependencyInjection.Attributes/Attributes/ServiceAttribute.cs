using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.DependencyInjection;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class ServiceAttribute : Attribute
{
    public ServiceAttribute(ServiceLifetime lifetime = ServiceLifetime.Singleton, Type? serviceType = null)
    {
        Lifetime = lifetime;
        ServiceType = serviceType;
    }

    /// <summary>
    /// The lifetime of the service.
    /// </summary>
    public ServiceLifetime Lifetime { get; set; }
    
    /// <summary>
    /// The type of the service to be registered under. If null, the service will be registered as the type this attribute is above.
    /// </summary>
    public Type? ServiceType { get; }
}





