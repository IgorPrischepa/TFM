namespace tfm.api.dal.Models
{
    internal class Style
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = string.Empty;
    }
}