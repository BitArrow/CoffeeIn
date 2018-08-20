using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.DTO
{
    public class SpecialOfferDto
    {
        public bool Error { get; set; }

        public List<SpecialOfferDto> Offers { get; set; } = new List<SpecialOfferDto>();
    }
}
