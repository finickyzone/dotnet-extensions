namespace Finickyzone.Extensions.DependencyInjection;

/// <summary>
/// Adds a scoped service of the type specified in <typeparamref name="TService"/> with Attribute's target type as the implementation to the DI container.
/// </summary>
/// <param name="serviceKey">
/// The <see cref="Microsoft.Extensions.DependencyInjection.ServiceDescriptor.ServiceKey"/> of the service.
/// </param>
/// <typeparam name="TService">
/// The type of the service to be registered under.
/// </typeparam>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class KeyedScopedAttribute<TService>(object serviceKey) : KeyedScopedAttribute(serviceKey, typeof(TService));