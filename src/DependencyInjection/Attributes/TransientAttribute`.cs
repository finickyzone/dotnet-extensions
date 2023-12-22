namespace Finickyzone.Extensions.DependencyInjection;

/// <inheritdoc />
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class TransientAttribute<TService>() : TransientAttribute(typeof(TService));