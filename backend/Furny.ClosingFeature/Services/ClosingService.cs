using AutoMapper;
using Furny.ClosingFeature.Data;
using Furny.ClosingFeature.ServiceInterfaces;
using Furny.ClosingFeature.ViewModels;
using Furny.Common.Services;
using Furny.Model;
using Microsoft.Extensions.Configuration;

namespace Furny.ClosingFeature.Services
{
    public class ClosingService : SingleElementBaseService<PanelCutter, Closing, ClosingFeatureClosingDto, ClosingFeatureClosingTableViewModel>, IClosingService
    {
        public ClosingService(
            IMapper mapper,
            IConfiguration configuration,
            string collectionName = "applicationUsers") : base(mapper, configuration, collectionName)
        { }
    }
}