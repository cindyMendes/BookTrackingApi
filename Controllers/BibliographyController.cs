using BookTrackingApi.Data;
using BookTrackingApi.DTOs.Bibliography;
using BookTrackingApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookTrackingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibliographyController : ControllerBase
    {
        private readonly IBibliographyService _bibliographyService;

        public BibliographyController(IBibliographyService bibliographyService)
        {
            _bibliographyService = bibliographyService;
        }



        [HttpGet("GetAllBibliographies")]
        public async Task<IActionResult> GetAllBibliographies()
        {
            try
            {
                var response = await _bibliographyService.GetAllBibliographies();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetBibliographyById/{bibliographyId}")]
        public async Task<IActionResult> GetBibliographyById(int bibliographyId)
        {
            try
            {
                var response = await _bibliographyService.GetBibliographyById(bibliographyId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddBibliography")]
        public async Task<IActionResult> AddBibliography([FromBody] AddBibliographyDTO addBibliography)
        {
            try
            {
                var response = await _bibliographyService.AddBibliography(addBibliography);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateBibliography")]
        public async Task<IActionResult> UpdateBibliography([FromBody] UpdateBibliographyDTO updateBibliography)
        {
            try
            {
                if (updateBibliography.Id > 0)
                {
                    var response = await _bibliographyService.UpdateBibliography(updateBibliography);
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

        [HttpDelete("DeleteBibliography/{bibliographyId}")]
        public async Task<IActionResult> DeleteBibliography(int bibliographyId)
        {
            try
            {
                if (bibliographyId > 0)
                {
                    var response = await _bibliographyService.DeleteBibliography(bibliographyId);
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
