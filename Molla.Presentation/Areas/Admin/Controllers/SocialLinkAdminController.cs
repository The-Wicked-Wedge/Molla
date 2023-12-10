using Microsoft.AspNetCore.Mvc;
using Molla.Application.DTOs;
using Molla.Application.Interfaces.IServices;

namespace Molla.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocialLinkAdminController : Controller
    {
        private readonly ISocialLinkService socialLinkService;

        public SocialLinkAdminController(ISocialLinkService socialLinkService)
        {
            this.socialLinkService = socialLinkService;
        }

        [Route("/Admin/SocialLink")]
        public async Task<IActionResult> Index()
        {
            return View(socialLinkService.GetAllSocialLinks());
        }

        [Route("/Admin/SocialLink/Create")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View(new SocialLinkDTO());
        }

        [Route("/Admin/SocialLink/Create")]
        [HttpPost]
        public async Task<IActionResult> Create(SocialLinkDTO socialLinkDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json("Error : " + "Model State Is Not Valid");
                }

                await socialLinkService.CreateSocialLink(socialLinkDTO);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Json("Error : " + ex.Message);
            }
        }
        [Route("/Admin/SocialLink/Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            try
            {
                var socialLinkDTO = await socialLinkService.GetByIdAsNoTrackingAsync(Id);
                if (socialLinkDTO == null)
                {
                    return RedirectToAction("Index");
                }

                return View(socialLinkDTO);
            }
            catch (Exception ex)
            {
                return Json("Error : " + ex.Message);
            }
        }
        [Route("/Admin/SocialLink/Edit")]
        [HttpPost]
        public async Task<IActionResult> Edit(SocialLinkDTO socialLinkDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json("Error : " + "ModelState Is Not Valid");
                }

                await socialLinkService.UpdateSocialLink(socialLinkDTO);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return Json("Error : "+ex.Message);
            }
        }
        [Route("/Admin/SocialLink/Delete/Id")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                if(await socialLinkService.GetByIdAsNoTrackingAsync(Id) == null)
                {
                    return Json("Error : " + "This Item Doesn't Exist");
                }
                await socialLinkService.DeleteSocialLinkByIdAsync(Id);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return Json("Error : " + ex.Message);
            }
        }
    }
}
