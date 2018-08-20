using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.DTO
{
    public class CoffeeShopsDto
    {
        public bool Error { get; set; }

        public List<CoffeeShopLocationDto> Places { get; set; } = new List<CoffeeShopLocationDto>();
    }
}
