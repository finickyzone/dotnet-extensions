using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Finickyzone.Extensions.DependencyInjection;

public static class ServiceCollectionAttributesExtensions
{
    /// <summary>
    /// Adds all the services with a <see cref="ServiceAttribute"/> from the <typeparamref name="T"/>'s <see cref="Assembly"/> in the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <typeparam name="T">The type from the <see cref="Assembly"/> that will be scanned to register the services.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection AddServicesFromAssembly<T>(this IServiceCollection services)
    {
        return services.AddServicesFromAssembly(typeof(T).Assembly);
    }

    /// <summary>
    /// Adds all the services with a <see cref="ServiceAttribute"/> from the specified <see cref="Assembly"/> in the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="assembly">The <see cref="Assembly"/> that will be scanned to register the services.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection AddServicesFromAssembly(this IServiceCollection services, Assembly assembly)
    {
        IEnumerable<ServiceDescriptor> descriptors = GetServiceDescriptorsFromAssembly(assembly);
        return services.AddRange(descriptors);
    }

    private static IServiceCollection AddRange(this IServiceCollection services, IEnumerable<ServiceDescriptor> serviceDescriptors)
    {
        foreach (ServiceDescriptor descriptor in serviceDescriptors)
        {
            services.Add(descriptor);
        }
        return services;
    }

    private static IEnumerable<ServiceDescriptor> GetServiceDescriptorsFromAssembly(Assembly assembly)
    {
        return from type in assembly.GetTypes()
               from attribute in type.GetCustomAttributes<ServiceAttribute>()
               select new ServiceDescriptor(attribute.ServiceType ?? type, type, attribute.Lifetime);
    }
}