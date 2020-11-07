using AutoMapper;
using Furny.Data;
using Furny.Models;
using Furny.ServiceInterfaces;
using Microsoft.Extensions.Configuration;

namespace Furny.Services
{
    public class MaterialService : SingleElementBaseService<PanelCutter, Material, MaterialCommand, MaterialTableCommand>, IMaterialService
    {
        public MaterialService(
            IMapper mapper,
            IConfiguration configuration,
            string collectionName = "applicationUsers") : base(mapper, configuration, collectionName)
        { }
    }
}
