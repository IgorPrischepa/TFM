namespace tfm.api.dal.Entities
{
    public class MasterEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public UserEntity User { get; set; } = null!;

        public byte[] Avatar { get; set; } = null!;

        public byte Exp { get; set; }

        public bool IsBlocked { get; set; } = false;

        public IEnumerable<StylePriceEntity> Prices { get; set; } = null!;
    }
}
