using Finickyzone.Extensions.DependencyInjection;

namespace Finickyzone.Extensions.Options;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public abstract class OptionsAttribute : GenericRegistrableAttribute
{
    public string? Name { get; set; }
}