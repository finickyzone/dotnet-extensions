using Finickyzone.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;

namespace Finickyzone.Extensions.Benchmarks.GenericServiceAttribute;

public class Expression_Inline : ServiceAttribute
{
    public void Register<TTarget>(IServiceCollection services) where TTarget : class
    {
        services.AddSingleton<Service>();
    }

    protected internal override void Register(IServiceCollection services, Type targetType)
    {
        CreateDelegate(targetType).DynamicInvoke(this, services);
    }
    
    private static Delegate CreateDelegate(Type targetType)
    {
        ParameterExpression instanceParameter = Expression.Parameter(typeof(Expression_Inline));
        ParameterExpression servicesParameter = Expression.Parameter(typeof(IServiceCollection));
        MethodCallExpression callExpression = Expression.Call(instanceParameter, nameof(Register), [targetType], servicesParameter);
        LambdaExpression lambdaExpression = Expression.Lambda(callExpression, instanceParameter, servicesParameter);
        return lambdaExpression.Compile();
    }
}