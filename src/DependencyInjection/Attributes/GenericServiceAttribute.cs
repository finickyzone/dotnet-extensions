using Finickyzone.Extensions.DependencyInjection.Internals;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Finickyzone.Extensions.DependencyInjection;

/// <summary>
/// Base <see cref="Attribute"/> to mark the inherited class as being registrable in the DI Container.
/// </summary>
public abstract class GenericServiceAttribute : ServiceAttribute
{
    private static readonly MemoryCache CachedMethods = new(Options.Create(new MemoryCacheOptions()));

    protected abstract void Register<TTarget>(IServiceCollection services) where TTarget : class;

    protected internal override void Register(IServiceCollection services, Type targetType)
    {
        GetMethodInvoker(targetType)!.Invoke(this, services);
    }

    private static MethodInvoker? GetMethodInvoker(Type targetType)
    {
        return CachedMethods.GetOrCreate(targetType, _ =>
        {
            MethodInfo? methodInfo = typeof(GenericServiceAttribute).GetMethod(nameof(Register), BindingFlags.Instance | BindingFlags.NonPublic, [typeof(IServiceCollection)]);
            return methodInfo?.MakeGenericMethod(targetType).ToMethodInvoker();
        });
    }
}