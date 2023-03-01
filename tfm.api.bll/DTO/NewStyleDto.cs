using System.ComponentModel.DataAnnotations;

namespace tfm.api.bll.DTO
{
    public sealed class NewStyleDto
    {
        [Required]
        public string StyleName { get; set; } = null!;
    }
}