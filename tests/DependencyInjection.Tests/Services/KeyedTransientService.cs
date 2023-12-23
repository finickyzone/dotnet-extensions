namespace Finickyzone.Extensions.DependencyInjection;

[KeyedTransient(Key)]
public sealed class KeyedTransientService : IService
{
    public const string Key = nameof(Key);
}