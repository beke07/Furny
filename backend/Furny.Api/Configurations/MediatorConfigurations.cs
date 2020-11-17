using Furny.AdFeature.Commands;
using Furny.AuthFeature.Commands;
using Furny.ClosingFeature.Commands;
using Furny.DesignerFeature.Commands;
using Furny.ExportFeature.Commands;
using Furny.FileHandlerFeature.CommandHandlers;
using Furny.FurnitureFeature.Commands;
using Furny.MaterialFeature.Commands;
using Furny.ModulFeature.Commands;
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
                typeof(FurnitureGetFurnituresCommandHandler).Assembly,
                typeof(ModulGetModulsCommandHandler).Assembly,
                typeof(ClosingFeatureGetClosingCommandHandler).Assembly,
                typeof(ExportCommandHandler).Assembly,
                typeof(OfferFeatureDesignerOfferCommandHandler).Assembly,
                typeof(AdFeatureCreateAdCommandHandler).Assembly,
                typeof(AddressFeatureGetAddressesCommandHandler).Assembly,
                typeof(OrderFeatureOrderCommandHandler).Assembly, 
                typeof(FileHandlerFeatureCommandHandler).Assembly,
                typeof(MaterialFeatureGetMaterialCommandHandler).Assembly,
                typeof(NotificationFeatureNotificationsCommandHandlers).Assembly,
                typeof(AuthFeatureCommandHandler).Assembly,
                typeof(PanelCutterCommandHandler).Assembly);

            return services;
        }
    }
}
