namespace Finickyzone.Extensions.DependencyInjection;

[KeyedSingleton(Key, typeof(IGenericService<>))]
public sealed class KeyedOpenGenericServiceImplementation<T> : IGenericService<T>
{
    public const string Key = nameof(Key);
}