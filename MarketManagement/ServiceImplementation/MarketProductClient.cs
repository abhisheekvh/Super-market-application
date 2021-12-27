using MarketManagement.Services;
using SharedClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

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
            return await _httpClient.GetFromJsonAsync<List<Product>>("api/market/products");

        }
    }
}
