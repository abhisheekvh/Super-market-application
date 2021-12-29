using API.DataConnection;
using API.Services;
using SharedClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class MarketApi : IMarketApi
    {
        private readonly AppDbContext _appDbContext;
        public MarketApi(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Category> AddCategory(Category category)
        {
            var result = await _appDbContext.categoriesTable.AddAsync(category);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var DeletedProd = await _appDbContext.categoriesTable.FirstOrDefaultAsync(x => x.CategoryId == id);
                if (DeletedProd != null)
                {
                    _appDbContext.categoriesTable.Remove(DeletedProd);
                    await _appDbContext.SaveChangesAsync();
                    return true;
                }
                else
                    return false;
            }catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Category>> GetCategories()
        {
            try
            {
                var lstRes= await _appDbContext.categoriesTable.ToListAsync();
                if (lstRes != null && lstRes.Count > 0)
                    return lstRes;
                else
                    return null;
            }catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<Category> GetCategoryBYId(int id)
        {
            try
            {
                var category = await _appDbContext.categoriesTable.FirstOrDefaultAsync(x => x.CategoryId == id);
                if (category != null)
                    return category;
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
                
            }

        }

        public async Task<Category> Updatecategory(Category category)
        {
            try
            {
                var categoryDetails = await _appDbContext.categoriesTable.FirstOrDefaultAsync(x => x.CategoryId == category.CategoryId);
                if(categoryDetails!=null)
                {
                    categoryDetails.name = category.name;
                    categoryDetails.Description = category.Description;
                    await _appDbContext.SaveChangesAsync();
                    return categoryDetails;
                }
                else
                {
                    return null;
                }

            }catch(Exception ex)
            {
                return null;
            }
        }
        

        public Task<List<Product>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddProducts()
        {
            throw new NotImplementedException();
        }
    }
}
