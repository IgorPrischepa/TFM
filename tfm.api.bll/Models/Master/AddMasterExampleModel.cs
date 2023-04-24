using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace tfm.api.bll.Models.Master
{
    public sealed class AddMasterExampleModel
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