using Aminimanesh.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aminimanesh.Web.Components
{
    public class CommonInfoComponent : ViewComponent
    {
        private readonly IOwnerService _ownerService;
        public CommonInfoComponent(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _ownerService.GetCommonInfoAsync();
            return View("CommonInfo", model);
        }
    }
}
