using Aminimanesh.Core.DTOs.ServiceDTOs;
using Aminimanesh.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aminimanesh.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [Route("services")]
        public async Task<IActionResult> Index()
        {
            var model = await _serviceService.GetAllServicesAsync();
            return View(model);
        }



        [Route("create-service")]
        public async Task<IActionResult> CreateService()
        {
            return View();
        }

        [HttpPost]
        [Route("create-service")]
        public async Task<IActionResult> CreateService(CreateServiceDTO service)
        {
            if (!ModelState.IsValid)
            {
                return View(service);
            }

            await _serviceService.AddServiceAsync(service);

            return RedirectToAction("Index");
        }



        [Route("edit-service")]
        public async Task<IActionResult> EditService(int id)
        {
            var service = await _serviceService.GetServiceForEditAsync(id);
            return View(service);
        }

        [HttpPost]
        [Route("edit-service")]
        public async Task<IActionResult> EditService(EditServiceDTO service)
        {
            if (!ModelState.IsValid)
            {
                return View(service);
            }

            await _serviceService.UpdateServiceAsync(service);

            return RedirectToAction("Index");
        }

        [Route("delete-service")]
        public async Task<IActionResult> DeleteService(int id)
        {
            await _serviceService.RemoveServiceByIdAsync(id);
            return RedirectToAction("Index");
        }
    }
}
