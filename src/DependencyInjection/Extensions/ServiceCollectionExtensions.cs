using Finickyzone.Extensions.DependencyInjection.Internals;
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
    /// <param name="collection">The <see cref="IServiceCollection" /> to add the service to.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection AddServicesFromAssemblyOf<T>(this IServiceCollection collection)
    {
        ArgumentNullException.ThrowIfNull(collection);

        return collection.AddServicesFromAssembly(typeof(T).Assembly);
    }

    /// <summary>
    /// Adds all the services with a <see cref="ServiceAttribute" /> from the specified <see cref="Assembly" /> in the
    /// <see cref="IServiceCollection" />.
    /// </summary>
    /// <param name="collection">The <see cref="IServiceCollection" /> to add the service to.</param>
    /// <param name="assembly">The <see cref="Assembly" /> that will be scanned to register the services.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection AddServicesFromAssembly(this IServiceCollection collection, Assembly assembly)
    {
        ArgumentNullException.ThrowIfNull(collection);

        IOrderedEnumerable<RegistrableService> services = assembly.GetRegistrableServices().OrderBy(service => service.Rank);
        return collection.AddServices(services);
    }

    /// <summary>
    /// Adds a service with the specified <paramref name="lifetime"/> of the type <paramref name="serviceType"/>
    /// with an implementation of the type specified in <paramref name="implementationType"/> to the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="collection">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="serviceType">The <see cref="Type"/> of the service.</param>
    /// <param name="implementationType">The <see cref="Type"/> implementing the service.</param>
    /// <param name="lifetime">The <see cref="ServiceLifetime"/> of the service.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection AddService(this IServiceCollection collection, Type serviceType, Type implementationType, ServiceLifetime lifetime)
    {
        ArgumentNullException.ThrowIfNull(collection);

        collection.Add(new ServiceDescriptor(serviceType, implementationType, lifetime));
        return collection;
    }

    /// <summary>
    /// Adds a service with the specified <paramref name="lifetime"/> of the type <paramref name="serviceType"/> to the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="collection">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="serviceType">The <see cref="Type"/> of the service.</param>
    /// <param name="lifetime">The <see cref="ServiceLifetime"/> of the service.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection AddService(this IServiceCollection collection, Type serviceType, ServiceLifetime lifetime)
    {
        ArgumentNullException.ThrowIfNull(collection);

        collection.Add(new ServiceDescriptor(serviceType, serviceType, lifetime));
        return collection;
    }

    /// <summary>
    /// Adds a service of the type specified in <typeparamref name="TService"/> to the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="collection">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="lifetime">The <see cref="ServiceLifetime"/> of the service.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection AddService<TService>(this IServiceCollection collection, ServiceLifetime lifetime)
        where TService : class
    {
        ArgumentNullException.ThrowIfNull(collection);

        return collection.AddService(typeof(TService), lifetime);
    }

    /// <summary>
    /// Adds a service of the type specified in <typeparamref name="TService"/>
    /// with an implementation of the type specified in <typeparamref name="TImplementation"/> to the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="collection">The <see cref="IServiceCollection"/> to add the service to.</param>
    /// <param name="lifetime">The <see cref="ServiceLifetime"/> of the service.</param>
    /// <returns>A reference to this instance after the operation has completed.</returns>
    public static IServiceCollection AddService<TService, TImplementation>(this IServiceCollection collection, ServiceLifetime lifetime)
        where TService : class
        where TImplementation : class, TService
    {
        ArgumentNullException.ThrowIfNull(collection);

        return collection.AddService(typeof(TService), typeof(TImplementation), lifetime);
    }

    /// <summary>
    /// Adds a sequence of <see cref="ServiceDescriptor"/> to the <paramref name="collection"/>.
    /// </summary>
    /// <param name="collection">The <see cref="IServiceCollection"/>to add the descriptors to.</param>
    /// <param name="descriptors">The <see cref="ServiceDescriptor"/>s to add.</param>
    public static IServiceCollection AddServices(this IServiceCollection collection, params ServiceDescriptor[] descriptors)
    {
        ArgumentNullException.ThrowIfNull(collection);
        ArgumentNullException.ThrowIfNull(descriptors);

        return collection.Add(descriptors);
    }

    /// <summary>
    /// Adds a sequence of <see cref="ServiceDescriptor"/> to the <paramref name="collection"/>.
    /// </summary>
    /// <param name="collection">The <see cref="IServiceCollection"/>to add the descriptors to.</param>
    /// <param name="descriptors">The <see cref="ServiceDescriptor"/>s to add.</param>
    public static IServiceCollection AddServices(this IServiceCollection collection, IEnumerable<ServiceDescriptor> descriptors)
    {
        ArgumentNullException.ThrowIfNull(collection);
        ArgumentNullException.ThrowIfNull(descriptors);

        return collection.Add(descriptors);
    }
}