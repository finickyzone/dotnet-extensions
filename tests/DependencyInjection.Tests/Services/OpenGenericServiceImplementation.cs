namespace Finickyzone.Extensions.DependencyInjection;

[Singleton(typeof(IGenericService<>))]
public sealed class OpenGenericServiceImplementation<T> : IGenericService<T>;