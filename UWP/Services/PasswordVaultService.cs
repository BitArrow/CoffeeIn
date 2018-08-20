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
        private const string BearerTokenVaultKey = "apiKey";
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

                    var bearer = new PasswordCredential(BearerTokenVaultKey, "", App.AuthToken);

                    _passwordVault.Add(bearer);
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
                var bearer = _passwordVault.FindAllByResource(BearerTokenVaultKey).FirstOrDefault();

                if (bearer == null)
                    return;

                bearer.RetrievePassword();

                App.AuthToken = bearer.Password;
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
