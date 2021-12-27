using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketController : ControllerBase
    {
         IMarketApi _imarketApi;
        public List<Category> lstCategory { get; set; } = new List<Category>();
        public MarketController(IMarketApi imarketApi)
        {
            _imarketApi = imarketApi;
        }
        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
           lstCategory= await  _imarketApi.GetCategories();
            if (lstCategory != null && lstCategory.Count > 0)
            {
                return Ok(lstCategory);
            }
            else
                return NotFound("Categories not found!");
        }
        [HttpPost]
        public async Task<ActionResult<Category>> AddCategory(Category category)
        {
            var result = await _imarketApi.AddCategory(category);
            if (result != null)
                return Ok(result);
            else
                return BadRequest("Failed to add");
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            try
            {
                var category = await _imarketApi.GetCategoryBYId(id);
                if (category != null)
                    return Ok(category);
                else
                    return NotFound("Category not found!");
            }catch(Exception ex)
            {
                return BadRequest("Something went wrong!");
            }
        }
        [HttpPut]
        public async Task<ActionResult<Category>> UpdateCategory(Category category)
        {
            try
            {
                var updatedCategory = await _imarketApi.Updatecategory(category);
                if (updatedCategory != null)
                    return Ok(updatedCategory);
                else
                    return NotFound("Failed to update");
            }catch(Exception ex)
            {
                return BadRequest("Something went wromg");
            }
        }

    }
}
