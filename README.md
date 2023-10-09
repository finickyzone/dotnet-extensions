# Finickyzone.Extensions

Provides a set of extensions that gives more features or capabilities on top of the dotnet libraries.

## Prerequisites

You will need the following tools:

- [.Net 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/)
  or [Rider](https://www.jetbrains.com/rider/)

## Packages

- [Finickyzone.Extensions.DependencyInjection.Attributes](src/DependencyInjection.Attributes)

## Samples

- [Finickyzone.Extensions.DependencyInjection.Attributes](samples/DependencyInjection.Attributes.Sample)

## How to Debug locally

Clone the repo

```bash
git clone https://github.com/finickyzone/dotnet-extensions.git -n finickyzone-dotnet-extensions
```

Restore the projects

```bash
dotnet restore
```

Run the unit tests

```bash
dotnet test
```

## How versioning work

- **Major** increment are reserved to .net SDK version and breaking changes (e.g .net 6 == version 6.x.x).
- **Minor** increment are reserved for breaking changes.
- **Patch** increment are for fixes, non-breaking enhancements and other changes.

## Feedback & Support

If you encounter a bug or would like to request a
feature, [submit an issue](https://github.com/finickyzone/dotnet-extensions/issues/new/choose).