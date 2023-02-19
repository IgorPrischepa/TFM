using System.ComponentModel.DataAnnotations;

namespace tfm.api.bll.DTO
{
    public sealed class LoginUserDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = null!;
    }
}