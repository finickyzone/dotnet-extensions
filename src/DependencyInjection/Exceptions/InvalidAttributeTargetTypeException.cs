using System.Diagnostics.CodeAnalysis;

namespace Finickyzone.Extensions.DependencyInjection;

public sealed class InvalidAttributeTargetTypeException : InvalidOperationException
{
    public InvalidAttributeTargetTypeException(Type targetType, Type expectedType)
        : base($"Attribute has an invalid target of type '{targetType}'. Expected Type to inherits from '{expectedType}'.")
    {
        TargetType = targetType;
        ExpectedType = expectedType;
    }

    public Type TargetType { get; }

    public Type ExpectedType { get; }

    public static void ThrowIfNotAssignableTo([NotNull] Type? actualType, [NotNull] Type? expectedType)
    {
        ArgumentNullException.ThrowIfNull(actualType);
        ArgumentNullException.ThrowIfNull(expectedType);

        if (!actualType.InheritsFrom(expectedType))
        {
            throw new InvalidAttributeTargetTypeException(actualType, expectedType);
        }
    }
}