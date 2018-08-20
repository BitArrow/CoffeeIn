using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.DTO
{
    class LoginDto
    {
        public bool Error { get; set; }

        public string Email { get; set; }

        public string ApiKey { get; set; }

        public string Created_at { get; set; }
    }
}
