namespace tfm.api.dal.Models
{
    internal class Example
    {
        public int Id { get; set; }

        public Master Master { get; set; } = null!;

        public Style StyleStyle { get; set; } = null!;

        public PhotoFile PhotoFile { get; set; } = null!;

        public string ShortDescription { get; set; } = string.Empty;
    }
}