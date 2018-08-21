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
        Task Login(string userName, string password);
        Task Refresh();
    }
}
