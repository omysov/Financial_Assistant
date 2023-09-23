using Assistans.Service.Frontend.Models.Dto;
using Frontend.Models;

namespace Frontend.Services.IService
{
    public interface ICategoryService
    {

        Task<ResponseDto?> GetAllCategoryUserAsync();
        Task<ResponseDto?> GetCategoryByIdAsync(int id);
        Task<ResponseDto?> CreateCategoryAsync(CategoryDto categoryDto);
        Task<ResponseDto?> UpdateCategoryAsync(CategoryDto categoryDto);
        Task<ResponseDto?> DeleteCategoryAsync(int id);

    }
}
