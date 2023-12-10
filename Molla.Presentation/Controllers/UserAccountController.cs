using Microsoft.AspNetCore.Mvc;
using Molla.Application.DTOs;
using Molla.Application.Interfaces.IServices;

namespace Molla.Presentation.Controllers
{
    public class UserAccountController : Controller
    {
        private readonly IUserAccountService _userAccountService;
        public UserAccountController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }
        [Route("/Register")]
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        [Route("/UserAccount/Register")]
        [HttpPost]
        public async Task<IActionResult> Index(RegisterUserDTO model)
        {
            await _userAccountService.RegisterAsync(model);
            return View();
        }

        [Route("/UserAccount/SingIn")]
        [HttpPost]
        public async Task<IActionResult> SingInAccount(LoginUserDTO model)
        {
            var x = await _userAccountService.LoginAccountAsync(model);
            return View();
        }
    }
}
