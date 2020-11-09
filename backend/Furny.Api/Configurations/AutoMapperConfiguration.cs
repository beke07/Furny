using AutoMapper;
using Furny.AdFeature.MappingProfiles;
using Furny.AuthFeature.MappingProfiles;
using Furny.ClosingFeature.MappingProfiles;
using Furny.DesignerFeature.MappingProfiles;
using Furny.FurnitureFeature.MappingProfiles;
using Furny.MaterialFeature.MappingProfiles;
using Furny.Model.Common.MappingProfiles;
using Furny.ModulFeature.MappingProfiles;
using Furny.NotificationFeature.MappingProfiles;
using Furny.OfferFeature.MappingProfiles;
using Furny.OrderFeature.MappingProfiles;
using Furny.PanelCutterFeature.MappingProfiles;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddStartupAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(CommonMappingProfile),
                typeof(DesignerMappingProfile),
                typeof(PanelCutterMappingProfile),
                typeof(FurnitureMappingProfile),
                typeof(MaterialMappingProfile),
                typeof(ModulMappingProfile),
                typeof(AdMappingProfile),
                typeof(ClosingMappingProfile),
                typeof(OfferMappingProfile),
                typeof(AuthMappingProfile),
                typeof(OrderMappingProfile),
                typeof(NotificationMappingProfile));

            return services;
        }
    }
}


