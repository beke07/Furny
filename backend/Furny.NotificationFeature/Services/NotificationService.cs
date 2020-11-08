using AutoMapper;
using Furny.Common.Services;
using Furny.Model;
using Furny.NotificationFeature.ServiceInterfaces;
using Furny.NotificationFeature.ViewModels;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.NotificationFeature.Services
{
    public class NotificationService : BaseService<ApplicationUser>, INotificationService
    {
        private const string collectionName = "applicationUsers";
        private readonly IMapper _mapper;

        public NotificationService(
            IMapper mapper,
            IConfiguration configuration) : base(configuration, collectionName)
        {
            _mapper = mapper;
        }

        public async Task CreateNotificationAsync(string userId, Notification notification)
        {
            var user = await FindByIdAsync(userId);
            user.AddNotification(notification);

            await UpdateAsync(user);
        }

        public async Task DoneNotificationAsync(string userId, string notificationId)
        {
            var user = await FindByIdAsync(userId);
            user.DoneNotification(notificationId);

            await UpdateAsync(user);
        }

        public async Task<IList<NotificationFeatureNotificationViewModel>> GetNotificationsAsync(string userId)
        {
            var user = await FindByIdAsync(userId);
            return _mapper.Map<IList<NotificationFeatureNotificationViewModel>>(user.Notifications.Where(n => !n.IsDone));
        }
    }
}

