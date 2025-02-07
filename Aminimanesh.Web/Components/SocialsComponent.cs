using Aminimanesh.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aminimanesh.Web.Components
{
    public class SocialsComponent : ViewComponent
    {
        private readonly IOwnerService _ownerService;
        public SocialsComponent(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _ownerService.GetAllSocialsAsync();
            return View("Socials", model);
        }
    }
}
