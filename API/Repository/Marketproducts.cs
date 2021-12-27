using API.DataConnection;
using API.Services;
using Microsoft.EntityFrameworkCore;
using SharedClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class Marketproducts : IMarketProducts
    {
        private readonly AppDbContext _appDbContext;
        public Marketproducts(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //public Task<List<Product>> GetProducts()
        //{
        //    throw new NotImplementedException();
        //}
        public async Task<List<Product>> GetProducts()
        {
            try
            {
                var lstProducts = await _appDbContext.products.ToListAsync();
                if(lstProducts!=null && lstProducts.Count>0)
                {
                    return lstProducts;
                }
                else return null;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
