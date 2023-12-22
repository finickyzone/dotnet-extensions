using System.ComponentModel.DataAnnotations;

namespace Finickyzone.Extensions.Options;

[ValidateOnStart(Name = Name), ValidateDataAnnotation(Name = Name)]
public record Options_WithValidateOnStart_WithValidateDataAnnotation_WithName
{
    public const string Name = nameof(Options_WithValidateOnStart_WithValidateDataAnnotation_WithName);

    [Required]
    public string? Value { get; set; }
}