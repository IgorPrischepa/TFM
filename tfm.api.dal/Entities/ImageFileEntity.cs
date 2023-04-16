namespace tfm.api.dal.Entities
{
    public class ImageFileEntity
    {
        public int Id { get; set; }

        public string FilePath { get; set; } = null!;
        
        public int UserId { get; set; }

        public UserEntity? User { get; set; }
        
        public int ExampleId { get; set; }

        public ExampleEntity? Example { get; set; }
    }
}