using Finickyzone.Extensions.DependencyInjection.Internals;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Finickyzone.Extensions.Benchmarks.GenericServiceAttribute;

public static class TypeExtensions
{
    private static readonly IMemoryCache CachedMethods = new MemoryCache(Options.Create(new MemoryCacheOptions()));

    public static MethodInfo? GetCachedGenericMethod(this Type type, string name, BindingFlags bindingFlags, Type[] genericTypeArguments, Type[] parametersType)
    {
        return CachedMethods.GetOrCreate(CreateCacheKey(nameof(GetCachedGenericMethod), type, name, genericTypeArguments, parametersType), _ =>
        {
            return type.GetGenericMethod(name, bindingFlags, genericTypeArguments, parametersType);
        });
    }

    public static MethodInvoker? GetCachedGenericMethodInvoker(this Type type, string name, BindingFlags bindingFlags, Type[] genericTypeArguments, Type[] parametersType)
    {
        return CachedMethods.GetOrCreate(CreateCacheKey(nameof(GetCachedGenericMethodInvoker), type, name, genericTypeArguments, parametersType), _ =>
        {
            return type.GetGenericMethod(name, bindingFlags, genericTypeArguments, parametersType).ToMethodInvoker();
        });
    }

    public static MethodInfo? GetGenericMethod(this Type type, string name, BindingFlags bindingFlags, Type[] genericTypeArguments, Type[] parametersType)
    {
        return type.GetMethod(name, bindingFlags, parametersType)?.MakeGenericMethod(genericTypeArguments);
    }

    public static MethodInvoker? GetGenericMethodInvoker(this Type type, string name, BindingFlags bindingFlags, Type[] genericTypeArguments, Type[] parametersType)
    {
        return GetGenericMethod(type, name, bindingFlags, genericTypeArguments, parametersType).ToMethodInvoker();
    }

    private static object CreateCacheKey(string overloadName, Type type, string name, Type[] genericTypeArguments, Type[] parametersType)
    {
        return (overloadName, type.FullName, name, genericTypeArguments.Length, parametersType.Length);
    }
}