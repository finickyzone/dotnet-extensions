using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Http;

public static class HttpClientBuilderExtensions
{
    /// <summary>
    /// Registers the dependency injection container to bind the <see cref="HttpClient"/> against
    /// the <see cref="IConfiguration"/> obtained from the DI service provider.
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="configSectionPath">The name of the configuration section to bind from.</param>
    /// <param name="configureBinder">Optional. Used to configure the <see cref="BinderOptions"/>.</param>
    /// <returns>The <see cref="IHttpClientBuilder"/> so that additional calls can be chained.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="builder"/> is <see langword="null"/>.
    /// </exception>
    public static IHttpClientBuilder BindHttpClientConfiguration(this IHttpClientBuilder builder, string? configSectionPath, Action<BinderOptions>? configureBinder = null)
    {
        ArgumentNullException.ThrowIfNull(builder);
        if (configSectionPath is null)
        {
            return builder;
        }
        return builder.ConfigureHttpClient((provider, client) =>
        {
            var configuration = provider.GetService<IConfiguration>();
            IConfiguration? section = string.IsNullOrEmpty(configSectionPath) ? configuration : configuration?.GetSection(configSectionPath);
            section?.Bind(client, configureBinder);
        });
    }

    internal static IHttpClientBuilder AddHttpClientInternal<TClient>(this IServiceCollection services, string? name) where TClient : class
    {
        return name is not null ? services.AddTransient<TClient>().AddHttpClient(name) : services.AddHttpClient<TClient>();
    }
}