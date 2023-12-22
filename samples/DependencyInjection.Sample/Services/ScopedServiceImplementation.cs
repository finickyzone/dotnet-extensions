using Finickyzone.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Samples;

[Scoped<IService>]
public sealed class ScopedServiceImplementation : IService
{
    public string Name => nameof(ScopedServiceImplementation);
}