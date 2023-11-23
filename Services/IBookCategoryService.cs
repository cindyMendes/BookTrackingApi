using BookTrackingApi.DTOs.BookCategory;
using BookTrackingApi.DTOs;

namespace BookTrackingApi.Services
{
    public interface IBookCategoryService
    {
        Task<MainResponse> GetAllBooksCategories();
        Task<MainResponse> GetBookCategoryById(int bookCategoryId);
        Task<MainResponse> AddBookCategory(AddBookCategoryDTO addBookCategory);
        Task<MainResponse> UpdateBookCategory(UpdateBookCategoryDTO updateBookCategory);
        Task<MainResponse> DeleteBookCategory(int bookCategoryId);
    }
}
