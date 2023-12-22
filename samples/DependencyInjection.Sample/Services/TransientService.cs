using Finickyzone.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Samples;

[Transient]
public sealed class TransientService : IService
{
    public string Name => nameof(TransientService);
}