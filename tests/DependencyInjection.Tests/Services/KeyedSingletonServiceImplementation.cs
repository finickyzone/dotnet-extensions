namespace Finickyzone.Extensions.DependencyInjection;

[KeyedSingleton<IService>(Key)]
public sealed class KeyedSingletonServiceImplementation : IService
{
    public const string Key = nameof(Key);
}