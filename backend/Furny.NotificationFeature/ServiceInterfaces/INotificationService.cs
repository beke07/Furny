using Furny.Model;
using Furny.NotificationFeature.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Furny.NotificationFeature.ServiceInterfaces
{
    public interface INotificationService
    {
        Task CreateNotificationAsync(string userId, Notification notification);

        Task DoneNotificationAsync(string userId, string notificationId);

        Task<IList<NotificationFeatureNotificationViewModel>> GetNotificationsAsync(string userId);
    }
}
