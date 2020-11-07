using Furny.ServiceInterfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class NotificationController : MediatorControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(
            INotificationService notificationService,
            IMediator mediator) : base(mediator)
        {
            _notificationService = notificationService;
        }

        [HttpPost("{id}/notifications/{nid}")]
        public async Task<IActionResult> Done(string id, string nid)
        {
            await _notificationService.DoneNotificationAsync(id, nid);
            return Ok();
        }

        [HttpGet("{id}/notifications")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _notificationService.GetNotificationsAsync(id));
        }
    }
}