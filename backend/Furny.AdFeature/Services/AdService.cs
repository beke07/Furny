using AutoMapper;
using Furny.AdFeature.Data;
using Furny.AdFeature.ServiceInterfaces;
using Furny.AdFeature.ViewModels;
using Furny.Common.Services;
using Furny.Model;
using Microsoft.Extensions.Configuration;

namespace Furny.AdFeature.Services
{
    public class AdService : SingleElementBaseService<PanelCutter, Ad, AdFeatureAdDto, AdFeatureAdTableViewModel>, IAdService
    {
        public AdService(
            IMapper mapper,
            IConfiguration configuration,
            string collectionName = "applicationUsers") : base(mapper, configuration, collectionName)
        { }
    }
}
