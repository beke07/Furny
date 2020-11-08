using AutoMapper;
using Furny.Common.Services;
using Furny.MaterialFeature.Data;
using Furny.MaterialFeature.ServiceInterfaces;
using Furny.MaterialFeature.ViewModels;
using Furny.Model;
using Microsoft.Extensions.Configuration;

namespace Furny.MaterialFeature.Services
{
    public class MaterialService : SingleElementBaseService<PanelCutter, Material, MaterialFeatureMaterialDto, MaterialFeatureMaterialTableViewModel>, IMaterialService
    {
        public MaterialService(
            IMapper mapper,
            IConfiguration configuration,
            string collectionName = "applicationUsers") : base(mapper, configuration, collectionName)
        { }
    }
}
