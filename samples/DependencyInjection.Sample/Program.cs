using Finickyzone.Extensions.DependencyInjection;
using Finickyzone.Extensions.Samples.Services;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddServicesFromAssemblyOf<Program>();

IHost host = builder.Build();

using IServiceScope scope = host.Services.CreateScope();

ILogger<Program> logger = scope.ServiceProvider.GetRequiredService<ILoggerFactory>().CreateLogger<Program>();

var singletonService = scope.ServiceProvider.GetRequiredService<SingletonService>();
logger.LogInformation("Singleton Service: {Name}", singletonService.Name);

var transientService = scope.ServiceProvider.GetRequiredService<TransientService>();
logger.LogInformation("Transient Service: {Name}", transientService.Name);

var scopedService = scope.ServiceProvider.GetRequiredService<ScopedService>();
logger.LogInformation("Scoped Service: {Name}", scopedService.Name);

IEnumerable<IService> services = scope.ServiceProvider.GetServices<IService>();
logger.LogInformation("{ServiceType} implementations: {Names}", nameof(IService), string.Join(", ", services.Select(service => service.Name)));