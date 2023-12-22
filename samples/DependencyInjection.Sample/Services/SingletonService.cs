using Finickyzone.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Samples;

[Singleton]
public sealed class SingletonService : IService
{
    public string Name => nameof(SingletonService);
}