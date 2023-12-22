using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.DependencyInjection;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class SingletonAttribute : ServiceAttribute
{
    public SingletonAttribute(Type? serviceType = null)
        : base(serviceType, ServiceLifetime.Singleton)
    {
    }
}