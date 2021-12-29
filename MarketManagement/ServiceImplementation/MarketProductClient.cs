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
    public class MarketProductClient : IMarketProductClient
    {
        private readonly HttpClient _httpClient;
        public MarketProductClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Product>> Getproducts()
        {
            try
            {
                var res = await _httpClient.GetFromJsonAsync<List<Product>>("api/market/products");
                if (res != null && res.Count > 0)
                    return res;
                else
                    return null;
            }
            catch (Exception ex)
            {

                return null;
            }

        }

        public async Task<bool> AddProducts(Product product)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Market/addproducts", product);
            var response = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<bool>(response);
        }
        public async Task<Product> Updateproducts(Product product)
        {
            try
            {
                var updatedproduct = await _httpClient.PutAsJsonAsync("api/Market/updateproducts", product);
                var response = await updatedproduct.Content.ReadFromJsonAsync<Product>();
                if (response != null)
                    return response;
                return null;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<Product> GetProductByid(int id)
        {
            try
            {
                var res= await _httpClient.GetFromJsonAsync<Product>("api/Market/getprodbyid/"+id);
                if(res != null)
                    return res;
                else
                    return null;
            }
            catch (Exception ex)
            {

                return null;
            }
            
        }

        public async Task<bool> DeleteProd(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync("api/Market/deleteprod/" + id);
                var res = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<bool>(res);

            }catch(Exception ex)
            {
                return false;
            }
        }
    }
}
