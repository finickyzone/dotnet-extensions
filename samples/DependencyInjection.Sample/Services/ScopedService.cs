using Finickyzone.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Samples;

[Scoped]
public sealed class ScopedService : IService
{
    public string Name => nameof(ScopedService);
}