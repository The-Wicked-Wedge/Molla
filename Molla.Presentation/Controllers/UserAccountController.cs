using Microsoft.AspNetCore.Mvc;
using Molla.Application.DTOs;
using Molla.Application.IServices;

namespace Molla.Presentation.Controllers
{
    public class UserAccountController(IUserAccountService userAccountService) : Controller
    {
        [Route("/Register")]
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        [Route("/UserAccount")]
        [HttpPost]
        public async Task<IActionResult> Index(RegisterUserDTO model)
        {
            await userAccountService.RegisterAsync(model);
            return View();
        }

        [Route("/UserAccount/SingIn")]
        [HttpPost]
        public async Task<IActionResult> SingInAccount(LoginUserDTO model)
        {
            var x = await userAccountService.LoginAccountAsync(model);
            return View();
        }
    }
}
