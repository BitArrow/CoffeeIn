using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.Services.Interfaces
{
    public interface IAuthService
    {
        void LogOut();
        Task<bool> Login(string username, string password);
        Task Refresh();
    }
}
