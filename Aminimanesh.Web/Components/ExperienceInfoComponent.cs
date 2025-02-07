using Aminimanesh.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Aminimanesh.Web.Components
{
    public class ExperienceInfoComponent : ViewComponent
    {
        private readonly IOwnerService _ownerService;
        public ExperienceInfoComponent(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _ownerService.GetExperienceInfoAsync();

            return View("ExperienceInfo", model);
        }
    }
}
