using Microsoft.AspNetCore.Mvc;
using Molla.Application.DTOs;
using Molla.Application.IServices;

namespace Molla.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderAdminController : Controller
    {
        private readonly ISliderService _sliderService;
        public SliderAdminController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        [Route("/Admin/Slider")]
        public async Task<IActionResult> Index()
        {
            IEnumerable<SliderDTO> x = await _sliderService.GetAllAsync();
            return View(x);
        }
        [Route("/Admin/Slider/Create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Route("/Admin/Slider/Create")]
        [HttpPost]
        public async Task<IActionResult> Create(SliderDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json("Error : " + "Model State Is Not Valid");
                }

                await _sliderService.CreateAsync(model);
                return RedirectToAction("Index", "SliderAdmin");

            }
            catch (Exception ex)
            {
                return Json("Error : " + ex.Message);
            }
        }
        [Route("/Admin/Slider/Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            SliderDTO res = await _sliderService.GetByIDAsync(id);
            return View(res);
        }
        [Route("/Admin/Slider/Edit")]
        [HttpPost]
        public async Task<IActionResult> Edit(SliderDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json("Error : " +"Model State Is Not Valid");
                }
                await _sliderService.UpdateByIDAsync(model);

                return RedirectToAction("Index","SliderAdmin");
            }
            catch (Exception ex)
            {
                return Json("Error : " + ex.Message);
            }
        }
        [Route("/Admin/Slider/Delete")]
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            SliderDTO res = await _sliderService.GetByIDAsync(id);
            return View(res);
        }
        [Route("/Admin/Slider/Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfig(Guid id)
        {
            await _sliderService.DeleteByIDAsync(id);
            return View();
        }
    }
}
