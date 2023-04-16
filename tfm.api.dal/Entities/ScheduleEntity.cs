namespace tfm.api.dal.Entities;

public sealed class ScheduleEntity
{
    public int Id { get; set; }

    public DayOfWeek DayOfWeek { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public int MasterId { get; set; }

    public MasterEntity Master { get; set; } = null!;
}