using MyFamilyManager.Mobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyFamilyManager.Mobile.Services
{
    public class TransactionDataStore : IDataStore<Transaction>
    {
        HttpClient httpClient;

        public TransactionDataStore()
        {
            httpClient = new HttpClient();
        }
        public async Task<bool> AddItemAsync(Transaction item)
        {
            var payload = new Dictionary<string, object>
            {
              {"CategoryId", item.CategoryId},
              {"SubCategoryId", item.SubCategoryId},
              {"Amount", item.Amount },
              {"FamilyId","08d815ad-f0f5-459d-83bf-1db3e135e58b" }
            };

            string strPayload = JsonConvert.SerializeObject(payload);
            HttpContent c = new StringContent(strPayload, Encoding.UTF8, "application/json");

            bool response = false;
            using (var client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("http://10.0.2.2:5000/transaction"),
                    Content = c
                };

                HttpResponseMessage result = await client.SendAsync(request);
                var resultString = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {
                    response = true;
                }
            }
            return response;
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Transaction> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Transaction>> GetItemsAsync(bool forceRefresh = false)
        {
            var response = await httpClient.GetAsync("http://10.0.2.2:5000/transaction").ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var transactionList = JsonConvert.DeserializeObject<TransactionList>(content);
            return transactionList.Transations;
        }

        public Task<bool> UpdateItemAsync(Transaction item)
        {
            throw new NotImplementedException();
        }
    }
}
