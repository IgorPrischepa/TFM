﻿using System.ComponentModel.DataAnnotations;

namespace tfm.api.bll.DTO
{
    public sealed class NewUserDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        [MinLength(4)]
        public string FirstName { get; set; } = null!;

        public string MiddleName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        [MinLength(6)]
        public string Password { get; set; } = null!;
    }
}