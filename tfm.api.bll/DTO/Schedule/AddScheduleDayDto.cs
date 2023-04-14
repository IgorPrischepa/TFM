namespace tfm.api.bll.DTO.Schedule;

public class AddScheduleDayDto
{
    public DayOfWeek DayOfWeek { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public int MasterId { get; set; }
}