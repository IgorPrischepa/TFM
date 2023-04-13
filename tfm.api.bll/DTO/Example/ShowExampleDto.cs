namespace tfm.api.bll.DTO.Example;

public class ShowExampleDto
{
    public int Id { get; set; }

    public int MasterId { get; set; }

    public int StyleId { get; set; }

    public string PhotoFile { get; set; } = null!;

    public string ShortDescription { get; set; } = string.Empty;
}