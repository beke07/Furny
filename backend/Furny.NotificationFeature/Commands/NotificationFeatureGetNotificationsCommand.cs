using Furny.NotificationFeature.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace Furny.NotificationFeature.Commands
{
    public class NotificationFeatureGetNotificationsCommand : IRequest<IList<NotificationFeatureNotificationViewModel>>
    {
        public string UserId { get; set; }

        public NotificationFeatureGetNotificationsCommand(string userId)
        {
            UserId = userId;
        }

        public static NotificationFeatureGetNotificationsCommand Create(string userId)
            => new NotificationFeatureGetNotificationsCommand(userId);
    }
}
