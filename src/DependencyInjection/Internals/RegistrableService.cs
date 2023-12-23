using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.DependencyInjection.Internals;

internal readonly struct RegistrableService(Type implementationType, ServiceAttribute attribute)
{
    public Type ImplementationType => implementationType;

    public ServiceAttribute Attribute => attribute;

    /// <inheritdoc cref="ServiceAttribute.Rank"/>
    public short Rank => attribute.Rank;

    public void Register(IServiceCollection services) => attribute.Register(services, implementationType);

    public static RegistrableService Create<TImplementation>(ServiceAttribute attribute)
        where TImplementation : class
    {
        return new RegistrableService(typeof(TImplementation), attribute);
    }

    public static RegistrableService Create<TImplementation, TAttribute>()
        where TImplementation : class
        where TAttribute : ServiceAttribute, new()
    {
        return new RegistrableService(typeof(TImplementation), new TAttribute());
    }
}