using Aminimanesh.Core.Services.Interfaces;
using Aminimanesh.DataLayer.Entities.Owner;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aminimanesh.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SocialController : Controller
    {
        private readonly IOwnerService _ownerService;
        public SocialController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [Route("socials")]
        public async Task<IActionResult> Index()
        {
            var socials = await _ownerService.GetAllSocialsAsync();
            return View(socials);
        }


        [Route("create-social")]
        public async Task<IActionResult> CreateSocial()
        {
            return View();
        }

        [HttpPost]
        [Route("create-social")]
        public async Task<IActionResult> CreateSocial(Social social)
        {
            if (!ModelState.IsValid)
            {
                return View(social);
            }

            await _ownerService.AddSocialAsync(social);

            return RedirectToAction("Index");
        }


        [Route("edit-social")]
        public async Task<IActionResult> EditSocial(int id)
        {
            var social = await _ownerService.GetSocialByIdAsync(id);
            return View(social);
        }

        [HttpPost]
        [Route("edit-social")]
        public async Task<IActionResult> EditSocial(Social social)
        {
            if (!ModelState.IsValid)
            {
                return View(social);
            }

            await _ownerService.UpdateSocialAsync(social);

            return RedirectToAction("Index");
        }

        [Route("delete-social")]
        public async Task<IActionResult> DeleteSocial(int id)
        {
            await _ownerService.RemoveSocialByIdAsync(id);
            return RedirectToAction("Index");
        }
    }
}
