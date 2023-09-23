using Assistans.Service.Frontend.Models.Dto;
using Frontend.Models;
using Frontend.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        
        public HomeController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            /*
            ResponseDto? response = await _categoryService.GetAllCategoryUserAsync();
            List<CategoryDto> listCategories = JsonConvert.DeserializeObject<List<CategoryDto>>(Convert.ToString(response.Result));
            */
			return View();
        }
    }
}
