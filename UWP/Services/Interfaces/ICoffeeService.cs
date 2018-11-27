using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP.DTO;

namespace UWP.Services.Interfaces
{
    public interface ICoffeeService
    {
        Task<MyProfileDto> GetProfile();
    }
}
