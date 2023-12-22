namespace Finickyzone.Extensions.Options;

[BindConfiguration(ConfigSection = Section)]
public record Options_WithBindConfiguration_WithSection
{
    public const string Section = "My:Section:Name";
}