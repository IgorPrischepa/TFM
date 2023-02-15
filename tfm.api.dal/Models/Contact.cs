namespace tfm.api.dal.Models
{
    internal class Contact
    {
        public int Id { get; set; }

        public User User { get; set; } = null!;

        public string Phone { get; set; } = null!;
    }
}