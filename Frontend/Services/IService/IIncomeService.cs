using Assistans.Service.Frontend.Models.Dto;
using Frontend.Models;

namespace Frontend.Services.IService
{
    public interface IIncomeService
    {
        Task<ResponseDto?> GetAllIncomeByUserAsync();
        Task<ResponseDto?> GetIncomeByIdAsync(int id);
        Task<ResponseDto?> DeleteIncomeAsync(int id);
        Task<ResponseDto?> UpdateIncomeAsync(IncomeDto incomeDto);
        Task<ResponseDto?> CreateIncomeAsync(IncomeDto incomeDto);
    }
}
