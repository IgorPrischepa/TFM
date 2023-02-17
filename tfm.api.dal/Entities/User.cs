namespace tfm.api.dal.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string MiddleName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public IEnumerable<Contact> Contacts { get; set; } = null!;

        public IEnumerable<Role> Roles { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;
    }
}