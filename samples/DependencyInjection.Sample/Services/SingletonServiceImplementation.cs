using Finickyzone.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Samples.Services;

[Singleton<IService>]
public sealed class SingletonServiceImplementation : IService
{
    public string Name => nameof(SingletonServiceImplementation);
}