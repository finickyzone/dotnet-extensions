namespace Finickyzone.Extensions.DependencyInjection;

[KeyedScoped(Key)]
public sealed class KeyedScopedService : IService
{
    public const string Key = nameof(Key);
}