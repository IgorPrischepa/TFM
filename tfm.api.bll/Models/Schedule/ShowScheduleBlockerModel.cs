namespace tfm.api.bll.Models.Schedule;

public class ShowScheduleBlockerModel
{
    public int Id { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }

    public int MasterId { get; set; }

    public string? Reason { get; set; }
}