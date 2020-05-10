using Furny.ServiceInterfaces;
using Furny.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IFileHandlerService, FileHandlerService>();
            services.AddTransient<IPanelCutterService, PanelCutterService>();
            services.AddTransient<IAdService, AdService>();
            services.AddTransient<IMaterialService, MaterialService>();
            services.AddTransient<IDesignerService, DesignerService>();
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<IClosingService, ClosingService>();
            services.AddTransient<IModulService, ModulService>();
            services.AddTransient<IFurnitureService, FurnitureService>();
        }
    }
}
