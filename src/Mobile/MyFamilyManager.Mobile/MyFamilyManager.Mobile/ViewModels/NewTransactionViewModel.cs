using MyFamilyManager.Mobile.Infrastructure;
using MyFamilyManager.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFamilyManager.Mobile.ViewModels
{
    public class NewTransactionViewModel:BaseViewModel
    {
        private Transaction _transaction;

        public Transaction Transaction
        {
            get => _transaction;
            set
            {
                SetProperty(ref _transaction, value);
            }
        }

        public Category SelectedCategory { get; set; }
        public SubCategory SelectedSubCategory { get; set; }
        public NewTransactionViewModel()
        {
            var transaction = new Transaction
            {
                 Amount = 0.0,
            };

            Transaction = transaction;
        }

    }
}
