using BookTrackingApi.DTOs;
using BookTrackingApi.DTOs.Category;
using BookTrackingApi.Context;
using Microsoft.EntityFrameworkCore;
using BookTrackingApi.Data;

namespace BookTrackingApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly BookDbContext _dbContext;

        public CategoryService(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<MainResponse> AddCategory(AddCategoryDTO addCategory)
        {
            try
            {
                var categoryExists = await _dbContext.Categories.AnyAsync(c => c.Name.ToLower() == addCategory.Name.ToLower());

                if (categoryExists)
                {
                    return new MainResponse { IsSuccess = false, Message = "Category already exists with this name" };
                }
                else
                {
                    await _dbContext.AddAsync(new Category
                    {
                        Name = addCategory.Name
                    });

                    await _dbContext.SaveChangesAsync();

                    return new MainResponse { Message = "Category added successfully" };
                }
            }
            catch (Exception ex)
            {
                return new MainResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }
    }
}
