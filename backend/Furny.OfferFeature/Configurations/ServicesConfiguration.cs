using Furny.OfferFeature.ServiceInterfaces;
using Furny.OfferFeature.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddOfferFeatureServices(this IServiceCollection services)
        {
            services.AddTransient<IOfferService, OfferService>();

            return services;
        }
    }
}
