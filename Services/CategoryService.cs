﻿using BookTrackingApi.DTOs;
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



        public async Task<MainResponse> GetAllCategories()
        {
            try
            {
                List<Category> categories = await _dbContext.Categories.ToListAsync();

                if (categories.Count == 0)
                {
                    return new MainResponse { Message = "No data found" };
                }
                else
                {
                    return new MainResponse { Content = categories, Message = "Categories retrieved successfully" };
                }
            }
            catch (Exception ex)
            {
                return new MainResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
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

        public async Task<MainResponse> UpdateCategory(UpdateCategoryDTO updateCategory)
        {
            try
            {
                var existingCategory = await _dbContext.Categories.Where(c => c.Id == updateCategory.Id).FirstOrDefaultAsync();

                if (existingCategory != null)
                {
                    existingCategory.Name = updateCategory.Name;
                    await _dbContext.SaveChangesAsync();

                    return new MainResponse { Message = "Category updated successfully" };
                }
                else
                {
                    return new MainResponse { IsSuccess = false, Message = "Category not found with this Id" };
                }
            }
            catch (Exception ex)
            {
                return new MainResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<MainResponse> DeleteCategory(int id)
        {
            try
            {
                var existingCategory = await _dbContext.Champagnes.Where(c => c.Id == champagneId).FirstOrDefaultAsync();

                if (existingCategory != null)
                {
                    _dbContext.Remove(existingCategory);
                    await _dbContext.SaveChangesAsync();

                    return new MainResponse { Message = "Champagne deleted successfully" };
                }
                else
                {
                    return new MainResponse { IsSuccess = false, Message = "Champagne not found with this Id" };
                }
            }
            catch (Exception ex)
            {
                return new MainResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }


        
    }
}
