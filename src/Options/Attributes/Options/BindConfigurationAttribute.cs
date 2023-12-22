using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Options;

/// <summary>
/// Registers the dependency injection container to bind the target Options against the IConfiguration obtained from the DI service provider.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public sealed class BindConfigurationAttribute : OptionsAttribute
{
    /// <summary>
    /// The name of the configuration section to bind from.
    /// </summary>
    public string Section { get; set; } = "";

    protected override void Register<TTarget>(IServiceCollection services)
    {
        services.AddOptions<TTarget>(Name).BindConfiguration(Section);
    }
}