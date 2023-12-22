using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.DependencyInjection;

[MeansImplicitUse]
public abstract class RegistrableAttribute : Attribute
{
    protected internal abstract void Register(IServiceCollection services, Type targetType);
}