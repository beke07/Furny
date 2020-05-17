using AutoMapper;
using Furny.Data;
using Furny.Models;
using Furny.ServiceInterfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.Services
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

        public async Task<IList<NotificationDto>> GetNotificationsAsync(string userId)
        {
            var user = await FindByIdAsync(userId);
            return _mapper.Map<IList<NotificationDto>>(user.Notifications.Where(n => !n.IsDone));
        }
    }
}

