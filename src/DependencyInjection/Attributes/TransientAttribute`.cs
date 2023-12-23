namespace Finickyzone.Extensions.DependencyInjection;

/// <summary>
/// Adds a transient service of the type specified in <typeparamref name="TService"/> with Attribute's target type as the implementation to the DI container.
/// </summary>
/// <typeparam name="TService">
/// The type of the service to be registered under.
/// </typeparam>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class TransientAttribute<TService>() : TransientAttribute(typeof(TService));