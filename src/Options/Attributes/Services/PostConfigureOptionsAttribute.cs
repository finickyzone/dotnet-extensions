using Microsoft.Extensions.Options;

namespace Finickyzone.Extensions.Options;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class PostConfigureOptionsAttribute : OptionsServiceAttribute
{
    public PostConfigureOptionsAttribute(Type? optionsType = null)
        : base(typeof(IPostConfigureOptions<>), optionsType)
    {
    }
}