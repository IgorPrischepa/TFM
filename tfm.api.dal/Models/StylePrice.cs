﻿namespace tfm.api.dal.Models
{
    internal class StylePrice
    {
        public int Id { get; set; }

        public Master Master { get; set; } = null!;

        public Style Style { get; set; } = null!;

        public decimal Price { get; set; }
    }
}