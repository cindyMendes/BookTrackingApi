using BookTrackingApi.Context;
using BookTrackingApi.Data;
using BookTrackingApi.DTOs;
using BookTrackingApi.DTOs.Bibliography;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace BookTrackingApi.Services
{
    public class BibliographyService : IBibliographyService
    {
        private readonly BookDbContext _dbContext;

        public BibliographyService(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<MainResponse> GetAllBibliographies()
        {
            try
            {
                List<Bibliography> booksAuthors = await _dbContext.Bibliographies.ToListAsync();

                if (booksAuthors.Count == 0)
                {
                    return new MainResponse { Message = "No data found" };
                }
                else
                {
                    return new MainResponse { Content = booksAuthors, Message = "Bibliographies retrieved successfully" };
                }
            }
            catch (Exception ex)
            {
                return new MainResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<MainResponse> GetBibliographyById(int bibliographyId)
        {
            try
            {
                var bibliography = await _dbContext.Bibliographies.Where(b => b.Id == bibliographyId).FirstOrDefaultAsync();

                if (bibliography != null)
                {
                    return new MainResponse { Content = bibliography, Message = "Bibliography retrieved successfully" };
                }
                else
                {
                    return new MainResponse { IsSuccess = false, Message = "No bibliography with this Id" };
                }
            }
            catch (Exception ex)
            {
                return new MainResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<MainResponse> AddBibliography(AddBibliographyDTO addBibliography)
        {
            try
            {
                var bibliographyExists = await _dbContext.Bibliographies.AnyAsync(
                            b => b.BookId == addBibliography.BookId && b.AuthorId == addBibliography.AuthorId);

                if (bibliographyExists)
                {
                    return new MainResponse { IsSuccess = false, Message = "Bibliography already exists with this author and book" };
                }
                else
                {
                    await _dbContext.AddAsync(new Bibliography
                    {
                        BookId = addBibliography.BookId,
                        AuthorId = addBibliography.AuthorId
                    });

                    await _dbContext.SaveChangesAsync();

                    return new MainResponse { Message = "Bibliography added successfully" };
                }
            }
            catch (Exception ex)
            {
                return new MainResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<MainResponse> UpdateBibliography(UpdateBibliographyDTO updateBibliography)
        {
            try
            {
                var existingBibliography = await _dbContext.Bibliographies.Where(b => b.Id == updateBibliography.Id).FirstOrDefaultAsync();

                if (existingBibliography != null)
                {
                    existingBibliography.BookId = updateBibliography.BookId;
                    existingBibliography.AuthorId = updateBibliography.AuthorId;
                    await _dbContext.SaveChangesAsync();

                    return new MainResponse { Message = "Bibliography updated successfully" };
                }
                else
                {
                    return new MainResponse { IsSuccess = false, Message = "Bibliography not found with this Id" };
                }
            }
            catch (Exception ex)
            {
                return new MainResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }

        public async Task<MainResponse> DeleteBibliography(int bibliographyId)
        {
            try
            {
                var existingBibliography = await _dbContext.Bibliographies.Where(b => b.Id == bibliographyId).FirstOrDefaultAsync();

                if (existingBibliography != null)
                {
                    _dbContext.Remove(existingBibliography);
                    await _dbContext.SaveChangesAsync();

                    return new MainResponse { Message = "Bibliography deleted successfully" };
                }
                else
                {
                    return new MainResponse { IsSuccess = false, Message = "Bibliography not found with this Id" };
                }
            }
            catch (Exception ex)
            {
                return new MainResponse { IsSuccess = false, Message = $"Error: {ex.Message}" };
            }
        }
    }
}
