using MyFamilyManager.Mobile.Models;
using MyFamilyManager.Mobile.Services;
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
    public partial class NewTransactionPage : ContentPage
    {
        private readonly NewTransactionViewModel _viewModel;
        private readonly MyFamilyManageDataStore _dataStore;
        public NewTransactionPage()
        {
            InitializeComponent();
            BindingContext = this._viewModel = new NewTransactionViewModel();
            _dataStore = new MyFamilyManageDataStore();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var categories = _dataStore.GetCategories().GetAwaiter().GetResult();
            
            ddlCategory.ItemsSource = categories.categories;
            ddlCategory.ItemDisplayBinding = new Binding("Name");
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            _viewModel.Transaction.CategoryId = _viewModel.SelectedCategory.Id;
            _viewModel.Transaction.CategoryName = _viewModel.SelectedCategory.Name;
            _viewModel.Transaction.SubCategoryId = _viewModel.SelectedSubCategory.Id;
            _viewModel.Transaction.SubCategoryName = _viewModel.SelectedSubCategory.Name;
            MessagingCenter.Send(this, "AddItem", _viewModel.Transaction);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategory.ItemsSource != null)
            {
                if (ddlSubCategory.ItemsSource != null)
                {
                    ddlSubCategory.ItemsSource = null;
                }

                string selectedCategoryId = ((Category)ddlCategory.SelectedItem).Id;

                var result = _dataStore.GetSubCategories(selectedCategoryId).GetAwaiter().GetResult();
                if (result != null)
                {
                    ddlSubCategory.ItemsSource = result.SubCategories;
                    ddlSubCategory.ItemDisplayBinding = new Binding("Name");
                }
            }
        }

        private void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}