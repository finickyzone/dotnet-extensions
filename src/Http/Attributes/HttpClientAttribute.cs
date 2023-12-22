using Finickyzone.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Http;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class HttpClientAttribute : GenericServiceAttribute
{
    public HttpClientAttribute(string? name = null)
    {
        Name = name;
    }

    /// <summary>
    /// The logical name of the HttpClient to configure.
    /// Leave empty to used the Attribute's Target type instead.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// The name of the configuration section to bind from.
    /// </summary>
    public string? ConfigSection { get; set; }

    protected override void Register<TTarget>(IServiceCollection services)
    {
        services.AddHttpClientInternal<TTarget>(Name).BindHttpClientConfiguration(ConfigSection);
    }
}