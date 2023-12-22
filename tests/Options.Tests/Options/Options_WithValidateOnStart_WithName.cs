using System.ComponentModel.DataAnnotations;

namespace Finickyzone.Extensions.Options;

[ValidateOnStart(Name = Name)]
public record Options_WithValidateOnStart_WithName
{
    public const string Name = nameof(Options_WithValidateOnStart_WithName);

    [Required]
    public string? Value { get; set; }
}