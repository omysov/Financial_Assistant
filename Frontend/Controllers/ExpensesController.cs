using Assistans.Service.Frontend.Models.Dto;
using Frontend.Models;
using Frontend.Models.Dto;
using Frontend.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Frontend.Controllers
{
    //[Authorize]
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


        public async Task<ActionResult> AddExpenses(int category_id)
        {
            ResponseDto? response = await _categoryService.GetCategoryByIdAsync(category_id);
            //List<CategoryDto> listCategories = JsonConvert.DeserializeObject<List<CategoryDto>>(Convert.ToString(response.Result));

            if (response != null && response.IsSuccess)
            {
                CategoryDto category = JsonConvert.DeserializeObject<CategoryDto>(Convert.ToString(response.Result));
                ExpensesItemListDto expensesItemList = new ExpensesItemListDto()
                {
                    UserId = category.UserId,
                    CategoryName = category.Name,
                    CategoryId = category.Id,
                };
                return View(expensesItemList);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> AddExpenses([FromForm]ExpensesItemListDto expensesItemList)
        {

                ExpensesDto model = new ExpensesDto()
                {
                    CategoryId = expensesItemList.CategoryId,
                    Date = expensesItemList.Date,
                    Count = expensesItemList.Count,
                    Description = expensesItemList.Description
                };

                ResponseDto? response = await _expensesService.CreateExpensesAsync(model);

                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction("Index", "Home");
                }

            return View(expensesItemList);
        }

        public async Task<ActionResult> DeleteExpenses(int expenses_id)
        {
            ResponseDto? response = await _expensesService.GetExpensesByIdAsync(expenses_id);

            if(response != null && response.IsSuccess)
            {
                ExpensesDto? model = JsonConvert.DeserializeObject<ExpensesDto>(Convert.ToString(response.Result));

                ResponseDto? category = await _categoryService.GetCategoryByIdAsync(model.CategoryId);
				CategoryDto? category_model = JsonConvert.DeserializeObject<CategoryDto>(Convert.ToString(category.Result));

				ExpensesItemListDto expensesItemList = new ExpensesItemListDto()
				{
					UserId = category_model.UserId,
					CategoryName = category_model.Name,
					CategoryId = category_model.Id,
                    Count = model.Count,
                    Date = model.Date,
                    ExpensesId = model.ExpensesId,
                    Description = model.Description
				};

				return View(expensesItemList);
            }
            return NotFound();
        }

        [HttpPost]
		public async Task<ActionResult> DeleteExpenses([FromForm] ExpensesItemListDto expensesItemList)
		{
            ResponseDto? response = await _expensesService.DeleteExpensesAsync(expensesItemList.ExpensesId);

            if(response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(AllExpenses));
            }
            return View(expensesItemList);
		}

		public async Task<ActionResult> UpdateExpenses(int expenses_id)
		{
			ResponseDto? response = await _expensesService.GetExpensesByIdAsync(expenses_id);

			if (response != null && response.IsSuccess)
			{
				ExpensesDto? model = JsonConvert.DeserializeObject<ExpensesDto>(Convert.ToString(response.Result));

				ResponseDto? category = await _categoryService.GetCategoryByIdAsync(model.CategoryId);
				CategoryDto? category_model = JsonConvert.DeserializeObject<CategoryDto>(Convert.ToString(category.Result));

				ExpensesItemListDto expensesItemList = new ExpensesItemListDto()
				{
					UserId = category_model.UserId,
					CategoryName = category_model.Name,
					CategoryId = category_model.Id,
					Count = model.Count,
					Date = model.Date,
					ExpensesId = model.ExpensesId,
					Description = model.Description
				};

				return View(expensesItemList);
			}
			return NotFound();
		}

		[HttpPost]
		public async Task<ActionResult> UpdateExpenses([FromForm] ExpensesItemListDto expensesItemList)
		{

			ExpensesDto model = new ExpensesDto()
			{
                ExpensesId = expensesItemList.ExpensesId,
				CategoryId = expensesItemList.CategoryId,
				Date = expensesItemList.Date,
				Count = expensesItemList.Count,
				Description = expensesItemList.Description
			};

			ResponseDto? response = await _expensesService.UpdateExpensesAsync(model);

			if (response != null && response.IsSuccess)
			{
				return RedirectToAction("Index", "Home");
			}

			return View(expensesItemList);
		}
	}
}
