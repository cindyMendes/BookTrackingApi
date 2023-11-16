using BookTrackingApi.DTOs;
using BookTrackingApi.DTOs.Category;

namespace BookTrackingApi.Services
{
    public interface ICategoryService
    {
        Task<MainResponse> AddCategory(AddCategoryDTO addCategory); 
    }
}
