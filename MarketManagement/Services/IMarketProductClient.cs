using SharedClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketManagement.Services
{
    public interface IMarketProductClient
    {
        Task<List<Product>> Getproducts();
        Task<bool> AddProducts(Product product);
        Task<Product> Updateproducts(Product product);
        Task<Product> GetProductByid(int id);

        Task<bool> DeleteProd(int id);
    }
}
