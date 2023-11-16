using BookTrackingApi.Context;
using BookTrackingApi.Data;
using BookTrackingApi.DTOs;
using BookTrackingApi.DTOs.Nationality;
using Microsoft.EntityFrameworkCore;

namespace BookTrackingApi.Services
{
    public class NationalityService : INationalityService
    {
        private readonly BookDbContext _dbContext;

        public NationalityService(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<MainResponse> GetAllNationalities()
        {
            try
            {
                List<Nationality> nationalities = await _dbContext.Nationalities.ToListAsync();

                if (nationalities.Count == 0)
                {
                    return new MainResponse { Message = "No data found" };
                }
                else
                {
                    return new MainResponse { Content = nationalities, Message = "Nationalitites retrieved successfully" };
                }
            }
            catch (Exception ex)
            {
                return new MainResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<MainResponse> AddNationality(AddNationalityDTO addNationality)
        {
            try
            {
                var nationalityExists = await _dbContext.Nationalities.AnyAsync(n => n.Name.ToLower() == addNationality.Name.ToLower());

                if (nationalityExists)
                {
                    return new MainResponse { IsSuccess = false, Message = "Nationality already exists with this name" };
                }
                else
                {
                    await _dbContext.AddAsync(new Nationality
                    {
                        Name = addNationality.Name
                    });

                    await _dbContext.SaveChangesAsync();

                    return new MainResponse { Message = "Nationality added successfully" };
                }
            }
            catch (Exception ex)
            {
                return new MainResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<MainResponse> UpdateNationality(UpdateNationalityDTO updateNationality)
        {
            try
            {
                var existingNationality = await _dbContext.Nationalities.Where(n => n.Id == updateNationality.Id).FirstOrDefaultAsync();

                if (existingNationality != null)
                {
                    existingNationality.Name = updateNationality.Name;
                    await _dbContext.SaveChangesAsync();

                    return new MainResponse { Message = "Nationality updated successfully" };
                }
                else
                {
                    return new MainResponse { IsSuccess = false, Message = "Nationality not found with this Id" };
                }
            }
            catch (Exception ex)
            {
                return new MainResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<MainResponse> DeleteNationality(int nationalalityId)
        {
            try
            {
                var existingNationality = await _dbContext.Nationalities.Where(n => n.Id == nationalalityId).FirstOrDefaultAsync();

                if (existingNationality != null)
                {
                    _dbContext.Remove(existingNationality);
                    await _dbContext.SaveChangesAsync();

                    return new MainResponse { Message = "Nationality deleted successfully" };
                }
                else
                {
                    return new MainResponse { IsSuccess = false, Message = "Nationality not found with this Id" };
                }
            }
            catch (Exception ex)
            {
                return new MainResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }

    }
}
