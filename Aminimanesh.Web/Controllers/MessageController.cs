using Aminimanesh.Core.Security;
using Aminimanesh.Core.Services.Interfaces;
using Aminimanesh.DataLayer.Entities.Owner;
using ElectronicLearn.Core.Convertors;
using ElectronicLearn.Core.Senders;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;

namespace Aminimanesh.Web.Controllers
{
    public class MessageController : Controller
    {
        private readonly IViewRenderService _renderView;
        private readonly IOwnerService _ownerService;
        private readonly IServiceService _serviceService;
        private readonly IpApiClient _ipApiClient;
        public MessageController(IViewRenderService renderView, IOwnerService ownerService, IServiceService serviceService, IpApiClient ipApiClient)
        {
            _renderView = renderView;
            _ownerService = ownerService;
            _serviceService = serviceService;
            _ipApiClient = ipApiClient;
        }

        [HttpPost]
        [Route("send-message")]
        public async Task<IActionResult> SendMessage(Message message, CancellationToken ct)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { success = false, message = "لطفا اطلاعات فرم را تکمیل کنید." });
            }

            message.SendDate = DateTime.Now;
            message.RemoteIPAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
            message.ActualIPAddress = HttpContext.GetServerVariable("HTTP_X_FORWARDED_FOR");
            message.CloudflareActualIPAddress = Request.Headers["CF-CONNECTING-IP"];

            var ipAddressWithoutPort = message.ActualIPAddress?.Split(':')[0];
            var ipApiResponse = await _ipApiClient.Get(ipAddressWithoutPort, ct);
            message.IpApiResponse = ipApiResponse;

            await _serviceService.AddMessageAsync(message);

            var body = _renderView.RenderToStringAsync("EmailMessage", message);
            var successBody = _renderView.RenderToStringAsync("EmailSent", message);
            SendEmail.Send(await _ownerService.GetIncomeEmailAsync(), $"aminimanesh.ir | Message from {message.SenderEmail}", body);
            SendEmail.Send(message.SenderEmail, $"پیام شما ارسال شد", successBody);

            return new JsonResult(new { success = true, message = "پیام شما با موفقیت ارسال شد." });
        }
    }
}
