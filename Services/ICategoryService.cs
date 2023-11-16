using BookTrackingApi.DTOs;
using BookTrackingApi.DTOs.Category;

namespace BookTrackingApi.Services
{
    public interface ICategoryService
    {
        Task<MainResponse> GetAllCategories(); 
        Task<MainResponse> AddCategory(AddCategoryDTO addCategory); 
        Task<MainResponse> UpdateCategory(UpdateCategoryDTO updateCategory); 
        Task<MainResponse> DeleteCategory(int categoryId); 

    }
}
