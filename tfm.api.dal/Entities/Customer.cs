namespace tfm.api.dal.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public User User { get; set; } = null!;

        public byte[]? Avatar { get; set; }
    }
}