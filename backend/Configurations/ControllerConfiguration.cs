using Furny.Filters;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ControllerConfiguration
    {
        public static void AddControllersWithExceptionFilter(this IServiceCollection services)
        {
            services.AddControllers(options => options.Filters.Add(new HttpResponseExceptionFilter()));
        }
    }
}
