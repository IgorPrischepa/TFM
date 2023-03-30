﻿using System.ComponentModel.DataAnnotations;

namespace tfm.api.bll.DTO
{
    public sealed class AddMasterPriceDto
    {
        [Required]
        public int MasterId { get; set; }

        [Required]
        public int StyleId { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}