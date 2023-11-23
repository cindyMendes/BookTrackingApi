using BookTrackingApi.DTOs.Book;
using BookTrackingApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookTrackingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }



        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var response = await _bookService.GetAllBooks();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetBookById/{bookId}")]
        public async Task<IActionResult> GetBookById(int bookId)
        {
            try
            {
                var response = await _bookService.GetBookById(bookId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook([FromBody] AddBookDTO addBook)
        {
            try
            {
                var response = await _bookService.AddBook(addBook);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateBook")]
        public async Task<IActionResult> UpdateBook([FromBody] UpdateBookDTO updateBook)
        {
            try
            {
                if (updateBook.Id > 0)
                {
                    var response = await _bookService.UpdateBook(updateBook);
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

        [HttpDelete("DeleteBook/{bookId}")]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            try
            {
                if (bookId > 0)
                {
                    var response = await _bookService.DeleteBook(bookId);
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
