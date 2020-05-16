using Furny.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost("{id}/notifications/{nid}")]
        public async Task<IActionResult> Done(string id, string nid)
        {
            await _notificationService.IsDoneNotificationAsync(id, nid);
            return Ok();
        }

        [HttpGet("{id}/notifications")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _notificationService.GetNotificationsAsync(id));
        }
    }
}