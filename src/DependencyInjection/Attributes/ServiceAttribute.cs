using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.DependencyInjection;

/// <summary>
/// Base <see cref="Attribute"/> to mark the inherited class as being registrable in the DI Container.
/// </summary>
[MeansImplicitUse]
public abstract class ServiceAttribute : Attribute
{
    /// <summary>
    /// Determines the order in which services are registered
    /// </summary>
    public short Rank { get; set; }
    
    protected internal abstract void Register(IServiceCollection services, Type targetType);
}