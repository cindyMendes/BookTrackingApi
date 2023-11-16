using BookTrackingApi.DTOs.Nationality;
using BookTrackingApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookTrackingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NationalityController : ControllerBase
    {
        private readonly INationalityService _nationalityService;

        public NationalityController(INationalityService nationalityService)
        {
            _nationalityService = nationalityService;
        }



        [HttpGet("GetAllNationalities")]
        public async Task<IActionResult> GetAllNationalities()
        {
            try
            {
                var response = await _nationalityService.GetAllNationalities();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddNationality")]
        public async Task<IActionResult> AddNationality([FromBody] AddNationalityDTO addNationality)
        {
            try
            {
                var response = await _nationalityService.AddNationality(addNationality);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateNationality")]
        public async Task<IActionResult> UpdateNationality([FromBody] UpdateNationalityDTO updateNationality)
        {
            try
            {
                if (updateNationality.Id > 0)
                {
                    var response = await _nationalityService.UpdateNationality(updateNationality);
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

        [HttpDelete("DeleteNationality/{categoryId}")]
        public async Task<IActionResult> DeleteNationality(int nationalityId)
        {
            try
            {
                if (nationalityId > 0)
                {
                    var response = await _nationalityService.DeleteNationality(nationalityId);
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
