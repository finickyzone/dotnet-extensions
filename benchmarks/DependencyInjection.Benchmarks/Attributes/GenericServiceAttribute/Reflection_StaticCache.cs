using Finickyzone.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Finickyzone.Extensions.Benchmarks.GenericServiceAttribute;

public class Reflection_StaticCached : ServiceAttribute
{
    private static readonly MethodInfo RegisterMethodInfo = typeof(Reflection_StaticCached).GetMethod(nameof(Register), BindingFlags.Instance | BindingFlags.NonPublic, [typeof(IServiceCollection)])!;

    protected void Register<TTarget>(IServiceCollection services) where TTarget : class
    {
        services.AddSingleton<Service>();
    }

    protected internal override void Register(IServiceCollection services, Type targetType)
    {
        RegisterMethodInfo.MakeGenericMethod(targetType).Invoke(this, [services]);
    }
}