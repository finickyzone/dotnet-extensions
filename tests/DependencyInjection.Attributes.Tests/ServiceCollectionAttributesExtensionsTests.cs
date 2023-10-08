using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Finickyzone.Extensions.DependencyInjection;

public class ServiceCollectionAttributesExtensionsTests
{
    [Fact]
    public void AddServicesFromAssembly_WithCurrentAssembly_ShouldReturnExpected()
    {
        // Arrange
        Assembly assembly = typeof(ServiceCollectionAttributesExtensionsTests).Assembly;
        var expected = new ServiceDescriptor[]
        {
            new(typeof(SingletonService), typeof(SingletonService), ServiceLifetime.Singleton),
            new(typeof(IService), typeof(SingletonServiceImplementation), ServiceLifetime.Singleton),
            new(typeof(TransientService), typeof(TransientService), ServiceLifetime.Transient),
            new(typeof(IService), typeof(TransientServiceImplementation), ServiceLifetime.Transient),
            new(typeof(ScopedService), typeof(ScopedService), ServiceLifetime.Scoped),
            new(typeof(IService), typeof(ScopedServiceImplementation), ServiceLifetime.Scoped),
        };

        // Act
        IServiceCollection actual = new ServiceCollection().AddServicesFromAssembly(assembly);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}