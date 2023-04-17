using System.ComponentModel.DataAnnotations;

namespace tfm.api.Dto.Master
{
    public class AddMasterExampleDto
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int MasterId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int StyleId { get; set; }

        [MaxLength(200)]
        public string ShortDescription { get; set; } = string.Empty;

        [Required]
        [FileExtensions(Extensions = "jpg,png,jpeg,bmp")]
        public IFormFile ExamplePhoto { get; set; } = null!;
    }
}
