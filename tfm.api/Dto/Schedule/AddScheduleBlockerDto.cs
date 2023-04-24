using System.ComponentModel.DataAnnotations;

namespace tfm.api.Dto.Schedule;

public sealed class AddScheduleBlockerDto
{
    [Required]
    public DateTime StartDateTime { get; set; }

    [Required]
    public DateTime EndDateTime { get; set; }

    [Required]
    [Range(1,int.MaxValue)]
    public int MasterId { get; set; }

    [MaxLength(200)]
    public string? Reason { get; set; }
}