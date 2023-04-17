namespace tfm.api.bll.Models.Schedule;

public class ShowScheduleModel
{
    public int Id { get; set; }

    public DayOfWeek DayOfWeek { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public int MasterId { get; set; }
}