using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Finickyzone.Extensions.DependencyInjection;

public abstract class GenericRegistrableAttribute : RegistrableAttribute
{
    protected abstract void Register<TTarget>(IServiceCollection services) where TTarget : class;

    protected internal override void Register(IServiceCollection services, Type targetType)
    {
        MethodInfo methodInfo = GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic).First(m => m is { Name: nameof(Register), IsGenericMethod: true });
        methodInfo.MakeGenericMethod(targetType).Invoke(this, new object[] { services });
    }
}