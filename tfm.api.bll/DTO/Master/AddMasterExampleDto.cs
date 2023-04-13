using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace tfm.api.bll.DTO.Master
{
    public sealed class AddMasterExampleDto
    {
        [Required]
        public int MasterId { get; set; }

        [Required]
        public int StyleId { get; set; }

        [MaxLength(200)]
        public string ShortDescription { get; set; } = string.Empty;

        [Required]
        public IFormFile ExamplePhoto { get; set; } = null!;
    }
}