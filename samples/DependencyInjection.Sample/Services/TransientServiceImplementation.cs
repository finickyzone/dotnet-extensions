using Finickyzone.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Samples.Services;

[Transient<IService>]
public sealed class TransientServiceImplementation : IService
{
    public string Name => nameof(TransientServiceImplementation);
}