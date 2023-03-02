namespace tfm.api.dal.Entities
{
    public class PhotoFile
    {
        public int Id { get; set; }

        public string FilePath { get; set; } = null!;

        public int ExampleId { get; set; }

        public Example Example { get; set; } = null!;
    }
}