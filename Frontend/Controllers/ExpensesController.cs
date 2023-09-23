using Assistans.Service.Frontend.Models.Dto;
using Frontend.Models;
using Frontend.Models.Dto;
using Frontend.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Frontend.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpensesService _expensesService;
        private readonly ICategoryService _categoryService;

        public ExpensesController(IExpensesService expensesService, ICategoryService categoryService)
        {
            _expensesService = expensesService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> AllExpenses()
        {
            List<ExpensesItemListDto> list = new();

            ResponseDto? responseExpenses = await _expensesService.GetAllExpensesByUserAsync();
            ResponseDto? responseCategory = await _categoryService.GetAllCategoryUserAsync();
            if((responseExpenses.IsSuccess = true) & (responseCategory.IsSuccess = true))
            {
                IEnumerable<ExpensesDto> listExpenses = JsonConvert.DeserializeObject<IEnumerable<ExpensesDto>>(Convert.ToString(responseExpenses.Result));
                IEnumerable<CategoryDto> listCategories = JsonConvert.DeserializeObject<IEnumerable<CategoryDto>>(Convert.ToString(responseCategory.Result));

                foreach(var expenses in listExpenses)
                {
                    list.Add(new ExpensesItemListDto()
                    {
                        ExpensesId = expenses.ExpensesId,
                        CategoryId = expenses.CategoryId,
                        UserId = expenses.UserId,
                        CategoryName = listCategories.First(u => u.Id == expenses.CategoryId).Name,
                        Date = expenses.Date,
                        Count = expenses.Count,
                        Description = expenses.Description
                    });
                }
            }
            return View(list);
        }


        public async Task<ActionResult> AddExpenses()
        {
            ResponseDto response = await _categoryService.GetAllCategoryUserAsync();
            List<CategoryDto> listCategories = JsonConvert.DeserializeObject<List<CategoryDto>>(Convert.ToString(response.Result));

            ViewBag.Message = listCategories;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddExpenses([FromBody] ExpensesDto expensesDto)
        {

            return View();
        }
    }
}
