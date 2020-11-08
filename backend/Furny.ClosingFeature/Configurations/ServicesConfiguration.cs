using Furny.ClosingFeature.ServiceInterfaces;
using Furny.ClosingFeature.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddClosingFeatureServices(this IServiceCollection services)
        {
            services.AddTransient<IClosingService, ClosingService>();

            return services;
        }
    }
}
