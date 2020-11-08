using Furny.ModulFeature.ServiceInterfaces;
using Furny.ModulFeature.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddModulFeatureServices(this IServiceCollection services)
        {
            services.AddTransient<IModulService, ModulService>();

            return services;
        }
    }
}
