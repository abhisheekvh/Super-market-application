using MarketManagement.Services;
using SharedClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MarketManagement.ServiceImplementation
{
    public class MarketClient : ImarketClient
    {
        private readonly HttpClient _httpclient;
        public MarketClient(HttpClient httpclient)
        {
            _httpclient = httpclient;
        }
        public async Task<Category> AddCategory(Category category)
        {
            var AddCat=await _httpclient.PostAsJsonAsync("api/Market", category);
            var result =await AddCat.Content.ReadFromJsonAsync<Category>();
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var res = await _httpclient.DeleteAsync("api/Market/" + id);
                var response = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<bool>(response);
            }
            catch (Exception ex)
            {

                throw;
            }//converted http response to bool

        }

        public async Task<List<Category>> GetCategories()
        {
            try
            {
                var res = await _httpclient.GetFromJsonAsync<List<Category>>("api/Market/getallcategories");
                if (res != null)
                    return res;
                else
                    return null;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<Category> GetCategoryById(int categoryId)
        {
            try
            {
                return await _httpclient.GetFromJsonAsync<Category>("api/Market/" + categoryId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            try
            {
                var updateCategory = await _httpclient.PutAsJsonAsync("api/Market", category);
                var res = await updateCategory.Content.ReadFromJsonAsync<Category>();
                return res;

            }catch(Exception ex)
            {
                return null;
            }
        }
    }
}
