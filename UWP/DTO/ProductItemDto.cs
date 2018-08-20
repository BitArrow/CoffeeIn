using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.DTO
{
    public class ProductItemDto
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        /// <summary>
        /// Image Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// To be specified...
        /// </summary>
        public string Art_krkup { get; set; }

        /// <summary>
        /// To be specified...
        /// </summary>
        public string Art_app1 { get; set; }

        /// <summary>
        /// HOT or COLD
        /// </summary>
        public string Art_app2 { get; set; }

        /// <summary>
        /// To be specified...
        /// </summary>
        public string Art_app3 { get; set; }

        /// <summary>
        /// Coffee type
        /// </summary>
        public string Art_app4 { get; set; }

        /// <summary>
        /// To be specified...
        /// </summary>
        public string Art_noom { get; set; }

        /// <summary>
        /// /// <summary>
        /// To be specified...
        /// </summary>
        /// </summary>
        public int Prioriteet { get; set; }

        public string Ts { get; set; }
    }
}
