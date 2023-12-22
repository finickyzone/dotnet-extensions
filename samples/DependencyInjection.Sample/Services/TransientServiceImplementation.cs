using Finickyzone.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Samples;

[Transient<IService>]
public sealed class TransientServiceImplementation : IService
{
    public string Name => nameof(TransientServiceImplementation);
}