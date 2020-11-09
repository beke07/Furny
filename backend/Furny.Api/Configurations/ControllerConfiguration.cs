using Furny.Common.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using System.Linq;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ControllerConfiguration
    {
        public static IServiceCollection AddControllersWithExceptionFilter(this IServiceCollection services)
        {
            services
                .AddControllers(options =>
                {
                    options.Filters.Add(new HttpResponseExceptionFilter());
                    options.InputFormatters.Insert(0, GetJsonPatchInputFormatter());
                })
                .AddNewtonsoftJson();

            return services;
        }

        private static NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter()
        {
            var builder = new ServiceCollection()
                .AddLogging()
                .AddMvc()
                .AddNewtonsoftJson()
                .Services.BuildServiceProvider();

            return builder
                .GetRequiredService<IOptions<MvcOptions>>()
                .Value
                .InputFormatters
                .OfType<NewtonsoftJsonPatchInputFormatter>()
                .First();
        }
    }
}
