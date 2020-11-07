using Furny.Model.ServiceInterfaces;
using Furny.Model.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static void AddCommonFeatureServices(this IServiceCollection services)
        {
            services.AddTransient<IAddressService, AddressService>();
        }
    }
}
