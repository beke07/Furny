using Furny.DesignerFeature.Commands;
using Furny.DesignerFurnitureFeature.Commands;
using Furny.PanelCutterFeature.CommandHandlers;
using MediatR;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MediatorConfigurations
    {
        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(
                Assembly.GetExecutingAssembly(),
                typeof(DesignerGetCommandHandler).Assembly,
                typeof(DesignerFurnitureGetFurnituresCommandHandler).Assembly,
                typeof(PanelCutterGetCommandHandler).Assembly);

            return services;
        }
    }
}
