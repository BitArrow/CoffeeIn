using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.DTO;
using UWP.Services.Interfaces;

namespace UWP.Services
{
    public class CoffeeService : APIBaseService, ICoffeeService
    {

        public async Task<MyProfileDto> GetProfile()
        {
            return await GetAsync<MyProfileDto>("profile");
        }
    }
}
