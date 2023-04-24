using System.ComponentModel.DataAnnotations;

namespace tfm.api.Dto.Schedule;

public sealed class AddScheduleDayDto
{
    [Required]
    [EnumDataType(typeof(DayOfWeek))]
    public DayOfWeek DayOfWeek { get; set; }

    [Required]
    public TimeOnly StartTime { get; set; }

    [Required]
    public TimeOnly EndTime { get; set; }
    
    [Required]
    [Range(1,int.MaxValue)]
    public int MasterId { get; set; }
}