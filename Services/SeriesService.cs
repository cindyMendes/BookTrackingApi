using BookTrackingApi.Context;
using BookTrackingApi.Data;
using BookTrackingApi.DTOs;
using BookTrackingApi.DTOs.Serie;
using Microsoft.EntityFrameworkCore;

namespace BookTrackingApi.Services
{
    public class SeriesService : ISeriesService
    {
        private readonly BookDbContext _dbContext;
        public SeriesService(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<MainResponse> GetAllSeries()
        {
            try
            {
                List<Serie> series = await _dbContext.Series.ToListAsync();

                if (series.Count == 0)
                {
                    return new MainResponse { Message = "No data found" };
                }
                else
                {
                    return new MainResponse { Content = series, Message = "Series retrieved successfully" };
                }
            }
            catch (Exception ex)
            {
                return new MainResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<MainResponse> GetSeriesById(int seriesId)
        {
            try
            {
                var series = await _dbContext.Series.Where(s => s.Id == seriesId).FirstOrDefaultAsync();

                if (series != null)
                {
                    return new MainResponse { Content = series, Message = "Series retrieved successfully" };
                }
                else
                {
                    return new MainResponse { IsSuccess = false, Message = "No series with this Id" };
                }
            }
            catch (Exception ex)
            {
                return new MainResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<MainResponse> AddSeries(AddSeriesDTO addSeries)
        {
            try
            {
                var seriesExixts = await _dbContext.Series.AnyAsync(s => s.Name.ToLower() == addSeries.Name.ToLower());

                if (seriesExixts)
                {
                    return new MainResponse { IsSuccess = false, Message = "Series already exists with this name" };
                }
                else
                {
                    await _dbContext.AddAsync(new Serie
                    {
                        Name = addSeries.Name,
                        IsFinished = addSeries.IsFinished
                    }) ;

                    await _dbContext.SaveChangesAsync();

                    return new MainResponse { Message = "Series added successfully" };
                }
            } 
            catch (Exception ex)
            {
                return new MainResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<MainResponse> UpdateSeries(UpdateSeriesDTO updateSeries)
        {
            try
            {
                var existingSeries = await _dbContext.Series.Where(c => c.Id == updateSeries.Id).FirstOrDefaultAsync();

                if (existingSeries != null)
                {
                    existingSeries.Name = updateSeries.Name;
                    existingSeries.IsFinished = updateSeries.IsFinished;
                    await _dbContext.SaveChangesAsync();

                    return new MainResponse { Message = "Series updated successfully" };
                }
                else
                {
                    return new MainResponse { IsSuccess = false, Message = "Series not found with this Id" };
                }
            }
            catch (Exception ex)
            {
                return new MainResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<MainResponse> DeleteSeries(int seriesId)
        {
            try
            {
                // Check if the series is used in the book table
                bool isSeriesUsedInBook = _dbContext.Books.Any(b => b.SerieId == seriesId);

                if (isSeriesUsedInBook)
                {
                    return new MainResponse { IsSuccess = false, Message = "Series cannot be deleted. (There is a book associated with this series)" };
                }
                else
                {
                    var existingSeries = await _dbContext.Series.Where(s => s.Id == seriesId).FirstOrDefaultAsync();

                    if (existingSeries != null)
                    {
                        _dbContext.Remove(existingSeries);
                        await _dbContext.SaveChangesAsync();

                        return new MainResponse { Message = "Series deleted successfully" };
                    }
                    else
                    {
                        return new MainResponse { IsSuccess = false, Message = "Series not found with this Id" };
                    }
                }
            }
            catch (Exception ex)
            {
                return new MainResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }


    }
}
