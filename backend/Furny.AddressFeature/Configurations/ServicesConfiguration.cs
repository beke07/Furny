using Furny.AddressFeature.ServiceInterfaces;
using Furny.AddressFeature.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddAddressFeatureServices(this IServiceCollection services)
        {
            services.AddTransient<IAddressService, AddressService>();

            return services;
        }
    }
}
