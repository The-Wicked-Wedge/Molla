using Microsoft.AspNetCore.Mvc;
using Molla.Application.DTOs;
using Molla.Application.Interfaces.IServices;
using System.Runtime.CompilerServices;

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
            await _sliderService.CreateAsync(model);
            return View();
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
            await _sliderService.UpdateByIDAsync(model);
            return View();
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
