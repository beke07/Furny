using AutoMapper;
using Furny.Model;
using Furny.NotificationFeature.ViewModels;

namespace Furny.NotificationFeature.MappingProfiles
{
    public class NotificationMappingProfile : Profile
    {
        public NotificationMappingProfile()
        {
            CreateMap<Notification, NotificationFeatureNotificationViewModel>().ReverseMap();
        }
    }
}
