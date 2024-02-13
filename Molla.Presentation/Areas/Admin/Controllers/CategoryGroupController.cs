using Microsoft.AspNetCore.Mvc;
using Molla.Application.DTOs;
using Molla.Application.DTOs.AdminDashBoard;
using Molla.Application.Interfaces.IServices;
using Molla.Application.Services;

namespace Molla.Presentation.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryGroupController : Controller
	{
		private readonly ICategoryGroupService _categoryGroupService;

		public CategoryGroupController(ICategoryGroupService categoryGroupService)
		{
			_categoryGroupService = categoryGroupService;
		}
		[Route("/Admin/CategoryGroup")]
		public async Task<IActionResult> Index()
		{
			IEnumerable<AdminCategoryGroupDTO> categories = await _categoryGroupService.GetAllAsync();
			return View(categories);
		}
		[Route("/Admin/CategoryGroup/Create")]
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[Route("/Admin/CategoryGroup/Create")]
		[HttpPost]
		public async Task<IActionResult> Create(AdminCategoryGroupDTO model)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return Json("Error : " + "Model State Is Not Valid");
				}
				await _categoryGroupService.Create(model);
				return RedirectToAction("Index");

			}
			catch (Exception ex)
			{
				return Json("Error : " + ex.Message);
			}
		}
		[Route("/Admin/CategoryGroup/Edit")]
		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			AdminCategoryGroupDTO res = await _categoryGroupService.GetByIDAsync(id);
			return View(res);
		}
		[Route("/Admin/CategoryGroup/Edit")]
		[HttpPost]
		public async Task<IActionResult> Edit(AdminCategoryGroupDTO model)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					return Json("Error : " + "Model State Is Not Valid");
				}
				await _categoryGroupService.Update(model);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				return Json("Error : " + ex.Message);
			}
		}
		[Route("/Admin/CategoryGroup/Delete")]
		[HttpGet]
		public async Task<IActionResult> Delete(Guid id)
		{
			AdminCategoryGroupDTO res = await _categoryGroupService.GetByIDAsync(id);
			return View(res);
		}
		[Route("/Admin/CategoryGroup/Delete")]
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Remove(Guid id)
		{
			await _categoryGroupService.DeleteByID(id);
			return View();
		}
	}
}