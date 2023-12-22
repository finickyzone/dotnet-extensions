namespace Finickyzone.Extensions.DependencyInjection;

/// <inheritdoc />
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class ScopedAttribute<TService>() : ScopedAttribute(typeof(TService));