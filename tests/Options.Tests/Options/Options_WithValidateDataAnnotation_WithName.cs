using System.ComponentModel.DataAnnotations;

namespace Finickyzone.Extensions.Options;

[ValidateDataAnnotation(Name = Name)]
public record Options_WithValidateDataAnnotation_WithName
{
    public const string Name = nameof(Options_WithValidateDataAnnotation_WithName);
    
    [Required]
    public string? Value { get; set; }
}