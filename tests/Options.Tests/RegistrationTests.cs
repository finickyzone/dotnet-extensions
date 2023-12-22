using Finickyzone.Extensions.DependencyInjection;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Diagnostics.CodeAnalysis;

namespace Finickyzone.Extensions.Options;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class ServicesExtensionsTests
{
    [Fact]
    public void AddOptionsFromAssembly_WithCurrentAssembly_ShouldReturnExpected()
    {
        // Arrange
        IServiceCollection expected = new ServiceCollection().AddOptions();

        // BindConfiguration
        expected.AddOptions<Options_WithBindConfiguration>().BindConfiguration("");
        expected.AddOptions<Options_WithBindConfiguration_WithName>(Options_WithBindConfiguration_WithName.Name).BindConfiguration("");
        expected.AddOptions<Options_WithBindConfiguration_WithSection>().BindConfiguration(Options_WithBindConfiguration_WithSection.Section);
        expected.AddOptions<Options_WithBindConfiguration_WithSection_WithName>(Options_WithBindConfiguration_WithSection_WithName.Name).BindConfiguration(Options_WithBindConfiguration_WithSection_WithName.Section);

        // Configure
        expected.AddSingleton<IConfigureOptions<Options_WithConfigureOptions>, Configure_Options>();
        expected.Add(new ServiceDescriptor(typeof(IConfigureOptions<>), typeof(Configure_Options_WithOpenGeneric<>), ServiceLifetime.Singleton));
        expected.AddSingleton<IConfigureOptions<Options_WithConfigureOptions>, Configure_Options_WithOptionsType<Options_WithConfigureOptions>>();

        // PostConfigure
        expected.AddSingleton<IPostConfigureOptions<Options_WithPostConfigureOptions>, PostConfigure_Options>();
        expected.Add(new ServiceDescriptor(typeof(IPostConfigureOptions<>), typeof(PostConfigure_Options_WithOpenGeneric<>), ServiceLifetime.Singleton));
        expected.AddSingleton<IPostConfigureOptions<Options_WithPostConfigureOptions>, PostConfigure_Options_WithOptionsType<Options_WithPostConfigureOptions>>();

        // ValidateDataAnnotation
        expected.AddOptions<Options_WithValidateDataAnnotation>().ValidateDataAnnotations();
        expected.AddOptions<Options_WithValidateDataAnnotation_WithName>(Options_WithValidateDataAnnotation_WithName.Name).ValidateDataAnnotations();

        // ValidateOnStart
        expected.AddOptions<Options_WithValidateOnStart>().ValidateOnStart();
        expected.AddOptions<Options_WithValidateOnStart_WithName>(Options_WithValidateOnStart_WithName.Name).ValidateOnStart();

        // Mixed
        expected.AddOptions<Options_WithValidateOnStart_WithValidateDataAnnotation>().ValidateOnStart().ValidateDataAnnotations();
        expected.AddOptions<Options_WithValidateOnStart_WithValidateDataAnnotation_WithName>(Options_WithValidateOnStart_WithValidateDataAnnotation_WithName.Name).ValidateOnStart().ValidateDataAnnotations();

        // Validate
        expected.AddSingleton<IValidateOptions<Options_WithValidateOptions>, Validate_Options>();
        expected.Add(new ServiceDescriptor(typeof(IValidateOptions<>), typeof(Validate_Options_WithOpenGeneric<>), ServiceLifetime.Singleton));
        expected.AddSingleton<IValidateOptions<Options_WithValidateOptions>, Validate_Options_WithOptionsType<Options_WithValidateOptions>>();

        // Act
        IServiceCollection actual = new ServiceCollection().AddServicesFromAssemblyOf<ServicesExtensionsTests>();

        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public async Task Options_WithValidateOnStart_WithInvalidOptions_ShouldThrowException()
    {
        // Arrange
        await using ServiceProvider provider = new ServiceCollection()
            .AddServicesFromAssemblyOf<ServicesExtensionsTests>()
            .BuildServiceProvider();

        var startupValidator = provider.GetRequiredService<IStartupValidator>();

        // Act
        Exception? exception = Record.Exception(() => startupValidator.Validate());

        // Assert
        exception.Should().NotBeNull();
    }

    [Fact]
    public async Task Options_WithValidateOnStart_WithValidOptions_ShouldThrowException()
    {
        // Arrange
        IServiceCollection services = new ServiceCollection()
            .AddServicesFromAssemblyOf<ServicesExtensionsTests>()
            .Configure<Options_WithValidateOnStart_WithValidateDataAnnotation>(options => options.Value = "value")
            .Configure<Options_WithValidateOnStart_WithValidateDataAnnotation_WithName>(Options_WithValidateOnStart_WithValidateDataAnnotation_WithName.Name, options => options.Value = "value");

        await using ServiceProvider provider = services.BuildServiceProvider();

        var startupValidator = provider.GetRequiredService<IStartupValidator>();

        // Act
        Exception? exception = Record.Exception(() => startupValidator.Validate());

        // Assert
        exception.Should().BeNull();
    }
}