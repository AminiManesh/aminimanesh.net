using Aminimanesh.Core.DTOs.SkillDTOs;
using Aminimanesh.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aminimanesh.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SkillController : Controller
    {
        private readonly IOwnerService _ownerService;
        public SkillController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [Route("skills")]
        public async Task<IActionResult> Index()
        {
            var skills = await _ownerService.GetAllSkillsAsync();
            return View(skills);
        }

        [Route("create-skill")]
        public async Task<IActionResult> CreateSkill()
        {
            return View();
        }

        [HttpPost]
        [Route("create-skill")]
        public async Task<IActionResult> CreateSkill(CreateSkillDTO skill)
        {
            if (!ModelState.IsValid)
            {
                return View(skill);
            }

            await _ownerService.AddSkillAsync(skill);

            return RedirectToAction("Index");
        }

        [Route("edit-skill")]
        public async Task<IActionResult> EditSkill(int id)
        {
            var skill = await _ownerService.GetSkillForEditAsync(id);
            return View(skill);
        }

        [HttpPost]
        [Route("edit-skill")]
        public async Task<IActionResult> EditSkill(EditSkillDTO skill)
        {
            if (!ModelState.IsValid)
            {
                return View(skill);
            }

            await _ownerService.UpdateSkillAsync(skill);

            return RedirectToAction("Index");
        }

        [Route("delete-skill")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            await _ownerService.RemoveSkillByIdAsync(id);
            return RedirectToAction("Index");
        }
    }
}
