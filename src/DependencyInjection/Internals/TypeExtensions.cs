using System.Reflection;

namespace Finickyzone.Extensions.DependencyInjection.Internals;

internal static class TypeExtensions
{
    internal static bool InheritsFrom(this Type type, Type parent)
    {
        if (type.IsAssignableTo(parent))
        {
            return true;
        }
        return Array.Exists(type.GetInterfaces(), typeInterface => typeInterface.GetGenericTypeDefinition() == parent);
    }

    internal static MethodInvoker? ToMethodInvoker(this MethodInfo? methodInfo)
    {
        return methodInfo is null ? null : MethodInvoker.Create(methodInfo);
    }
}