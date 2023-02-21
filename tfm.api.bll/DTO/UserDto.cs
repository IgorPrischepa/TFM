namespace tfm.api.bll.DTO
{
    public sealed class UserDTO
    {
        public string Email { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string MiddleName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public IEnumerable<string> Roles { get; set; } = null!;
    }
}