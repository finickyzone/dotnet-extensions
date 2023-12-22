using Finickyzone.Extensions.DependencyInjection;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Finickyzone.Extensions.Options;

public sealed class ValidateOptionsAttributeTests
{
    [Theory]
    [InlineData(typeof(Validate_Options), typeof(UnrelatedOptions), typeof(InvalidAttributeTargetTypeException))]
    [InlineData(typeof(Validate_Options_WithOptionsType<>), typeof(int), typeof(ArgumentException))]
    public void Register_WithInvalidOptionsType_ShouldThrowException(Type targetType, Type optionsType, Type exceptionType)
    {
        // Arrange
        var services = new ServiceCollection();
        var sut = new ValidateOptionsAttribute(optionsType);

        // Act
        Exception? exception = Record.Exception(() => sut.Register(services, targetType));

        // Assert
        exception.Should().BeOfType(exceptionType);
    }
    
    [Theory]
    [InlineData(typeof(Validate_Options), null, typeof(IValidateOptions<Options_WithValidateOptions>), typeof(Validate_Options))]
    [InlineData(typeof(Validate_Options_WithOpenGeneric<>), null, typeof(IValidateOptions<>), typeof(Validate_Options_WithOpenGeneric<>))]
    [InlineData(typeof(Validate_Options_WithOptionsType<>), typeof(Options_WithValidateOptions), typeof(IValidateOptions<Options_WithValidateOptions>), typeof(Validate_Options_WithOptionsType<Options_WithValidateOptions>))]
    public void Register_ShouldReturnExpected(Type targetType, Type? optionsType, Type expectedServiceType, Type expectedTargetType)
    {
        // Arrange
        var expected = new ServiceCollection
        {
            new ServiceDescriptor(expectedServiceType, expectedTargetType, ServiceLifetime.Singleton)
        };
        var actual = new ServiceCollection();
        var sut = new ValidateOptionsAttribute(optionsType);

        // Act
        sut.Register(actual, targetType);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    private record UnrelatedOptions;
}