using Microsoft.AspNetCore.Mvc;
using Molla.Application.DTOs;
using Molla.Application.Interfaces.IServices;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Identity;

namespace Molla.Presentation.Controllers
{
    public class UserAccountController : Controller
    {
        private readonly IUserAccountService _userAccountService;
        public UserAccountController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterUserDTO model)
        {
            await _userAccountService.RegisterAsync(model);
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        public async Task<IActionResult> SingInAccount(LoginUserDTO model)
        {
            var x = await _userAccountService.LoginAccountAsync(model);
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _userAccountService.LogOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
