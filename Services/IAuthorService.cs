using BookTrackingApi.DTOs;
using BookTrackingApi.DTOs.Author;
using System.Data.Entity.Core.Mapping;

namespace BookTrackingApi.Services
{
    public interface IAuthorService
    {
        Task<MainResponse> GetAllAuthors();
        Task<MainResponse> GetAuthorById(int authorId);
        Task<MainResponse> AddAuthor(AddAuthorDTO addAuthor);
        Task<MainResponse> UpdateAuthor(UpdateAuthorDTO updateAuthor);
        Task<MainResponse> DeleteAuthor(int authorId);
    }
}
