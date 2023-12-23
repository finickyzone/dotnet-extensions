namespace Finickyzone.Extensions.DependencyInjection;

/// <summary>
/// Decorates all registered services of the specified <typeparamref name="TService"/> using the Attribute's target type.
/// </summary>
/// <typeparam name="TService">The type of services to decorate.</typeparam>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class DecorateAttribute<TService>() : DecorateAttribute(typeof(TService));