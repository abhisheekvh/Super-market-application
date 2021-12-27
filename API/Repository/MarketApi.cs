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
            var result = await _appDbContext.categories.AddAsync(category);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var DeletedProd = await _appDbContext.categories.FirstOrDefaultAsync(x => x.CategoryId == id);
                if (DeletedProd != null)
                {
                    _appDbContext.categories.Remove(DeletedProd);
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
                return await _appDbContext.categories.ToListAsync();
            }catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<Category> GetCategoryBYId(int id)
        {
            try
            {
                var category = await _appDbContext.categories.FirstOrDefaultAsync(x => x.CategoryId == id);
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
                var categoryDetails = await _appDbContext.categories.FirstOrDefaultAsync(x => x.CategoryId == category.CategoryId);
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

        
    }
}
