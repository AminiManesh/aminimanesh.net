using Aminimanesh.Core.DTOs.OwnerDTOs;
using Aminimanesh.Core.Security;
using Aminimanesh.Core.Services.Interfaces;
using Aminimanesh.Core.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Aminimanesh.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OwnerController : Controller
    {
        private readonly IOwnerService _ownerService;
        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [Route("show-owner")]
        public async Task<IActionResult> Index()
        {
            var owner = await _ownerService.GetOwnerForShowAsync();
            return View(owner);
        }

        [Route("create-owner")]
        public async Task<IActionResult> CreateOwner()
        {
            if (await _ownerService.HasOwner())
            {
                return RedirectToAction("OwnerExists");
            }

            return View();
        }

        [Route("create-owner")]
        [HttpPost]
        public async Task<IActionResult> CreateOwner(CreateOwnerDTO owner, IFormFile? avatar, IFormFile? cvFile)
        {
            if (!ModelState.IsValid)
            {
                return View(owner);
            }

            if (cvFile != null && cvFile.Length > 0)
            {
                var savePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/owner/doc/");
                var fileName = "Amini Manesh - CV.pdf";

                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }

                FileTools.SaveFileWithCustomName(cvFile, fileName, savePath, true, fileName);

                owner.CVFile = fileName;
            }
            else
            {
                ModelState.AddModelError("CVFile", "Please select an pdf file for your CV File.");
                return View(owner);
            }

            if (avatar != null && avatar.Length > 0)
            {
                if (!ImageValidator.IsImage(avatar))
                {
                    ModelState.AddModelError("Avatar", "Please select an image for your avatar.");
                    return View(owner);
                }

                var savePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/owner/img/");
                var fileName = "avatar.jpg";

                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }

                FileTools.SaveFileWithCustomName(avatar, fileName, savePath, true, fileName);

                string thumbnailPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/owner/img/thumbnails/");

                if (!Directory.Exists(thumbnailPath))
                {
                    Directory.CreateDirectory(thumbnailPath);
                }

                var fullThumbnailPath = Path.Combine(thumbnailPath, fileName);

                await FileTools.SaveThumbnailCustomWidthAsync(Path.Combine(savePath, fileName), fullThumbnailPath, 256);

                owner.Avatar = fileName;
            }
            else
            {
                ModelState.AddModelError("CVFile", "Please select an image for your avatar.");
                return View(owner);
            }

            await _ownerService.AddOwnerAsync(owner);

            return RedirectToAction("Index");
        }

        [Route("owner-exists")]
        public async Task<IActionResult> OwnerExists()
        {
            return View();
        }

        [Route("edit-owner")]
        public async Task<IActionResult> EditOwner()
        {
            if (!await _ownerService.HasOwner())
            {
                return RedirectToAction("CreateOwner");
            }

            var owner = await _ownerService.GetOwnerForEditAsync();

            return View(owner);
        }

        [HttpPost]
        [Route("edit-owner")]
        public async Task<IActionResult> EditOwner(EditOwnerDTO owner, IFormFile? avatar = null, IFormFile? cvFile = null)
        {
            if (!ModelState.IsValid)
            {
                return View(owner);
            }

            if (cvFile != null && cvFile.Length > 0)
            {
                var savePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/owner/doc/");
                var fileName = "Amini Manesh - CV.pdf";

                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }

                FileTools.SaveFileWithCustomName(cvFile, fileName, savePath, true, fileName);

                owner.CVFile = fileName;
            }

            if (avatar != null && avatar.Length > 0)
            {
                if (!ImageValidator.IsImage(avatar))
                {
                    ModelState.AddModelError("Avatar", "Please select an image for your avatar.");
                    return View(owner);
                }

                var savePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/owner/img/");
                var fileName = "avatar.jpg";

                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }

                FileTools.SaveFileWithCustomName(avatar, fileName, savePath, true, fileName);

                string thumbnailPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/owner/img/thumbnails/");

                if (!Directory.Exists(thumbnailPath))
                {
                    Directory.CreateDirectory(thumbnailPath);
                }

                var fullThumbnailPath = Path.Combine(thumbnailPath, fileName);

                await FileTools.SaveThumbnailCustomWidthAsync(Path.Combine(savePath, fileName), fullThumbnailPath, 256);

                owner.Avatar = fileName;
            }

            await _ownerService.UpdateOwnerAsync(owner);

            return RedirectToAction("Index");
        }
    }
}
