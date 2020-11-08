using Furny.NotificationFeature.Commands;
using Furny.NotificationFeature.ViewModels;
using Furny.ServiceInterfaces;
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
        private readonly INotificationService _notificationService;

        public NotificationController(
            INotificationService notificationService,
            IMediator mediator) : base(mediator)
        {
            _notificationService = notificationService;
        }

        [HttpPost("{id}/notifications/{nid}")]
        public async Task Done(string id, string nid)
            => await SendAsync(NotificationFeatureDoneNotificationCommand.Create(id, nid));

        [HttpGet("{id}/notifications")]
        public async Task<IList<NotificationFeatureNotificationViewModel>> Get(string id)
            => await SendAsync(NotificationFeatureGetNotificationsCommand.Create(id));
    }
}