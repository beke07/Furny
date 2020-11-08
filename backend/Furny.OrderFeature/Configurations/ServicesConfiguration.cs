using Furny.OrderFeature.ServiceInterfaces;
using Furny.OrderFeature.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddOrderFeatureServices(this IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>();

            return services;
        }
    }
}
