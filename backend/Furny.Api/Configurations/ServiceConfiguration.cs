namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddDesignerFeatureServices()
                .AddFurnitureFeatureServices()
                .AddModulFeatureServices()
                .AddPanelCutterFeatureServices()
                .AddAddressFeatureServices()
                .AddExportFeatureServices()
                .AddOfferFeatureServices()
                .AddOrderFeatureServices()
                .AddNotificationFeatureServices()
                .AddFileHandlerFeatureServices()
                .AddAdFeatureServices()
                .AddClosingFeatureServices()
                .AddMaterialFeatureServices()
                .AddAuthFeatureServices();

            return services;
        }
    }
}
