using Furny.DesignerModulFeature.ServiceInterfaces;
using Furny.DesignerModulFeature.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static void AddDesignerModulFeatureServices(this IServiceCollection services)
        {
            services.AddTransient<IModulService, ModulService>();
        }
    }
}
