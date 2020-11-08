using Furny.DesignerFeature.Commands;
using Furny.DesignerFurnitureFeature.Commands;
using Furny.DesignerModulFeature.Commands;
using Furny.ExportFeature.Commands;
using Furny.FileHandlerFeature.CommandHandlers;
using Furny.NotificationFeature.Commands;
using Furny.OfferFeature.CommandHandlers;
using Furny.OrderFeature.CommandHandlers;
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
                typeof(DesignerModulGetModulsCommandHandler).Assembly,
                typeof(ExportCommandHandler).Assembly,
                typeof(OfferFeatureDesignerOfferCommandHandler).Assembly,
                typeof(OrderFeatureOrderCommandHandler).Assembly,
                typeof(FileHandlerFeatureCommandHandler).Assembly,
                typeof(NotificationFeatureNotificationsCommandHandlers).Assembly,
                typeof(PanelCutterCommandHandler).Assembly);

            return services;
        }
    }
}
