using Finickyzone.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Samples;

[Decorate<IService>]
public sealed class DecorateService(IService service, ILoggerFactory loggerFactory) : IService
{
    private readonly ILogger _logger = loggerFactory.CreateLogger(service.GetType());

    public string Name
    {
        get
        {
            _logger.LogInformation("'{Property}' invoked", nameof(Name));
            return service.Name;
        }
    }
}