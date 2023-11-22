using BookTrackingApi.DTOs.Serie;
using BookTrackingApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookTrackingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly ISeriesService _seriesService;

        public SeriesController(ISeriesService seriesService)
        {
            _seriesService = seriesService;
        }



        [HttpGet("GetAllSeries")]
        public async Task<IActionResult> GetAllSeries()
        {
            try
            {
                var response = await _seriesService.GetAllSeries();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetSeriesById")]
        public async Task<IActionResult> GetSeriesById(int seriesId)
        {
            try
            {
                var response = await _seriesService.GetSeriesById(seriesId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddSeries")]
        public async Task<IActionResult> AddSeries([FromBody] AddSeriesDTO addSeries)
        {
            try
            {
                var response = await _seriesService.AddSeries(addSeries);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateSeries")]
        public async Task<IActionResult> UpdateSeries([FromBody] UpdateSeriesDTO updateSeries)
        {
            try
            {
                if (updateSeries.Id > 0)
                {
                    var response = await _seriesService.UpdateSeries(updateSeries);
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

        [HttpDelete("DeleteSeries/{seriesId}")]
        public async Task<IActionResult> DeleteSeries(int seriesId)
        {
            try
            {
                if (seriesId > 0)
                {
                    var response = await _seriesService.DeleteSeries(seriesId);
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
