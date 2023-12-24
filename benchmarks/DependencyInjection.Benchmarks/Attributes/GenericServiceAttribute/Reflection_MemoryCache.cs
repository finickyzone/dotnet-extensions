using Finickyzone.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Finickyzone.Extensions.Benchmarks.GenericServiceAttribute;

public class Reflection_MemoryCache : ServiceAttribute
{
    private static readonly IMemoryCache CachedMethods = new MemoryCache(Options.Create(new MemoryCacheOptions()));

    protected void Register<TTarget>(IServiceCollection services) where TTarget : class
    {
        services.AddSingleton<Service>();
    }

    protected internal override void Register(IServiceCollection services, Type targetType)
    {
        CachedMethods.GetOrCreate(targetType.Name, _ => GetMethodInfo(targetType))!.Invoke(this, [services]);
    }

    private static MethodInfo? GetMethodInfo(Type targetType)
    {
        return typeof(Reflection_MemoryCache).GetMethod(nameof(Register), BindingFlags.Instance | BindingFlags.NonPublic, [typeof(IServiceCollection)])?.MakeGenericMethod(targetType);
    }
}