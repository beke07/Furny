using Furny.MaterialFeature.ServiceInterfaces;
using Furny.MaterialFeature.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddMaterialFeatureServices(this IServiceCollection services)
        {
            services.AddTransient<IMaterialService, MaterialService>();

            return services;
        }
    }
}
