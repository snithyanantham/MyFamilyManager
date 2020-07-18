using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Browser;
using MyFamilyManager.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyFamilyManager.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private readonly LoginViewModel _viewModel;
       

        public LoginPage()
        {
            InitializeComponent();
            BindingContext = this._viewModel = new LoginViewModel();
            Shell.SetFlyoutBehavior(Shell.Current, FlyoutBehavior.Disabled);
            
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}