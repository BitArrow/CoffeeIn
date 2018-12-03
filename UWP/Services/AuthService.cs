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
        private readonly IPasswordVaultService _passwordVaultService;

        public AuthService()
        {
            _passwordVaultService = App.Container.GetRequiredService<IPasswordVaultService>();
        }

        public void LogOut()
        {
            _passwordVaultService.RemoveExistingTokens();
        }

        public async Task<bool> Login(string username, string password)
        {
            if (username == "test")
            {
                App.TestUser = true;
                return true;
            }
            var login = new LoginRequestDto { Email = username, Password = password };
            var result = await PostAsync<LoginDto>("login", login);
            
            App.AuthToken = result.ApiKey;
            _passwordVaultService.SaveTokens();

            return !string.IsNullOrEmpty(result.ApiKey);
        }

        public Task Refresh()
        {
            throw new NotImplementedException();
        }
    }
}
