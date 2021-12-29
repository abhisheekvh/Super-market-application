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
                var lstProducts = await _appDbContext.productsTable.ToListAsync();
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
        public async Task<bool> AddProducts(Product product)
        {
            bool flag=false;
            try
            {
                var res = await _appDbContext.productsTable.AddAsync(product);
                await _appDbContext.SaveChangesAsync();
                if (res != null)
                {
                    return flag = true;
                }
                else
                    return flag;



            }catch(Exception ex)
            {
                return flag;
            }
        }

        
        public async Task<Product> UpdateProduct(Product product)
        {
            try
            {
                var updateCategory = await _appDbContext.productsTable.FirstOrDefaultAsync(x => x.ProductId == product.ProductId);
                if (updateCategory != null)
                {
                    updateCategory.ProductId = product.ProductId;
                    updateCategory.name = product.name;
                    updateCategory.Quantity = product.Quantity;
                    updateCategory.price = product.price;
                    await _appDbContext.SaveChangesAsync();
                    return updateCategory;
                }
                else
                    return null;

            }catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<Product> GetproductByid(int id)
        {
            try
            {
                var result = await _appDbContext.productsTable.FirstOrDefaultAsync(x => x.ProductId == id);
                if (result != null)
                    return result;
                return null;
            }catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> DeleteProd(int id)
        {
           try
            {
                var res = await _appDbContext.productsTable.FirstOrDefaultAsync(x => x.ProductId == id);
                if(res != null)
                {
                    _appDbContext.productsTable.Remove(res);
                    await _appDbContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }catch(Exception ex)
            {
                return false;
            }
        }
    }
}
