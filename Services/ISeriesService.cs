using BookTrackingApi.DTOs;
using BookTrackingApi.DTOs.Serie;
using System.Net.Mail;

namespace BookTrackingApi.Services
{
    public interface ISeriesService
    {
        Task<MainResponse> GetAllSeries();
        Task<MainResponse> GetSeriesById(int seriesId);
        Task<MainResponse> AddSeries(AddSeriesDTO addSeries);
        Task<MainResponse> UpdateSeries(UpdateSeriesDTO updateSeries);
        Task<MainResponse> DeleteSeries(int seriesId);

    }
}
