namespace Finickyzone.Extensions.DependencyInjection;

[Singleton]
public sealed class OpenGenericService<T> : IGenericService<T>;