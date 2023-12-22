using Finickyzone.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Options;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddOptionsService(this IServiceCollection services, Type serviceType, Type implementationType, Type? optionsType)
    {
        InvalidAttributeTargetTypeException.ThrowIfNotAssignableTo(implementationType, serviceType);

        if (implementationType is not { IsGenericType: true, IsGenericTypeDefinition: true })
        {
            serviceType = implementationType.GetInterface(serviceType.Name) ?? serviceType;
        }
        if (optionsType is not null)
        {
            serviceType = serviceType.GetGenericTypeDefinition().MakeGenericType(optionsType);
        }

        if (optionsType is not null && implementationType.IsGenericType)
        {
            implementationType = implementationType.GetGenericTypeDefinition().MakeGenericType(optionsType);
        }

        InvalidAttributeTargetTypeException.ThrowIfNotAssignableTo(implementationType, serviceType);
        return services.AddSingleton(serviceType, implementationType);
    }
}