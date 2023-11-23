using BookTrackingApi.Context;
using BookTrackingApi.Data;
using BookTrackingApi.DTOs;
using BookTrackingApi.DTOs.Book;
using Microsoft.EntityFrameworkCore;

namespace BookTrackingApi.Services
{
    public class BookService : IBookService
    {
        private readonly BookDbContext _dbContext;

        public BookService(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MainResponse> GetAllBooks()
        {
            try
            {
                List<Book> books = await _dbContext.Books.ToListAsync();

                if (books.Count == 0)
                {
                    return new MainResponse { Message = "No data found" };
                }
                else
                {
                    return new MainResponse { Content = books, Message = "Books retrieved successfully" };
                }
            }
            catch (Exception ex)
            {
                return new MainResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<MainResponse> GetBookById(int bookId)
        {
            try
            {
                var book = await _dbContext.Books.Where(b => b.Id == bookId).FirstOrDefaultAsync();

                if (book != null)
                {
                    return new MainResponse { Content = book, Message = "Book retrieved successfully" };
                }
                else
                {
                    return new MainResponse { IsSuccess = false, Message = "No book with this Id" };
                }
            }
            catch (Exception ex)
            {
                return new MainResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<MainResponse> AddBook(AddBookDTO addBook)
        {
            try
            {
                var bookExists = await _dbContext.Books.AnyAsync(b => b.Title.ToLower() == addBook.Title.ToLower());

                if (bookExists)
                {
                    return new MainResponse { IsSuccess = false, Message = "Book already exists with this title" };
                }
                else
                {
                    await _dbContext.AddAsync(new Book
                    {
                        Title = addBook.Title,
                        Description = addBook.Description,
                        PublishingDate = addBook.PublishingDate,
                        IsFavorite = addBook.IsFavorite,
                        IsRead = addBook.IsRead,
                        IsTBR = addBook.IsTBR,
                        SerieId = addBook.SerieId,
                    }) ;

                    await _dbContext.SaveChangesAsync();

                    return new MainResponse { Message = "Book added successfully" };
                }
            }
            catch (Exception ex)
            {
                return new MainResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<MainResponse> UpdateBook(UpdateBookDTO updateBook)
        {
            try
            {
                var existingBook = await _dbContext.Books.Where(b => b.Id == updateBook.Id).FirstOrDefaultAsync();

                if (existingBook != null)
                {
                    existingBook.Title = updateBook.Title;
                    existingBook.Description = updateBook.Description;
                    existingBook.PublishingDate = updateBook.PublishingDate;
                    existingBook.IsFavorite = updateBook.IsFavorite;
                    existingBook.IsRead = updateBook.IsRead;
                    existingBook.IsTBR = updateBook.IsTBR;
                    existingBook.SerieId = updateBook.SerieId;
                    await _dbContext.SaveChangesAsync();

                    return new MainResponse { Message = "Book updated successfully" };
                }
                else
                {
                    return new MainResponse { IsSuccess = false, Message = "Book not found with this Id" };
                }
            }
            catch (Exception ex)
            {
                return new MainResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<MainResponse> DeleteBook(int bookId)
        {
            try
            {
                var existingBook = await _dbContext.Books.Where(b => b.Id == bookId).FirstOrDefaultAsync();

                if (existingBook != null)
                {
                    _dbContext.Remove(existingBook);
                    await _dbContext.SaveChangesAsync();

                    return new MainResponse { Message = "Book deleted successfully" };
                }
                else
                {
                    return new MainResponse { IsSuccess = false, Message = "Book not found with this Id" };
                }
            }
            catch (Exception ex)
            {
                return new MainResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }
        
    }
}
