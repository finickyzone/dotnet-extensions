using Finickyzone.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Options;

/// <summary>
/// Registers the dependency injection container to bind the target Options against the IConfiguration obtained from the DI service provider.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public sealed class BindConfigurationAttribute : GenericServiceAttribute
{
    /// <summary>
    /// The name of the options instance
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// The name of the configuration section to bind from.
    /// </summary>
    public string ConfigSection { get; set; } = "";

    protected override void Register<TTarget>(IServiceCollection services)
    {
        services.AddOptions<TTarget>(Name).BindConfiguration(ConfigSection);
    }
}