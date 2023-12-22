using System.ComponentModel.DataAnnotations;

namespace Finickyzone.Extensions.Options;

[ValidateOnStart, ValidateDataAnnotation]
public record Options_WithValidateOnStart_WithValidateDataAnnotation
{
    [Required]
    public string? Value { get; set; }
}