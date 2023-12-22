namespace Finickyzone.Extensions.DependencyInjection;

/// <inheritdoc />
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class SingletonAttribute<TService>() : SingletonAttribute(typeof(TService));