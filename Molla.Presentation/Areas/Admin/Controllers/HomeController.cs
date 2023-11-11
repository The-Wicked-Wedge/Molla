using Microsoft.AspNetCore.Mvc;

namespace Molla.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        [Route("/Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
