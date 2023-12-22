using Finickyzone.Extensions.DependencyInjection;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace Finickyzone.Extensions.Options;

public sealed class PostConfigureOptionsAttributeTests
{
    [Theory]
    [InlineData(typeof(PostConfigure_Options), typeof(UnrelatedOptions), typeof(InvalidAttributeTargetTypeException))]
    [InlineData(typeof(PostConfigure_Options_WithOptionsType<>), typeof(int), typeof(ArgumentException))]
    public void Register_WithInvalidOptionsType_ShouldThrowException(Type targetType, Type optionsType, Type exceptionType)
    {
        // Arrange
        var services = new ServiceCollection();
        var sut = new PostConfigureOptionsAttribute(optionsType);

        // Act
        Exception? exception = Record.Exception(() => sut.Register(services, targetType));

        // Assert
        exception.Should().BeOfType(exceptionType);
    }
    
    [Theory]
    [InlineData(typeof(PostConfigure_Options), null, typeof(IPostConfigureOptions<Options_WithPostConfigureOptions>), typeof(PostConfigure_Options))]
    [InlineData(typeof(PostConfigure_Options_WithOpenGeneric<>), null, typeof(IPostConfigureOptions<>), typeof(PostConfigure_Options_WithOpenGeneric<>))]
    [InlineData(typeof(PostConfigure_Options_WithOptionsType<>), typeof(Options_WithPostConfigureOptions), typeof(IPostConfigureOptions<Options_WithPostConfigureOptions>), typeof(PostConfigure_Options_WithOptionsType<Options_WithPostConfigureOptions>))]
    public void Register_ShouldReturnExpected(Type targetType, Type? optionsType, Type expectedServiceType, Type expectedTargetType)
    {
        // Arrange
        var expected = new ServiceCollection
        {
            new ServiceDescriptor(expectedServiceType, expectedTargetType, ServiceLifetime.Singleton)
        };
        var actual = new ServiceCollection();
        var sut = new PostConfigureOptionsAttribute(optionsType);

        // Act
        sut.Register(actual, targetType);

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    private record UnrelatedOptions;
}