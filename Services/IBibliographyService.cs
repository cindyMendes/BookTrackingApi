using BookTrackingApi.DTOs.Bibliography;
using BookTrackingApi.DTOs;

namespace BookTrackingApi.Services
{
    public interface IBibliographyService
    {
        Task<MainResponse> GetAllBibliographies();
        Task<MainResponse> GetBibliographyById(int bibliographyId);
        Task<MainResponse> AddBibliography(AddBibliographyDTO addBibliography);
        Task<MainResponse> UpdateBibliography(UpdateBibliographyDTO updateBibliography);
        Task<MainResponse> DeleteBibliography(int bibliographyId);
    }
}
