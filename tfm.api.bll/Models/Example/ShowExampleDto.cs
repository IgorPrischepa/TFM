namespace tfm.api.bll.Models.Example;

public sealed class ShowExampleDto
{
    public int Id { get; set; }

    public int MasterId { get; set; }

    public int StyleId { get; set; }

    public string PhotoBase64 { get; set; } = null!;

    public string ShortDescription { get; set; } = string.Empty;
}