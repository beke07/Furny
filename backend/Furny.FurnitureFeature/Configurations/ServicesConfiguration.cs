using Furny.FurnitureFeature.ServiceInterfaces;
using Furny.FurnitureFeature.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddFurnitureFeatureServices(this IServiceCollection services)
        {
            services.AddTransient<IFurnitureService, FurnitureService>();

            return services;
        }
    }
}
