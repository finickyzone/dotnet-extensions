# Finickyzone.Extensions.DependencyInjection.Attributes

Service registration extensions
for [Microsoft.Extensions.DependencyInjection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection).
This package enables you to register your service by simply using Attributes.

## Installation

Install the [Nuget Package](https://www.nuget.org/packages/Finickyzone.Extensions.DependencyInjection.Attributes).

### dotnet cli
```bash
dotnet add package Finickyzone.Extensions.DependencyInjection.Attributes
```

## Usage

```c#
var services = new ServiceCollection();
services.AddServicesFromAssembly(typeof(Program).Assembly);

using ServiceProvider provider = services.BuildServiceProvider();

IMessageWriter messageWriter = provider.GetRequiredService<IMessageWriter>()!;
messageWriter.Write("Hello");

public interface IMessageWriter
{
    void Write(string message);
}

[Singleton(typeof(IMessageWriter))]
internal class MessageWriter : IMessageWriter
{
    public void Write(string message)
    {
        Console.WriteLine($"MessageWriter.Write(message: \"{message}\")");
    }
}
```

## Feedback & Support

If you encounter a bug or would like to request a
feature, [submit an issue](https://github.com/finickyzone/dotnet-extensions/issues/new/choose).