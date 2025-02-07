using Aminimanesh.Core.Services.Interfaces;
using Aminimanesh.DataLayer.Entities.Owner;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aminimanesh.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class SpeechController : Controller
    {
        private readonly IServiceService _serviceService;
        public SpeechController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [Route("speechs")]
        public async Task<IActionResult> Index()
        {
            var speechs = await _serviceService.GetAllSpeechsAsync();
            return View(speechs);
        }

        [Route("create-speech")]
        public async Task<IActionResult> CreateSpeech()
        {
            return View();
        }

        [HttpPost]
        [Route("create-speech")]
        public async Task<IActionResult> CreateSpeech(Speech speech)
        {
            if (!ModelState.IsValid)
            {
                return View(speech);
            }

            await _serviceService.AddSpeechAsync(speech);

            return RedirectToAction("Index");
        }

        [Route("edit-speech")]
        public async Task<IActionResult> EditSpeech(int id)
        {
            var speech = await _serviceService.GetSpeechByIdAsync(id);
            return View(speech);
        }

        [HttpPost]
        [Route("edit-speech")]
        public async Task<IActionResult> EditSpeech(Speech speech)
        {
            if (!ModelState.IsValid)
            {
                return View(speech);
            }

            await _serviceService.UpdateSpeechAsync(speech);

            return RedirectToAction("Index");
        }

        [Route("delete-speech")]
        public async Task<IActionResult> DeleteSpeech(int id)
        {
            await _serviceService.RemoveSpeechbyIdAsync(id);
            return RedirectToAction("Index");
        }
    }
}
