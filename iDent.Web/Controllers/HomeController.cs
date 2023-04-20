using iDent.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace iDent.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
            //User user = new User();
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login()//User user)
        //{
        //    //User userObj = await _accountRepo.LoginAsync(SD.AccountAPIPath + "authenticate/", user);

        //    //if (userObj.Token == null)
        //    //{
        //    //    return View();
        //    //}

        //    //var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
        //    //identity.AddClaim(new Claim(ClaimTypes.Name, userObj.Username));
        //    //identity.AddClaim(new Claim(ClaimTypes.Role, userObj.Role));
        //    //var principal = new ClaimsPrincipal(identity);
        //    //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        //    //HttpContext.Session.SetString("JWToken", userObj.Token);
        //    //TempData["alert"] = $"Welcome, {userObj.Username}!";
        //    return await Task.FromResult(RedirectToAction("Index"));
        //}

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Register(User user)
        //{
        //    bool result = await _accountRepo.RegisterAsync(SD.AccountAPIPath + "register/", user);

        //    if (result == false)
        //    {
        //        return View();
        //    }

        //    TempData["alert"] = $"Registration Successful!";
        //    return RedirectToAction("Login");
        //}

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