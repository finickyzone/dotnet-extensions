using FluentAssertions;
using FluentAssertions.Equivalency;
using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.DependencyInjection;

public sealed class ServiceDescriptorEquivalency : IEquivalencyStep
{
    private static readonly Type ServiceDescriptorType = typeof(ServiceDescriptor);

    public static ServiceDescriptorEquivalency Instance { get; } = new();

    public EquivalencyResult Handle(Comparands comparands, IEquivalencyValidationContext context, IEquivalencyValidator nestedValidator)
    {
        if (context.CurrentNode.Type == ServiceDescriptorType)
        {
            var subject = comparands.Subject as ServiceDescriptor;
            var expectation = comparands.Expectation as ServiceDescriptor;

            string because = context.Reason.FormattedMessage;
            object[] becauseArguments = context.Reason.Arguments;

            if (expectation is null)
            {
                subject.Should().BeNull(because, becauseArguments);
                return EquivalencyResult.AssertionCompleted;
            }

            subject.Should().NotBeNull();
            subject!.ServiceType.Should().Be(expectation.ServiceType, because, becauseArguments);
            subject.Lifetime.Should().Be(expectation.Lifetime, because, becauseArguments);
            subject.ServiceKey.Should().BeEquivalentTo(expectation.ServiceKey, because, becauseArguments);
            subject.IsKeyedService.Should().Be(expectation.IsKeyedService, because, becauseArguments);

            if (subject.IsKeyedService)
            {
                subject.KeyedImplementationType.Should().Be(expectation.KeyedImplementationType, because, becauseArguments);
                subject.KeyedImplementationInstance.Should().BeEquivalentTo(expectation.KeyedImplementationInstance, because, becauseArguments);
                subject.KeyedImplementationFactory?.ToString().Should().Be(expectation.KeyedImplementationFactory?.ToString(), because, becauseArguments);
            }
            else
            {
                subject.ImplementationType.Should().Be(expectation.ImplementationType, because, becauseArguments);
                subject.ImplementationInstance.Should().BeEquivalentTo(expectation.ImplementationInstance, because, becauseArguments);
                subject.ImplementationFactory?.ToString().Should().Be(expectation.ImplementationFactory?.ToString(), because, becauseArguments);
            }

            return EquivalencyResult.AssertionCompleted;
        }
        return EquivalencyResult.ContinueWithNext;
    }
}