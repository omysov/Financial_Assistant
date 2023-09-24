using Assistans.Service.Frontend.Models.Dto;
using Frontend.Models;
using Frontend.Models.Dto;
using Frontend.Services;
using Frontend.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Frontend.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IExpensesService _expensesService;

        public CategoryController(ICategoryService categoryService, IExpensesService expensesService)
        {
            _categoryService = categoryService;
            _expensesService = expensesService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AllCategory()
        {
            ResponseDto? response = await _categoryService.GetAllCategoryUserAsync();
            if(response != null && response.IsSuccess)
            {
                IEnumerable<CategoryDto> list = JsonConvert.DeserializeObject<IEnumerable<CategoryDto>>(Convert.ToString(response.Result));

                return View(list);
            }
            return NotFound();
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory( CategoryDto categoryDto)
        {
            ResponseDto? response = await _categoryService.CreateCategoryAsync(categoryDto);

            if (response != null && response.IsSuccess)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(response);
        }

        public async Task<IActionResult> DeleteCategory(int category_id)
        {
			ResponseDto? category = await _categoryService.GetCategoryByIdAsync(category_id);
            CategoryDto model = JsonConvert.DeserializeObject<CategoryDto>(Convert.ToString(category.Result));
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteCategory(CategoryDto categoryDto)
        {
            int category_id = categoryDto.Id;


			ResponseDto? responseExpenses = await _expensesService.GetExpensesByIdCategory(category_id);
			IEnumerable<ExpensesDto> list = JsonConvert.DeserializeObject<IEnumerable<ExpensesDto>>(Convert.ToString(responseExpenses.Result));

			//ResponseDto? response = await _categoryService.DeleteCategoryAsync(category_id);

            if (responseExpenses != null && responseExpenses.IsSuccess)
            {
                foreach(var expenses in list)
                {
                    await _expensesService.DeleteExpensesAsync(expenses.ExpensesId);
                }

                await _categoryService.DeleteCategoryAsync(category_id);

                return RedirectToAction("Index", "Home");
            }
            return NotFound();
        }

        public async Task<IActionResult> UpdateCategory(int category_id)
        {
            ResponseDto? response = await _categoryService.GetCategoryByIdAsync(category_id);

            if(response != null && response.IsSuccess)
            {
                CategoryDto category = JsonConvert.DeserializeObject<CategoryDto>(Convert.ToString(response.Result));
                return View(category);
            }

            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateCategory(CategoryDto categoryDto)
        {
            ResponseDto? response = await _categoryService.UpdateCategoryAsync(categoryDto);

            if(response != null && response.IsSuccess)
            {
                return RedirectToAction("AllCategory", "Category");
            }
            return View(categoryDto);
        }
    }
}
