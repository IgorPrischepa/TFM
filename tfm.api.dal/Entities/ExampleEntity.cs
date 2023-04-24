namespace tfm.api.dal.Entities

{
    public sealed class ExampleEntity
    {
        public int Id { get; set; }

        public int MasterId { get; set; }

        public MasterEntity Master { get; set; } = null!;

        public int StyleId { get; set; }

        public StyleEntity Style { get; set; } = null!;

        public int PhotoFileId { get; set; }

        public ImageFileEntity ImageFile { get; set; } = null!;

        public string? ShortDescription { get; set; }
    }
}