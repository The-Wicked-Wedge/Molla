using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Molla.Application.Interfaces.IServices;

namespace Molla.Presentation.Areas.Admin.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminDashBoardController : Controller
    {
        
        private readonly IAdminDashboardService adminDashboardService;
        private readonly IOrderService orderService;

        public AdminDashBoardController(IAdminDashboardService adminDashboardService,
                                        IOrderService orderService)
        {
            this.adminDashboardService = adminDashboardService;
            this.orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> AllOrdersSummary()
        {
            return View(await adminDashboardService.GetAllOrdersSummary());
        }

        public async Task<IActionResult> AllIncome()
        {
            return Json(await orderService.AllPurchases());
        }

    }
}
