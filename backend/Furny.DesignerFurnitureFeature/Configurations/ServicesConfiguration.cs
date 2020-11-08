using Furny.DesignerFurnitureFeature.ServiceInterfaces;
using Furny.DesignerFurnitureFeature.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static void AddDesignerFurnitureFeatureServices(this IServiceCollection services)
        {
            services.AddTransient<IFurnitureService, FurnitureService>();
        }
    }
}
