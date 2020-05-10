using AutoMapper;
using Furny.Data;
using Furny.Models;
using Furny.ServiceInterfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.Services
{
    public class ModulService : SingleElementBaseService<Designer, Modul, ModulDto, ModulTableDto>, IModulService
    {
        private readonly IMapper _mapper;

        public ModulService(
            IMapper mapper,
            IConfiguration configuration,
            string collectionName = "applicationUsers") : base(mapper, configuration, collectionName)
        {
            _mapper = mapper;
        }

        public async Task AddComponentAsync(ComponentDto component, string id, string mid)
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
