using Furny.NotificationFeature.ServiceInterfaces;
using Furny.NotificationFeature.ViewModels;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Furny.NotificationFeature.Commands
{
    public class NotificationFeatureNotificationsCommandHandlers :
        IRequestHandler<NotificationFeatureGetNotificationsCommand, IList<NotificationFeatureNotificationViewModel>>,
        IRequestHandler<NotificationFeatureDoneNotificationCommand>,
        IRequestHandler<NotificationFeatureCreateNotificationCommand>
    {
        private readonly INotificationService _notificationService;

        public NotificationFeatureNotificationsCommandHandlers(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task<IList<NotificationFeatureNotificationViewModel>> Handle(NotificationFeatureGetNotificationsCommand request, CancellationToken cancellationToken)
            => await _notificationService.GetNotificationsAsync(request.UserId);

        public async Task<Unit> Handle(NotificationFeatureDoneNotificationCommand request, CancellationToken cancellationToken)
        {
            await _notificationService.DoneNotificationAsync(request.UserId, request.Nid);

            return Unit.Value;
        }

        public async Task<Unit> Handle(NotificationFeatureCreateNotificationCommand request, CancellationToken cancellationToken)
        {
            await _notificationService.CreateNotificationAsync(request.UserId, request.Notifcation);

            return Unit.Value;
        }
    }
}
