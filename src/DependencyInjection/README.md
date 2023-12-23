# Finickyzone.Extensions.DependencyInjection

## Description

`Finickyzone.Extensions.DependencyInjection` provides extra functionalities on top
of [Microsoft.Extensions.DependencyInjection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection).
It also offers you to register your services by simply using Attributes.

## Installation

Install the [Nuget Package](https://www.nuget.org/packages/Finickyzone.Extensions.DependencyInjection).

### dotnet cli

```bash
dotnet add package Finickyzone.Extensions.DependencyInjection
```

## How to use

```csharp
using Finickyzone.Extensions.DependencyInjection;

var services = new ServiceCollection();
    
services.AddServiceFromAssemblyOf<Program>(); // Add this line

using ServiceProvider provider = services.BuildServiceProvider();

IMessageWriter messageWriter = provider.GetRequiredService<IMessageWriter>()!;
messageWriter.Write("Hello");

public interface IMessageWriter
{
    void Write(string message);
}

// Create custom implementation and add Attribute to register it in the DI container
[Singleton<IMessageWriter>]
internal class MessageWriter : IMessageWriter
{
    public void Write(string message)
    {
        Console.WriteLine($"MessageWriter.Write(message: \"{message}\")");
    }
}
```

## Main Types

Attributes that can be applied on Services:

- `ScopedAttribute` and `ScopedAttribute<TService>`
- `SingletonAttribute` and `SingletonAttribute<TService>`
- `TransientAttribute` and `TransientAttribute<TService>`
- `KeyedScopedAttribute` and `KeyedScopedAttribute<TService>`
- `KeyedSingletonAttribute` and `KeyedSingletonAttribute<TService>`
- `KeyedTransientAttribute` and `KeyedTransientAttribute<TService>`
- `DecorateAttribute` and `DecorateAttribute<TService>`

Attributes that can be used for extensive capabilities:

- `ServiceAttribute`
- `GenericServiceAttribute`

## Related Packages

- [Finickyzone.Extensions.Options](https://www.nuget.org/packages/Finickyzone.Extensions.Options)
- [Finickyzone.Extensions.Http](https://www.nuget.org/packages/Finickyzone.Extensions.Http)

## Feedback & Support

If you encounter a bug or would like to request a
feature, [submit an issue](https://github.com/finickyzone/dotnet-extensions/issues/new/choose).