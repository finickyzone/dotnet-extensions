namespace Finickyzone.Extensions.DependencyInjection;

/// <summary>
/// Adds a singleton service of the type specified in serviceType with Attribute's target type as the implementation to the DI container.
/// </summary>
/// <param name="serviceKey">
/// The <see cref="Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey"/> of the service.
/// </param>
/// <typeparam name="TService">
/// The type of the service to be registered under.
/// </typeparam>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class KeyedSingletonAttribute<TService>(object serviceKey) : KeyedSingletonAttribute(serviceKey, typeof(TService));