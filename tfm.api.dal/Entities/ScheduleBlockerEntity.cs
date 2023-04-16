namespace tfm.api.dal.Entities;

public class ScheduleBlockerEntity
{
    public int Id { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }

    public int MasterId { get; set; }

    public MasterEntity? Master { get; set; }

    public string Reason { get; set; } = Constants.DefaultBlockerReason;
}