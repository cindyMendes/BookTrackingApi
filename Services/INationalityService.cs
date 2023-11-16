using BookTrackingApi.DTOs.Nationality;
using BookTrackingApi.DTOs;

namespace BookTrackingApi.Services
{
    public interface INationalityService
    {
        Task<MainResponse> GetAllNationalities();
        Task<MainResponse> AddNationality(AddNationalityDTO addNationality);
        Task<MainResponse> UpdateNationality(UpdateNationalityDTO updateNationality);
        Task<MainResponse> DeleteNationality(int nationalalityId);

    }
}
