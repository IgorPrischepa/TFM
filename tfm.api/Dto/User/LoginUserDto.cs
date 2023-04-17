using System.ComponentModel.DataAnnotations;

namespace tfm.api.Dto.User;

public sealed class LoginUserDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    [MinLength(6)]
    [MaxLength(50)]
    public string Password { get; set; } = null!;
}