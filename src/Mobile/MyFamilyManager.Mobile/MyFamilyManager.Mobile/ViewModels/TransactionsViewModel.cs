using MyFamilyManager.Mobile.Infrastructure;
using MyFamilyManager.Mobile.Models;
using MyFamilyManager.Mobile.Services;
using MyFamilyManager.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyFamilyManager.Mobile.ViewModels
{
    public class TransactionsViewModel:BaseViewModel
    {
        public ObservableCollection<Transaction> Transactions { get; set; }
        public IDataStore<Transaction> TransactionDataStore => DependencyService.Get<IDataStore<Transaction>>();

        public Command LoadItemsCommand { get; set; }

        public TransactionsViewModel()
        {
            Title = "Transactions";
            Transactions = new ObservableCollection<Transaction>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewTransactionPage, Transaction>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Transaction;
                var result = await TransactionDataStore.AddItemAsync(newItem);
                if(result)
                {
                    Transactions.Add(newItem);
                }
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Transactions.Clear();
                var items = await TransactionDataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Transactions.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
