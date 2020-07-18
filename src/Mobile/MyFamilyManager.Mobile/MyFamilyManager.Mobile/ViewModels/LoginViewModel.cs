using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Browser;
using MyFamilyManager.Mobile.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyFamilyManager.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        
        LoginResult _result;
        public LoginViewModel()
        {
            
            ExecuteLogin = new Command(() => Login());
        }

        public ICommand ExecuteLogin { get; set; }

        private async void Login()
        {
            OidcClient _client;
            var browser = DependencyService.Get<IBrowser>();

            var options = new OidcClientOptions
            {
                Authority = "https://demo.identityserver.io",
                ClientId = "interactive.public",
                Scope = "openid profile email api offline_access",
                RedirectUri = "xamarinformsclients://callback",
                Browser = browser,

                ResponseMode = OidcClientOptions.AuthorizeResponseMode.Redirect
            };

            _client = new OidcClient(options);
            _result = await _client.LoginAsync(new LoginRequest());

            if (_result.IsError)
            {
                return;
            }
            else
            {
                await Xamarin.Essentials.SecureStorage.SetAsync("AccessToken", _result.AccessToken);
                await Xamarin.Essentials.SecureStorage.SetAsync("IdentityToken", _result.IdentityToken);
            }
            await Shell.Current.GoToAsync("///home");
            Shell.SetFlyoutBehavior(Shell.Current, FlyoutBehavior.Flyout);
           
        }

        private void Register()
        {
            //Shell.Current.GoToAsync("//login/registration");
        }
    }
}
