namespace Finickyzone.Extensions.Options;

[BindConfiguration(Name = Name)]
public record Options_WithBindConfiguration_WithName
{
    public const string Name = nameof(Options_WithBindConfiguration_WithName);
}