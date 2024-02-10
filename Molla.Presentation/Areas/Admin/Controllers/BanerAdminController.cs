using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Molla.Application.DTOs;
using Molla.Application.Interfaces.IServices;

namespace Molla.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BanerAdminController : Controller
    {
        private readonly IBanerService banerService;
        private readonly IPhotoService photoService;

        public BanerAdminController(IBanerService banerService,
                                    IPhotoService photoService)
        {
            this.banerService = banerService;
            this.photoService = photoService;
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
            return View();
        }
        
        
        [HttpPost]
        [Route("/Admin/Baner/Create")]
        public async Task<IActionResult> Create(BanerDTO baner)
        {
            try
            {
                ModelState.Remove("ImageSource");
                if (!ModelState.IsValid)
                {
                    return Json("Error : ModelState Is Not Valid");
                }

                if(baner.ImageFile == null)
                {
                    return Json("Error : Select An Image First");
                }

                var upload = await photoService.AddPhotoAsync(baner.ImageFile);
                baner.ImageSource = upload.Url.ToString();

                await banerService.CreateAsync(baner);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {

                baner.Error = ex.Message;

                return Json("Error : "+ ex.Message);
            
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
                    return RedirectToAction("Index");
                }
                return View(baner);
            }
            catch(Exception ex)
            {
                return Json("Error : " + ex.Message);
            }
        }

        [HttpPost]
        [Route("/Admin/Baner/Edit")]
        public async Task<IActionResult> Edit(BanerDTO baner)
        {
            try
            {
                ModelState.Remove("ImageSource");
                if (!ModelState.IsValid)
                {
                    return Json("Error : Model State Is Not Valid");
                }
                if(baner.ImageFile != null)
                {
                    var upload = await photoService.AddPhotoAsync(baner.ImageFile);
                    baner.ImageSource = upload.Url.ToString();
                }


                await banerService.UpdateAsync(baner);

                return RedirectToAction("Index");
            }catch(Exception ex)
            {
                return Json("Error : " + ex);
            }
        }

        [Route("/Admin/Baner/Delete/{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                await banerService.DeleteByIdAsync(Id);

                return RedirectToAction("Index");

            }catch(Exception ex)
            {
                return Json("Error : "+ex.Message);
            }
        }



    }
}
