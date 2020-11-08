using Furny.Model.ServiceInterfaces;
using Furny.Model.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddCommonFeatureServices(this IServiceCollection services)
        {
            services.AddTransient<IAddressService, AddressService>();

            return services;
        }
    }
}
