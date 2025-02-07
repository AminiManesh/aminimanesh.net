using Aminimanesh.Core.Services.Interfaces;
using Aminimanesh.DataLayer.Entities.Owner;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aminimanesh.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HistoryController : Controller
    {
        private readonly IOwnerService _ownerService;
        public HistoryController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [Route("history-lines")]
        public async Task<IActionResult> Index()
        {
            var lines = await _ownerService.GetAllHistoryLinesAsync();
            return View(lines);
        }

        [Route("create-history-line")]
        public async Task<IActionResult> CreateHistoryLine()
        {
            return View();
        }

        [HttpPost]
        [Route("create-history-line")]
        public async Task<IActionResult> CreateHistoryLine(HistoryLine line)
        {
            if (!ModelState.IsValid)
            {
                return View(line);
            }

            await _ownerService.AddHistoryLineAsync(line);

            return RedirectToAction("Index");
        }


        [Route("edit-history-line")]
        public async Task<IActionResult> EditHistoryLine(int id)
        {
            var line = await _ownerService.GetHistoryLineByIdAsync(id);
            return View(line);
        }

        [HttpPost]
        [Route("edit-history-line")]
        public async Task<IActionResult> EditHistoryLine(HistoryLine line)
        {
            if (!ModelState.IsValid)
            {
                return View(line);
            }

            await _ownerService.UpdateHistoryLineAsync(line);

            return RedirectToAction("Index");
        }

        [Route("history-list")]
        public async Task<IActionResult> HistoryList(int id)
        {
            var line = await _ownerService.GetHistoryLineByIdAsync(id);
            return View(line);
        }


        [Route("create-history")]
        public async Task<IActionResult> CreateHistory(int id)
        {
            ViewData["LineId"] = id;
            return View();
        }

        [HttpPost]
        [Route("create-history")]
        public async Task<IActionResult> CreateHistory(History history)
        {
            if (!ModelState.IsValid)
            {
                return View(history);
            }

            var lineId = await _ownerService.AddHistoryAsync(history);

            return RedirectToAction("HistoryList", new { id = lineId });
        }


        [Route("edit-history")]
        public async Task<IActionResult> EditHistory(int id)
        {
            var history = await _ownerService.GetHistoryByIdAsync(id);
            return View(history);
        }

        [HttpPost]
        [Route("edit-history")]
        public async Task<IActionResult> EditHistory(History history)
        {
            if (!ModelState.IsValid)
            {
                return View(history);
            }

            var lineId = await _ownerService.UpdateHistoryAsync(history);

            return RedirectToAction("HistoryList", new { id = lineId });
        }

        [Route("delete-history")]
        public async Task<IActionResult> DeleteHistory(int id)
        {
            var lineId = await _ownerService.RemoveHistoryByIdAsync(id);
            return RedirectToAction("HistoryList", new { id = lineId });
        }
    }
}
