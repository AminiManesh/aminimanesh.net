using Aminimanesh.Core.Services;
using Aminimanesh.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aminimanesh.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MessageController : Controller
    {
        private readonly IServiceService _serviceService;
        public MessageController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [Route("messages")]
        public async Task<IActionResult> Index()
        {
            var messages = await _serviceService.GetAllMessages();
            return View(messages);
        }

        [Route("deleted-messages")]
        public async Task<IActionResult> GetDeletedMessages()
        {
            var messages = await _serviceService.GetDeletedMessages();
            return View(messages);
        }

        [Route("delete-message")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _serviceService.RemoveMessageByIdAsync(id);
            return RedirectToAction("Index");
        }

        [Route("restore-message")]
        public async Task<IActionResult> RestoreMessage(int id)
        {
            await _serviceService.RestoreMessageByIdAsync(id);
            return RedirectToAction("GetDeletedMessages");
        }

        [Route("message-info")]
        public async Task<IActionResult> GetMessageInfo(int id)
        {
            var model = await _serviceService.GetMessageByIdAsync(id);
            return View(model);
        }
    }
}
