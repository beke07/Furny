using MediatR;

namespace Furny.NotificationFeature.Commands
{
    public class NotificationFeatureDoneNotificationCommand : IRequest
    {
        public string UserId { get; set; }

        public string Nid { get; set; }

        public NotificationFeatureDoneNotificationCommand(string userId, string nid)
        {
            UserId = userId;
            Nid = nid;
        }

        public static NotificationFeatureDoneNotificationCommand Create(string userId, string nid)
            => new NotificationFeatureDoneNotificationCommand(userId, nid);
    }
}
