using Aminimanesh.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aminimanesh.Web.Components
{
    public class LanguagesComponent : ViewComponent
    {
        private readonly IOwnerService _ownerService;
        public LanguagesComponent(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _ownerService.GetAllLanguagesAsync();
            return View("Languages", model);
        }
    }
}
