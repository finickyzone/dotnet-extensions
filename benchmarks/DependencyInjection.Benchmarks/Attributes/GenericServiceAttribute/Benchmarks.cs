using Finickyzone.Extensions.DependencyInjection;
using Finickyzone.Extensions.DependencyInjection.Internals;
using Microsoft.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Benchmarks.GenericServiceAttribute;

[MemoryDiagnoser]
public class Benchmarks
{
    /// <remarks>
    /// | Mean      | Error    | StdDev   | Gen0   | Allocated |
    /// |----------:|---------:|---------:|-------:|----------:|
    /// |  47.51 ns | 0.741 ns | 0.693 ns | 0.0258 |     216 B |
    /// </remarks>
    [Benchmark]
    public void Register_Baseline()
    {
        var services = new ServiceCollection();
        var service = RegistrableService.Create<Service, SingletonAttribute<Service>>();

        service.Register(services);
    }

    /// <remarks>
    /// | Mean      | Error    | StdDev   | Gen0   | Allocated |
    /// |----------:|---------:|---------:|-------:|----------:|
    /// | 459.95 ns | 1.993 ns | 1.864 ns | 0.0639 |     536 B |
    /// </remarks>
    [Benchmark]
    public void Register_Reflection_Inline()
    {
        var services = new ServiceCollection();
        var service = RegistrableService.Create<Service, Reflection_Inline>();

        service.Register(services);
    }

    /// <remarks>
    /// | Mean      | Error    | StdDev   | Gen0   | Allocated |
    /// |----------:|---------:|---------:|-------:|----------:|
    /// | 615.75 ns | 2.015 ns | 1.787 ns | 0.0858 |     720 B |
    /// </remarks>
    [Benchmark]
    public void Register_Reflection_Inline_MethodInvoker()
    {
        var services = new ServiceCollection();
        var service = RegistrableService.Create<Service, Reflection_Inline_MethodInvoker>();

        service.Register(services);
    }

    /// <remarks>
    /// | Mean      | Error    | StdDev   | Gen0   | Allocated |
    /// |----------:|---------:|---------:|-------:|----------:|
    /// | 338.02 ns | 0.533 ns | 0.445 ns | 0.0525 |     440 B |
    /// </remarks>
    [Benchmark]
    public void Register_Reflection_StaticCache()
    {
        var services = new ServiceCollection();
        var service = RegistrableService.Create<Service, Reflection_StaticCached>();

        service.Register(services);
    }

    /// <remarks>
    /// | Mean      | Error    | StdDev   | Gen0   | Allocated |
    /// |----------:|---------:|---------:|-------:|----------:|
    /// | 125.35 ns | 0.871 ns | 0.815 ns | 0.0391 |     328 B |
    /// </remarks>
    [Benchmark]
    public void Register_Reflection_MemoryCache()
    {
        var services = new ServiceCollection();
        var service = RegistrableService.Create<Service, Reflection_MemoryCache>();

        service.Register(services);
    }

    /// <remarks>
    /// | Mean      | Error    | StdDev   | Gen0   | Allocated |
    /// |----------:|---------:|---------:|-------:|----------:|
    /// | 236.01 ns | 1.500 ns | 1.403 ns | 0.0525 |     440 B |
    /// </remarks>
    [Benchmark]
    public void Register_Reflection_MemoryCache_Utilities()
    {
        var services = new ServiceCollection();
        var service = RegistrableService.Create<Service, Reflection_MemoryCache_Utilities>();

        service.Register(services);
    }

    /// <remarks>
    /// | Mean      | Error    | StdDev   | Gen0   | Allocated |
    /// |----------:|---------:|---------:|-------:|----------:|
    /// | 104.64 ns | 0.349 ns | 0.291 ns | 0.0353 |     296 B |
    /// </remarks>
    [Benchmark]
    public void Register_Reflection_MemoryCache_MethodInvoker()
    {
        var services = new ServiceCollection();
        var service = RegistrableService.Create<Service, Reflection_MemoryCache_MethodInvoker>();

        service.Register(services);
    }
    
    /// <remarks>
    /// | Mean      | Error    | StdDev   | Gen0   | Allocated |
    /// |----------:|---------:|---------:|-------:|----------:|
    /// | 220.87 ns | 1.290 ns | 1.143 ns | 0.0486 |     408 B |
    /// </remarks>
    [Benchmark]
    public void Register_Reflection_MemoryCache_Utilities_MethodInvoker()
    {
        var services = new ServiceCollection();
        var service = RegistrableService.Create<Service, Reflection_MemoryCache_Utilities_MethodInvoker>();

        service.Register(services);
    }

    /// <remarks>
    /// | Mean         | Error       | StdDev      | Gen0   | Gen1   | Allocated |
    /// |-------------:|------------:|------------:|-------:|-------:|----------:|
    /// | 198,746.1 ns | 1,301.87 ns | 1,217.77 ns | 0.4883 | 0.2441 |    5914 B |
    /// </remarks>
    // [Benchmark] // Too Slow
    public void Register_Expression_Inline()
    {
        var services = new ServiceCollection();
        var service = RegistrableService.Create<Service, Expression_Inline>();

        service.Register(services);
    }

    /// <remarks>
    /// | Mean      | Error    | StdDev   | Gen0   | Allocated |
    /// |----------:|---------:|---------:|-------:|----------:|
    /// | 246.29 ns | 0.960 ns | 0.851 ns | 0.0296 |     248 B |
    /// </remarks>
    [Benchmark]
    public void Register_Expression_MemoryCache()
    {
        var services = new ServiceCollection();
        var service = RegistrableService.Create<Service, Expression_MemoryCache>();

        service.Register(services);
    }
}