namespace tfm.api.dal.Entities
{
    public class Style
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = string.Empty;
    }
}