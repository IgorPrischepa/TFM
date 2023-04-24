using System.ComponentModel.DataAnnotations;

namespace tfm.api.Dto.Master
{
    public sealed class AddMasterPriceDto
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int MasterId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int StyleId { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
