using MyFamilyManager.Mobile.Infrastructure;
using MyFamilyManager.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFamilyManager.Mobile.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private Item _item;

        public Item Item
        {
            get => _item;
            set
            {
                SetProperty(ref _item, value);
            }
        }

        public NewItemViewModel()
        {
            var item = new Item
            {
                Text = "Item name",
                Description = "This is an item description."
            };

            Item = item;
        }
    }
}
