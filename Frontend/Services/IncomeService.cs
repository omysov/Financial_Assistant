using Assistans.Service.Frontend.Models.Dto;
using Frontend.Controllers;
using Frontend.Models;
using Frontend.Services.IService;
using Frontend.Utils;

namespace Frontend.Services
{
    public class IncomeService : IIncomeService
    {
        private readonly IBaseService _baseService;

        public IncomeService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async  Task<ResponseDto?> CreateIncomeAsync(IncomeDto incomeDto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.POST,
                Data = incomeDto,
                Url = SD.IncomeAPIBase + "/api/income"
            });
        }

        public async Task<ResponseDto?> DeleteIncomeAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.IncomeAPIBase + "/api/income/" + id
            });
        }

        public async Task<ResponseDto?> GetAllIncomeByUserAsync()
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.IncomeAPIBase + "/api/income"
            });
        }

        public async Task<ResponseDto?> GetIncomeByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType= SD.ApiType.GET,
                Url = SD.IncomeAPIBase + "/api/income/" + id
            });
        }

        public async Task<ResponseDto?> UpdateIncomeAsync(IncomeDto incomeDto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.PUT,
                Data = incomeDto,
                Url = SD.IncomeAPIBase + "/api/income"
            });
        }
    }
}
