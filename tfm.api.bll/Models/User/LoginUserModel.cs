using System.ComponentModel.DataAnnotations;

namespace tfm.api.bll.Models.User
{
    public sealed class LoginUserModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = null!;
    }
}