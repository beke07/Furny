using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Furny
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCorsWithOrigins();

            services.AddMediatR();

            services.AddServices();

            services.AddSwagger();

            services.AddStartupAutoMapper();

            services.AddControllersWithExceptionFilter();

            services.AddMongoIdentity(configuration: Configuration);

            services.AddJwtAuthentication(configuration: Configuration);

            services.AddHttpClient();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCorsWithOrigins();

            app.UseEndpointsWithCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSwaggerWithUI();

            app.RegisterMiddlewares();
        }
    }
}
