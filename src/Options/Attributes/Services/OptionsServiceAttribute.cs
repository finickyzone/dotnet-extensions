using Finickyzone.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Options;

public abstract class OptionsServiceAttribute : ServiceAttribute
{
    protected OptionsServiceAttribute(Type serviceType, Type? optionsType)
        : base(serviceType, ServiceLifetime.Singleton)
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
        InvalidAttributeTargetTypeException.ThrowIfNotAssignableTo(targetType, ServiceType);

        Type serviceType = targetType is { IsGenericType: true, IsGenericTypeDefinition: true } ? ServiceType : targetType.GetInterface(ServiceType.Name) ?? ServiceType;
        if (OptionsType is not null)
        {
            serviceType = serviceType.GetGenericTypeDefinition().MakeGenericType(OptionsType);
        }

        Type implementationType = targetType;
        if (OptionsType is not null && implementationType.IsGenericType)
        {
            implementationType = implementationType.GetGenericTypeDefinition().MakeGenericType(OptionsType);
        }

        InvalidAttributeTargetTypeException.ThrowIfNotAssignableTo(implementationType, serviceType);
        services.Add(new ServiceDescriptor(serviceType, implementationType, Lifetime));
    }
}