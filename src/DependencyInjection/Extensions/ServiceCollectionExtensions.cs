using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace Finickyzone.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds all the services with a <see cref="ServiceAttribute" /> from the <typeparamref name="T" />'s
    /// <see cref="Assembly" /> in the <see cref="IServiceCollection" />.
    /// </summary>
    /// <typeparam name="T">The type from the <see cref="Assembly" /> that will be scanned to register the services.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection" /> to add the service to.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection AddServicesFromAssemblyOf<T>(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);
        return services.AddServicesFromAssembly(typeof(T).Assembly);
    }

    /// <summary>
    /// Adds all the services with a <see cref="ServiceAttribute" /> from the specified <see cref="Assembly" /> in the
    /// <see cref="IServiceCollection" />.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add the service to.</param>
    /// <param name="assembly">The <see cref="Assembly" /> that will be scanned to register the services.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection AddServicesFromAssembly(this IServiceCollection services, Assembly assembly)
    {
        ArgumentNullException.ThrowIfNull(services);
        foreach (Type type in assembly.GetTypes())
        {
            foreach (ServiceAttribute attribute in type.GetCustomAttributes<ServiceAttribute>(true))
            {
                attribute.Register(services, type);
            }
        }
        return services;
    }

    /// <summary>
    /// Adds a service with the specified <paramref name="lifetime"/> of the type <paramref name="serviceType"/>
    /// with an implementation of the type specified in <paramref name="implementationType"/> to the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="serviceType">The <see cref="Type"/> of the service.</param>
    /// <param name="implementationType">The <see cref="Type"/> implementing the service.</param>
    /// <param name="lifetime">The <see cref="ServiceLifetime"/> of the service.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection Add(this IServiceCollection services, Type serviceType, Type implementationType, ServiceLifetime lifetime)
    {
        ArgumentNullException.ThrowIfNull(services);
        services.Add(new ServiceDescriptor(serviceType, implementationType, lifetime));
        return services;
    }

    /// <summary>
    /// Adds a service with the specified <paramref name="lifetime"/> of the type <paramref name="serviceType"/> to the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="serviceType">The <see cref="Type"/> of the service.</param>
    /// <param name="lifetime">The <see cref="ServiceLifetime"/> of the service.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection Add(this IServiceCollection services, Type serviceType, ServiceLifetime lifetime)
    {
        ArgumentNullException.ThrowIfNull(services);
        services.Add(new ServiceDescriptor(serviceType, serviceType, lifetime));
        return services;
    }

    /// <summary>
    /// Adds a service of the type specified in <typeparamref name="TService"/> to the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="lifetime">The <see cref="ServiceLifetime"/> of the service.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection Add<TService>(this IServiceCollection services, ServiceLifetime lifetime)
        where TService : class
    {
        ArgumentNullException.ThrowIfNull(services);
        return services.Add(typeof(TService), lifetime);
    }

    /// <summary>
    /// Adds a service of the type specified in <typeparamref name="TService"/>
    /// with an implementation of the type specified in <typeparamref name="TImplementation"/> to the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="lifetime">The <see cref="ServiceLifetime"/> of the service.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection Add<TService, TImplementation>(this IServiceCollection services, ServiceLifetime lifetime)
        where TService : class
        where TImplementation : class, TService
    {
        ArgumentNullException.ThrowIfNull(services);
        return services.Add(typeof(TService), typeof(TImplementation), lifetime);
    }

    /// <summary>
    /// Adds a sequence of <see cref="ServiceDescriptor"/> to the <paramref name="services"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/>to add the descriptors to.</param>
    /// <param name="descriptors">The <see cref="ServiceDescriptor"/>s to add.</param>
    public static IServiceCollection AddRange(this IServiceCollection services, params ServiceDescriptor[] descriptors)
    {
        return services.Add(descriptors);
    }

    /// <summary>
    /// Adds a sequence of <see cref="ServiceDescriptor"/> to the <paramref name="services"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/>to add the descriptors to.</param>
    /// <param name="descriptors">The <see cref="ServiceDescriptor"/>s to add.</param>
    public static IServiceCollection AddRange(this IServiceCollection services, IEnumerable<ServiceDescriptor> descriptors)
    {
        return services.Add(descriptors);
    }
}