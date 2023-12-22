using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.DependencyInjection;

/// <summary>
/// Base <see cref="Attribute"/> to mark the inherited class as being registrable in the DI Container.
/// </summary>
[MeansImplicitUse]
public abstract class ServiceAttribute : Attribute
{
    protected internal abstract void Register(IServiceCollection services, Type targetType);
}