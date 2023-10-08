using Finickyzone.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

using ServiceProvider serviceProvider = new ServiceCollection().AddServicesFromAssembly<Program>().BuildServiceProvider();
using IServiceScope scope = serviceProvider.CreateScope();

Console.WriteLine("Singleton Service: {0}", serviceProvider.GetRequiredService<SingletonService>().Name);
Console.WriteLine("Transient Service: {0}", serviceProvider.GetRequiredService<TransientService>().Name);
Console.WriteLine("Scoped Service: {0}", serviceProvider.GetRequiredService<ScopedService>().Name);
Console.WriteLine("{0} implementations: {1}", nameof(IService), string.Join(", ", serviceProvider.GetServices<IService>().Select(service => service.Name)));