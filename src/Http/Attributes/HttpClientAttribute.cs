using Finickyzone.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Http;

/// <summary>
/// Adds the IHttpClientFactory and related services to the DI Container and configures a binding between the Attribute's target and a named HttpClient.
/// If no name is specified, the client name will be set to the type name of Attribute's target.
/// </summary>
/// <param name="name">The logical name of the HttpClient to configure.</param>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class HttpClientAttribute(string? name = null) : GenericServiceAttribute
{
    /// <summary>
    /// The logical name of the HttpClient to configure.
    /// Leave empty to use the Attribute's Target type name instead.
    /// </summary>
    public string? Name { get; set; } = name;

    /// <summary>
    /// The name of the configuration section to bind from.
    /// </summary>
    public string? ConfigSection { get; set; }

    protected override void Register<TTarget>(IServiceCollection services)
    {
        services.AddHttpClientInternal<TTarget>(Name).BindHttpClientConfiguration(ConfigSection);
    }
}