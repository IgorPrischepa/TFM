namespace tfm.api.dal.Entities

{
    public sealed class Example
    {
        public int Id { get; set; }

        public int MasterId { get; set; }

        public Master Master { get; set; } = null!;

        public int StyleId { get; set; }

        public Style Style { get; set; } = null!;

        public int PhotoFileId { get; set; }

        public PhotoFile PhotoFile { get; set; } = null!;

        public string ShortDescription { get; set; } = string.Empty;
    }
}