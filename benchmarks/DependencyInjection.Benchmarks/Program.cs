#if DEBUG
var benchmark = new Finickyzone.Extensions.Benchmarks.GenericServiceAttribute.Benchmarks();
benchmark.Register_Reflection_MemoryCache_MethodInvoker();
#else
BenchmarkRunner.Run<Finickyzone.Extensions.Benchmarks.GenericServiceAttribute.Benchmark>();
#endif