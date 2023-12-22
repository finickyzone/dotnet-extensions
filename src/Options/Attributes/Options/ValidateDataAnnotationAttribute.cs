using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Options;

/// <summary>
/// Register this options instance for validation of its DataAnnotations.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public sealed class ValidateDataAnnotationAttribute : OptionsAttribute
{
    protected override void Register<TTarget>(IServiceCollection services)
    {
        services.AddOptions<TTarget>(Name).ValidateDataAnnotations();
    }
}