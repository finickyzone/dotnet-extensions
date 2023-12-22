using System.ComponentModel.DataAnnotations;

namespace Finickyzone.Extensions.Options;

[ValidateDataAnnotation]
public record Options_WithValidateDataAnnotation
{
    [Required]
    public string? Value { get; set; }
}