using SharedClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketManagement.Services
{
    public interface ImarketClient
    {
        Task<List<Category>> GetCategories();
        Task<Category> AddCategory(Category category);
        Task<Category> GetCategoryById(int categoryId);
        Task<Category> UpdateCategory(Category category);
        Task<bool> Delete(int id);
    }
}
