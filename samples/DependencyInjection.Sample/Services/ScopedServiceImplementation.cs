using Finickyzone.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Samples.Services;

[Scoped<IService>]
public sealed class ScopedServiceImplementation : IService
{
    public string Name => nameof(ScopedServiceImplementation);
}