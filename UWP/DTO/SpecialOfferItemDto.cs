using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.DTO
{
    class SpecialOfferItemDto
    {
        public int Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public double Special_price { get; set; }

        public object Url { get; set; }

        /// <summary>
        /// Offer from
        /// </summary>
        public string Date1 { get; set; }

        /// <summary>
        /// Offer to
        /// </summary>
        public string Date2 { get; set; }

        public string Created_at { get; set; }
    }
}
