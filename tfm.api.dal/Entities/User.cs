namespace tfm.api.dal.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public IEnumerable<Contact> Contacts { get; set; } = null!;

        public IEnumerable<Role> Roles { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;
    }
}