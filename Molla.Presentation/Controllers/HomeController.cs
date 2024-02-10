using Microsoft.AspNetCore.Mvc;
using Molla.Application.Interfaces.IServices;
using Molla.Presentation.Models;
using System.Diagnostics;

namespace Molla.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeIndexService _homeIndexService;


        public HomeController(ILogger<HomeController> logger, IHomeIndexService homeIndexService)
        {
            _logger = logger;
            _homeIndexService = homeIndexService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _homeIndexService.GetHomeAsync());
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
    }
}