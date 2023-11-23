using BookTrackingApi.DTOs.Book;
using BookTrackingApi.DTOs.BookCategory;
using BookTrackingApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookTrackingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCategoryController : ControllerBase
    {
        private readonly IBookCategoryService _bookCategoryService;

        public BookCategoryController(IBookCategoryService bookCategoryService)
        {
            _bookCategoryService = bookCategoryService;
        }



        [HttpGet("GetAllBooksCategories")]
        public async Task<IActionResult> GetAllBooksCategories()
        {
            try
            {
                var response = await _bookCategoryService.GetAllBooksCategories();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetBookCategoryById/{bookCategoryId}")]
        public async Task<IActionResult> GetBookCategoryById(int bookCategoryId)
        {
            try
            {
                var response = await _bookCategoryService.GetBookCategoryById(bookCategoryId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddBookCategory")]
        public async Task<IActionResult> AddBookCategory([FromBody] AddBookCategoryDTO addBookCategory)
        {
            try
            {
                var response = await _bookCategoryService.AddBookCategory(addBookCategory);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateBookCategory")]
        public async Task<IActionResult> UpdateBookCategory([FromBody] UpdateBookCategoryDTO updateBookCategory)
        {
            try
            {
                if (updateBookCategory.Id > 0)
                {
                    var response = await _bookCategoryService.UpdateBookCategory(updateBookCategory);
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

        [HttpDelete("DeleteBookCategory/{bookCategoryId}")]
        public async Task<IActionResult> DeleteBookCategory(int bookCategoryId)
        {
            try
            {
                if (bookCategoryId > 0)
                {
                    var response = await _bookCategoryService.DeleteBookCategory(bookCategoryId);
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
