using Furny.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MiddlewareConfigurations
    {
        public static void RegisterMiddlewares(this IApplicationBuilder app)
        {
            app.UseWhen(ctx => ctx.Request.Path.ToString().ToLower().Equals("/api/auth/user-sync"), app =>
            {
                app.UseMiddleware<UserSyncMiddleware>();
            });
        }
    }
}
