using Microsoft.AspNetCore.Builder;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CorsConfiguration
    {
        private const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        private const string FrontendUrl = "http://localhost:8080";

        public static IServiceCollection AddCorsWithOrigins(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins(FrontendUrl)
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            return services;
        }

        public static void UseCorsWithOrigins(this IApplicationBuilder app)
        {
            app.UseCors(MyAllowSpecificOrigins);
        }

        public static void UseEndpointsWithCors(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers()
                    .RequireCors(MyAllowSpecificOrigins);
            });
        }
    }
}
