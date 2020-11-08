using Furny.NotificationFeature.Commands;
using Furny.NotificationFeature.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furny.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class NotificationController : MediatorControllerBase
    {
        public NotificationController(IMediator mediator) : base(mediator)
        { }

        [HttpPost("{id}/notifications/{nid}")]
        public async Task Done(string id, string nid)
            => await SendAsync(NotificationFeatureDoneNotificationCommand.Create(id, nid));

        [HttpGet("{id}/notifications")]
        public async Task<IList<NotificationFeatureNotificationViewModel>> Get(string id)
            => await SendAsync(NotificationFeatureGetNotificationsCommand.Create(id));
    }
}