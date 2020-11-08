using Furny.NotificationFeature.ServiceInterfaces;
using Furny.NotificationFeature.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddNotificationFeatureServices(this IServiceCollection services)
        {
            services.AddTransient<INotificationService, NotificationService>();

            return services;
        }
    }
}
