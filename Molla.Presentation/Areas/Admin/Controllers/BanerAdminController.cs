using Microsoft.AspNetCore.Mvc;
using Molla.Application.DTOs;
using Molla.Application.IServices;

namespace Molla.Presentation.Areas.Admin.Controllers
{
    public class BanerAdminController : Controller
    {
        private readonly IBanerService banerService;

        public BanerAdminController(IBanerService banerService)
        {
            this.banerService = banerService;
        }

        [Route("/Admin/Baner")]
        public async Task<IActionResult> Index()
        {
            var baners = await banerService.GetAllAsync();
            
            return View(baners);
        }

        
        [Route("/Admin/Baner/Create")]
        public IActionResult Create()
        {
            var reload = new BanerDTO();

            return View(reload);
        }
        
        
        [HttpPost]
        [Route("/Admin/Baner/Create")]
        public async Task<IActionResult> Create(BanerDTO baner)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    baner.Error = "ModelState Is Not Valid";
                    return View(baner);
                }
                await banerService.CreateAsync(baner);

                return RedirectToAction("Index", "Home");
            }
            catch(Exception ex)
            {

                baner.Error = ex.Message;

                return View(baner);
            
            }
        }


        [Route("/Admin/Baner/Edit")]
        public async Task<IActionResult> Edit(Guid Id)
        {

            try
            {
                var baner = await banerService.GetByIdAsync(Id);

                if(baner == null)
                {
                    return NotFound(StatusCodes.Status404NotFound);
                }

                return View(baner);


            }
            catch(Exception ex)
            {
                return NotFound(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("/Admin/Baner/Edit")]
        public async Task<IActionResult> Edit(BanerDTO baner)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    baner.Error = "ModelState Is Not Valid";
                    return View(baner);
                }

                await banerService.UpdateAsync(baner);

                return RedirectToAction("Index", "Home");
            }catch(Exception ex)
            {
                baner.Error = ex.Message;
                return View(baner);
            }
        }

        [Route("/Admin/Baner/Delete/{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                await banerService.DeleteByIdAsync(Id);

                return Json(true);
            }catch(Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}
