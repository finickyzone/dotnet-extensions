using Finickyzone.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

using ServiceProvider serviceProvider = new ServiceCollection()
    .AddServicesFromAssemblyOf<Program>()
    .BuildServiceProvider();

using IServiceScope scope = serviceProvider.CreateScope();

var singletonService = serviceProvider.GetRequiredService<SingletonService>();
Console.WriteLine("Singleton Service: {0}", singletonService.Name);

var transientService = serviceProvider.GetRequiredService<TransientService>();
Console.WriteLine("Transient Service: {0}", transientService.Name);

var scopedService = serviceProvider.GetRequiredService<ScopedService>();
Console.WriteLine("Scoped Service: {0}", scopedService.Name);

IEnumerable<IService> services = serviceProvider.GetServices<IService>();
Console.WriteLine("{0} implementations: {1}", nameof(IService), string.Join(", ", services.Select(service => service.Name)));