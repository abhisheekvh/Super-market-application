using SharedClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IMarketApi
    {
        Task<List<Category>> GetCategories();
        Task<Category> AddCategory(Category category);
        Task<Category> Updatecategory(Category category);
        Task<Category> GetCategoryBYId(int id);
        Task<bool> Delete(int id);
    }
}
