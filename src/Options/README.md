# Finickyzone.Extensions.Options

## Description

`Finickyzone.Extensions.Options` provides extra functionalities on top of [Microsoft.Extensions.Options](https://www.nuget.org/packages/Microsoft.Extensions.Options).
It offers to Bind, Configure and Validate Options by simply using Attributes.

## Installation

Install the [Nuget Package](https://www.nuget.org/packages/Finickyzone.Extensions.Options).

### dotnet cli
```bash
dotnet add package Finickyzone.Extensions.Options
```

## How to use

Using BindConfiguration, ValidateDataAnnotation, and ValidateOnStart:

**Programs.cs**
```csharp
using Finickyzone.Extensions.Options;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServiceFromAssemblyOf<Program>(); // Add this line

var app = builder.Build();

app.Map("/", (IOptions<ClientOptions> options) => Results.Ok(options.Value));

app.Run();

// Create custom options with Attributes to register it in the DI container
[ValidateOnStart]
[ValidateDataAnnotation]
[BindConfiguration(Section = "Client")]
public record ClientOptions
{
    [Required]
    public Uri? Address { get; set; }
}
```

**appsettings.json**
```json
{
  "Client:Address": "https://github.com"
}
```

Using ConfigureOptions, PostConfigureOptions, and ValidateOptions:
```csharp
[ConfigureOptions]
public class MyConfigConfiguration : IConfigureOptions<MyConfigOptions>
{
    // ...
}

[PostConfigureOptions]
public class MyPostConfigConfiguration : IPostConfigureOptions<MyConfigOptions>
{
    // ...
}

[ValidateOptions]
public class MyConfigValidation : IValidateOptions<MyConfigOptions>
{
    // ...
}
```

## Main Types
The main types provided by this library are:
- `BindConfigurationAttribute`, `ValidateDataAnnotationAttribute`, and `ValidateOnStartAttribute`
- `ConfigureOptionsAttribute`, `PostConfigureOptionsAttribute`, and `ValidateOptionsAttribute`

## Related Packages
- [Finickyzone.Extensions.DependencyInjection](https://www.nuget.org/packages/Finickyzone.Extensions.DependencyInjection)

## Feedback & Support

If you encounter a bug or would like to request a
feature, [submit an issue](https://github.com/finickyzone/dotnet-extensions/issues/new/choose).