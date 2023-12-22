using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Options;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public sealed class BindConfigurationAttribute : OptionsAttribute
{
    public string Section { get; set; } = "";

    protected override void Register<TTarget>(IServiceCollection services)
    {
        services.AddOptions<TTarget>(Name).BindConfiguration(Section);
    }
}