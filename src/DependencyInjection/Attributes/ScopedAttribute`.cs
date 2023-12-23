namespace Finickyzone.Extensions.DependencyInjection;

/// <summary>
/// Adds a scoped service of the type specified in serviceType with Attribute's target type as the implementation to the DI container.
/// </summary>
/// <typeparam name="TService">
/// The type of the service to be registered under.
/// </typeparam>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class ScopedAttribute<TService>() : ScopedAttribute(typeof(TService));