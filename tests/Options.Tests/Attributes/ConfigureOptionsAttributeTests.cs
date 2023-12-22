using Finickyzone.Extensions.DependencyInjection;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Finickyzone.Extensions.Options;

public sealed class ConfigureOptionsAttributeTests
{
    [Theory]
    [InlineData(typeof(Configure_Options), typeof(UnrelatedOptions), typeof(InvalidAttributeTargetTypeException))]
    [InlineData(typeof(Configure_Options_WithOptionsType<>), typeof(int), typeof(ArgumentException))]
    public void Register_WithInvalidOptionsType_ShouldThrowException(Type targetType, Type optionsType, Type exceptionType)
    {
        // Arrange
        var services = new ServiceCollection();
        var sut = new ConfigureOptionsAttribute(optionsType);

        // Act
        Exception? exception = Record.Exception(() => sut.Register(services, targetType));

        // Assert
        exception.Should().BeOfType(exceptionType);
    }

    [Theory]
    [InlineData(typeof(Configure_Options), null, typeof(IConfigureOptions<Options_WithConfigureOptions>), typeof(Configure_Options))]
    [InlineData(typeof(Configure_Options_WithOpenGeneric<>), null, typeof(IConfigureOptions<>), typeof(Configure_Options_WithOpenGeneric<>))]
    [InlineData(typeof(Configure_Options_WithOptionsType<>), typeof(Options_WithConfigureOptions), typeof(IConfigureOptions<Options_WithConfigureOptions>), typeof(Configure_Options_WithOptionsType<Options_WithConfigureOptions>))]
    public void Register_ShouldReturnExpected(Type targetType, Type? optionsType, Type expectedServiceType, Type expectedTargetType)
    {
        // Arrange
        var expected = new ServiceCollection
        {
            new ServiceDescriptor(expectedServiceType, expectedTargetType, ServiceLifetime.Singleton)
        };
        var actual = new ServiceCollection();
        var sut = new ConfigureOptionsAttribute(optionsType);

        // Act
        sut.Register(actual, targetType);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    private record UnrelatedOptions;
}