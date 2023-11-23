using BookTrackingApi.Context;
using BookTrackingApi.Data;
using BookTrackingApi.DTOs;
using BookTrackingApi.DTOs.BookCategory;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BookTrackingApi.Services
{
    public class BookCategoryService : IBookCategoryService
    {
        private readonly BookDbContext _dbContext;

        public BookCategoryService(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<MainResponse> GetAllBooksCategories()
        {
            try
            {
                List<BookCategory> booksCategories = await _dbContext.BooksCategories.ToListAsync();

                if (booksCategories.Count == 0)
                {
                    return new MainResponse { Message = "No data found" };
                }
                else
                {
                    return new MainResponse { Content = booksCategories, Message = "BooksCategories retrieved successfully" };
                }
            }
            catch (Exception ex)
            {
                return new MainResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<MainResponse> GetBookCategoryById(int bookCategoryId)
        {
            try
            {
                var bookCategory = await _dbContext.BooksCategories.Where(b => b.Id == bookCategoryId).FirstOrDefaultAsync();

                if (bookCategory != null)
                {
                    return new MainResponse { Content = bookCategory, Message = "BookCategory retrieved successfully" };
                }
                else
                {
                    return new MainResponse { IsSuccess = false, Message = "No bookCategory with this Id" };
                }
            }
            catch (Exception ex)
            {
                return new MainResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<MainResponse> AddBookCategory(AddBookCategoryDTO addBookCategory)
        {
            try
            {
                var bookCategoryExists = await _dbContext.BooksCategories.AnyAsync(
                                b => b.BookId == addBookCategory.BookId && b.CategoryId == addBookCategory.CategoryId);

                if (bookCategoryExists)
                {
                    return new MainResponse { IsSuccess = false, Message = "BookCategory already exists with this book and category" };
                }
                else
                {
                    await _dbContext.AddAsync(new BookCategory
                    {
                        BookId = addBookCategory.BookId,
                        CategoryId = addBookCategory.CategoryId,
                    });

                    await _dbContext.SaveChangesAsync();

                    return new MainResponse { Message = "BookCategory added successfully" };
                }
            }
            catch (Exception ex)
            {
                return new MainResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<MainResponse> UpdateBookCategory(UpdateBookCategoryDTO updateBookCategory)
        {
            try
            {
                var existingBookCategory = await _dbContext.BooksCategories.Where(b => b.Id == updateBookCategory.Id).FirstOrDefaultAsync();

                if (existingBookCategory != null)
                {
                    existingBookCategory.BookId = updateBookCategory.BookId;
                    existingBookCategory.CategoryId = updateBookCategory.CategoryId;
                    await _dbContext.SaveChangesAsync();

                    return new MainResponse { Message = "BookCategory updated successfully" };
                }
                else
                {
                    return new MainResponse { IsSuccess = false, Message = "BookCategory not found with this Id" };
                }
            }
            catch (Exception ex)
            {
                return new MainResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<MainResponse> DeleteBookCategory(int bookCategoryId)
        {
            try
            {
                var existingBookCategory = await _dbContext.BooksCategories.Where(b => b.Id == bookCategoryId).FirstOrDefaultAsync();

                if (existingBookCategory != null)
                {
                    _dbContext.Remove(existingBookCategory);
                    await _dbContext.SaveChangesAsync();

                    return new MainResponse { Message = "BookCategory deleted successfully" };
                }
                else
                {
                    return new MainResponse { IsSuccess = false, Message = "BookCategory not found with this Id" };
                }
            }
            catch (Exception ex)
            {
                return new MainResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }
        
    }
}
