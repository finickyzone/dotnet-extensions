namespace Finickyzone.Extensions.DependencyInjection;

[Transient(typeof(IService))]
public sealed class TransientServiceImplementation : IService
{
}