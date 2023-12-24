using Finickyzone.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Samples.Services;

[Transient]
public sealed class TransientService : IService
{
    public string Name => nameof(TransientService);
}