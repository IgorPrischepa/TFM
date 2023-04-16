namespace tfm.api.bll.DTO.Schedule;

public class ShowScheduleBlockerDto
{
    public int Id { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }

    public int MasterId { get; set; }

    public string? Reason { get; set; }
}