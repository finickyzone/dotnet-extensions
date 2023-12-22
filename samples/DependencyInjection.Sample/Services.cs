using Finickyzone.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Samples;

public interface IService
{
    string Name { get; }
}

[Singleton]
public sealed class SingletonService : IService
{
    public string Name => nameof(SingletonService);
}

[Singleton(typeof(IService))]
public sealed class SingletonServiceImplementation : IService
{
    public string Name => nameof(SingletonServiceImplementation);
}

[Transient]
public sealed class TransientService : IService
{
    public string Name => nameof(TransientService);
}

[Transient(typeof(IService))]
public sealed class TransientServiceImplementation : IService
{
    public string Name => nameof(TransientServiceImplementation);
}

[Scoped]
public sealed class ScopedService : IService
{
    public string Name => nameof(ScopedService);
}

[Scoped(typeof(IService))]
public sealed class ScopedServiceImplementation : IService
{
    public string Name => nameof(ScopedServiceImplementation);
}