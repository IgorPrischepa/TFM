using System.ComponentModel.DataAnnotations;

namespace tfm.api.Dto.Style;

public sealed class AddStyleDto
{
    [Required]
    [MinLength(4)]
    [MaxLength(100)]
    public string StyleName { get; set; } = null!;
}