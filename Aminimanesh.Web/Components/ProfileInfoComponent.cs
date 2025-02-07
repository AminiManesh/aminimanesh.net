using Aminimanesh.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Aminimanesh.Web.Components
{
    public class ProfileInfoComponent : ViewComponent
    {
        private readonly IOwnerService _ownerService;
        public ProfileInfoComponent(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _ownerService.GetProfileInfoAsync();
            return View("ProfileInfo", model);
        }
    }
}
