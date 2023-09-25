using Frontend.Models;
using Frontend.Models.Dto;
using Frontend.Services.IService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Frontend.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ITokenProvider _tokenProvider;

        public AuthController(IAuthService authService, ITokenProvider tokenProvider)
        {
            _authService = authService;
            _tokenProvider = tokenProvider;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDto loginRequestDto = new LoginRequestDto();
            return View(loginRequestDto);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto obj)
        {
            ResponseDto responseDto = await _authService.LoginAsync(obj);

            if(responseDto != null && responseDto.IsSuccess)
            {
                LoginResponseDto loginResponseDto =
                    JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(responseDto.Result));

                _tokenProvider.SetToken(loginResponseDto.Token);
                return View(obj);// RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Customer Error", responseDto.Message);
                return View(obj);
            }
        }

		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegistrationRequestDto obj)
		{
			ResponseDto responseDto = await _authService.RegisterAsync(obj);

			if (responseDto != null && responseDto.IsSuccess)
			{
				return RedirectToAction("Login", "Auth");
			}
			else
			{
				ModelState.AddModelError("Customer Error", responseDto.Message);
				return View(obj);
			}
		}

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            _tokenProvider.ClearToken();
            return RedirectToAction("Index", "Home");
        }
	}
}
