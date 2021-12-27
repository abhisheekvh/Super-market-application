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
    }
}
