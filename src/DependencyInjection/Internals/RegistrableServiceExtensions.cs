using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Finickyzone.Extensions.DependencyInjection.Internals;

internal static class RegistrableServiceExtensions
{
    /// <summary>
    /// Adds a sequence of <see cref="RegistrableService"/> to the <paramref name="collection"/>.
    /// </summary>
    /// <param name="collection">The <see cref="IServiceCollection"/>to add the descriptors to.</param>
    /// <param name="services">The <see cref="RegistrableService"/>s to add.</param>
    internal static IServiceCollection AddServices(this IServiceCollection collection, params RegistrableService[] services)
    {
        ArgumentNullException.ThrowIfNull(collection);
        ArgumentNullException.ThrowIfNull(services);

        return collection.AddServices((IEnumerable<RegistrableService>)services);
    }

    /// <summary>
    /// Adds a sequence of <see cref="RegistrableService"/> to the <paramref name="collection"/>.
    /// </summary>
    /// <param name="collection">The <see cref="IServiceCollection"/>to add the descriptors to.</param>
    /// <param name="services">The <see cref="RegistrableService"/>s to add.</param>
    internal static IServiceCollection AddServices(this IServiceCollection collection, IEnumerable<RegistrableService> services)
    {
        ArgumentNullException.ThrowIfNull(collection);
        ArgumentNullException.ThrowIfNull(services);

        foreach (RegistrableService service in services)
        {
            service.Register(collection);
        }
        return collection;
    }
    
    /// <summary>
    /// Returns all the <see cref="RegistrableService"/> from within the specified <paramref name="assembly"/>.
    /// </summary>
    internal static IEnumerable<RegistrableService> GetRegistrableServices(this Assembly assembly)
    {
        return assembly.GetTypes().SelectMany(GetRegistrableServices);
    }

    /// <summary>
    /// Returns all the <see cref="RegistrableService"/> from within the specified <paramref name="type"/>.
    /// </summary>
    internal static IEnumerable<RegistrableService> GetRegistrableServices(this Type type)
    {
        return from attribute in type.GetCustomAttributes<ServiceAttribute>(true)
               select new RegistrableService(type, attribute);
    }
}