using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.DependencyInjection;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class TransientAttribute : ServiceAttribute
{
    public TransientAttribute(Type? serviceType = null)
        : base(serviceType, ServiceLifetime.Transient)
    {
    }
}