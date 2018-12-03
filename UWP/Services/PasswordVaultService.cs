using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Credentials;
using UWP.Services.Interfaces;

namespace UWP.Services
{
    public class PasswordVaultService : IPasswordVaultService
    {
        private const string ApiKeyValue = "apiKey";
        private const int ElementNotFound = unchecked((int)0x80070490);
        private readonly PasswordVault _passwordVault;

        public PasswordVaultService()
        {
            _passwordVault = new PasswordVault();
        }

        public void SaveTokens()
        {
            if (!string.IsNullOrEmpty(App.AuthToken))
            {
                try
                {
                    EmptyVault();

                    var authToken = new PasswordCredential(ApiKeyValue, ApiKeyValue, App.AuthToken);

                    _passwordVault.Add(authToken);
                }
                catch (Exception ex)
                {
                    Debug.Write("SaveTokensError: " + ex.ToString());
                }
            }
            else
            {
                Debug.Write("Token is empty");
            }
        }

        public void LoadExistingTokens()
        {
            try
            {
                var authToken = _passwordVault.FindAllByResource(ApiKeyValue).FirstOrDefault();

                if (authToken == null)
                    return;

                authToken.RetrievePassword();

                App.AuthToken = authToken.Password;
            }
            catch (Exception ex)
            {
                if (ex.HResult != ElementNotFound)
                {
                    Debug.Write("LoadExistingTokenError: " + ex.ToString());
                    RemoveAllCredentials();
                }
            }
        }

        public void RemoveExistingTokens()
        {
            RemoveAllCredentials();
            App.TestUser = false;
        }

        private void EmptyVault()
        {
            var creds = _passwordVault.RetrieveAll();
            foreach (var cred in creds)
            {
                _passwordVault.Remove(cred);
            }
        }

        private void RemoveAllCredentials()
        {
            try
            {
                EmptyVault();
                // Clear app saved values
                App.AuthToken = string.Empty;
            }
            catch (Exception ex)
            {
                Debug.Write("RemoveAllCredentialsError: " + ex.ToString());
            }
        }
    }
}
