using Magic_Villa_Web.Models;
using MagicVilla_Web.Models.DTO;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using Utility;

namespace MagicVilla_Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IAuthServices _authServices;
        public UserController(IAuthServices authServices)
        {
            _authServices = authServices;
        }
        public IActionResult Login()
        {
            LoginRequestDto obj = new();
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginRequestDto obj)
        {
            APIResponse res = await _authServices.LoginAsync<APIResponse>(obj);
            if (res != null && res.IsSuccess)
            {
                LoginResponseDto model = JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(res.Result));
               
                //becouse we dont need to login again when we select to do any operation,(save the login detealis)
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name,model.user.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Role, model.user.Role));
                var princple = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,princple);

                //this lines for token and send it to the authantication operagions
                HttpContext.Session.SetString(SD.SessionToken,model.Token);
                return RedirectToAction("Index", "Home");
                
            }
            else
            {
                ModelState.AddModelError("CustomError",res.ErrorMessages.FirstOrDefault());
                return View(obj);
            }
        }

        public IActionResult Register()
        {
            RegistrationRequestDto obj = new();
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegistrationRequestDto obj)
        {
            APIResponse res = await _authServices.RegisterAsync<APIResponse>(obj);
            if (res != null && res.IsSuccess)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            HttpContext.Session.SetString(SD.SessionToken, "");
            return RedirectToAction("Index","Home");
        }

        public IActionResult AccessDenied() 
        {
                return View();
        }
    }
}
