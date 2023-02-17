using System.ComponentModel.DataAnnotations;

namespace tfm.api.bll.DTO
{
    public sealed class UserDto
    {
        [Required]
        [MinLength(4)]
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string MiddleName { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = null!;
    }
}