namespace tfm.api.dal.Entities
{
    public class CustomerEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public UserEntity User { get; set; } = null!;

        public byte[]? Avatar { get; set; }
    }
}