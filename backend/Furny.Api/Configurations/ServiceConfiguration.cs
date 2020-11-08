using Furny.ServiceInterfaces;
using Furny.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddDesignerFeatureServices();
            services.AddPanelCutterFeatureServices();
            services.AddCommonFeatureServices();
            services.AddDesignerFurnitureFeatureServices();
            services.AddExportFeatureServices();
            
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IFileHandlerService, FileHandlerService>();
            services.AddTransient<IExcelService, ExcelService>();
            services.AddTransient<IExportService, ExportService>();
            services.AddTransient<IPanelCutterService, PanelCutterService>();
            services.AddTransient<IAdService, AdService>();
            services.AddTransient<IMaterialService, MaterialService>();
            services.AddTransient<IDesignerService, DesignerService>();
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<IClosingService, ClosingService>();
            services.AddTransient<IModulService, ModulService>();
            services.AddTransient<IFurnitureService, FurnitureService>();
            services.AddTransient<IOfferService, OfferService>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IOrderService, OrderService>();

            return services;
        }
    }
}
