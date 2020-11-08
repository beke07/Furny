using Furny.ExportFeature.ServiceInterfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddExportFeatureServices(this IServiceCollection services)
        {
            services.AddTransient<IExcelService, ExcelService>();
            services.AddTransient<IExportService, ExportService>();

            return services;
        }
    }
}
