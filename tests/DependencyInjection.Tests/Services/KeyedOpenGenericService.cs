namespace Finickyzone.Extensions.DependencyInjection;

[KeyedSingleton(Key)]
public sealed class KeyedOpenGenericService<T> : IGenericService<T>
{
    public const string Key = nameof(Key);
}