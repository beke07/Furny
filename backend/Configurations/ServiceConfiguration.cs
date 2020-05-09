﻿using Furny.ServiceInterfaces;
using Furny.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IFileHandlerService, FileHandlerService>();
            services.AddTransient<IPanelCutterService, PanelCutterService>();
        }
    }
}
