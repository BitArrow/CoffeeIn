﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.DTO
{
    public class ProductsDto
    {
        public bool Error { get; set; }

        public List<ProductItemDto> Items { get; set; } = new List<ProductItemDto>();
    }
}
