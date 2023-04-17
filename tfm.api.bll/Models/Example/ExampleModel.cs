namespace tfm.api.bll.Models.Example;

public class ExampleModel
{
    public int Id { get; set; }

    public int MasterId { get; set; }

    public int StyleId { get; set; }

    public int PhotoFileId { get; set; }

    public string ShortDescription { get; set; } = string.Empty;
}