namespace tfm.api.dal.Entities
{
    public class Contact
    {
        public int Id { get; set; }

        public User User { get; set; } = null!;

        public string Phone { get; set; } = null!;
    }
}