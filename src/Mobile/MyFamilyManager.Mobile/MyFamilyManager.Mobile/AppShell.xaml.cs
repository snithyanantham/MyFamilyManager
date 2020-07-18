using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Browser;
using MyFamilyManager.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyFamilyManager.Mobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("itemdetailpage", typeof(ItemDetailPage));
            Routing.RegisterRoute("itemspage", typeof(ItemsPage));
            Routing.RegisterRoute("main/login", typeof(LoginPage));

            BindingContext = this;
        }

        public ICommand ExecuteLogout => new Command(async () =>
        {
            OidcClient _client;
            var browser = DependencyService.Get<IBrowser>();

            var options = new OidcClientOptions
            {
                Authority = "https://demo.identityserver.io",
                ClientId = "interactive.public",
                Scope = "openid profile email api offline_access",
                PostLogoutRedirectUri = "xamarinformsclients://callback",
                Browser = browser,

                ResponseMode = OidcClientOptions.AuthorizeResponseMode.Redirect
            };

            _client = new OidcClient(options);
            var idToken = await SecureStorage.GetAsync("IdentityToken");
            LogoutRequest logoutRequest = new LogoutRequest { IdTokenHint = idToken, BrowserDisplayMode = DisplayMode.Hidden };
            await _client.LogoutAsync(logoutRequest);

            await Shell.Current.GoToAsync("///login");
            Shell.SetFlyoutBehavior(Shell.Current, FlyoutBehavior.Disabled);
            Shell.Current.FlyoutIsPresented = false;
        });
    }
}
