namespace Finickyzone.Extensions.Options;

[BindConfiguration(Name = Name, ConfigSection = Section)]
public record Options_WithBindConfiguration_WithSection_WithName
{
    public const string Name = nameof(Options_WithBindConfiguration_WithSection_WithName);
    public const string Section = "My:Section:Name:1";
}