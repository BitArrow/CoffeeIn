using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.DTO;
using UWP.DTO.Mock;
using UWP.Services.Interfaces;

namespace UWP.Services
{
    public class CoffeeService : APIBaseService, ICoffeeService
    {

        public async Task<MyProfileDto> GetProfile()
        {
            if (App.TestUser)
                return MockData.GetTestProfile();
            return await GetAsync<MyProfileDto>("profile");
        }
    }
}
