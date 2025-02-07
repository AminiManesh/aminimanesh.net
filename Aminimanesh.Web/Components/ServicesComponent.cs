using Aminimanesh.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aminimanesh.Web.Components
{
    public class ServicesComponent : ViewComponent
    {
        private readonly IServiceService _serviceService;
        public ServicesComponent(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _serviceService.GetAllServicesAsync();
            return View("Services", model);
        }
    }
}
