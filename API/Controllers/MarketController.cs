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
        IMarketProducts _imarketProducts;
        public List<Category> lstCategory { get; set; } = new List<Category>();
        public MarketController(IMarketApi imarketApi,IMarketProducts imarketProducts)
        {
            _imarketApi = imarketApi;
            _imarketProducts = imarketProducts;
        }
        [HttpGet("getallcategories")]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            try
            {
                lstCategory = await _imarketApi.GetCategories();
                if (lstCategory != null && lstCategory.Count > 0)
                {
                    return Ok(lstCategory);
                }
                else
                    return NotFound("Not found");
            }
            catch (Exception ex)
            {

                return null;
            }
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
        [HttpDelete("{id}")]

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                bool res = await _imarketApi.Delete(id);
                if (res)
                    return true;
                return false;

            }catch(Exception ex)
            {
                return false;
            }
        }
        //Getting product lists
        [HttpGet("products")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            try
            {
                var lstProducts = await _imarketProducts.GetProducts();
                if (lstProducts != null && lstProducts.Count > 0)
                    return Ok(lstProducts);
                return NotFound("Not Found");

            }catch(Exception ex)
            {
                return BadRequest("Something went wrong please try again later");
            }
        }
        [HttpPost("addproducts")]
        public async Task<bool> Addproducts(Product product)
        {
            bool flag = false;
            try
            {
                bool res = await _imarketProducts.AddProducts(product);
                if (res)
                    return flag = true;
                return flag;
            }
            catch(Exception ex)
            {
                return flag;
            }
        }
       [HttpPut("updateproducts")]
       public async Task<ActionResult<Product>> UpdateProduct(Product product)
        {
            try
            {
                var updatedProduct = await _imarketProducts.UpdateProduct(product);
                if (updatedProduct != null)
                    return Ok(updatedProduct);
                else
                    return NotFound("Not found!");


            }catch(Exception ex)
            {
                return BadRequest("Something went wrong please try again later!");
            }
        }
       
        [HttpGet("getprodbyid/{id}")]
        
        public async Task<ActionResult<Product>> GetProductsByid(int id)
        {
            try
            {
                var productData = await _imarketProducts.GetproductByid(id);
                if(productData != null)
                {
                    return Ok(productData);
                }
                else
                {
                    return Ok("Not found!");
                }

            }catch(Exception ex)
            {
                return BadRequest("Something went wrong please try again later!");
            }
        }
        [HttpDelete("deleteprod/{id}")]
        public async Task<bool> DeleteProd(int id)
        {
            try
            {
                bool result = await _imarketProducts.DeleteProd(id);
                return result;

            }catch(Exception ex)
            {
                return false;
            }
        }


    }
}
