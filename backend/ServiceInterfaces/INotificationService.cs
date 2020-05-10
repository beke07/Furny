using Furny.Data;
using Furny.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.ServiceInterfaces
{
    public interface INotificationService
    {
        Task CreateNotificationAsync(string userId, Notification notification);

        Task IsDoneNotificationAsync(string userId, string notificationId);

        Task<IList<NotificationDto>> GetNotificationsAsync(string userId);
    }
}
