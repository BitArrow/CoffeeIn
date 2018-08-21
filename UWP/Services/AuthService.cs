using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using UWP.DTO;
using UWP.Services.Interfaces;

namespace UWP.Services
{
    public class AuthService : APIBaseService, IAuthService
    {
        public void LogOut()
        {
            App.AuthToken = string.Empty;
        }

        public async Task Login(string userName, string password)
        {
            var login = new LoginRequestDto { Email = userName, Password = password };
            var result = await PostAsync<LoginDto>("login", login);
            throw new NotImplementedException();
        }

        public Task Refresh()
        {
            throw new NotImplementedException();
        }
    }
}
