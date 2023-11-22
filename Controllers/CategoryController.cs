using BookTrackingApi.DTOs.Category;
using BookTrackingApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookTrackingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }



        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var response = await _categoryService.GetAllCategories();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCategoryById/{categoryId}")]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            try
            {
                var response = await _categoryService.GetCategoryById(categoryId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryDTO addCategory)
        {
            try
            {
                var response = await _categoryService.AddCategory(addCategory);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDTO updateCategory)
        {
            try
            {
                if (updateCategory.Id > 0)
                {
                    var response = await _categoryService.UpdateCategory(updateCategory);
                    return Ok(response);
                }
                else
                {
                    return BadRequest("Please enter a correct Id");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteCategory/{categoryId}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            try
            {
                if (categoryId > 0)
                {
                    var response = await _categoryService.DeleteCategory(categoryId);
                    return Ok(response);
                }
                else
                {
                    return BadRequest("Please enter a correct Id");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
