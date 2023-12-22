using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Finickyzone.Extensions.DependencyInjection;

public class ServiceCollectionExtensionsTests
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
        IServiceCollection actual = new ServiceCollection().AddServicesFromAssemblyOf<ServiceCollectionExtensionsTests>();

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData(typeof(SingletonService), typeof(SingletonService), ServiceLifetime.Singleton)]
    [InlineData(typeof(IService), typeof(SingletonService), ServiceLifetime.Singleton)]
    [InlineData(typeof(IService), typeof(ScopedService), ServiceLifetime.Scoped)]
    [InlineData(typeof(IService), typeof(TransientService), ServiceLifetime.Transient)]
    public void Add_WithServiceType_WithImplementationType(Type serviceType, Type implementationType, ServiceLifetime lifetime)
    {
        // Arrange
        var expected = new ServiceCollection().Add(new ServiceDescriptor(serviceType, implementationType, lifetime));

        // Act
        var actual = new ServiceCollection().Add(serviceType, implementationType, lifetime);


        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Theory]
    [InlineData(typeof(SingletonService), ServiceLifetime.Singleton)]
    [InlineData(typeof(ScopedService), ServiceLifetime.Scoped)]
    [InlineData(typeof(TransientService), ServiceLifetime.Transient)]
    public void Add_WithServiceType(Type serviceType, ServiceLifetime lifetime)
    {
        // Arrange
        var expected = new ServiceCollection().Add(new ServiceDescriptor(serviceType, serviceType, lifetime));

        // Act
        var actual = new ServiceCollection().Add(serviceType, lifetime);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Add_WithServiceTypeParam()
    {
        // Arrange
        var expected = new ServiceCollection().AddSingleton<SingletonService>();

        // Act
        var actual = new ServiceCollection().Add<SingletonService>(ServiceLifetime.Singleton);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Add_WithServiceTypeParam_WithImplementationTypeParam()
    {
        // Arrange
        var expected = new ServiceCollection().AddSingleton<IService, SingletonService>();

        // Act
        var actual = new ServiceCollection().Add<IService, SingletonService>(ServiceLifetime.Singleton);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void AddRange_WithArray()
    {
        // Arrange
        var descriptors = new ServiceDescriptor[]
        {
            new(typeof(IService), typeof(SingletonService), ServiceLifetime.Singleton),
            new(typeof(IService), typeof(TransientService), ServiceLifetime.Transient),
            new(typeof(IService), typeof(ScopedService), ServiceLifetime.Scoped)
        };

        var expected = new ServiceCollection();
        foreach (ServiceDescriptor descriptor in descriptors)
        {
            expected.Add(descriptor);
        }

        // Act
        var actual = new ServiceCollection().AddRange(descriptors);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Fact]
    public void AddRange_WithEnumerable()
    {
        // Arrange
        IEnumerable<ServiceDescriptor> descriptors = new ServiceDescriptor[]
        {
            new(typeof(IService), typeof(SingletonService), ServiceLifetime.Singleton),
            new(typeof(IService), typeof(TransientService), ServiceLifetime.Transient),
            new(typeof(IService), typeof(ScopedService), ServiceLifetime.Scoped)
        };

        var expected = new ServiceCollection();
        foreach (ServiceDescriptor descriptor in descriptors)
        {
            expected.Add(descriptor);
        }

        // Act
        var actual = new ServiceCollection().AddRange(descriptors);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}