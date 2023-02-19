namespace tfm.api.dal.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string MiddleName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public ICollection<Contact> Contacts { get; set; } = null!;

        public ICollection<Role> Roles { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;
    }
}