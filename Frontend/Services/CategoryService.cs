using Assistans.Service.Frontend.Models.Dto;
using Frontend.Models;
using Frontend.Services.IService;
using Frontend.Utils;

namespace Frontend.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IBaseService _baseService;

        public CategoryService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateCategoryAsync(CategoryDto categoryDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = categoryDto,
                Url = SD.ExpensesAPIBase + "/api/expenses/categories"
            });
        }

        public async Task<ResponseDto?> DeleteCategoryAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ExpensesAPIBase + "/api/expenses/category" + id
            });
        }

        public async Task<ResponseDto?> GetAllCategoryUserAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ExpensesAPIBase + "/api/expenses/categories"
            });
        }

        public async Task<ResponseDto?> GetCategoryByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ExpensesAPIBase + "/api/expenses/categories" + id
            });
        }

        public async Task<ResponseDto?> UpdateCategoryAsync(CategoryDto categoryDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,   
                Data = categoryDto,
                Url = SD.ExpensesAPIBase + "/api/expenses/categories"
            });
        }
    }
}
