using Finickyzone.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Samples.Services;

[Singleton]
public sealed class SingletonService : IService
{
    public string Name => nameof(SingletonService);
}