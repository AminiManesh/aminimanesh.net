using Aminimanesh.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aminimanesh.Web.Components
{
    public class SideSkillsComponent : ViewComponent
    {
        private readonly IOwnerService _ownerService;
        public SideSkillsComponent(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _ownerService.GetAllSideSkillsAsync();
            return View("SideSkills", model);
        }
    }
}
