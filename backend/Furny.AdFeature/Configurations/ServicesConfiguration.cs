using Furny.AdFeature.ServiceInterfaces;
using Furny.AdFeature.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddAdFeatureServices(this IServiceCollection services)
        {
            services.AddTransient<IAdService, AdService>();

            return services;
        }
    }
}
