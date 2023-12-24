using Finickyzone.Extensions.DependencyInjection;
using Finickyzone.Extensions.DependencyInjection.Internals;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Finickyzone.Extensions.Benchmarks.GenericServiceAttribute;

public class Reflection_MemoryCache_MethodInvoker : ServiceAttribute
{
    private static readonly IMemoryCache CachedMethods = new MemoryCache(Options.Create(new MemoryCacheOptions()));

    protected void Register<TTarget>(IServiceCollection services) where TTarget : class
    {
        services.AddSingleton<Service>();
    }

    protected internal override void Register(IServiceCollection services, Type targetType)
    {
        GetMethodInvoker(targetType)!.Invoke(this, services);
    }

    private static MethodInvoker? GetMethodInvoker(Type targetType)
    {
        return CachedMethods.GetOrCreate(targetType.Name, _ =>
        {
            MethodInfo? methodInfo = typeof(Reflection_MemoryCache_MethodInvoker).GetMethod(nameof(Register), BindingFlags.Instance | BindingFlags.NonPublic, [typeof(IServiceCollection)]);
            return methodInfo?.MakeGenericMethod(targetType).ToMethodInvoker();
        });
    }
}