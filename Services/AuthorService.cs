using BookTrackingApi.Context;
using BookTrackingApi.Data;
using BookTrackingApi.DTOs;
using BookTrackingApi.DTOs.Author;
using Microsoft.EntityFrameworkCore;

namespace BookTrackingApi.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly BookDbContext _dbContext;

        public AuthorService(BookDbContext dbContext)
        {
            _dbContext = dbContext; 
        }



        public async Task<MainResponse> GetAllAuthors()
        {
            try
            {
                List<Author> authors = await _dbContext.Authors.ToListAsync();

                if (authors.Count == 0 )
                {
                    return new MainResponse { Content = authors, Message = "No data found" };
                }
                else
                {
                    return new MainResponse { Content = authors, Message = "Authors retrieved successfully" };
                }
            }
            catch (Exception ex)
            {
                return new MainResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<MainResponse> GetAuthorById(int authorId)
        {
            try
            {
                var author = await _dbContext.Authors.Where(a => a.Id == authorId).FirstOrDefaultAsync();

                if (author != null)
                {
                    return new MainResponse { Content = author, Message = "Author retrieved successfully" };
                }
                else
                {
                    return new MainResponse { IsSuccess = false, Message = "No author with this Id" };
                }
            }
            catch (Exception ex)
            {
                return new MainResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<MainResponse> AddAuthor(AddAuthorDTO addAuthor)
        {
            try
            {
                var authorExists = await _dbContext.Authors.AnyAsync(
                    a => a.FirstName.ToLower() == addAuthor.FirstName.ToLower() 
                      && a.MiddleName.ToLower() == addAuthor.MiddleName.ToLower() 
                      && a.LastName.ToLower() == addAuthor.LastName.ToLower());

                if (authorExists)
                {
                    return new MainResponse { IsSuccess = false, Message = "Author already exists with this name" };
                }
                else
                {
                    await _dbContext.AddAsync(new Author
                    {
                        FirstName = addAuthor.FirstName,
                        MiddleName = addAuthor.MiddleName,
                        LastName = addAuthor.LastName,
                        Birthday = addAuthor.Birthday,
                        NationalityId = addAuthor.NationalityId,
                    });

                    await _dbContext.SaveChangesAsync();

                    return new MainResponse { Message = "Author added successfully" };
                }
            }
            catch (Exception ex)
            {
                return new MainResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<MainResponse> UpdateAuthor(UpdateAuthorDTO updateAuthor)
        {
            try
            {
                var existingAuthor = await _dbContext.Authors.Where(a => a.Id == updateAuthor.Id).FirstOrDefaultAsync();

                if (existingAuthor != null)
                {
                    existingAuthor.FirstName = updateAuthor.FirstName;
                    existingAuthor.MiddleName = updateAuthor.MiddleName;
                    existingAuthor.LastName = updateAuthor.LastName;
                    existingAuthor.Birthday = updateAuthor.Birthday;
                    existingAuthor.NationalityId = updateAuthor.NationalityId;
                    await _dbContext.SaveChangesAsync();

                    return new MainResponse { Message = "Author updated successfully" };
                }
                else
                {
                    return new MainResponse { IsSuccess = false, Message = "Author not found with this Id" };
                }
            }
            catch (Exception ex)
            {
                return new MainResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<MainResponse> DeleteAuthor(int authorId)
        {
            try
            {
                // Check if the author has books associated 
                bool isAuthorUsedInBook = _dbContext.Bibliographies.Any(b => b.AuthorId == authorId);

                if (isAuthorUsedInBook)
                {
                    return new MainResponse { IsSuccess = false, Message = "Author cannot be deleted. (There is a book associated with this author)" };
                }
                else
                {
                    var existingAuthor = await _dbContext.Authors.Where(a => a.Id == authorId).FirstOrDefaultAsync();

                    if (existingAuthor != null)
                    {
                        _dbContext.Remove(existingAuthor);
                        await _dbContext.SaveChangesAsync();

                        return new MainResponse { Message = "Author deleted successfully" };
                    }
                    else
                    {
                        return new MainResponse { IsSuccess = false, Message = "Author not found with this Id" };
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
