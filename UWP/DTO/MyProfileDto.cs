using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.DTO
{
    public class MyProfileDto
    {
        public bool Error { get; set; }

        public int Id { get; set; }

        /// <summary>
        /// Client short code
        /// </summary>
        public string Client_code { get; set; }

        /// <summary>
        /// Card number
        /// </summary>
        public string Card_code { get; set; }

        public string First_name { get; set; }

        public string Last_name { get; set; }

        public string Birthdate { get; set; }

        /// <summary>
        /// To be specified...
        /// </summary>
        public int Class { get; set; }

        /// <summary>
        /// Current bonus amount
        /// </summary>
        public double Kl_boonus { get; set; }

        /// <summary>
        /// Current level
        /// </summary>
        public int Kl_taseh { get; set; }

        /// <summary>
        /// Next month level
        /// </summary>
        public int Kl_tasej { get; set; }

        /// <summary>
        /// Missing drinks from next level
        /// </summary>
        public int Kl_jktp { get; set; }

        /// <summary>
        /// Drinks bought this month
        /// </summary>
        public int Kl_skost { get; set; }

        /// <summary>
        /// When bonus was last updated
        /// </summary>
        public string Ts_bonus { get; set; }

        /// <summary>
        /// User created at
        /// </summary>
        public string Created_at { get; set; }
    }
}
