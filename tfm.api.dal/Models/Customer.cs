﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tfm.api.dal.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public User User { get; set; } = null!;

        public byte[]? Avatar { get; set; }
    }
}