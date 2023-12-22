using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Finickyzone.Extensions.DependencyInjection;

/// <summary>
/// Base <see cref="Attribute"/> to mark the inherited class as being registrable in the DI Container.
/// </summary>
public abstract class GenericServiceAttribute : ServiceAttribute
{
    protected abstract void Register<TTarget>(IServiceCollection services) where TTarget : class;

    protected internal override void Register(IServiceCollection services, Type targetType)
    {
        MethodInfo methodInfo = typeof(GenericServiceAttribute).GetMethods(BindingFlags.Instance | BindingFlags.NonPublic).Single(m => m is { Name: nameof(Register), IsGenericMethod: true });
        methodInfo.MakeGenericMethod(targetType).Invoke(this, [services]);
    }
}