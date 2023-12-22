using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.DependencyInjection;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class ServiceAttribute : RegistrableAttribute
{
    public ServiceAttribute(Type? serviceType, ServiceLifetime lifetime)
    {
        ServiceType = serviceType;
        Lifetime = lifetime;
    }
    
    /// <summary>
    /// The lifetime of the service.
    /// </summary>
    public ServiceLifetime Lifetime { get; }

    /// <summary>
    /// The type of the service to be registered under. If null, the service will be registered as the type this attribute is
    /// above.
    /// </summary>
    public Type? ServiceType { get; }

    protected internal override void Register(IServiceCollection services, Type targetType)
    {
        Type serviceType = ServiceType ?? targetType;
        services.Add(new ServiceDescriptor(serviceType, targetType, Lifetime));
    }
}