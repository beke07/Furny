using AutoMapper;
using Furny.Data;
using Furny.Data.Designer;
using Furny.Data.Designer.TableDto;
using Furny.Models;
using Furny.ServiceInterfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.Services
{
    public class FurnitureService : SingleElementBaseService<Designer, Furniture, FurnitureDto, FurnitureTableDto>, IFurnitureService
    {
        private readonly IMapper _mapper;

        public FurnitureService(
            IMapper mapper,
            IConfiguration configuration,
            string collectionName = "applicationUsers") : base(mapper, configuration, collectionName)
        {
            _mapper = mapper;
        }

        public override async Task CreateAsync(FurnitureDto element, string id)
        {
            element.DesignerId = id;
            await base.CreateAsync(element, id);
        }

        public async Task AddModulAsync(string id, string fid, string mid)
        {
            var designer = await FindByIdAsync(id);
            var furniture = await FindByIdAsync(id, fid);

            var modul = designer.Moduls.FirstOrDefault(e => e.Id == ObjectId.Parse(mid));

            furniture.Moduls.Add(modul);
            await ReplaceByIdAsync(id, furniture);
        }

        public async Task RemoveModulAsync(string id, string fid, string mid)
        {
            var furniture = await FindByIdAsync(id, fid);
            furniture.Moduls.RemoveById(mid);

            await ReplaceByIdAsync(id, furniture);
        }

        public async Task AddComponentAsync(ComponentDto component, string id, string fid)
        {
            var furniture = await FindByIdAsync(id, fid);
            furniture.Components.Add(_mapper.Map<Component>(component));

            await ReplaceByIdAsync(id, furniture);
        }

        public async Task CopyComponentAsync(string id, string fid, string cid)
        {
            var furniture = await FindByIdAsync(id, fid);
            furniture.CopyComponent(cid);

            await ReplaceByIdAsync(id, furniture);
        }

        public async Task RemoveComponentAsync(string id, string fid, string cid)
        {
            var furniture = await FindByIdAsync(id, fid);
            furniture.Components.RemoveById(cid);

            await ReplaceByIdAsync(id, furniture);
        }
    }
}
