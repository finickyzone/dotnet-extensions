namespace Finickyzone.Extensions.DependencyInjection;

public interface IService
{
}

[Singleton]
public sealed class SingletonService : IService
{
}

[Singleton(typeof(IService))]
public sealed class SingletonServiceImplementation : IService
{
}

[Transient]
public sealed class TransientService : IService
{
}

[Transient(typeof(IService))]
public sealed class TransientServiceImplementation : IService
{
}

[Scoped]
public sealed class ScopedService : IService
{
}

[Scoped(typeof(IService))]
public sealed class ScopedServiceImplementation : IService
{
}