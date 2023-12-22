namespace Finickyzone.Extensions.Options;

/// <inheritdoc />
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class ConfigureOptionsAttribute<TOptions>() : ConfigureOptionsAttribute(typeof(TOptions)) where TOptions : class;