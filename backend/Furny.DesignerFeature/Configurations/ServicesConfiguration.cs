using Furny.DesignerFeature.ServiceInterfaces;
using Furny.DesignerFeature.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddDesignerFeatureServices(this IServiceCollection services)
        {
            services.AddTransient<IDesignerService, DesignerService>();

            return services;
        }
    }
}
