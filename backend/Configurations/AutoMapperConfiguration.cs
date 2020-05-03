using AutoMapper;
using Furny;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AutoMapperConfiguration
    {
        public static void AddStartupAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
        }
    }
}
