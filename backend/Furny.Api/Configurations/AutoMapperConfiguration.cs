using AutoMapper;
using Furny.DesignerFeature.MappingProfiles;
using Furny.DesignerFurnitureFeature.MappingProfiles;
using Furny.DesignerModulFeature.MappingProfiles;
using Furny.Model.Common.MappingProfiles;
using Furny.NotificationFeature.MappingProfiles;
using Furny.OfferFeature.MappingProfiles;
using Furny.OrderFeature.MappingProfiles;
using Furny.PanelCutterFeature.MappingProfiles;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AutoMapperConfiguration
    {
        public static void AddStartupAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(CommonMappingProfile),
                typeof(DesignerMappingProfile),
                typeof(PanelCutterMappingProfile),
                typeof(FurnitureMappingProfile),
                typeof(ModulMappingProfile),
                typeof(OfferMappingProfiles),
                typeof(OrderMappingProfile),
                typeof(NotificationMappingProfile));
        }
    }
}


