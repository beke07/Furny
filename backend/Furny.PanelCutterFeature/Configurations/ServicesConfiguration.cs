using Furny.PanelCutterFeature.ServiceInterfaces;
using Furny.PanelCutterFeature.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static void AddPanelCutterFeatureServices(this IServiceCollection services)
        {
            services.AddTransient<IPanelCutterService, PanelCutterService>();
        }
    }
}
