using BookTrackingApi.Data;
using BookTrackingApi.DTOs.Author;
using BookTrackingApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookTrackingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("GetAllAuthors")]
        public async Task<IActionResult> GetAllAuthors()
        {
            try
            {
                var response = await _authorService.GetAllAuthors();
                return Ok(response);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAuthorById/{authorId}")]
        public async Task<IActionResult> GetAuthorById(int authorId)
        {
            try
            {
                var response = await _authorService.GetAuthorById(authorId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddAuthor")]
        public async Task<IActionResult> AddAuthor([FromBody] AddAuthorDTO addAuthor)
        {
            try
            {
                var response = await _authorService.AddAuthor(addAuthor);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateAuthor")]
        public async Task<IActionResult> UpdateAuthor([FromBody] UpdateAuthorDTO updateAuthor)
        {
            try
            {
                if (updateAuthor.Id > 0)
                {
                    var response = await _authorService.UpdateAuthor(updateAuthor);
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

        [HttpDelete("DeleteAuthor/{authorId}")]
        public async Task<IActionResult> DeleteAuthor(int authorId)
        {
            try
            {
                if (authorId > 0)
                {
                    var response = await _authorService.DeleteAuthor(authorId);
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
