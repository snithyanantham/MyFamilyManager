using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyFamilyManager.Mobile.Services;
using MyFamilyManager.Mobile.Views;

namespace MyFamilyManager.Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<TransactionDataStore>();
            DependencyService.Register<IdentityService>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
