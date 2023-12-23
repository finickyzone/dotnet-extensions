using Finickyzone.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Http;

/// <summary>
/// Configures the primary <see cref="HttpMessageHandler"/> from the dependency injection container
/// for a named <see cref="HttpClient"/>.
/// </summary>
/// <param name="name">The logical name of the HttpClient to configure.</param>
/// <typeparam name="THandler">
/// The type of the <see cref="DelegatingHandler"/>. The handler type must be registered as a transient service.
/// </typeparam>
/// <remarks>
/// <para>
/// The <typeparamref name="THandler"/> will be resolved from a scoped service provider that shares
/// the lifetime of the handler being constructed.
/// </para>
/// </remarks>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class PrimaryHttpMessageHandlerAttribute<THandler>(string? name = null) : GenericServiceAttribute
    where THandler : HttpMessageHandler
{
    /// <summary>
    /// The logical name of the HttpClient to configure.
    /// Leave empty to use the Attribute's Target type name instead.
    /// </summary>
    public string? Name { get; set; } = name;

    protected override void Register<TTarget>(IServiceCollection services)
    {
        services.AddHttpClientInternal<TTarget>(Name).ConfigurePrimaryHttpMessageHandler<THandler>();
    }
}