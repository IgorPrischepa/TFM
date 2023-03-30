namespace tfm.api.dal.Entities
{
    public class StylePriceEntity
    {
        public int Id { get; set; }

        public int MasterId { get; set; }

        public MasterEntity Master { get; set; } = null!;

        public int StyleId { get; set; }

        public StyleEntity Style { get; set; } = null!;

        public decimal Price { get; set; }
    }
}