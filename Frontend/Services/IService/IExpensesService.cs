using Assistans.Service.Frontend.Models.Dto;
using Frontend.Models;

namespace Frontend.Services.IService
{
    public interface IExpensesService
    {
        Task<ResponseDto?> GetAllExpensesByUserAsync();
        Task<ResponseDto?> GetExpensesByIdAsync(int id);
        Task<ResponseDto?> CreateExpensesAsync(ExpensesDto expensesDto);
        Task<ResponseDto?> UpdateExpensesAsync(ExpensesDto expensesDto);
        Task<ResponseDto?> DeleteExpensesAsync(int id);
        Task<ResponseDto?> GetExpensesByIdCategory (int id);

    }
}
