namespace tfm.api.dal.Models
{
    public class Master
    {
        public int Id { get; set; }

        public User User { get; set; } = null!;

        public byte[] Avatar { get; set; } = null!;

        public byte Exp { get; set; }

        public IEnumerable<StylePrice> Prices { get; set; } = null!;
    }
}
