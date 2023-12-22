using Finickyzone.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Options;

/// <summary>
/// Enforces options validation check on start rather than in runtime.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public sealed class ValidateOnStartAttribute : GenericServiceAttribute
{
    /// <summary>
    /// The name of the options instance
    /// </summary>
    public string? Name { get; set; }

    protected override void Register<TTarget>(IServiceCollection services)
    {
        services.AddOptions<TTarget>(Name).ValidateOnStart();
    }
}