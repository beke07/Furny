using Furny.Model;
using MediatR;

namespace Furny.NotificationFeature.Commands
{
    public class NotificationFeatureCreateNotificationCommand : IRequest
    {
        public string UserId { get; set; }

        public Notification Notifcation { get; set; }

        public NotificationFeatureCreateNotificationCommand(string userId, Notification notifcation)
        {
            UserId = userId;
            Notifcation = notifcation;
        }

        public static NotificationFeatureCreateNotificationCommand Create(string userId, Notification notifcation)
            => new NotificationFeatureCreateNotificationCommand(userId, notifcation);
    }
}
