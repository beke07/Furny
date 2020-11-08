using AutoMapper;
using Furny.Common.Services;
using Furny.ModulFeature.Data;
using Furny.ModulFeature.ServiceInterfaces;
using Furny.ModulFeature.ViewModels;
using Furny.Model;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Furny.ModulFeature.Services
{
    public class ModulService : SingleElementBaseService<Designer, Modul, ModulModulDto, ModulTableViewModel>, IModulService
    {
        private readonly IMapper _mapper;

        public ModulService(
            IMapper mapper,
            IConfiguration configuration,
            string collectionName = "applicationUsers") : base(mapper, configuration, collectionName)
        {
            _mapper = mapper;
        }

        public async Task AddComponentAsync(ModulComponentDto component, string id, string mid)
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
