namespace Finickyzone.Extensions.DependencyInjection;

[KeyedScoped<IService>(Key)]
public sealed class KeyedScopedServiceImplementation : IService
{
    public const string Key = nameof(Key);
}