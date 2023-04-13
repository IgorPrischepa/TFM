namespace tfm.api.dal.Entities
{
    public class StyleEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = string.Empty;

        public IEnumerable<StylePriceEntity> Prices { get; set; } = null!;
    }
}