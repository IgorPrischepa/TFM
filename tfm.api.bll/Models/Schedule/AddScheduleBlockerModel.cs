using System.ComponentModel.DataAnnotations;

namespace tfm.api.bll.Models.Schedule;

public sealed class AddScheduleBlockerModel
{
    public DateTime StartDateTime { get; set; }
    
    public DateTime EndDateTime { get; set; }
    
    public int MasterId { get; set; }
    
    public string? Reason { get; set; }
}