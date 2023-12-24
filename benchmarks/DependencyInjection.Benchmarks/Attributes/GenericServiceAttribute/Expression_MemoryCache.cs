using Finickyzone.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;

namespace Finickyzone.Extensions.Benchmarks.GenericServiceAttribute;

public class Expression_MemoryCache : ServiceAttribute
{
    private static readonly IMemoryCache CachedMethods = new MemoryCache(Options.Create(new MemoryCacheOptions()));

    public void Register<TTarget>(IServiceCollection services) where TTarget : class
    {
        services.AddSingleton<Service>();
    }

    protected internal override void Register(IServiceCollection services, Type targetType)
    {
        CachedMethods.GetOrCreate(targetType, CreateDelegate)!.DynamicInvoke(this, services);
    }

    private static Delegate CreateDelegate(ICacheEntry cacheEntry)
    {
        return CreateDelegate((Type)cacheEntry.Key);
    }
    private static Delegate CreateDelegate(Type targetType)
    {
        ParameterExpression instanceParameter = Expression.Parameter(typeof(Expression_MemoryCache));
        ParameterExpression servicesParameter = Expression.Parameter(typeof(IServiceCollection));
        MethodCallExpression callExpression = Expression.Call(instanceParameter, nameof(Register), [targetType], servicesParameter);
        LambdaExpression lambdaExpression = Expression.Lambda(callExpression, instanceParameter, servicesParameter);
        return lambdaExpression.Compile();
    }
}