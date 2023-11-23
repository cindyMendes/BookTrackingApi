using BookTrackingApi.DTOs;
using BookTrackingApi.DTOs.Book;

namespace BookTrackingApi.Services
{
    public interface IBookService
    {
        Task<MainResponse> GetAllBooks();
        Task<MainResponse> GetBookById(int bookId);
        Task<MainResponse> AddBook(AddBookDTO addBook);
        Task<MainResponse> UpdateBook(UpdateBookDTO updateBook);
        Task<MainResponse> DeleteBook(int bookId);
    }
}
