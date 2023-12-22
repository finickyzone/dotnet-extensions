using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Options;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public sealed class ValidateDataAnnotationAttribute : OptionsAttribute
{
    protected override void Register<TTarget>(IServiceCollection services)
    {
        services.AddOptions<TTarget>(Name).ValidateDataAnnotations();
    }
}