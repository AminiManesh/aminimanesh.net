using Aminimanesh.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aminimanesh.Web.Components
{
    public class ContactInfoComponent : ViewComponent
    {
        private readonly IOwnerService _ownerService;
        public ContactInfoComponent(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _ownerService.GetContactInfoAsync();
            return View("ContactInfo", model);
        }
    }
}
