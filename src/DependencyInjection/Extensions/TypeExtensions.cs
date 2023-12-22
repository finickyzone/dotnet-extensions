namespace Finickyzone.Extensions.DependencyInjection;

internal static class TypeExtensions
{
    public static bool InheritsFrom(this Type type, Type parent)
    {
        if (type.IsAssignableTo(parent))
        {
            return true;
        }
        return Array.Exists(type.GetInterfaces(), typeInterface => typeInterface.GetGenericTypeDefinition() == parent);
    }
}