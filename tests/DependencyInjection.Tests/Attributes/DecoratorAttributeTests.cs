using Finickyzone.Extensions.DependencyInjection.Internals;
using FluentAssertions;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace Finickyzone.Extensions.DependencyInjection.Attributes;

public sealed class DecoratorAttributeTests
{
    [Fact]
    public void Decorate_WithInnerService_ShouldReturnExpected()
    {
        // Arrange
        var inner = RegistrableService.Create<ServiceImplementation, SingletonAttribute<IService>>();
        var decorator = RegistrableService.Create<ServiceDecorator, DecorateAttribute<IService>>();
        var expected = new ServiceDecorator(new ServiceImplementation());

        using ServiceProvider provider = new ServiceCollection().AddServices(inner, decorator).BuildServiceProvider();

        // Act
        var actual = provider.GetRequiredService<IService>();

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Build_WithoutInnerService_ShouldThrowException()
    {
        // Arrange
        var decorator = RegistrableService.Create<ServiceDecorator, DecorateAttribute<IService>>();

        void Build() => new ServiceCollection().AddServices(decorator).BuildServiceProvider();

        // Act
        Exception? exception = Record.Exception(Build);

        // Assert
        exception.Should().BeOfType<DecorationException>();
    }

    private sealed class ServiceImplementation : IService;

    private sealed class ServiceDecorator(IService service) : IService
    {
        [UsedImplicitly]
        public IService InnerService => service;
    }
}