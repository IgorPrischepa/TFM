namespace tfm.api.dal.Entities
{
    public class PhotoFileEntity
    {
        public int Id { get; set; }

        public string FilePath { get; set; } = null!;

        public int ExampleId { get; set; }

        public ExampleEntity Example { get; set; } = null!;
    }
}