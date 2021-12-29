using SharedClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IMarketProducts
    {
        Task<List<Product>> GetProducts();
        Task<bool> AddProducts(Product product);
        Task<Product> UpdateProduct(Product product);

        Task<Product> GetproductByid(int id);
        Task<bool> DeleteProd(int id);
    }
}
