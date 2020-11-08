using AutoMapper;
using Furny.Common.Services;
using Furny.DesignerModulFeature.Data;
using Furny.DesignerModulFeature.ServiceInterfaces;
using Furny.DesignerModulFeature.ViewModels;
using Furny.Model;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Furny.DesignerModulFeature.Services
{
    public class ModulService : SingleElementBaseService<Designer, Modul, DesignerModulModulDto, DesignerModulModulTableViewModel>, IModulService
    {
        private readonly IMapper _mapper;

        public ModulService(
            IMapper mapper,
            IConfiguration configuration,
            string collectionName = "applicationUsers") : base(mapper, configuration, collectionName)
        {
            _mapper = mapper;
        }

        public async Task AddComponentAsync(DesignerModulComponentDto component, string id, string mid)
        {
            var modul = await FindByIdAsync(id, mid);
            modul.Components.Add(_mapper.Map<Component>(component));

            await ReplaceByIdAsync(id, modul);
        }

        public async Task CopyComponentAsync(string id, string mid, string cid)
        {
            var modul = await FindByIdAsync(id, mid);
            modul.CopyComponent(cid);

            await ReplaceByIdAsync(id, modul);
        }

        public async Task RemoveComponentAsync(string id, string mid, string cid)
        {
            var modul = await FindByIdAsync(id, mid);
            modul.Components.RemoveById(cid);

            await ReplaceByIdAsync(id, modul);
        }
    }
}
