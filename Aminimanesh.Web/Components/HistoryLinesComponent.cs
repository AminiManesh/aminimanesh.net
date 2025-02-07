using Aminimanesh.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Aminimanesh.Web.Components
{
    public class HistoryLinesComponent : ViewComponent
    {
        private readonly IOwnerService _ownerService;
        public HistoryLinesComponent(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _ownerService.GetAllHistoryLinesAsync();
            return View("HistoryLines", model);
        }
    }
}
