using Furny.AuthFeature.ServiceInterfaces;
using Furny.AuthFeature.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddAuthFeatureServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthService, AuthService>();

            return services;
        }
    }
}
