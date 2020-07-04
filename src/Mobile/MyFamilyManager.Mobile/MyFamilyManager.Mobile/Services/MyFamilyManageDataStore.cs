using MyFamilyManager.Mobile.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyFamilyManager.Mobile.Services
{
    public class MyFamilyManageDataStore
    {
        HttpClient httpClient;

        public MyFamilyManageDataStore()
        {
            httpClient = new HttpClient();
        }
        public async Task<List<Category>> GetCategories()
        {
            var response = await httpClient.GetAsync("https://localhost:5001/Category");
            var content = await response.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<Category>>(content);
            return categories;
        }
    }
}
