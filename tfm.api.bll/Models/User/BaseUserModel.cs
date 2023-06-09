﻿namespace tfm.api.bll.Models.User
{
    public sealed class BaseUserModel
    {
        public string Email { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string MiddleName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public IEnumerable<string> Roles { get; set; } = null!;
    }
}