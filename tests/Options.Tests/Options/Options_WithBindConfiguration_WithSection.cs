namespace Finickyzone.Extensions.Options;

[BindConfiguration(Section = Section)]
public record Options_WithBindConfiguration_WithSection
{
    public const string Section = "My:Section:Name";
}