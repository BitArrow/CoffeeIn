using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.DTO.Mock
{
    public static class MockData
    {
        public static MyProfileDto GetTestProfile()
        {
            return new MyProfileDto
            {
                Birthdate = "1990-01-01 00:00:00",
                Card_code = "1234567890123456",
                Class = 10,
                Client_code = "123456",
                Created_at = DateTime.Now.ToString("yyyy-M-dd hh:mm:ss"),
                Error = false,
                First_name = "Peeter",
                Id = 12345,
                Kl_boonus = 5.56,
                Kl_jktp = 3,
                Kl_skost = 7,
                Kl_taseh = 5,
                Kl_tasej = 2,
                Last_name = "Pakiraam",
                Ts_bonus = DateTime.Now.ToString("yyyy-M-dd hh:mm:ss")
            };
        }
    }
}
