using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace Finickyzone.Extensions.DependencyInjection;

public class ServiceCollectionExtensionsTests
{
    [Fact]
    public void AddServicesFromAssembly_WithCurrentAssembly_ShouldReturnExpected()
    {
        // Arrange
        ServiceDescriptor[] expected =
        [
            // Keyed Open Generic
            new ServiceDescriptor(typeof(KeyedOpenGenericService<>), KeyedOpenGenericService<object>.Key, typeof(KeyedOpenGenericService<>), ServiceLifetime.Singleton),
            new ServiceDescriptor(typeof(IGenericService<>), KeyedOpenGenericServiceImplementation<object>.Key, typeof(KeyedOpenGenericServiceImplementation<>), ServiceLifetime.Singleton),

            // Keyed Scoped
            new ServiceDescriptor(typeof(KeyedScopedService), KeyedScopedService.Key, typeof(KeyedScopedService), ServiceLifetime.Scoped),
            new ServiceDescriptor(typeof(IService), KeyedScopedServiceImplementation.Key, typeof(KeyedScopedServiceImplementation), ServiceLifetime.Scoped),

            // Keyed Singleton
            new ServiceDescriptor(typeof(KeyedSingletonService), KeyedSingletonService.Key, typeof(KeyedSingletonService), ServiceLifetime.Singleton),
            new ServiceDescriptor(typeof(IService), KeyedSingletonServiceImplementation.Key, typeof(KeyedSingletonServiceImplementation), ServiceLifetime.Singleton),

            // Keyed Transient
            new ServiceDescriptor(typeof(KeyedTransientService), KeyedTransientService.Key, typeof(KeyedTransientService), ServiceLifetime.Transient),
            new ServiceDescriptor(typeof(IService), KeyedTransientServiceImplementation.Key, typeof(KeyedTransientServiceImplementation), ServiceLifetime.Transient),

            // Open Generic
            new ServiceDescriptor(typeof(OpenGenericService<>), typeof(OpenGenericService<>), ServiceLifetime.Singleton),
            new ServiceDescriptor(typeof(IGenericService<>), typeof(OpenGenericServiceImplementation<>), ServiceLifetime.Singleton),

            // Scoped
            new ServiceDescriptor(typeof(ScopedService), typeof(ScopedService), ServiceLifetime.Scoped),
            new ServiceDescriptor(typeof(IService), typeof(ScopedServiceImplementation), ServiceLifetime.Scoped),

            // Singleton
            new ServiceDescriptor(typeof(SingletonService), typeof(SingletonService), ServiceLifetime.Singleton),
            new ServiceDescriptor(typeof(IService), typeof(SingletonServiceImplementation), ServiceLifetime.Singleton),

            // Transient
            new ServiceDescriptor(typeof(TransientService), typeof(TransientService), ServiceLifetime.Transient),
            new ServiceDescriptor(typeof(IService), typeof(TransientServiceImplementation), ServiceLifetime.Transient),
        ];

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
        var actual = new ServiceCollection().AddService(serviceType, implementationType, lifetime);


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
        var actual = new ServiceCollection().AddService(serviceType, lifetime);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Add_WithServiceTypeParam()
    {
        // Arrange
        var expected = new ServiceCollection().AddSingleton<SingletonService>();

        // Act
        var actual = new ServiceCollection().AddService<SingletonService>(ServiceLifetime.Singleton);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Add_WithServiceTypeParam_WithImplementationTypeParam()
    {
        // Arrange
        var expected = new ServiceCollection().AddSingleton<IService, SingletonService>();

        // Act
        var actual = new ServiceCollection().AddService<IService, SingletonService>(ServiceLifetime.Singleton);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void AddRange_WithArray()
    {
        // Arrange
        ServiceDescriptor[] descriptors =
        [
            new ServiceDescriptor(typeof(IService), typeof(SingletonService), ServiceLifetime.Singleton),
            new ServiceDescriptor(typeof(IService), typeof(TransientService), ServiceLifetime.Transient),
            new ServiceDescriptor(typeof(IService), typeof(ScopedService), ServiceLifetime.Scoped)
        ];

        var expected = new ServiceCollection();
        foreach (ServiceDescriptor descriptor in descriptors)
        {
            expected.Add(descriptor);
        }

        // Act
        var actual = new ServiceCollection().AddServices(descriptors);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
    public void AddRange_WithEnumerable()
    {
        // Arrange
        IEnumerable<ServiceDescriptor> descriptors =
        [
            new ServiceDescriptor(typeof(IService), typeof(SingletonService), ServiceLifetime.Singleton),
            new ServiceDescriptor(typeof(IService), typeof(TransientService), ServiceLifetime.Transient),
            new ServiceDescriptor(typeof(IService), typeof(ScopedService), ServiceLifetime.Scoped)
        ];

        var expected = new ServiceCollection();
        foreach (ServiceDescriptor descriptor in descriptors)
        {
            expected.Add(descriptor);
        }

        // Act
        var actual = new ServiceCollection().AddServices(descriptors);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}