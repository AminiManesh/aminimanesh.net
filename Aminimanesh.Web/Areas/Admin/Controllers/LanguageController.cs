using Aminimanesh.Core.DTOs.LanguageDTOs;
using Aminimanesh.Core.Services.Interfaces;
using Aminimanesh.DataLayer.Entities.Owner;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Aminimanesh.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class LanguageController : Controller
    {
        private readonly IOwnerService _ownerService;
        public LanguageController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [Route("languages")]
        public async Task<IActionResult> Index()
        {
            var model = await _ownerService.GetAllLanguagesAsync();
            return View(model);
        }

        [Route("create-language")]
        public async Task<IActionResult> CreateLanguage()
        {
            return View();
        }

        [HttpPost]
        [Route("create-language")]
        public async Task<IActionResult> CreateLanguage(Language language)
        {
            if (!ModelState.IsValid)
            {
                return View(language);
            }

            await _ownerService.AddLanguageAsync(language);

            return RedirectToAction("Index");
        }


        [Route("edit-language")]
        public async Task<IActionResult> EditLanguage(int id)
        {
            var lang = await _ownerService.GetLanguageByIdAsync(id);
            return View(lang);
        }

        [HttpPost]
        [Route("edit-language")]
        public async Task<IActionResult> EditLanguage(Language language)
        {
            if (!ModelState.IsValid)
            {
                return View(language);
            }

            await _ownerService.UpdateLanguageAsync(language);

            return RedirectToAction("Index");
        }

        [Route("delete-language")]
        public async Task<IActionResult> DeleteLanguage(int id)
        {
            await _ownerService.RemoveLanguageByIdAsync(id);
            return RedirectToAction("Index");
        }
    }
}
