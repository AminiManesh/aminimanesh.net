using Aminimanesh.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aminimanesh.Web.Areas.Admin.Components
{
    public class MessagesDropdownComponent : ViewComponent
    {
        private readonly IServiceService _serviceService;
        public MessagesDropdownComponent(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _serviceService.GetNewMessages(5);
            return View("MessagesDropdown", model);
        }
    }
}
