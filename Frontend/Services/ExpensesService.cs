using Assistans.Service.Frontend.Models.Dto;
using Frontend.Models;
using Frontend.Services.IService;
using Frontend.Utils;

namespace Frontend.Services
{
    public class ExpensesService : IExpensesService
    {
        private readonly IBaseService _baseService;

        public ExpensesService(IBaseService service)
        {
            _baseService = service;
        }

        public async Task<ResponseDto?> CreateExpensesAsync(ExpensesDto expensesDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Data = expensesDto,
                Url = SD.ExpensesAPIBase + "/api/expenses"
            });
        }

        public async Task<ResponseDto?> DeleteExpensesAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ExpensesAPIBase + "/api/expenses/" + id
            });
        }

        public async Task<ResponseDto?> GetAllExpensesByUserAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ExpensesAPIBase + "/api/expenses"
            });
        }

        public async Task<ResponseDto?> GetExpensesByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType= SD.ApiType.GET,
                Url = SD.ExpensesAPIBase + "/api/expenses/" + id
            });
        }

        public async Task<ResponseDto?> GetExpensesByIdCategory(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ExpensesAPIBase + "/api/expenses/category_id/" + id
            });
        }

        public async Task<ResponseDto?> UpdateExpensesAsync(ExpensesDto expensesDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = expensesDto,
                Url = SD.ExpensesAPIBase + "/api/expenses"
            });
        }
    }
}
