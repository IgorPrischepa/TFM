namespace tfm.api.dal.Models
{
    internal class Role
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public IEnumerable<User> Users { get; set; } = null!;
    }
}