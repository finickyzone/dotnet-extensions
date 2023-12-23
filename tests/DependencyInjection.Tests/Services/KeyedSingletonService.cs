namespace Finickyzone.Extensions.DependencyInjection;

[KeyedSingleton(Key)]
public sealed class KeyedSingletonService : IService
{
    public const string Key = nameof(Key);
}