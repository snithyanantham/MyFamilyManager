using MyFamilyManager.Mobile.ViewModels;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyFamilyManager.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AboutPage : ContentPage
    {
        private readonly AboutViewModel _viewModel;
        public AboutPage()
        {
            InitializeComponent();
            BindingContext = this._viewModel = new AboutViewModel();
        }
    }
}