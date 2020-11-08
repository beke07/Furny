using AutoMapper;
using Furny.Common.Enums;
using Furny.Common.Services;
using Furny.DesignerFurnitureFeature.Data;
using Furny.DesignerFurnitureFeature.ServiceInterfaces;
using Furny.DesignerFurnitureFeature.ViewModels;
using Furny.ExportFeature.Commands;
using Furny.Model;
using MediatR;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Furny.DesignerFurnitureFeature.Services
{
    public class FurnitureService : SingleElementBaseService<Designer, Furniture, DesignerFurnitureFurnitureDto, DesignerFurnitureFurnitureTableViewModel>, IFurnitureService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public FurnitureService(
            IMapper mapper,
            IMediator mediator,
            IConfiguration configuration,
            string collectionName = "applicationUsers") : base(mapper, configuration, collectionName)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task CreateAsync(DesignerFurnitureFurnitureDto element, string id)
        {
            element.DesignerId = id;
            await base.CreateAsync(element, id);
        }

        public async Task<Tuple<MemoryStream, string>> ExportAsync(ExcelType excelType, string id, string fid)
        {
            var furniture = await FindByIdAsync(id, fid);
            var fileName = excelType.GetDescription();

            var components = new List<Component>();
            components.AddRange(furniture.Moduls.SelectMany(e => e.Components));
            components.AddRange(furniture.Components);

            var resultComponents = components.GroupBy(e => e.Name).Select(e => e.ToList());

            return await _mediator.Send(ExportCommand.Create(excelType, resultComponents));
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

        public async Task AddComponentAsync(DesignerFurnitureComponentDto component, string id, string fid)
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
