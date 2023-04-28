using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TestTask.BusinessLayer.Interfaces;
using TestTask.ViewModels;
using System.Text;
using System.Security.Cryptography;
using TestTask.BusinessLayer.BusinessModels;
using Microsoft.AspNetCore.Authorization;

namespace TestTask.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public AccountController(IUserService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.FindFirst(ClaimsIdentity.DefaultNameClaimType) != null)            
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            model.Password = GetHash(model.Password);

            if (ModelState.IsValid)
            {
                var user = await this._service.GetUserByLoginAndPasswordAsync(model.Login, model.Password);
                if (user != null)
                {
                    await Authenticate(model.Login);

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (User.FindFirst(ClaimsIdentity.DefaultNameClaimType) != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError("", "Пароли не совпадают");
                return View(model);
            }

            model.Password = GetHash(model.Password);

            if (ModelState.IsValid)
            {
                var user = await this._service.GetUserByLoginAndPasswordAsync(model.Login, model.Password);
                if (user == null)
                {
                    await this._service.CreateUserAsync(this._mapper.Map<RegisterModel>(model));

                    await Authenticate(model.Login); // аутентификация

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        private async Task Authenticate(string login)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, login)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        private static string GetHash(string password)
        {
            using SHA256 sha256Hash = SHA256.Create();

            byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
