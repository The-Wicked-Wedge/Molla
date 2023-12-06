using Microsoft.AspNetCore.Mvc;
using Molla.Application.DTOs;
using Molla.Application.IServices;

namespace Molla.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderAdminController(ISliderService sliderService) : Controller
    {
        [Route("/Admin/Slider")]
        public async Task<IActionResult> Index()
        {
            IEnumerable<SliderDTO> x = await sliderService.GetAllAsync();
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
            await sliderService.CreateAsync(model);
            return View();
        }
        [Route("/Admin/Slider/Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            SliderDTO res = await sliderService.GetByIDAsync(id);
            return View(res);
        }
        [Route("/Admin/Slider/Edit")]
        [HttpPost]
        public async Task<IActionResult> Edit(SliderDTO model)
        {
            await sliderService.UpdateByIDAsync(model);
            return View();
        }
        [Route("/Admin/Slider/Delete")]
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            SliderDTO res = await sliderService.GetByIDAsync(id);
            return View(res);
        }
        [Route("/Admin/Slider/Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfig(Guid id)
        {
            await sliderService.DeleteByIDAsync(id);
            return View();
        }
    }
}
