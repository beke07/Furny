using Furny.FileHandlerFeature.ServiceInterfaces;
using Furny.FileHandlerFeature.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddFileHandlerFeatureServices(this IServiceCollection services)
        {
            services.AddTransient<IFileHandlerService, FileHandlerService>();

            return services;
        }
    }
}
