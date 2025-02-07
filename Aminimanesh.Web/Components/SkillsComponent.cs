using Aminimanesh.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aminimanesh.Web.Components
{
    public class SkillsComponent : ViewComponent
    {
        private readonly IOwnerService _ownerService;
        public SkillsComponent(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _ownerService.GetAllMainSkillsAsync();
            return View("Skills", model);
        }
    }
}
