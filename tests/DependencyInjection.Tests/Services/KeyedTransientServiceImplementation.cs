namespace Finickyzone.Extensions.DependencyInjection;

[KeyedTransient<IService>(Key)]
public sealed class KeyedTransientServiceImplementation : IService
{
    public const string Key = nameof(Key);
}