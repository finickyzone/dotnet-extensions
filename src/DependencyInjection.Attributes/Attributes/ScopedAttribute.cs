using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.DependencyInjection;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class ScopedAttribute : ServiceAttribute
{
    public ScopedAttribute(Type? serviceType = null)
        : base(ServiceLifetime.Scoped, serviceType)
    {
    }
}