using Assistans.Service.Frontend.Models.Dto;
using Frontend.Models;
using Frontend.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Frontend.Controllers
{
    public class IncomeController : Controller
    {
        private readonly IIncomeService _incomeService;

        public IncomeController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }

        public async Task<IActionResult> AllIncome()
        {
            // Невозможно добавить income если нет ни одной записи. Перекидывает на Login
            List<IncomeDto> list = new();

            ResponseDto? response = await _incomeService.GetAllIncomeByUserAsync();
            if (response.Result != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<IncomeDto>>(Convert.ToString(response.Result));

                return View(list);
            }

            return View(list);
        }

        public IActionResult CreateIncome()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateIncome(IncomeDto incomeDto)
        {
            ResponseDto? response = await _incomeService.CreateIncomeAsync(incomeDto);

            if(response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(AllIncome));
            }

            return View();
        }

        public async Task<IActionResult> DeleteIncome(int income_id)
        {
            ResponseDto? response = await _incomeService.GetIncomeByIdAsync(income_id);
            IncomeDto income = JsonConvert.DeserializeObject<IncomeDto>(Convert.ToString(response.Result));

            return View(income);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteIncome(IncomeDto incomeDto)
        {
            ResponseDto response = await _incomeService.DeleteIncomeAsync(incomeDto.IncomeId);

            if(response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(AllIncome));
            }

            return View();
        }


        public async Task<IActionResult> UpdateIncomeAsync(int income_id)
        {
            ResponseDto? response = await _incomeService.GetIncomeByIdAsync(income_id);
            IncomeDto income = JsonConvert.DeserializeObject<IncomeDto>(Convert.ToString(response.Result));

            return View(income);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateIncome(IncomeDto incomeDto)
        {
            ResponseDto response = await _incomeService.UpdateIncomeAsync(incomeDto);

            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(AllIncome));
            }

            return View();
        }
    }
}
