using Finickyzone.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Finickyzone.Extensions.Benchmarks.GenericServiceAttribute;

public class Reflection_Inline : ServiceAttribute
{
    private static readonly Type Type = typeof(Reflection_Inline);
    private static readonly Type[] ParameterTypes = [typeof(IServiceCollection)];

    protected void Register<TTarget>(IServiceCollection services) where TTarget : class
    {
        services.AddSingleton<Service>();
    }

    protected internal override void Register(IServiceCollection services, Type targetType)
    {
        Type.GetGenericMethod(nameof(Register), BindingFlags.Instance | BindingFlags.NonPublic, [targetType], ParameterTypes)!.Invoke(this, [services]);
    }
}