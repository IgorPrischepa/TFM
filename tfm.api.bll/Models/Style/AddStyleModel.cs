using System.ComponentModel.DataAnnotations;

namespace tfm.api.bll.Models.Style
{
    public sealed class AddStyleModel
    {
        [Required]
        public string StyleName { get; set; } = null!;
    }
}