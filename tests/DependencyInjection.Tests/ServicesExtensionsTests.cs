using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.DependencyInjection;

public class ServicesExtensionsTests
{
    [Fact]
    public void AddServicesFromAssembly_WithCurrentAssembly_ShouldReturnExpected()
    {
        // Arrange
        var expected = new ServiceDescriptor[]
        {
            new(typeof(SingletonService), typeof(SingletonService), ServiceLifetime.Singleton),
            new(typeof(IService), typeof(SingletonServiceImplementation), ServiceLifetime.Singleton),
            new(typeof(TransientService), typeof(TransientService), ServiceLifetime.Transient),
            new(typeof(IService), typeof(TransientServiceImplementation), ServiceLifetime.Transient),
            new(typeof(ScopedService), typeof(ScopedService), ServiceLifetime.Scoped),
            new(typeof(IService), typeof(ScopedServiceImplementation), ServiceLifetime.Scoped)
        };

        // Act
        IServiceCollection actual = new ServiceCollection().AddServicesFromAssemblyOf<ServicesExtensionsTests>();

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}