using Aminimanesh.Core.DTOs.UserDTOs;
using Aminimanesh.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aminimanesh.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("user-info")]
        public async Task<IActionResult> UserInfo()
        {
            var user = await _userService.GetUserAsync();

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [Route("change-credentials")]
        public async Task<IActionResult> ChangeCredentials()
        {
            var user = await _userService.GetUserCredentialsAsync();
            return View(user);
        }

        [HttpPost]
        [Route("change-credentials")]
        public async Task<IActionResult> ChangeCredentials(ChangeCredentialsDTO credentials)
        {
            if (!ModelState.IsValid)
            {
                return View(credentials);
            }

            if (! await _userService.CheckUserCredentialsAsync(credentials))
            {
                ModelState.AddModelError("Password", "اطلاعات وارد شده نادرست می‌باشد.");
                return View(credentials);
            }

            await _userService.ChagneUserCredentialsAsync(credentials);
            
            return RedirectToAction("UserInfo");
        }
    }
}
