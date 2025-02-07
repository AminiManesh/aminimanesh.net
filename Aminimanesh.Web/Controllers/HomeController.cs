using Aminimanesh.Core.DTOs;
using Aminimanesh.Core.Services.Interfaces;
using Aminimanesh.DataLayer.Context;
using ElectronicLearn.Core.Convertors;
using ElectronicLearn.Core.Senders;
using Microsoft.AspNetCore.Mvc;

namespace Aminimanesh.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceService _serviceService;
        public HomeController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        [Route("GetSpeechs")]
        public async Task<IActionResult> GetSpeechs()
        {
            var speechs = await _serviceService.GetAllSpeechsAsync();
            return new JsonResult(speechs.Select(s => s.Text));
        }
    }
}
