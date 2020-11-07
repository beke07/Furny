using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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
            services.AddMediatR(Assembly.GetExecutingAssembly());
            
            services.AddServices();

            services.AddSwagger();

            services.AddStartupAutoMapper();

            services.AddControllersWithExceptionFilter();

            services.AddMongoIdentity(configuration: Configuration);

            services.AddCorsWithOrigins();

            services.AddJwtAuthentication(configuration: Configuration);

            services.AddHttpClient();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCorsWithOrigins();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpointsWithCors();

            app.UseSwaggerWithUI();

            app.RegisterMiddlewares();
        }
    }
}
