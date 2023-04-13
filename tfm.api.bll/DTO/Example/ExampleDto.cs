namespace tfm.api.bll.DTO.Example;

public class ExampleDto
{
    public int Id { get; set; }

    public int MasterId { get; set; }

    public int StyleId { get; set; }

    public int PhotoFileId { get; set; }

    public string ShortDescription { get; set; } = string.Empty;
}