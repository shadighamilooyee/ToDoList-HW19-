using System.Diagnostics;
using App.Domain.Core.UserAgg.Contracts;
using App.Domain.Core.UserAgg.Dtos;
using App.Infra.Db.SqlServer.LocalDb;
using Hw19.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hw19.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IUserAppService _userAppService;
        public AuthenticationController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {
            var login = _userAppService.LoginUser(Username, Password);
            if (login.IsSucceed == true)
            {
                LocalStorage.CurrentUser = login.Data;
                return RedirectToAction("Index", "ManageItems");
            }
            else
            {
                ViewBag.ErrorMessage = login.Message;
                return View();
            }
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveUser(AddUserDto model)
        {
            var register = _userAppService.RegisterUser(model);
            if (register.IsSucceed == true)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Logout()
        {
            LocalStorage.CurrentUser = null;
            return RedirectToAction("Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
