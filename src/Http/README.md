# Finickyzone.Extensions.Http

## Description

`Finickyzone.Extensions.Http` provides extra functionalities on top of [Microsoft.Extensions.Http](https://www.nuget.org/packages/Microsoft.Extensions.Http).
It also offers to Bind and Configure HttpClient by simply using attributes.

## Installation

Install the [Nuget Package](https://www.nuget.org/packages/Finickyzone.Extensions.Http).

### dotnet cli

```bash
dotnet add package Finickyzone.Extensions.Http
```

## How to use

**Programs.cs**

```csharp
using Finickyzone.Extensions.DependencyInjection;
using Finickyzone.Extensions.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServicesFromAssemblyOf<Program>(); // Add this line

var app = builder.Build();

app.Map("/", async (CatFactClient client, CancellationToken token) => Results.Ok(await client.GetCatFact(token)));

app.Run();

[HttpClient(ConfigSection = nameof(CatFactClient))]
public sealed class CatFactClient CatFactClient(HttpClient client)
{
    public async Task<string?> GetCatFact(CancellationToken cancellationToken = default)
    {
        var response = await client.GetFromJsonAsync<Response>("fact", cancellationToken);
        return response?.Fact;
    }

    private record Response(string Fact);
}
```

**appsettings.json**

```json
{
  "CatFactClient": {
    "BaseAddress": "https://catfact.ninja"
  }
}
```

## Main Types

Attributes that can be applied to classes using HttpClient:

- `HttpClientAttribute`

## Related Packages

- [Finickyzone.Extensions.DependencyInjection](https://www.nuget.org/packages/Finickyzone.Extensions.DependencyInjection)

## Feedback & Support

If you encounter a bug or would like to request a
feature, [submit an issue](https://github.com/finickyzone/dotnet-extensions/issues/new/choose).