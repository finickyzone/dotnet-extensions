using Finickyzone.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Finickyzone.Extensions.Benchmarks.GenericServiceAttribute;

public class Reflection_MemoryCache_Utilities : ServiceAttribute
{
    private static readonly Type Type = typeof(Reflection_MemoryCache_Utilities);
    private static readonly Type[] ParameterTypes = [typeof(IServiceCollection)];

    protected void Register<TTarget>(IServiceCollection services) where TTarget : class
    {
        services.AddSingleton<Service>();
    }

    protected internal override void Register(IServiceCollection services, Type targetType)
    {
        Type.GetCachedGenericMethod(nameof(Register), BindingFlags.NonPublic | BindingFlags.Instance, [targetType], ParameterTypes)!.Invoke(this, [services]);
    }
}