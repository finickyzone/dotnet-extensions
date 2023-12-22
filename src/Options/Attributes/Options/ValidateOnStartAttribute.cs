using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Options;

/// <summary>
/// Enforces options validation check on start rather than in runtime.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public sealed class ValidateOnStartAttribute : OptionsAttribute
{
    protected override void Register<TTarget>(IServiceCollection services)
    {
        services.AddOptions<TTarget>(Name).ValidateOnStart();
    }
}