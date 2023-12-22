namespace Finickyzone.Extensions.Options;

/// <inheritdoc />
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class ValidateOptionsAttribute<TOptions>() : ValidateOptionsAttribute(typeof(TOptions)) where TOptions : class;