using FluentAssertions;
using FluentAssertions.Equivalency;
using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Options;

public sealed class ImplementationFactoryComparer : IEquivalencyStep
{
    private static readonly Type FactoryType = typeof(Func<IServiceProvider, object>);

    public static ImplementationFactoryComparer Instance { get; } = new();

    public EquivalencyResult Handle(Comparands comparands, IEquivalencyValidationContext context, IEquivalencyValidator nestedValidator)
    {
        if (context.CurrentNode.Name == nameof(ServiceDescriptor.ImplementationFactory) && context.CurrentNode.Type == FactoryType)
        {
            comparands.Subject?.ToString().Should().Be(comparands.Expectation?.ToString());

            return EquivalencyResult.AssertionCompleted;
        }
        return EquivalencyResult.ContinueWithNext;
    }
}