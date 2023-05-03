using iDent.ModelLibrary.Models.Data;
using iDent.ModelLibrary.Models.Local;
using iDent.Web.Models;
using iDent.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace iDent.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountService _accountService;

        public HomeController(ILogger<HomeController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Login()
        {
            //Account account = new();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await _accountService.LoginAsync(request);

            if (result.Data!.Token == null) return View();
            
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Email, result.Data!.Email!));
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            HttpContext.Session.SetString("JWToken", result.Data!.Token);
            TempData["alert"] = $"Welcome, {result.Data!.Email}!";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AccountRequest request)
        {
            var result = await _accountService.AddAsync(request);

            if (!result.Success) return View();

            TempData["alert"] = $"Registration Successful!";
            return RedirectToAction("Login");
        }

        //public async Task<IActionResult> Logout()
        //{
        //    await HttpContext.SignOutAsync();
        //    HttpContext.Session.SetString("JWToken", "");
        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public IActionResult AccessDenied()
        //{
        //    return View();
        //}
    }
}