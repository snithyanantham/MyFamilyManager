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
            List<Category> categoryList = new List<Category>();
            foreach (var item in categories)
            {
                categoryList.Add(item);
            }
            ddlCategory.ItemsSource = categoryList;
            ddlCategory.ItemDisplayBinding = new Binding("Name");
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
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

                ddlSubCategory.ItemsSource = new List<SubCategory> { new SubCategory { Id = "1", Name = "Others" }, new SubCategory { Id = "2", Name = "Rent" } };
                ddlSubCategory.ItemDisplayBinding = new Binding("Name");
            }
        }

        private void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}